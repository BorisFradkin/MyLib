Imports System.Data.SQLite
Imports System.IO
Imports System.Collections.Generic

Public Class clsCardBookFb2
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
    Public Sub New(fName As String, FiBook As FileInfo)
        Try
            If File.Exists(fName) Then
                Dim fi As FileInfo = FiBook 'New FileInfo(fName)
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
                Write2Log("File '" & fName & "' Not Found", "clsCardBookFb2.New")
                m_lastError = "File '" & fName & "' Not Found"
            End If
        Catch ex As Exception
            Write2Log(ex.Message, "clsCardBookFb2.New")
            m_lastError = ex.Message
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
            xDoc = XDocument.Load(fName)
            Return ""
        Catch ex As Exception
            Write2Log(ex.Message & " FileName='" & fName & "'", "clsCardBookFb2.OpenBook")
            Return ex.Message
        End Try
    End Function
    Private Function m_GetCoverPicture() As String

        Dim pic As String = String.Empty
        If xDoc IsNot Nothing Then
            Try
                Dim CoverPic As String = xDoc.Descendants.Where(Function(x) x.Name.LocalName = "title-info").
                    Descendants.Where(Function(x) x.Name.LocalName = "coverpage").
                    Descendants.Where(Function(x) x.Name.LocalName = "image").First.
                    Attributes.Where(Function(x) x.ToString.Contains("href")).First.Value
                If CoverPic.StartsWith("#") Then
                    pic = xDoc.Descendants.Where(Function(x) x.Name.ToString.Contains("binary")).Where(Function(x) x.Attribute("id") = CoverPic.Substring(1)).First.Value.ToString
                End If
            Catch ex As Exception
                If Not ex.Message.Contains("Sequence contains no elements") Then
                    Write2Log(ex.Message, "clsCardBookFb2.m_GetCoverPicture")
                End If
                pic = String.Empty
            End Try
            If Not CheckCover(pic) Then
                pic = String.Empty
            End If
        End If
        Return pic
    End Function
    Private Function CheckCover(ByRef Pic As String) As Boolean
        Dim Ret As Boolean = True
        If Pic.Length > 0 Then
            Try
                Dim xxx As New IO.MemoryStream(System.Convert.FromBase64String(Pic))
                Dim img As Image = Image.FromStream(xxx)
                If img.Width > 210 OrElse img.Height > 250 Then
                    Pic = ImageToBase64(img, 210, 250, System.Drawing.Imaging.ImageFormat.Jpeg)
                End If
            Catch ex As Exception
                Ret = False
            End Try
        End If
        Return Ret
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



    Private Sub m_GetSeries()
        'sequence
        If xDoc IsNot Nothing Then
            For Each xEl In xDoc.Descendants.Where(Function(x) x.Name.LocalName = "title-info").
                Descendants.Where(Function(x) x.Name.LocalName = "sequence")
                SeqNumber = 0
                Series = ""
                For Each el In xEl.Attributes
                    Select Case el.Name
                        Case "number"
                            Integer.TryParse(el.Value, SeqNumber)
                        Case "name"
                            Series = el.Value
                    End Select
                Next
            Next
        End If
    End Sub

    Private Function m_GetTitle() As String
        'sequence
        If xDoc IsNot Nothing Then
            Return xDoc.Descendants.Where(Function(x) x.Name.LocalName = "title-info").
                Descendants.Where(Function(x) x.Name.LocalName = "book-title").Value.ToString
        Else
            Return String.Empty
        End If
    End Function
    Private Function m_GetGenres() As List(Of String)
        'sequence
        If xDoc IsNot Nothing Then
            Return xDoc.Descendants.Where(Function(x) x.Name.LocalName = "title-info").
                Descendants.Where(Function(x) x.Name.LocalName = "genre").
                Select(Of String)(Function(x) x.Value).ToList
        Else
            Return Nothing
        End If
    End Function
    Private Function m_GetAuthors() As List(Of Author)
        If xDoc IsNot Nothing Then
            Dim LstAuth As List(Of Author) = New List(Of Author)
            Dim cl As Author = Nothing
            For Each el In xDoc.Descendants.Where(Function(x) x.Name.LocalName = "title-info").Descendants.Where(Function(x) x.Name.ToString.Contains("author")).Descendants
                If el.Name.LocalName = "first-name" Then
                    cl = New Author
                    cl.MiddleName = String.Empty
                    cl.FirstName = el.Value
                ElseIf el.Name.LocalName = "middle-name" Then
                    If cl IsNot Nothing Then
                        cl.MiddleName = el.Value
                    End If
                ElseIf el.Name.ToString.Contains("last-name") Then
                    If cl IsNot Nothing Then
                        cl.LastName = el.Value
                        LstAuth.Add(cl)
                        cl = Nothing
                    End If
                End If
            Next
            Return LstAuth
        Else
            Return Nothing
        End If
    End Function
    Private Function m_GetAnnotation() As String
        Dim stAnnotation As String = String.Empty
        If xDoc IsNot Nothing Then
            For Each el In xDoc.Descendants.Where(Function(x) x.Name.LocalName = "title-info").
                Descendants.Where(Function(x) x.Name.LocalName = "annotation").Descendants
                If el.Name.LocalName = "p" Or el.Name.LocalName = "empty-line" Then
                    stAnnotation &= el.Value & ControlChars.CrLf
                End If
            Next
        End If
        Return stAnnotation

    End Function
    Private Function m_GetKeyWords() As String
        Dim stKeyWords As String = String.Empty
        If xDoc IsNot Nothing Then
            Try
                For Each el In xDoc.Descendants.Where(Function(x) x.Name.LocalName = "title-info").
                Descendants.Where(Function(x) x.Name.LocalName = "keywords")
                    stKeyWords &= el.Value & ControlChars.CrLf
                Next
            Catch ex As Exception
                stKeyWords = String.Empty
            End Try
        End If
        If stKeyWords.EndsWith(ControlChars.CrLf) Then
            stKeyWords = stKeyWords.Substring(0, stKeyWords.Length - 2)
        End If
        If stKeyWords.Length > 0 AndAlso Not stKeyWords.EndsWith(",") Then
            stKeyWords &= ","
        End If
        Return stKeyWords

    End Function
    Private Function m_GetPublisher() As String
        Dim stPublisher As String = String.Empty
        If xDoc IsNot Nothing Then
            For Each el In xDoc.Descendants.Where(Function(x) x.Name.LocalName = "publish-info").Descendants '.Where(Function(x) x.Name.LocalName = "annotation").Descendants
                Select Case el.Name.LocalName
                    Case "book-name"
                        stPublisher &= "Название: " & el.Value & ControlChars.CrLf
                    Case "publisher"
                        stPublisher &= "Издательство: " & el.Value & ControlChars.CrLf
                    Case "city"
                        stPublisher &= "Город: " & el.Value & ControlChars.CrLf
                    Case "year"
                        stPublisher &= "Год: " & el.Value & ControlChars.CrLf
                    Case "sequence"
                        stPublisher &= "Серия: " & el.Attribute("name").Value & ControlChars.CrLf
                    Case "isbn"
                        stPublisher &= "ISBN: " & el.Value & ControlChars.CrLf
                    Case Else
                        stPublisher &= el.Name.LocalName & ":" & el.Value & ControlChars.CrLf
                End Select
            Next
        End If
        Return stPublisher
    End Function
    Private Sub Write2Log(msg As String, Fun As String)
        Dim st As String = Now.ToString & " Fun=" & Fun & " " & msg & vbCrLf & Path.Combine(FolderName, FileName)
        Dim LogStream As StreamWriter = New StreamWriter(Path.Combine(Config.CatalogBase, Config.LogFile), FileMode.OpenOrCreate)
        LogStream.WriteLine(st)
        LogStream.Close()
    End Sub
End Class
