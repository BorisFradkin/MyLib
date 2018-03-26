Imports System.IO
Imports System.IO.Compression
Imports System.Data.SQLite

Public Class clsCardBookEpub
    Dim cn As SQLiteConnection = Nothing 'New SQLiteConnection("Data Source=" & Path.Combine(Config.CatalogBase, Catalog))
    Dim sql As String = String.Empty
    Dim cmd As SQLiteCommand = Nothing 'New SQLiteCommand(Sql, cn)

    Private m_lastError As String = String.Empty
    Public Property BookID() As Integer = 0
    Public Property Title() As String = String.Empty
    Public Property LoadBook() As Integer = 0 '0-From Folder, 1-a separate book
    Public Property FolderName() As String = String.Empty
    Public Property FileName() As String = String.Empty
    Public Property BookSize() As Integer = 0
    Public Property KeyWords As String = String.Empty
    Public Property LoadDate() As String = String.Empty
    Public Property Cover As String = String.Empty
    Public Property SeriesID As Integer = 0
    Public Property Series As String = String.Empty
    Public Property SeqNumber As Integer = 0
    Public Property Genres As List(Of String) = Nothing
    Public Property Authors As List(Of Author) = Nothing
    Public Property Annotation As String = String.Empty
    Public Property Publisher As String = String.Empty
    Private xDoc As XDocument = Nothing
    Private m_Catalog As String

    Private m_CardBookPth As String = String.Empty
    Private m_UnzipPath As String = String.Empty

    Public Sub New(fName As String)
        Try
            If File.Exists(fName) Then
                Dim fi As FileInfo = New FileInfo(fName)
                FileName = fi.Name
                FolderName = fi.DirectoryName
                BookSize = fi.Length
                LoadDate = Format(fi.LastWriteTimeUtc.ToLocalTime, "dd/MM/yyyy")
                LoadBook = 0
                m_lastError = Me.OpenBook(fName)
                If Not Me.IsError Then
                    Title = m_GetTitle()
                    Cover = m_GetCoverPicture()
                    m_GetSeries()
                    Genres = m_GetGenres()
                    Authors = m_GetAuthors()
                    Annotation = m_GetAnnotation()
                    Publisher = m_GetPublisher()
                    KeyWords = m_GetKeyWords()
                End If
            Else
                Write2Log("File '" & fName & "' Not Found", "clsCardBookEpub.New")
                m_lastError = "File '" & fName & "' Not Found"
            End If
        Catch ex As Exception
            Write2Log(ex.Message, "clsCardBookEpub.New")
            m_lastError = ex.Message
        Finally
            Try
                Directory.Delete(m_UnzipPath, True)
            Catch ex As Exception
                Write2Log(ex.Message, "clsCardBookEpub.New")
            End Try
        End Try
    End Sub

    Public ReadOnly Property LastError() As String
        Get
            LastError = m_lastError
        End Get
    End Property
    Public ReadOnly Property IsError() As Boolean
        Get
            IsError = (m_lastError.Length > 0)
        End Get
    End Property

    Public Function OpenBook(fName As String) As String
        Try
            m_UnzipPath = m_Unzip(fName)
            m_CardBookPth = m_UnzipPath
            If m_CardBookPth.Length > 0 Then
                Dim xCont As XDocument = XDocument.Load(Path.Combine(m_CardBookPth, "META-INF\container.xml"))
                Dim PathOpf As String = xCont.Descendants.Where(Function(x) x.Name.LocalName = "rootfiles").
                Descendants.Where(Function(x) x.Name.LocalName = "rootfile").Attributes("full-path").First.Value
                If PathOpf.Length > 0 Then
                    xDoc = XDocument.Load(Path.Combine(m_CardBookPth, PathOpf))
                    m_CardBookPth = (New FileInfo(Path.Combine(m_CardBookPth, PathOpf))).DirectoryName
                End If
            End If
            Return ""
        Catch ex As Exception
            Write2Log(ex.Message & " FileName='" & fName & "'", "clsCardBookEpub.OpenBook")
            Return ex.Message
        End Try
    End Function
    Private Function m_Unzip(st As String) As String
        Try
            Dim fi As FileInfo = New FileInfo(st)
            Dim Path_unZip As String = Path.Combine(Config.TempPath, Path.GetRandomFileName.Substring(0, 8))
            If Not Directory.Exists(Path_unZip) Then
                Directory.CreateDirectory(Path_unZip)
            End If
            ZipFile.ExtractToDirectory(st, Path_unZip)
            Return Path_unZip
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.m_Unzip")
            Write2Log("Error Unzip: " & st, "")
            'MsgBox(ex.Message)
            Return String.Empty
        End Try
    End Function
    Private Sub Write2Log(msg As String, Fun As String)
        Dim st As String = Now.ToString & " Fun=" & Fun & " " & msg & vbCrLf & Path.Combine(FolderName, FileName)
        Dim LogStream As StreamWriter = New StreamWriter(Path.Combine(Config.CatalogBase, Config.LogFile), FileMode.OpenOrCreate)
        LogStream.WriteLine(st)
        LogStream.Close()
    End Sub
    Private Function CheckCover(ByRef Pic As String) As String
        Dim Ret As String = String.Empty
        If Pic.Length > 0 Then
            Try
                Dim bytes = File.ReadAllBytes(Pic)
                Dim fs As New FileStream(Pic, FileMode.Open, FileAccess.Read)
                Dim img As Image = Image.FromStream(fs)
                If img.Width > 210 OrElse img.Height > 250 Then
                    Ret = ImageToBase64(img, 210, 250, System.Drawing.Imaging.ImageFormat.Jpeg)
                End If
                fs.Close()
                fs.Dispose()
                img = Nothing
            Catch ex As Exception
                Ret = String.Empty
            Finally

            End Try
        End If
        Return Ret
    End Function
    Private Function m_GetTitle() As String
        'sequence
        If xDoc IsNot Nothing Then
            Return xDoc.Descendants.Where(Function(x) x.Name.LocalName = "metadata").
                Descendants.Where(Function(x) x.Name.LocalName = "title").Value.ToString
        Else
            Return String.Empty
        End If
    End Function
    Private Function m_GetCoverPicture() As String
        Dim pic As String = String.Empty
        If xDoc IsNot Nothing Then
            Try
                Dim CoverPic As String = xDoc.Descendants.Where(Function(x) x.Name.LocalName = "metadata").
                    Descendants.Where(Function(x) x.Name.LocalName = "meta").
                    Where(Function(x) x.Attribute("name").Value.ToLower = "cover").First.Attribute("content").Value

                If CoverPic.Length > 0 Then
                    Dim hRef As String = xDoc.Descendants.Where(Function(x) x.Name.LocalName = "manifest").
                    Descendants.Where(Function(x) x.Attribute("id").Value = CoverPic).First.Attribute("href").Value
                    pic = CheckCover(Path.Combine(m_CardBookPth, hRef.Replace("/", "\")))
                End If
            Catch ex As Exception
                If Not ex.Message.Contains("Sequence contains no elements") Then
                    Write2Log(ex.Message, "clsCardBookEpub.m_GetCoverPicture")
                End If
                pic = String.Empty
            End Try
        End If
        Return pic
    End Function
    Private Function ImageToBase64(img As Image, NewW As Integer, NewH As Integer,
      format As System.Drawing.Imaging.ImageFormat) As String
        Dim scale_factor As Single = Math.Round(Math.Min(210 / img.Width, 250 / img.Height), 3)
        Dim bm_dest As New Bitmap(
                CInt(img.Width * scale_factor),
                CInt(img.Height * scale_factor))

        Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

        gr_dest.DrawImage(img, 0, 0,
            bm_dest.Width + 1,
            bm_dest.Height + 1)



        Dim xxx As New IO.MemoryStream()
        Using xxx
            ' Convert Image to byte[]
            bm_dest.Save(xxx, format)
            Dim imageBytes() As Byte = xxx.ToArray()

            ' Convert byte[] to Base64 String
            Dim base64String As String = Convert.ToBase64String(imageBytes)
            Return base64String
        End Using
    End Function
    Private Function m_GetAuthors() As List(Of Author)
        If xDoc IsNot Nothing Then
            Dim LstAuth As List(Of Author) = New List(Of Author)
            Dim cl As Author = Nothing
            For Each el In xDoc.Descendants.Where(Function(x) x.Name.LocalName = "metadata").Descendants.Where(Function(x) x.Name.ToString.Contains("creator"))
                Dim Ar() As String = el.Value.Split(" ")
                cl = New Author
                cl.LastName = String.Empty
                cl.FirstName = String.Empty
                cl.MiddleName = String.Empty
                If Ar.Length > 0 Then
                    cl.FirstName = Ar(0)
                End If
                If Ar.Length > 2 Then
                    cl.MiddleName = Ar(1)
                Else
                    cl.LastName = Ar(1)
                End If
                If Ar.Length >= 3 Then
                    cl.LastName = Ar(2)
                End If
                LstAuth.Add(cl)
            Next
            Return LstAuth
        Else
            Return Nothing
        End If
    End Function
    Private Function m_GetAnnotation() As String
        Dim stAnnotation As String = String.Empty
        If xDoc IsNot Nothing Then
            stAnnotation = xDoc.Descendants.Where(Function(x) x.Name.LocalName = "metadata").
                Descendants.Where(Function(x) x.Name.LocalName = "description").Value
        End If
        If stAnnotation Is Nothing Then
            Return String.Empty
        Else
            Return stAnnotation
        End If
    End Function
    Private Function m_GetPublisher() As String
        Dim stPublisher As String = String.Empty
        If xDoc IsNot Nothing Then
            stPublisher = xDoc.Descendants.Where(Function(x) x.Name.LocalName = "metadata").
                            Descendants.Where(Function(x) x.Name.LocalName = "publisher").Value
        End If
        Return If(stPublisher IsNot Nothing, stPublisher, String.Empty)
    End Function
    Private Function m_GetKeyWords() As String
        Dim stKeyWords As String = String.Empty
        'If xDoc IsNot Nothing Then
        '    Try
        '        For Each el In xDoc.Descendants.Where(Function(x) x.Name.LocalName = "title-info").
        '        Descendants.Where(Function(x) x.Name.LocalName = "keywords")
        '            stKeyWords &= el.Value & ControlChars.CrLf
        '        Next
        '    Catch ex As Exception
        '        stKeyWords = String.Empty
        '    End Try
        'End If
        'If stKeyWords.EndsWith(ControlChars.CrLf) Then
        '    stKeyWords = stKeyWords.Substring(0, stKeyWords.Length - 2)
        'End If
        'If stKeyWords.Length > 0 AndAlso Not stKeyWords.EndsWith(",") Then
        '    stKeyWords &= ","
        'End If
        Return stKeyWords

    End Function
    Private Sub m_GetSeries()
        'sequence
        SeqNumber = 0
        Series = Nothing
        If xDoc IsNot Nothing Then
            For Each xEl In xDoc.Descendants.Where(Function(x) x.Name.LocalName = "metadata").
                Descendants.Where(Function(x) x.Name.LocalName = "meta")
                If xEl.Attribute("name").Value.ToLower.Contains("series") Then
                    If xEl.Attribute("name").Value.ToLower.Contains("series_index") Then
                        Integer.TryParse(xEl.Attribute("content").Value, SeqNumber)
                    Else
                        Series = xEl.Attribute("content").Value
                    End If
                End If
            Next
        End If
    End Sub
    Private Function m_GetGenres() As List(Of String)
        'sequence
        If xDoc IsNot Nothing Then
            Return xDoc.Descendants.Where(Function(x) x.Name.LocalName = "metadata").
                Descendants.Where(Function(x) x.Name.LocalName = "subject").
                Select(Of String)(Function(x) x.Value).ToList
        Else
            Return Nothing
        End If
    End Function
End Class
