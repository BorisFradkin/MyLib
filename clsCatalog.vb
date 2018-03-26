Imports System.Data.SQLite
Imports System.IO
Imports System.Collections.Generic
Imports System.IO.Compression

Public Class clsCatalog
    Private FlagAddBooks As Boolean = False
    Private m_PthDB As String
    Private m_LastError As String
    Private WithEvents cn As SQLiteConnection = Nothing
    Private cmd As SQLiteCommand = Nothing
    Private sql As String = String.Empty
    Private GenresDic As Dictionary(Of String, String) = Nothing
    Private m_NumAddBooks As Integer = 0
    Public ListOfSeries As Dictionary(Of Integer, SerieInfo) = Nothing
    Private Adp As SQLiteDataAdapter = Nothing
    Private Ds As DataSet = Nothing
    Private RefreshTree_TypePbj As Integer
    Private RefreshTree_ObjId As Object
    Private clsGenres As Genres = Nothing

    Public Sub New()
        MyBase.New()
    End Sub
    Public Function OpenCatalog(ByVal PthDb As String) As Integer
        m_LastError = String.Empty
        m_PthDB = Path.Combine(Config.CatalogBase, PthDb)
        Try
            If File.Exists(m_PthDB) Then
                cn = New SQLiteConnection("Data Source=" & m_PthDB)
                cn.Open()
                clsGenres = New Genres(cn)
                Return 0
            Else
                Write2Log("File '" & m_PthDB & "' is not Exists!", "clsCatalog.OpenCatalog")
                m_LastError = "OpenCatalog" & vbCrLf & "File '" & m_PthDB & "' is not Exists!"
                Return 1
            End If
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.OpenCatalog")
            m_LastError = "OpenCatalog" & vbCrLf & ex.Message
            Return 2
        End Try
    End Function

    Public Sub CreteNewCatalog(CatName As String)
        m_PthDB = Path.Combine(Config.CatalogBase, CatName)
        CheckCatalog()
        If Not IsError Then
            cn = New SQLiteConnection("Data Source=" & m_PthDB)
            cn.Open()
        End If
    End Sub
    Public Sub CloseCatalog()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub
    Public ReadOnly Property LastError() As String
        Get
            LastError = m_LastError
        End Get
    End Property
    Public ReadOnly Property IsError() As Boolean
        Get
            IsError = (m_LastError.Length > 0)
        End Get
    End Property


    Private Sub FillGenresContents()
        Dim cmd As SQLiteCommand = Nothing
        Dim ArGenre As Genres = New Genres()
        Try
            If cn.State <> ConnectionState.Open Then
                cn = New SQLiteConnection("Data Source=" & m_PthDB)
                cn.Open()
            End If
            For Each gr As Genre In ArGenre.GenresList
                Try
                    Dim SQL As String = "INSERT INTO [GENRES] VALUES("
                    SQL &= "'" & gr.GenreCode & "',"
                    SQL &= "'" & gr.ParentCode & "',"
                    SQL &= "'" & gr.FB2Code & "',"
                    SQL &= "'" & gr.GenreAlias.Replace("'", "''") & "')"
                    cmd = New SQLiteCommand(SQL, cn)
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Write2Log(ex.Message & vbCrLf & sql, "clsCatalog.FillGenresContents")
                End Try
            Next
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.FillGenresContents")
            m_LastError = "FillGenresContents" & vbCrLf & ex.Message
        End Try

    End Sub
    Private Sub CheckCatalog()
        Try
            If Not Directory.Exists(Config.CatalogBase) Then
                Directory.CreateDirectory(Config.CatalogBase)
            End If
            If CreateDBCatalog() Then
                If CheckOrCreateTableInfo() AndAlso
                     CheckOrCreateTableSeries() AndAlso
                    CheckOrCreateTableGenres() AndAlso
                    CheckOrCreateTableBooks() AndAlso
                    CheckOrCreateTableAuthors() AndAlso
                    CheckOrCreateTableAuthor_List() AndAlso
                    CheckOrCreateTableGenre_List() Then

                End If
            End If
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.CheckCatalog")
            m_LastError = "clsCatalog.CheckCatalog" & vbCrLf & ex.Message
        Finally
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Sub
    Private Function CreateDBCatalog() As Boolean
        m_LastError = String.Empty
        Dim sql As String = String.Empty
        Try
            SQLiteConnection.CreateFile(m_PthDB)
            CreateDBCatalog = True
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.CreateDBCatalog")
            m_LastError = "CreateDBCatalog" & vbCrLf & ex.Message
            CreateDBCatalog = False
        Finally
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Function
    Private Function CheckOrCreateTableInfo() As Boolean
        Try
            cn = New SQLiteConnection("Data Source=" & m_PthDB)
            cn.Open()
            sql = "SELECT Count(*) FROM sqlite_master WHERE type='table' AND name='CATALOGINFO'"
            cmd = New SQLiteCommand(sql, cn)
            If cmd.ExecuteScalar() = 0 Then
                sql = "CREATE TABLE [CATALOGINFO] ("
                sql &= "[Version]    NVARCHAR(256),"
                sql &= "[Name]    NVARCHAR(256),"
                sql &= "[FileName]    NVARCHAR(256),"
                sql &= "[Path2Books] BLOB,"
                sql &= "[Description]    NVARCHAR(4096))"
                cmd = New SQLiteCommand(sql, cn)
                cmd.ExecuteNonQuery()

            End If
            Return True
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.CheckOrCreateTableInfo")
            m_LastError = "CheckOrCreateTableInfo" & vbCrLf & ex.Message
            Return False
        Finally
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Function
    Private Function CheckOrCreateTableSeries() As Boolean
        Try
            cn = New SQLiteConnection("Data Source=" & m_PthDB)
            cn.Open()
            sql = "SELECT Count(*) FROM sqlite_master WHERE type='table' AND name='SERIES'"
            cmd = New SQLiteCommand(sql, cn)
            If cmd.ExecuteScalar() = 0 Then
                sql = "CREATE TABLE [SERIES] ("
                sql &= "[SeriesID]          INTEGER       Not NULL PRIMARY KEY AUTOINCREMENT,"
                sql &= "[SeriesTitle]       NVARCHAR(256) Not NULL  UNIQUE,"
                sql &= "[SearchSeriesTitle] NVARCHAR(256)          );"
                sql &= "CREATE Index IXSeries_Title ON Series (SeriesTitle);"
                sql &= "CREATE Index IXSeries_SearchSeriesTitle ON Series (SearchSeriesTitle);"
                cmd = New SQLiteCommand(sql, cn)
                cmd.ExecuteNonQuery()
            End If
            Return True
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.CheckOrCreateTableSeries")
            m_LastError = "CheckOrCreateTableSeries" & vbCrLf & ex.Message
            Return False
        Finally
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try
    End Function
    Private Function CheckOrCreateTableGenres() As Boolean
        Try
            cn = New SQLiteConnection("Data Source=" & m_PthDB)
            cn.Open()
            sql = "SELECT Count(*) FROM sqlite_master WHERE type='table' AND name='GENRES'"
            cmd = New SQLiteCommand(sql, cn)
            If cmd.ExecuteScalar() = 0 Then
                sql = "CREATE TABLE [GENRES] ("
                sql &= "[GenreCode]  VARCHAR(20)  Not NULL  PRIMARY KEY,"
                sql &= "[ParentCode] NVARCHAR(20),"
                sql &= "[FB2Code]    NVARCHAR(20),"
                sql &= "[GenreAlias] NNVARCHAR(256) Not NULL );"
                sql &= "CREATE UNIQUE INDEX IXGenres_ParentCode_GenreCode On Genres (ParentCode, GenreCode);"
                sql &= "CREATE Index IXGenres_FB2Code ON GENRES (FB2Code);"
                sql &= "CREATE Index IXGenres_GenreAlias ON GENRES (GenreAlias);"
                cmd = New SQLiteCommand(sql, cn)
                cmd.ExecuteNonQuery()
            End If
            cmd = New SQLiteCommand("SELECT Count(*) from GENRES", cn)
            If cmd.ExecuteScalar < My.Resources.Genres.Split(vbCrLf).Count Then
                cmd = New SQLiteCommand("delete from GENRES", cn)
                cmd.ExecuteNonQuery()
                FillGenresContents()
            End If
            Return True
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.CheckOrCreateTableGenres")
            m_LastError = "CheckOrCreateTableGenres" & vbCrLf & ex.Message
            Return False
        Finally
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Function
    Private Function CheckOrCreateTableBooks() As Boolean
        Try
            cn = New SQLiteConnection("Data Source=" & m_PthDB)
            cn.Open()
            sql = "SELECT Count(*) FROM sqlite_master WHERE type='table' AND name='BOOKS'"
            cmd = New SQLiteCommand(sql, cn)
            If cmd.ExecuteScalar() = 0 Then
                sql = "CREATE TABLE [BOOKS] ("
                sql &= "[BookID]           Integer        Not NULL PRIMARY KEY AUTOINCREMENT,"
                sql &= "[Title]            NVARCHAR(512)  Not NULL ,"
                sql &= "[SeriesID]         Integer,"
                sql &= "[SeqNumber]        Integer,"
                sql &= "[LoadBook]         Integer,"
                sql &= "[Folder]           VARCHAR(256)            ,"
                sql &= "[FileName]         VARCHAR(256)   Not NULL ,"
                sql &= "[BookSize]         Integer,"
                sql &= "[LoadDate]         VARCHAR(10)             ,"
                sql &= "[Keywords]         NVARCHAR(512)           ,"
                sql &= "[Annotation]       NVARCHAR(8192)          ,"
                sql &= "[Cover]            BLOB,"
                sql &= "[Publisher]        NVARCHAR(8192)          ,"
                sql &= "[SearchTitle]      NVARCHAR(512)           ,"
                sql &= "[SearchKeyWords]   NVARCHAR(255)           ,"
                sql &= "[SearchAnnotation] NVARCHAR(8192));"
                sql &= "CREATE Index IXBooks_SeriesID_SeqNumber On Books (SeriesID, SeqNumber);"
                sql &= "CREATE Index IXBooks_Title ON Books (Title);"
                sql &= "CREATE Index IXBooks_KeyWords ON Books (KeyWords);"
                sql &= "CREATE Index IXBooks_SearchTitle ON Books (SearchTitle);"
                sql &= "CREATE Index IXBooks_SearchKeyWords ON Books (SearchKeyWords);"
                sql &= "CREATE Index IXBooks_SearchAnnotation ON Books (SearchAnnotation);"
                cmd = New SQLiteCommand(sql, cn)
                cmd.ExecuteNonQuery()
            End If
            Return True
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.CheckOrCreateTableBooks")
            m_LastError = "CheckOrCreateTableBooks" & vbCrLf & ex.Message
            Return False
        Finally
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Function
    Private Function CheckOrCreateTableAuthors() As Boolean
        Try
            cn = New SQLiteConnection("Data Source=" & m_PthDB)
            cn.Open()
            sql = "SELECT Count(*) FROM sqlite_master WHERE type='table' AND name='AUTHORS'"
            cmd = New SQLiteCommand(sql, cn)
            If cmd.ExecuteScalar() = 0 Then
                sql = "CREATE TABLE [AUTHORS] ("
                sql &= "[AuthorID]   Integer        Not NULL PRIMARY KEY AUTOINCREMENT, "
                sql &= "[LastName]   NNVARCHAR(128) Not NULL ,"
                sql &= "[FirstName]  NVARCHAR(128)           ,"
                sql &= "[MiddleName] NVARCHAR(128)           ,"
                sql &= "[SearchName] NVARCHAR(512)           );"
                sql &= "CREATE Index IXAuthors_FullName On Authors (LastName, FirstName, MiddleName);"
                sql &= "CREATE Index IXAuthors_SearchName ON Authors (SearchName);"
                cmd = New SQLiteCommand(sql, cn)
                cmd.ExecuteNonQuery()
            End If
            Return True
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.CheckOrCreateTableAuthors")
            m_LastError = "CheckOrCreateTableAuthors" & vbCrLf & ex.Message
            Return False
        Finally
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Function
    Private Function CheckOrCreateTableAuthor_List() As Boolean
        Try
            cn = New SQLiteConnection("Data Source=" & m_PthDB)
            cn.Open()
            sql = "SELECT Count(*) FROM sqlite_master WHERE type='table' AND name='AUTHOR_LIST'"
            cmd = New SQLiteCommand(sql, cn)
            If cmd.ExecuteScalar() = 0 Then
                sql = "CREATE TABLE [AUTHOR_LIST] ("
                sql &= "AuthorID Integer Not NULL,"
                sql &= "BookID   Integer Not NULL,"
                sql &= "Constraint ""PKAuthorList"" PRIMARY KEY (BookID, AuthorID))"
                cmd = New SQLiteCommand(sql, cn)
                cmd.ExecuteNonQuery()
            End If
            Return True
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.CheckOrCreateTableAuthor_List")
            m_LastError = "CheckOrCreateTableAuthor_List" * vbCrLf & ex.Message
            Return False
        Finally
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Function
    Private Function CheckOrCreateTableGenre_List() As Boolean
        Try
            cn = New SQLiteConnection("Data Source=" & m_PthDB)
            cn.Open()
            sql = "SELECT Count(*) FROM sqlite_master WHERE type='table' AND name='GENRE_LIST'"
            cmd = New SQLiteCommand(sql, cn)
            If cmd.ExecuteScalar() = 0 Then
                sql = "CREATE TABLE [GENRE_LIST] ("
                sql &= "GenreCode VARCHAR(20) Not NULL ,"
                sql &= "BookID    Integer     Not NULL,"
                sql &= "Constraint ""PKGenreList"" PRIMARY KEY (BookID, GenreCode))"
                cmd = New SQLiteCommand(sql, cn)
                cmd.ExecuteNonQuery()

            End If
            Return True
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.CheckOrCreateTableGenre_List")
            m_LastError = "CheckOrCreateTableGenre_List" & vbCrLf & ex.Message
            Return False
        Finally
            If cn IsNot Nothing AndAlso cn.State = ConnectionState.Open Then
                cn.Close()
            End If
        End Try

    End Function

    Public Function SaveBookFb2ToCatalog(book As clsCardBookFb2) As Boolean

        Dim SeriesID As Integer = 0
        Dim SeqNumber As Integer = 0
        Dim BookID As Integer = 0
        m_LastError = String.Empty
        Try
            If cn Is Nothing OrElse cn.State <> ConnectionState.Open Then
                cn = New SQLiteConnection("Data Source=" & m_PthDB)
                cn.Open()
            End If
            'If GenresDic Is Nothing Then
            '    FillGenresDic()
            'End If
            If book.Series IsNot Nothing Then
                SeriesID = GetSeries(book.Series)
                SeqNumber = book.SeqNumber
            End If
            Dim AuthID As List(Of Integer) = GetAuthID(book.Authors)
            Dim GenresID As List(Of String) = GetGenresId(book.Genres)
            sql = "INSERT INTO [BOOKS] ("
            sql &= "[Title],"
            sql &= "[SeriesID],"
            sql &= "[SeqNumber],"
            sql &= "[LoadBook],"
            sql &= "[Folder],"
            sql &= "[FileName],"
            sql &= "[BookSize],"
            sql &= "[LoadDate],"
            sql &= "[Keywords],"
            sql &= "[Annotation],"
            sql &= "[Cover],"
            sql &= "[Publisher],"
            sql &= "[SearchTitle],"
            sql &= "[SearchKeyWords],"
            sql &= "[SearchAnnotation]) VALUES("
            sql &= "'" & book.Title.Trim.Replace("'", "''") & "',"
            sql &= SeriesID.ToString & ","
            sql &= SeqNumber.ToString & ","
            sql &= book.LoadBook.ToString & ","
            sql &= "'" & book.FolderName.Trim.Replace("'", "''") & "',"
            sql &= "'" & book.FileName.Trim.Replace("'", "''") & "',"
            sql &= book.BookSize & ","
            sql &= "'" & book.LoadDate & "',"
            sql &= "'" & book.KeyWords.Replace("'", "''") & "',"
            sql &= "'" & book.Annotation.Replace("'", "''") & "',"
            sql &= "'" & book.Cover & "',"
            sql &= "'" & book.Publisher.Replace("'", "''") & "',"
            sql &= "'" & book.Title.ToUpper.Replace("'", "''") & "',"
            sql &= "'" & book.KeyWords.ToUpper.Replace("'", "''") & "',"
            sql &= "'" & book.Annotation.ToUpper.Replace("'", "''") & "'); SELECT last_insert_rowid()"
            cmd = New SQLiteCommand(sql, cn)
            BookID = cmd.ExecuteScalar()
            If AuthID IsNot Nothing Then
                For Each id In AuthID.Distinct
                    sql = "INSERT INTO [AUTHOR_LIST] VALUES(" & id.ToString & "," & BookID.ToString & ")"
                    cmd = New SQLiteCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Next
            End If
            If GenresID IsNot Nothing Then
                For Each id In GenresID.Distinct
                    sql = "INSERT INTO [GENRE_LIST] VALUES('" & id.Trim & "'," & BookID.ToString & ")"
                    cmd = New SQLiteCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Next
            End If
            Return True
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.SaveBooktoCatalog")
            Write2Log("SQL=" & sql, "clsCatalog.SaveBooktoCatalog")
            m_LastError = "SaveBooktoCatalog" & vbCrLf & ex.Message
            Return False
        End Try

    End Function
    Public Function SaveBookEpubToCatalog(book As clsCardBookEpub) As Boolean

        Dim SeriesID As Integer = 0
        Dim SeqNumber As Integer = 0
        Dim BookID As Integer = 0
        m_LastError = String.Empty
        Try
            If cn Is Nothing OrElse cn.State <> ConnectionState.Open Then
                cn = New SQLiteConnection("Data Source=" & m_PthDB)
                cn.Open()
            End If
            'If GenresDic Is Nothing Then
            '    FillGenresDic()
            'End If
            If book.Series IsNot Nothing Then
                SeriesID = GetSeries(book.Series)
                SeqNumber = book.SeqNumber
            End If
            Dim AuthID As List(Of Integer) = GetAuthID(book.Authors)
            Dim GenresID As List(Of String) = GetGenresId(book.Genres)
            sql = "INSERT INTO [BOOKS] ("
            sql &= "[Title],"
            sql &= "[SeriesID],"
            sql &= "[SeqNumber],"
            sql &= "[LoadBook],"
            sql &= "[Folder],"
            sql &= "[FileName],"
            sql &= "[BookSize],"
            sql &= "[LoadDate],"
            sql &= "[Keywords],"
            sql &= "[Annotation],"
            sql &= "[Cover],"
            sql &= "[Publisher],"
            sql &= "[SearchTitle],"
            sql &= "[SearchKeyWords],"
            sql &= "[SearchAnnotation]) VALUES("
            sql &= "'" & book.Title.Trim.Replace("'", "''") & "',"
            sql &= SeriesID.ToString & ","
            sql &= SeqNumber.ToString & ","
            sql &= book.LoadBook.ToString & ","
            sql &= "'" & book.FolderName.Trim.Replace("'", "''") & "',"
            sql &= "'" & book.FileName.Trim.Replace("'", "''") & "',"
            sql &= book.BookSize & ","
            sql &= "'" & book.LoadDate & "',"
            sql &= "'" & book.KeyWords.Replace("'", "''") & "',"
            sql &= "'" & book.Annotation.Replace("'", "''") & "',"
            sql &= "'" & book.Cover & "',"
            sql &= "'" & book.Publisher.Replace("'", "''") & "',"
            sql &= "'" & book.Title.ToUpper.Replace("'", "''") & "',"
            sql &= "'" & book.KeyWords.ToUpper.Replace("'", "''") & "',"
            sql &= "'" & book.Annotation.ToUpper.Replace("'", "''") & "'); SELECT last_insert_rowid()"
            cmd = New SQLiteCommand(sql, cn)
            BookID = cmd.ExecuteScalar()
            If AuthID IsNot Nothing Then
                For Each id In AuthID.Distinct
                    sql = "INSERT INTO [AUTHOR_LIST] VALUES(" & id.ToString & "," & BookID.ToString & ")"
                    cmd = New SQLiteCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Next
            End If
            If GenresID IsNot Nothing Then
                For Each id In GenresID.Distinct
                    sql = "INSERT INTO [GENRE_LIST] VALUES('" & id.Trim & "'," & BookID.ToString & ")"
                    cmd = New SQLiteCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Next
            End If
            Return True
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.SaveBooktoCatalog")
            Write2Log("SQL=" & sql, "clsCatalog.SaveBooktoCatalog")
            m_LastError = "SaveBooktoCatalog" & vbCrLf & ex.Message
            Return False
        End Try

    End Function
    Public Function GetGenriesIDByBookId(BookID As Integer) As List(Of String)
        Dim lst As List(Of String) = New List(Of String)
        Try
            If cn Is Nothing OrElse cn.State <> ConnectionState.Open Then
                cn = New SQLiteConnection("Data Source=" & m_PthDB)
                cn.Open()
            End If
            sql = "SELECT * FROM [GENRE_LIST] WHERE [BOOKID]=" & BookID.ToString
            cmd = New SQLiteCommand(sql, cn)
            Dim rd As SQLiteDataReader = cmd.ExecuteReader
            While rd.Read
                lst.Add(rd("GenreCode"))
            End While
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.FillGenresDic")
            m_LastError = "FillGenresDic" & vbCrLf & ex.Message
        End Try
        Return lst
    End Function
    Private Sub FillGenresDic()
        Try
            GenresDic = New Dictionary(Of String, String)
            sql = "SELECT [GenreCode],[FB2Code] FROM [GENRES] WHERE [FB2Code]<>'' ORDER BY [FB2Code]"
            cmd = New SQLiteCommand(sql, cn)
            Dim rd As SQLiteDataReader = cmd.ExecuteReader
            While rd.Read
                If Not GenresDic.ContainsKey(rd("FB2Code").ToString.ToLower) Then
                    GenresDic.Add(rd("FB2Code").ToString.ToLower, rd("GenreCode").ToString.Trim)
                End If
            End While
            rd.Close()
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.FillGenresDic")
            m_LastError = "FillGenresDic" & vbCrLf & ex.Message
        End Try
    End Sub

    Private Function GetSeries(txt As String) As Integer
        Dim Ret As Integer
        sql = "SELECT [SeriesID] FROM [SERIES] WHERE [SearchSeriesTitle]='" & txt.ToUpper.Replace("'", "''") & "'"
        cmd = New SQLiteCommand(sql, cn)
        Ret = cmd.ExecuteScalar
        If Ret = 0 Then
            sql = "INSERT INTO [SERIES] ([SeriesTitle],[SearchSeriesTitle]) VALUES('" & txt.Replace("'", "''") & "','" & txt.ToUpper.Replace("'", "''") & "') ; SELECT last_insert_rowid()"
            cmd = New SQLiteCommand(sql, cn)
            Ret = cmd.ExecuteScalar
        End If
        Return Ret
    End Function
    Private Function GetAuthID(Auth As List(Of Author)) As List(Of Integer)
        Dim Ret As List(Of Integer) = New List(Of Integer)
        Dim RecID As Integer
        For Each St In Auth
            sql = "SELECT [AuthorID] FROM [AUTHORS] WHERE [SearchName]='" & St.LastName.Trim.ToUpper.Replace("'", "''") & " " & St.FirstName.Trim.ToUpper.Replace("'", "''") & " " & St.MiddleName.Trim.ToUpper.Replace("'", "''") & "'"
            cmd = New SQLiteCommand(sql, cn)
            RecID = cmd.ExecuteScalar
            If RecID = 0 Then
                sql = "INSERT INTO [AUTHORS] (" & "[LastName],[FirstName],[MiddleName],[SearchName]) VALUES("
                sql &= "'" & St.LastName.Trim.Replace("'", "''") & "',"
                sql &= "'" & St.FirstName.Trim.Replace("'", "''") & "',"
                sql &= "'" & St.MiddleName.Trim.Replace("'", "''") & "',"
                sql &= "'" & St.LastName.Trim.ToUpper.Replace("'", "''") & " " & St.FirstName.Trim.ToUpper.Replace("'", "''") & " " & St.MiddleName.Trim.ToUpper.Replace("'", "''") & "');"
                sql &= " SELECT last_insert_rowid()"
                cmd = New SQLiteCommand(sql, cn)
                RecID = cmd.ExecuteScalar
            End If
            Ret.Add(RecID)
        Next
        Return Ret
    End Function

    Private Function GetGenresId(Genre As List(Of String)) As List(Of String)
        Dim Ret As List(Of String) = New List(Of String)
        Dim GenreID As String
        For Each St In Genre
            GenreID = clsGenres.GetGenreCode(St)
            If GenreID <> "nan" Then
                Ret.Add(GenreID)
            Else
                Write2Log("Не найден жанр '" & St.Trim & "'", "clsCatalog.GetGenresId")
            End If
        Next
        Return Ret
    End Function

    Public Sub AddBooks(Pth As String, pr As ProgressBar, lbl As Label)
        Dim Num As Integer = 0
        FlagAddBooks = True
        m_NumAddBooks = 0
        pr.Visible = True
        lbl.Visible = True
        Application.DoEvents()
        Dim Di As DirectoryInfo = New DirectoryInfo(Pth)
        Dim Fi() As FileInfo = Di.GetFiles("*", SearchOption.AllDirectories) '.Where(Function(x) x.Extension.ToLower = ".fb2" Or x.Extension.ToLower = ".zip")
        Dim Ret As List(Of FileInfo) = Fi.Where(Function(x) Config.Formats.ToLower.Contains(x.Extension.ToLower) Or x.Extension.ToLower = ".zip").ToList
        For Each BookFI As FileInfo In Ret
            If BookFI.Extension.ToLower = ".fb2" Then
                m_AddFb2Book(BookFI.FullName, BookFI)
                Num += 1
            ElseIf BookFI.Extension.ToLower = ".epub" Then
                m_AddEpubBook(BookFI.FullName, BookFI)
                Num += 1
            Else
                Num += m_AddBookFromZip(BookFI.FullName, BookFI)
            End If

            lbl.Text = "Добавлено книг " & Num.ToString & " из " & Ret.Count.ToString & " файлов"
            pr.Value = (Num / Ret.Count) * 100
            Application.DoEvents()
            If Not FlagAddBooks Then
                Exit For
            End If
        Next
    End Sub
    Public Sub StopAddBooks()
        FlagAddBooks = False
    End Sub
    Public ReadOnly Property NumAddBooks() As String
        Get
            NumAddBooks = m_NumAddBooks
        End Get
    End Property
    Private Sub m_AddFb2Book(pth As String, FiBook As FileInfo)
        Dim cl As clsCardBookFb2 = New clsCardBookFb2(pth, FiBook)
        If Not cl.IsError Then
            Me.SaveBookFb2ToCatalog(cl)
            m_NumAddBooks += 1
        End If
    End Sub
    Private Sub m_AddEpubBook(pth As String, FiBook As FileInfo)

        Dim cl As clsCardBookEpub = New clsCardBookEpub(pth)
        If Not cl.IsError Then
            Me.SaveBookEpubToCatalog(cl)
            m_NumAddBooks += 1
        End If
    End Sub
    Private Function m_AddBookFromZip(pth As String, FiBook As FileInfo) As Integer
        Dim Num As Integer = 0
        Dim PthZip As String = m_Unzip(pth)
        If PthZip.Length > 0 Then
            Dim Di As DirectoryInfo = New DirectoryInfo(PthZip)
            Dim ArTmp() As FileInfo = Di.GetFiles("*", SearchOption.AllDirectories)
            Dim Fi As List(Of FileInfo) = ArTmp.Where(Function(x) Config.Formats.ToLower.Contains(x.Extension.ToLower) Or x.Extension.ToLower = ".zip").ToList
            For Idx = 0 To Fi.Count - 1
                If Fi(Idx).Extension.ToLower = ".fb2" Then
                    m_AddFb2Book(Fi(Idx).FullName, FiBook)
                    Num += 1
                ElseIf Fi(Idx).Extension.ToLower = ".epub" Then
                    m_AddEpubBook(Fi(Idx).FullName, FiBook)
                    Num += 1
                Else
                    Num += m_AddBookFromZip(Fi(Idx).FullName, FiBook)
                End If
            Next
            Directory.Delete(PthZip, True)
        End If
        Return Num
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
    Public Function Unzip(St As String) As String
        Unzip = m_Unzip(St)
    End Function
    Public Function GetListOfAthors() As List(Of Author)
        Dim ret As List(Of Author) = New List(Of Author)
        If cn.State = ConnectionState.Open Then
            sql = "SELECT * FROM AUTHORS ORDER BY [LastName]"
            cmd = New SQLiteCommand(sql, cn)
            Dim rd As SQLiteDataReader = cmd.ExecuteReader
            While rd.Read
                Dim cl As Author = New Author
                cl.AuthorID = rd("AuthorId")
                cl.LastName = rd("LastName")
                cl.FirstName = rd("FirstName")
                cl.MiddleName = rd("MiddleName")
                Dim cmd1 As New SQLiteCommand("SELECT Count(*) FROM [AUTHOR_LIST] GROUP BY [AuthorID] HAVING [AuthorID]=" & cl.AuthorID.ToString, cn)
                cl.NumBooks = cmd1.ExecuteScalar
                ret.Add(cl)
            End While
        End If
        Return ret
    End Function
    Public Function GetListOfSeries() As List(Of SerieInfo)
        Dim ret As List(Of SerieInfo) = New List(Of SerieInfo)
        If cn.State = ConnectionState.Open Then
            sql = "SELECT * FROM [SERIES] ORDER BY [SeriesTitle]"
            cmd = New SQLiteCommand(sql, cn)
            Dim rd As SQLiteDataReader = cmd.ExecuteReader
            While rd.Read
                Dim cl As SerieInfo = New SerieInfo
                cl.SeriesID = rd("SeriesID")
                cl.SeriesTitle = rd("SeriesTitle")
                cl.SearchSeriesTitle = rd("SearchSeriesTitle")
                ret.Add(cl)
            End While
        End If
        Return ret
    End Function
    Public Function GetTreeGenries(trv As TreeView) As List(Of GenreInfo)
        Dim ret As List(Of GenreInfo) = New List(Of GenreInfo)
        trv.Nodes.Clear()
        Dim Nodes As Dictionary(Of String, TreeNode) = New Dictionary(Of String, TreeNode)
        Dim Node As TreeNode = Nothing
        If cn.State = ConnectionState.Open Then
            sql = "SELECT * FROM [GENRES] ORDER BY [ParentCode],[GenreAlias]"
            cmd = New SQLiteCommand(sql, cn)
            Dim rd As SQLiteDataReader = cmd.ExecuteReader
            While rd.Read
                Dim Key As String = rd("GenreCode").ToString.Trim
                If Nodes.ContainsKey(rd("ParentCode").ToString.Trim) Then
                    Node = Nodes(rd("ParentCode").ToString.Trim).Nodes.Add(rd("GenreAlias"))
                    Node.Tag = Key
                Else
                    Node = trv.Nodes.Add(rd("GenreAlias"))
                    Node.Tag = ""
                End If
                Nodes.Add(Key, Node)
            End While
            rd.Close()
            sql = "SELECT DISTINCT [GenreCode] FROM GENRE_LIST"
            cmd = New SQLiteCommand(sql, cn)
            rd = cmd.ExecuteReader
            While rd.Read
                Node = Nodes(rd("GenreCode").ToString.Trim)
                'Node.NodeFont = New Font(trv.Font, FontStyle.Bold)
                Node.ForeColor = Color.Blue
                Dim cl As GenreInfo = New GenreInfo
                cl.GenreCode = rd("GenreCode").ToString.Trim
                cl.GenreAllias = Node.Text
                cl.TrvNode = Node
                ret.Add(cl)
                Node = Node.Parent
                If Node IsNot Nothing Then
                    'Node.NodeFont = New Font(trv.Font, FontStyle.Bold)
                    Node.ForeColor = Color.Blue
                End If
            End While
            rd.Close()
        End If
        Return ret.OrderBy(Function(x) x.GenreAllias).ToList
    End Function
    Private Function GetListOfBooksByAuthor(AuthID As Integer) As List(Of clsCardBook)
        Dim ret As List(Of clsCardBook) = New List(Of clsCardBook)
        ListOfSeries = Nothing
        If cn.State = ConnectionState.Open Then

            Ds = New DataSet
            sql = "SELECT BookID FROM AUTHOR_LIST WHERE AuthorID=" & AuthID.ToString
            Adp = New SQLiteDataAdapter(sql, cn)
            Adp.Fill(Ds)
            Dim Ar() = (From el In Ds.Tables(0).Rows
                        Select el.item(0)).ToArray
            Dim stBooksID As String = "(" & String.Join(",", Ar) & ")"
            sql = "SELECT * FROM [BOOKS] WHERE [BookID] in " & stBooksID & " ORDER BY [Title]"
            Adp = New SQLiteDataAdapter(sql, cn)
            Adp.Fill(Ds, "Books")
            Ar = (From el In Ds.Tables("Books").Rows
                   Where el.item("SeriesID") <> 0
                   Select el.item("SeriesID")).ToArray
            If Ar.Length > 0 Then
                'ListOfSeries = New Dictionary(Of Integer, SerieInfo)
                Dim stSeriesID As String = "(" & String.Join(",", Ar) & ")"
                sql = "SELECT * FROM [SERIES] WHERE [SeriesID] in " & stSeriesID & " ORDER BY [SearchSeriesTitle]"
                Adp = New SQLiteDataAdapter(sql, cn)
                Adp.Fill(Ds, "Series")
                ListOfSeries = (From El In Ds.Tables("Series").Rows
                                Select New SerieInfo With {.SeriesID = El.Item("SeriesID"), .SeriesTitle = El.Item("SeriesTitle"), .SearchSeriesTitle = El.Item("SearchSeriesTitle")}).ToDictionary(Of Integer, SerieInfo)(Function(x) x.SeriesID, Function(x) x)
            End If
            For Each Dr As DataRow In Ds.Tables("Books").Rows
                ret.Add(GetCardBookByID(Dr))
            Next

        End If
        Return ret
    End Function
    Public Function GetListOfBooksByListOfAuthors(AuthIDs() As Integer) As String()
        Dim ret() As String = {}
        If cn.State = ConnectionState.Open Then

            Ds = New DataSet
            sql = "SELECT A.BookID,A.Title,C.LastName,C.FirstName FROM [BOOKS] AS A INNER JOIN [AUTHOR_LIST] AS B INNER JOIN [AUTHORS] AS C ON  B.BookID=A.BookId AND C.AUTHORID=B.AUTHORID And B.AUTHORID In (" & String.Join(",", AuthIDs) & ")"
            Adp = New SQLiteDataAdapter(sql, cn)
            Adp.Fill(Ds)
            ret = (From el In Ds.Tables(0).Rows
                   Select DirectCast(el.item(1), String) & " (" & DirectCast(el.item(2), String) & " " & DirectCast(el.item(3), String) & ")").ToArray

        End If
        Return ret
    End Function
    Public Function GetBookByID(BookID As Integer) As clsCardBook
        sql = "SELECT * FROM [BOOKS] WHERE [BookID] = " & BookID
        Adp = New SQLiteDataAdapter(sql, cn)
        Adp.Fill(Ds, "Books")
        Return GetCardBookByID(Ds.Tables("Books").Rows(0))
    End Function
    Private Function GetCardBookByID(Dr As DataRow) As clsCardBook
        Dim cl As clsCardBook = New clsCardBook()
        Try
            cl.BookID = Dr("BookId")
            cl.Title = Dr("Title").ToString
            cl.SeriesID = Dr("SeriesID")
            cl.Series = m_GetSeriesFromDB(Dr("SeriesID"))
            cl.SeqNumber = Dr("SeqNumber")
            cl.FolderName = Dr("Folder").ToString
            cl.FileName = Dr("FileName").ToString
            cl.BookSize = Dr("BookSize")
            cl.LoadDate = Dr("LoadDate")
            cl.KeyWords = Dr("KeyWords").ToString
            cl.Annotation = Dr("Annotation").ToString
            cl.Cover = System.Text.Encoding.Default.GetString(Dr("Cover"))
            cl.Publisher = Dr("Publisher").ToString
            cl.Authors = m_getAuthorsFromDB(Dr("BookId"))
            cl.Genres = m_getGenresFromDB(Dr("BookId"))
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.GetCardBookByID")
            m_LastError = "clsCatalog.GetCardBookByID" & vbCrLf & ex.Message
        End Try
        Return cl
    End Function
    Private Function m_GetSeriesFromDB(SeriesID As Integer) As String
        If (ListOfSeries Is Nothing) OrElse (Not ListOfSeries.ContainsKey(SeriesID)) Then
            sql = "SELECT [SeriesTitle] FROM [SERIES] WHERE [SeriesId]=" & SeriesID.ToString
            cmd = New SQLiteCommand(sql, cn)
            Return cmd.ExecuteScalar
        Else
            Return ListOfSeries(SeriesID).SeriesTitle
        End If
    End Function
    Private Function m_getAuthorsFromDB(BookId As Integer) As List(Of Author)
        Dim ret As List(Of Author) = New List(Of Author)
        sql = "SELECT * FROM [AUTHORS] AS A INNER JOIN [AUTHOR_LIST] AS B ON B.AuthorID=A.AuthorID AND B.BookID=" & BookId
        Dim rd As SQLiteDataReader
        cmd = New SQLiteCommand(sql, cn)
        rd = cmd.ExecuteReader
        While rd.Read
            Dim cl As Author = New Author
            cl.AuthorID = rd("AuthorID")
            cl.FirstName = rd("FirstName")
            cl.LastName = rd("LastName")
            cl.MiddleName = rd("MiddleName")
            ret.Add(cl)
        End While
        rd.Close()
        Return ret
    End Function
    Private Function m_getGenresFromDB(BookId As Integer) As List(Of String)
        Dim ret As List(Of String) = New List(Of String)
        sql = "SELECT * FROM [GENRES] AS A INNER JOIN [GENRE_LIST] AS B ON B.GenreCode=A.GenreCode AND B.BookID=" & BookId
        Dim rd As SQLiteDataReader
        cmd = New SQLiteCommand(sql, cn)
        rd = cmd.ExecuteReader
        While rd.Read
            ret.Add(rd("GenreAlias"))
        End While
        rd.Close()
        Return ret
    End Function
    Public Function GetGenresAlias(Cdes As List(Of String)) As List(Of String)
        Dim ret As List(Of String) = New List(Of String)
        Try
            If cn Is Nothing OrElse cn.State <> ConnectionState.Open Then
                cn = New SQLiteConnection("Data Source=" & m_PthDB)
                cn.Open()
            End If
            Dim St As String = "(" & Join((From el In Cdes
                                           Select "'" & el & "'").ToArray, ",") & ")"

            sql = "SELECT * FROM [GENRES] Where GenreCode in " & St
            Dim rd As SQLiteDataReader
            cmd = New SQLiteCommand(sql, cn)
            rd = cmd.ExecuteReader
            While rd.Read
                ret.Add(rd("GenreAlias"))
            End While
            rd.Close()
        Catch ex As Exception

        End Try
        Return ret

    End Function
    Private Sub Write2Log(msg As String, Fun As String)
        Dim st As String = Now.ToString & " Fun=" & Fun & " " & msg
        Dim LogStream As StreamWriter = New StreamWriter(Path.Combine(Config.CatalogBase, Config.LogFile), FileMode.OpenOrCreate)
        LogStream.WriteLine(st)
        LogStream.Close()
    End Sub
    Public Sub Add2Log(msg As String, Fun As String)
        Dim st As String = Now.ToString & " Fun=" & Fun & " " & msg
        Dim LogStream As StreamWriter = New StreamWriter(Path.Combine(Config.CatalogBase, Config.LogFile), FileMode.OpenOrCreate)
        LogStream.WriteLine(st)
        LogStream.Close()
    End Sub
    '/// Parametr TypeObj = 0-Authors,1-Series,2-Genres
    Public Sub FillTreeBooks(TypeObj As Integer, ObjId As Object, Trv As TreeView, Cntx As ContextMenuStrip)
        RefreshTree_TypePbj = TypeObj
        RefreshTree_ObjId = ObjId
        Dim lst As List(Of clsCardBook) = Nothing
        Trv.Nodes.Clear()
        ListOfSeries = New Dictionary(Of Integer, SerieInfo)
        If cn Is Nothing OrElse cn.State <> ConnectionState.Open Then
            cn = New SQLiteConnection("Data Source=" & m_PthDB)
            cn.Open()
        End If
        Select Case TypeObj
            Case 0
                lst = GetListOfBooksByAuthor(DirectCast(ObjId, Integer))
            Case 1
                lst = GetListOfBooksBySerie(DirectCast(ObjId, Integer))
            Case 2
                lst = GetListOfBooksByGenre(DirectCast(ObjId, String))
            Case 4
                lst = GetLIstOfBooksByDuplicate()
            Case 5
                lst = DirectCast(ObjId, List(Of clsCardBook))
            Case 6
                lst = GetLIstOfBooksByNonDuplicate()
        End Select

        Dim Nodes As Dictionary(Of Integer, TreeNode) = New Dictionary(Of Integer, TreeNode)
        Dim Node As TreeNode = Nothing
        If ListOfSeries IsNot Nothing AndAlso ListOfSeries.Count > 0 AndAlso Config.ShowSeriesOnTree Then
            For Each Si As SerieInfo In ListOfSeries.Values
                Nodes.Add(Si.SeriesID, Trv.Nodes.Add("Серия: " & Si.SeriesTitle))
                Nodes(Si.SeriesID).ForeColor = Color.DarkBlue
                'Nodes(Si.SeriesID).NodeFont = New Font(Trv.Font, FontStyle.Bold)
                Nodes(Si.SeriesID).Tag = Nothing
            Next
        End If
        For Each cl In lst
            'Dim Tit As String = If(TypeObj > 0, "Автор: " & cl.Authors(0).ToShow & "  Название: ", "Название: ") & cl.Title &
            '    If(TypeObj = 4, "  Size=" & cl.BookSize & "  File:" & Path.Combine(cl.FolderName, cl.FileName), "")
            Dim Tit As String = If(TypeObj > 0, If(cl.Authors.Count > 0, cl.Authors(0).ToShow, "") & "  - ", "") & cl.Title &
                If(TypeObj = 4, "  Size=" & cl.BookSize & "  File:" & Path.Combine(cl.FolderName, cl.FileName), "")
            If cl.SeriesID <> 0 And Config.ShowSeriesOnTree Then
                If Nodes.ContainsKey(cl.SeriesID) Then
                    Node = Nodes(cl.SeriesID).Nodes.Add(Tit)
                Else
                    Node = Trv.Nodes.Add(Tit)
                End If
            Else
                Node = Trv.Nodes.Add(Tit)
            End If
            Node.Tag = cl
            Node.ContextMenuStrip = Cntx
        Next
    End Sub
    Public Sub RefreshTreeBooks(Trv As TreeView, Cntx As ContextMenuStrip)
        Dim TypeObj As Integer = RefreshTree_TypePbj
        Dim ObjId As Object = RefreshTree_ObjId
        Dim lst As List(Of clsCardBook) = Nothing
        Trv.Nodes.Clear()
        ListOfSeries = New Dictionary(Of Integer, SerieInfo)
        If cn Is Nothing OrElse cn.State <> ConnectionState.Open Then
            cn = New SQLiteConnection("Data Source=" & m_PthDB)
            cn.Open()
        End If
        Select Case TypeObj
            Case 0
                lst = GetListOfBooksByAuthor(DirectCast(ObjId, Integer))
            Case 1
                lst = GetListOfBooksBySerie(DirectCast(ObjId, Integer))
            Case 2
                lst = GetListOfBooksByGenre(DirectCast(ObjId, String))
            Case 4
                lst = GetLIstOfBooksByDuplicate()
        End Select

        Dim Nodes As Dictionary(Of Integer, TreeNode) = New Dictionary(Of Integer, TreeNode)
        Dim Node As TreeNode = Nothing
        If ListOfSeries IsNot Nothing AndAlso ListOfSeries.Count > 0 AndAlso Config.ShowSeriesOnTree Then
            For Each Si As SerieInfo In ListOfSeries.Values
                Nodes.Add(Si.SeriesID, Trv.Nodes.Add("Серия: " & Si.SeriesTitle))
                Nodes(Si.SeriesID).ForeColor = Color.DarkBlue
                'Nodes(Si.SeriesID).NodeFont = New Font(Trv.Font, FontStyle.Bold)
                Nodes(Si.SeriesID).Tag = Nothing
            Next
        End If
        For Each cl In lst
            Dim Tit As String = If(TypeObj > 0, cl.Authors(0).ToShow & "  - ", "") & cl.Title &
                If(TypeObj = 4, "  Size=" & cl.BookSize & "  File:" & Path.Combine(cl.FolderName, cl.FileName), "")
            If cl.SeriesID <> 0 And Config.ShowSeriesOnTree Then
                If Nodes.ContainsKey(cl.SeriesID) Then
                    Node = Nodes(cl.SeriesID).Nodes.Add(Tit)
                Else
                    Node = Trv.Nodes.Add(Tit)
                End If
            Else
                Node = Trv.Nodes.Add(Tit)
            End If
            Node.Tag = cl
            Node.ContextMenuStrip = Cntx
        Next
    End Sub
    Public Function NumAuthors() As Integer
        sql = "SELECT count(*) FROM AUTHORS"
        cmd = New SQLiteCommand(sql, cn)
        Return cmd.ExecuteScalar
    End Function
    Public Function NumBooks() As Integer
        sql = "SELECT count(*) FROM BOOKS"
        cmd = New SQLiteCommand(sql, cn)
        Return cmd.ExecuteScalar
    End Function
    Public Function NumSeries() As Integer
        sql = "SELECT count(*) FROM SERIES"
        cmd = New SQLiteCommand(sql, cn)
        Return cmd.ExecuteScalar
    End Function
    Private Function GetListOfBooksBySerie(SerieId As Integer) As List(Of clsCardBook)
        Dim ret As List(Of clsCardBook) = New List(Of clsCardBook)
        Ds = New DataSet
        sql = "SELECT * FROM [BOOKS] WHERE [SeriesID] = " & SerieId & " ORDER BY [Title]"
        Adp = New SQLiteDataAdapter(sql, cn)
        Adp.Fill(Ds, "Books")
        For Each Dr As DataRow In Ds.Tables("Books").Rows
            ret.Add(GetCardBookByID(Dr))
        Next
        Return ret
    End Function
    Private Function GetLIstOfBooksByDuplicate()
        Dim ret As List(Of clsCardBook) = New List(Of clsCardBook)
        Ds = New DataSet
        sql = "SELECT * FROM [BOOKS] WHERE [BookID] In ("
        sql &= "SELECT BookId From BOOKS WHERE BookID IN (SELECT DISTINCT BookID FROM (SELECT a.BookId,title,b.authorid from books as a "
        sql &= "INNER JOIN author_list as b on a.bookid=b.bookid  where a.Title In (SELECT title as cnt FROM books GROUP BY searchtitle HAVING count(*)>1 ))) ORDER BY Title"
        sql &= ") ORDER BY [Title]"
        Adp = New SQLiteDataAdapter(sql, cn)
        Adp.Fill(Ds, "Books")
        For Each Dr As DataRow In Ds.Tables("Books").Rows
            ret.Add(GetCardBookByID(Dr))
        Next
        Return ret

    End Function
    Private Function GetLIstOfBooksByNonDuplicate()
        Dim ret As List(Of clsCardBook) = New List(Of clsCardBook)
        Ds = New DataSet
        sql = "SELECT * FROM [BOOKS] WHERE [BookID] In ("
        sql &= "SELECT BookId From BOOKS WHERE BookID IN (SELECT DISTINCT BookID FROM (SELECT a.BookId,title,b.authorid from books as a "
        sql &= "INNER JOIN author_list as b on a.bookid=b.bookid  where a.Title In (SELECT title as cnt FROM books GROUP BY searchtitle HAVING count(*)=1 ))) ORDER BY Title"
        sql &= ") ORDER BY [Title]"
        Adp = New SQLiteDataAdapter(sql, cn)
        Adp.Fill(Ds, "Books")
        For Each Dr As DataRow In Ds.Tables("Books").Rows
            ret.Add(GetCardBookByID(Dr))
        Next
        Return ret

    End Function
    Private Function GetListOfBooksByGenre(GenreId As String) As List(Of clsCardBook)
        Dim ret As List(Of clsCardBook) = New List(Of clsCardBook)
        Ds = New DataSet
        sql = "SELECT BookID FROM [GENRE_LIST] WHERE GenreCode='" & GenreId & "'"
        Adp = New SQLiteDataAdapter(sql, cn)
        Adp.Fill(Ds)
        Dim Ar() = (From el In Ds.Tables(0).Rows
                    Select el.item(0)).ToArray
        Dim stBooksID As String = "(" & String.Join(",", Ar) & ")"
        sql = "SELECT * FROM [BOOKS] WHERE [BookID] in " & stBooksID & " ORDER BY [Title]"
        Adp = New SQLiteDataAdapter(sql, cn)
        Adp.Fill(Ds, "Books")
        Ar = (From el In Ds.Tables("Books").Rows
              Where el.item("SeriesID") <> 0
              Select el.item("SeriesID")).ToArray
        If Ar.Length > 0 Then
            'ListOfSeries = New Dictionary(Of Integer, SerieInfo)
            Dim stSeriesID As String = "(" & String.Join(",", Ar) & ")"
            sql = "SELECT * FROM [SERIES] WHERE [SeriesID] in " & stSeriesID & " ORDER BY [SearchSeriesTitle]"
            Adp = New SQLiteDataAdapter(sql, cn)
            Adp.Fill(Ds, "Series")
            ListOfSeries = (From El In Ds.Tables("Series").Rows
                            Select New SerieInfo With {.SeriesID = El.Item("SeriesID"), .SeriesTitle = El.Item("SeriesTitle"), .SearchSeriesTitle = El.Item("SearchSeriesTitle")}).ToDictionary(Of Integer, SerieInfo)(Function(x) x.SeriesID, Function(x) x)
        End If
        For Each Dr As DataRow In Ds.Tables("Books").Rows
            ret.Add(GetCardBookByID(Dr))
        Next
        Return ret

    End Function
    Public Sub DeleteBook(Books As List(Of DeletingBooks), FlDelFie As Boolean)
        Try
            For Each Book In Books
                sql = "DELETE FROM [BOOKS] WHERE BookID=" & Book.ID & ";"
                sql &= "DELETE FROM GENRE_LIST  WHERE BookID=" & Book.ID & ";"
                sql &= "DELETE FROM AUTHOR_LIST  WHERE BookID=" & Book.ID & ";"
                cmd = New SQLiteCommand(sql, cn)
                cmd.ExecuteNonQuery()
                If FlDelFie Then
                    File.Delete(Book.FilePath)
                End If
            Next
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.DeleteBook")
            m_LastError = "DeleteBook" & vbCrLf & ex.Message
        End Try
    End Sub
    Public Function GetPath2Books() As String
        Dim Ret As String = String.Empty
        Dim rd As SQLiteDataReader
        Dim PrevFolder As String = String.Empty
        Try
            sql = "SELECT DISTINCT [Folder] FROM [BOOKS] WHERE [LoadBook]=0 Order BY [Folder]"
            cmd = New SQLiteCommand(sql, cn)
            rd = cmd.ExecuteReader
            While rd.Read
                If Ret.Length = 0 Then
                    Ret = rd(0)
                    PrevFolder = rd(0)
                End If
                If Not rd(0).ToString.StartsWith(PrevFolder) Then
                    Ret &= ";" & rd(0)
                    PrevFolder = rd(0)
                End If
            End While
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.GetPath2Books")
            m_LastError = "GetPath2Books" & vbCrLf & ex.Message
        End Try
        Return Ret
    End Function
    Public Sub SaveCatalogInfo(ci As CatalogInfo)
        m_LastError = String.Empty
        Try
            If cn Is Nothing OrElse cn.State <> ConnectionState.Open Then
                cn = New SQLiteConnection("Data Source=" & m_PthDB)
                cn.Open()
            End If
            sql = "DELETE FROM [CATALOGINFO];"
            sql = "INSERT INTO [CATALOGINFO] ("
            sql &= "[Version],"
            sql &= "[Name],"
            sql &= "[FileName],"
            sql &= "[Path2Books],"
            sql &= "[Description]) VALUES("
            sql &= "'" & ci.Version.Replace("'", "''") & "',"
            sql &= "'" & ci.Name.Replace("'", "''") & "',"
            sql &= "'" & ci.FileName.Replace("'", "''") & "',"
            sql &= "'" & ci.Path2Books.Replace("'", "''") & "',"
            sql &= "'" & ci.Description.Replace("'", "''") & "')"
            cmd = New SQLiteCommand(sql, cn)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.SaveCatalogInfo")
            Write2Log("SQL=" & sql, "clsCatalog.SaveCatalogInfo")
            m_LastError = "SaveCatalogInfo" & vbCrLf & ex.Message

        End Try
    End Sub

    Public Function GetListSearch(Genrecode As String, SeriesID As Object, AuthorID As Object, Title As String, Annotation As String, KeyWords As String) As List(Of clsCardBook)
        Dim ListSearch As List(Of clsCardBook) = Nothing
        m_LastError = ""
        Try
            If cn Is Nothing OrElse cn.State <> ConnectionState.Open Then
                cn = New SQLiteConnection("Data Source=" & m_PthDB)
                cn.Open()
            End If
            If (Genrecode IsNot Nothing) AndAlso Genrecode.Length > 0 Then
                ListSearch = GetListOfBooksByGenre(Genrecode)
            End If
            If (SeriesID IsNot Nothing) AndAlso SeriesID <> 0 Then
                If ListSearch Is Nothing Then
                    ListSearch = GetListOfBooksBySerie(SeriesID)
                Else
                    ListSearch = (From El In ListSearch
                        Where El.SeriesID = SeriesID
                        Select El).ToList
                End If
            End If
            If (AuthorID IsNot Nothing) AndAlso AuthorID <> 0 Then
                If ListSearch Is Nothing Then
                    ListSearch = GetListOfBooksByAuthor(AuthorID)
                Else
                    ListSearch = (From El In ListSearch
                                  From At In El.Authors
                                  Where At.AuthorID = AuthorID
                                  Select El).ToList
                End If
            End If
            If Title.Trim.Length > 0 Then
                If ListSearch Is Nothing Then
                    ListSearch = GetListOfBooksByTitle(Title)
                Else
                    ListSearch = (From El In ListSearch
                        Where El.Title.ToUpper.Contains(Title.ToUpper)
                        Select El).ToList
                End If
            End If
            If Annotation.Trim.Length > 0 Then
                If ListSearch Is Nothing Then
                    ListSearch = GetListOfBooksByAnnotation(Annotation)
                Else
                    ListSearch = (From El In ListSearch
                        Where El.Annotation.ToUpper.Contains(Annotation.ToUpper)
                        Select El).ToList
                End If
            End If
            If KeyWords.Trim.Length > 0 Then
                If ListSearch Is Nothing Then
                    ListSearch = GetListOfBooksByKeyWords(KeyWords)
                Else
                    Dim ar() As String = Split(KeyWords, ",")
                    ListSearch = (From El In ListSearch
                                  From Kw In ar.ToList
                                  Where El.KeyWords.ToUpper.Contains(Kw.ToUpper)
                        Select El).ToList
                End If
            End If

        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.GetListSearch")
            m_LastError = ex.Message
        End Try
        Return ListSearch
    End Function
    Private Function GetListOfBooksByTitle(Title As String) As List(Of clsCardBook)
        Dim ret As List(Of clsCardBook) = New List(Of clsCardBook)
        Ds = New DataSet
        sql = "SELECT * FROM [BOOKS] WHERE [SEARCHTITLE] Like '%" & Title.ToUpper & "%' ORDER BY [Title]"
        Adp = New SQLiteDataAdapter(sql, cn)
        Adp.Fill(Ds, "Books")
        For Each Dr As DataRow In Ds.Tables("Books").Rows
            ret.Add(GetCardBookByID(Dr))
        Next
        Return ret

    End Function
    Private Function GetListOfBooksByAnnotation(Annotation As String) As List(Of clsCardBook)
        Dim ret As List(Of clsCardBook) = New List(Of clsCardBook)
        Ds = New DataSet
        sql = "SELECT * FROM [BOOKS] WHERE [SEARCHANNOTATION] Like '%" & Annotation.ToUpper & "%' ORDER BY [Title]"
        Adp = New SQLiteDataAdapter(sql, cn)
        Adp.Fill(Ds, "Books")
        For Each Dr As DataRow In Ds.Tables("Books").Rows
            ret.Add(GetCardBookByID(Dr))
        Next
        Return ret

    End Function
    Private Function GetListOfBooksByKeyWords(KeyWords As String) As List(Of clsCardBook)

        Dim ret As List(Of clsCardBook) = New List(Of clsCardBook)
        Ds = New DataSet
        Dim Ar() As String = Split(KeyWords, ",")
        Dim StSearch As String = String.Empty
        For Each St As String In Ar
            StSearch &= " [SEARCHKEYWORDS] LIke '%" & St.ToUpper & "%' OR"
        Next
        If StSearch.EndsWith(" OR") Then
            StSearch = StSearch.Substring(0, StSearch.Length - 3)
        End If
        sql = "SELECT * FROM [BOOKS] WHERE " & StSearch & " ORDER BY [Title]"
        Adp = New SQLiteDataAdapter(sql, cn)
        Adp.Fill(Ds, "Books")
        For Each Dr As DataRow In Ds.Tables("Books").Rows
            ret.Add(GetCardBookByID(Dr))
        Next
        Return ret

    End Function
    Public Sub RefreshGenres(ByRef lblStatus As ToolStripStatusLabel)
        lblStatus.Text = "Refresh Genres"
        My.Application.DoEvents()
        Dim Cl As Genres = New Genres()
        Try
            If cn Is Nothing OrElse cn.State <> ConnectionState.Open Then
                cn = New SQLiteConnection("Data Source=" & m_PthDB)
                cn.Open()
            End If
            sql = "DELETE FROM GENRES"
            cmd = New SQLiteCommand(sql, cn)
            cmd.ExecuteNonQuery()
            For Each gr As Genre In Cl.GenresList
                sql = "INSERT INTO [GENRES] VALUES('" & gr.GenreCode & "','" & gr.ParentCode & "','" & gr.FB2Code & "','" & gr.GenreAlias.Replace("'", "''") & "')"
                cmd = New SQLiteCommand(sql, cn)
                cmd.ExecuteNonQuery()
            Next
            clsGenres = New Genres(cn)
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.RefreshGenres")
            m_LastError = "RefreshGenres" & vbCrLf & ex.Message
        End Try
        lblStatus.Text = " "
        My.Application.DoEvents()
    End Sub
    Public Sub RefreshCatalog(CatInfo As CatalogInfo, ByRef AddBook As Integer, ByRef DelBook As Integer, ByRef lblStatus As ToolStripStatusLabel)
        RefreshGenres(lblStatus)
        lblStatus.Text = "Get Refresh Info"
        My.Application.DoEvents()
        m_NumAddBooks = 0
        Dim colFi As Dictionary(Of String, Integer) = New Dictionary(Of String, Integer)
        Dim RefreshBook As List(Of String) = New List(Of String)
        Dim DeletedBooks As List(Of DeletingBooks) = New List(Of DeletingBooks)
        Dim dcl As DeletingBooks = Nothing
        Try
            If cn Is Nothing OrElse cn.State <> ConnectionState.Open Then
                cn = New SQLiteConnection("Data Source=" & m_PthDB)
                cn.Open()
            End If

            Dim arPath() As String = CatInfo.Path2Books.Split(";")
            For Each Pth In arPath
                If Pth.Trim.Length > 0 AndAlso Directory.Exists(Pth.Trim) Then
                    Dim DI As DirectoryInfo = New DirectoryInfo(Pth)
                    Dim arFi() As FileInfo = DI.GetFiles("*", SearchOption.AllDirectories).Where(Function(x) Config.Formats.ToLower.Contains(x.Extension.ToLower) Or x.Extension.ToLower = ".zip").ToArray
                    For Each Fi As FileInfo In arFi
                        colFi.Add(Fi.FullName, 0)
                    Next
                End If
            Next
            sql = "SELECT BookID,LoadBook,Folder,Filename From BOOKS"
            cmd = New SQLiteCommand(sql, cn)
            Dim rd As SQLiteDataReader = cmd.ExecuteReader
            While rd.Read
                If rd("LoadBook") = 0 Then
                    If colFi.ContainsKey(Path.Combine(rd("Folder"), rd("FileName"))) Then
                        colFi.Remove(Path.Combine(rd("Folder"), rd("FileName")))
                        RefreshBook.Add(Path.Combine(rd("Folder"), rd("FileName")))
                    Else
                        dcl = New DeletingBooks("", rd("BookID"))
                        dcl.FilePath = Path.Combine(rd("Folder"), rd("FileName"))
                        DeletedBooks.Add(dcl)
                    End If
                Else
                    If Not File.Exists(Path.Combine(rd("Folder"), rd("FileName"))) Then
                        dcl = New DeletingBooks("", rd("BookID"))
                        dcl.FilePath = Path.Combine(rd("Folder"), rd("FileName"))
                        DeletedBooks.Add(dcl)
                    End If
                End If
            End While
            lblStatus.Text = "Delete Books"
            My.Application.DoEvents()
            Me.DeleteBook(DeletedBooks, False)
            Me.RefreshBooks(RefreshBook, lblStatus)
            For Each st In colFi.Keys
                Dim fi As FileInfo = New FileInfo(st)
                If fi.Extension.ToLower = ".fb2" Then
                    Me.m_AddFb2Book(st, fi)
                    m_NumAddBooks += 1
                ElseIf fi.Extension.ToLower = ".epub" Then
                    Me.m_AddEpubBook(st, fi)
                    m_NumAddBooks += 1
                ElseIf fi.Extension.ToLower = ".zip" Then
                    Me.m_AddBookFromZip(st, fi)
                    m_NumAddBooks += 1
                End If
                lblStatus.Text = "Refresh Catalog Add Book " & m_NumAddBooks & " From " & colFi.Count
                My.Application.DoEvents()
            Next
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.RefreshCatalog")
            m_LastError = "RefreshCatalog" & vbCrLf & ex.Message
        End Try
        AddBook = m_NumAddBooks
        DelBook = DeletedBooks.Count
    End Sub
    Private Sub RefreshBooks(pthBooks As List(Of String), ByRef lblStatus As ToolStripStatusLabel)
        Dim cntBook As Integer = 0
        For Each st In pthBooks
            Dim fi As FileInfo = New FileInfo(st)
            If fi.Extension.ToLower = ".fb2" Then
                cntBook += Me.m_RefreshFb2Book(fi)
            ElseIf fi.Extension.ToLower = ".epub" Then
                cntBook += Me.m_RefreshEpubBook(fi)
            ElseIf fi.Extension.ToLower = ".zip" Then
                cntBook += Me.m_RefreshBookFromZip(fi)
            End If
            lblStatus.Text = "Refresh Book " & cntBook & " from " & pthBooks.Count
            My.Application.DoEvents()
        Next
    End Sub
    Private Function m_RefreshFb2Book(fi As FileInfo) As Integer
        Try
            If cn Is Nothing OrElse cn.State <> ConnectionState.Open Then
                cn = New SQLiteConnection("Data Source=" & m_PthDB)
                cn.Open()
            End If
            Dim cl As clsCardBookFb2 = New clsCardBookFb2(fi.FullName, fi)
            Dim BookGenres As List(Of String) = cl.Genres
            If BookGenres.Count > 0 Then
                sql = "SELECT BookID from BOOKS Where Folder='" & fi.DirectoryName & "' AND FileName='" & fi.Name & "'"
                cmd = New SQLiteCommand(sql, cn)
                Dim BookID = cmd.ExecuteScalar
                sql = "DELETE FROM GENRE_LIST WHERE BookID=" & BookID.ToString
                cmd = New SQLiteCommand(sql, cn)
                cmd.ExecuteNonQuery()
                For Each GCode As String In BookGenres
                    sql = "INSERT INTO GENRE_LIST VALUES('" & GCode & "'," & BookID.ToString & ")"
                    cmd = New SQLiteCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Next
            End If
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.m_RefreshFb2Book")
            m_LastError = "m_RefreshFb2Book" & vbCrLf & ex.Message
        End Try
        Return 1
    End Function
    Private Function m_RefreshEpubBook(fi As FileInfo) As Integer
        Try
            If cn Is Nothing OrElse cn.State <> ConnectionState.Open Then
                cn = New SQLiteConnection("Data Source=" & m_PthDB)
                cn.Open()
            End If
            Dim cl As clsCardBookEpub = New clsCardBookEpub(fi.FullName)
            Dim BookGenres As List(Of String) = cl.Genres
            If BookGenres.Count > 0 Then
                sql = "SELECT BookID from BOOKS Where Folder='" & fi.DirectoryName & "' AND FileName='" & fi.Name & "'"
                cmd = New SQLiteCommand(sql, cn)
                Dim BookID = cmd.ExecuteScalar
                sql = "DELETE FROM GENRE_LIST WHERE BookID=" & BookID.ToString
                cmd = New SQLiteCommand(sql, cn)
                cmd.ExecuteNonQuery()
                For Each GCode As String In BookGenres
                    sql = "INSERT INTO GENRE_LIST VALUES('" & GCode & "'," & BookID.ToString & ")"
                    cmd = New SQLiteCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Next
            End If
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.m_RefreshFb2Book")
            m_LastError = "m_RefreshFb2Book" & vbCrLf & ex.Message
        End Try
        Return 1
    End Function
    Private Function m_RefreshBookFromZip(fi As FileInfo) As Integer
        Return 1
    End Function
    Public Function EditBookInfo(book As clsCardBook, FlagEditAuth As Boolean, FlagEditSeries As Boolean, lstGenres As List(Of String)) As clsCardBook
        Try
            If cn Is Nothing OrElse cn.State <> ConnectionState.Open Then
                cn = New SQLiteConnection("Data Source=" & m_PthDB)
                cn.Open()
            End If
            sql = "UPDATE BOOKS SET Title='" & book.Title & "',SeriesID=" & book.SeriesID.ToString & ",Annotation='" & book.Annotation & "',"
            sql &= "Publisher='" & book.Publisher & "',Keywords='" & book.KeyWords & "' Where BookID=" & book.BookID.ToString
            cmd = New SQLiteCommand(sql, cn)
            cmd.ExecuteNonQuery()
            If FlagEditAuth Then
                sql = "DELETE From [AUTHOR_LIST] WHERE BookID=" & book.BookID.ToString
                cmd = New SQLiteCommand(sql, cn)
                cmd.ExecuteNonQuery()
                For Each Auth As Author In book.Authors
                    sql = "INSERT INTO [AUTHOR_LIST] VALUES(" & Auth.AuthorID.ToString & "," & book.BookID.ToString & ")"
                    cmd = New SQLiteCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Next
            End If
            If lstGenres IsNot Nothing Then
                sql = "DELETE From [GENRE_LIST] WHERE BookID=" & book.BookID.ToString
                cmd = New SQLiteCommand(sql, cn)
                cmd.ExecuteNonQuery()
                For Each Gn As String In lstGenres
                    sql = "INSERT INTO [GENRE_LIST] VALUES('" & Gn & "'," & book.BookID.ToString & ")"
                    cmd = New SQLiteCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Next
            End If
            Return GetBookByID(book.BookID)
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.EditBookInfo")
            m_LastError = "RefreshCatalog" & vbCrLf & ex.Message
            Return Nothing
        End Try
    End Function
    Public Function GetCatalogInfoFromDB() As CatalogInfo
        Dim ci As CatalogInfo = New CatalogInfo()
        sql = String.Empty
        Try
            If cn Is Nothing OrElse cn.State <> ConnectionState.Open Then
                cn = New SQLiteConnection("Data Source=" & m_PthDB)
                cn.Open()
            End If
            sql = "SELECT Count(*) FROM sqlite_master WHERE type='table' AND name='CATALOGINFO'"
            cmd = New SQLiteCommand(sql, Cn)
            If cmd.ExecuteScalar() > 0 Then
                sql = "SELECT * FROM [CATALOGINFO]"
                cmd = New SQLiteCommand(sql, Cn)
                Dim rd As SQLiteDataReader = cmd.ExecuteReader
                If rd.Read() Then
                    ci.Version = rd("Version")
                    ci.Description = rd("Description")
                    ci.FileName = rd("FileName")
                    ci.Name = rd("Name")
                    'ci.Path2Books = rd("Path2Books")
                End If

            End If
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.GetCatalogInfoFromDB")
            m_LastError = "GetCatalogInfoFromDB" & vbCrLf & ex.Message
        End Try
        Return ci
    End Function
    Public Sub EditListOfAuthors(FlagEdit As Integer, lst As Object)
        'FlagEdit - 0-Add,1-Edit,2-Merge,3-Delete
        Try
            If cn Is Nothing OrElse cn.State <> ConnectionState.Open Then
                cn = New SQLiteConnection("Data Source=" & m_PthDB)
                cn.Open()
            End If
            Select Case FlagEdit
                Case 0 'Add
                    'Insert into authors (Lastname,FirstName,MiddleName,SearchName) values('aa','bb','cc','AA BB CC');
                    sql = String.Empty
                    For Each El As Author In DirectCast(lst, List(Of Author))
                        sql &= "INSERT INTO AUTHORS (Lastname,FirstName,MiddleName,SearchName) VALUES("
                        sql &= "'" & El.LastName.Replace("'", "''") & "',"
                        sql &= "'" & El.FirstName.Replace("'", "''") & "',"
                        sql &= "'" & El.MiddleName.Replace("'", "''") & "',"
                        sql &= "'" & El.FullName.Replace("'", "''").ToUpper & "');"
                    Next
                    cmd = New SQLiteCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Case 1 'Edit
                    sql = String.Empty
                    For Each El As Author In DirectCast(lst, List(Of Author))
                        sql &= "UPDATE AUTHORS SET "
                        sql &= "LastName='" & El.LastName.Replace("'", "''") & "',"
                        sql &= "FirstName='" & El.FirstName.Replace("'", "''") & "',"
                        sql &= "MiddleName='" & El.MiddleName.Replace("'", "''") & "',"
                        sql &= "SearchName='" & El.FullName.Replace("'", "''").ToUpper & "' WHERE AuthorID=" & El.AuthorID.ToString & ";"
                    Next
                    cmd = New SQLiteCommand(sql, cn)
                    cmd.ExecuteNonQuery()

                Case 2 'Merge

                    For Each El As MergeAuthors In DirectCast(lst, List(Of MergeAuthors))
                        sql = String.Empty
                        Dim Ids As String = String.Empty
                        For Each at As Author In El.ListOfMerge
                            Ids &= at.AuthorID.ToString & ","
                        Next
                        If Ids.EndsWith(",") Then
                            Ids = Ids.Substring(0, Ids.Length - 1)
                        End If
                        sql &= "UPDATE AUTHORS SET "
                        sql &= "LastName='" & El.Auth.LastName.Replace("'", "''") & "',"
                        sql &= "FirstName='" & El.Auth.FirstName.Replace("'", "''") & "',"
                        sql &= "MiddleName='" & El.Auth.MiddleName.Replace("'", "''") & "',"
                        sql &= "SearchName='" & El.Auth.FullName.Replace("'", "''").ToUpper & "' WHERE AuthorID=" & El.Auth.AuthorID.ToString & ";"
                        sql &= "DELETE FROM AUTHORS WHERE [AuthorID] in " & "(" & Ids & ");"
                        sql &= "UPDATE AUTHOR_LIST SET AuthorID=" & El.Auth.AuthorID & " WHERE [AuthorID] in " & "(" & Ids & ");"
                        cmd = New SQLiteCommand(sql, cn)
                        cmd.ExecuteNonQuery()
                    Next

                Case 3 'Delete
                    Dim Ids As String = String.Empty
                    For Each El As Author In DirectCast(lst, List(Of Author))
                        Ids &= El.AuthorID.ToString & ","
                    Next
                    If Ids.EndsWith(",") Then
                        Ids = Ids.Substring(0, Ids.Length - 1)
                    End If
                    If Ids.Length > 0 Then
                        sql = "DELETE FROM AUTHORS WHERE [AuthorID] in " & "(" & Ids & ");"
                        sql &= "DELETE FROM AUTHOR_LIST WHERE [AuthorID] in " & "(" & Ids & ");"
                        cmd = New SQLiteCommand(sql, cn)
                        cmd.ExecuteNonQuery()
                    End If

            End Select
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.EditListOfAuthors" & " (" & FlagEdit.ToString & ")")
            Write2Log("sql=" & sql, "")
            m_LastError = "EditListOfAuthors" & vbCrLf & ex.Message
        End Try

    End Sub
    Public Sub EditListOfSeries(FlagEdit As Integer, lst As Object)
        'FlagEdit - 0-Add,1-Edit,2-Merge,3-Delete
        Try
            If cn Is Nothing OrElse cn.State <> ConnectionState.Open Then
                cn = New SQLiteConnection("Data Source=" & m_PthDB)
                cn.Open()
            End If
            Select Case FlagEdit
                Case 0 'Add
                    'Insert into Series (SeriesTitle,SearchSeriesTitle) values('aa','AA');
                    sql = String.Empty
                    For Each El As SerieInfo In DirectCast(lst, List(Of SerieInfo))
                        sql &= "INSERT INTO SERIES (SeriesTitle,SearchSeriesTitle) VALUES("
                        sql &= "'" & El.SeriesTitle.Replace("'", "''") & "',"
                        sql &= "'" & El.SeriesTitle.Replace("'", "''").ToUpper & "');"
                    Next
                    cmd = New SQLiteCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Case 1 'Edit
                    sql = String.Empty
                    For Each El As SerieInfo In DirectCast(lst, List(Of SerieInfo))
                        sql &= "UPDATE SERIES SET "
                        sql &= "SeriesTitle='" & El.SeriesTitle.Replace("'", "''") & "',"
                        sql &= "SearchSeriesTitle='" & El.SearchSeriesTitle.Replace("'", "''") & "'"
                        sql &= " WHERE SeriesID=" & El.SeriesID.ToString & ";"
                    Next
                    cmd = New SQLiteCommand(sql, cn)
                    cmd.ExecuteNonQuery()
                Case 2 'Merge
                    For Each El As MergeSerieInfo In DirectCast(lst, List(Of MergeSerieInfo))
                        Dim Ids As String = String.Empty
                        sql = String.Empty
                        For Each at As SerieInfo In El.ListOfMerge
                            Ids &= at.SeriesID.ToString & ","
                        Next
                        If Ids.EndsWith(",") Then
                            Ids = Ids.Substring(0, Ids.Length - 1)
                        End If
                        sql &= "UPDATE SERIES SET "
                        sql &= "SeriesTitle='" & El.Serie.SeriesTitle.Replace("'", "''") & "',"
                        sql &= "SearchSeriesTitle='" & El.Serie.SearchSeriesTitle.Replace("'", "''") & "'"
                        sql &= " WHERE SeriesID=" & El.Serie.SeriesID.ToString & ";"
                        sql &= "DELETE FROM SERIES WHERE [SeriesID] in " & "(" & Ids & ");"
                        sql &= "UPDATE BOOKS SET SeriesID=" & El.Serie.SeriesID & " WHERE [SeriesID] in " & "(" & Ids & ");"
                        cmd = New SQLiteCommand(sql, cn)
                        cmd.ExecuteNonQuery()
                    Next
                Case 3 'delete
                    Dim Ids As String = String.Empty
                    For Each El As SerieInfo In DirectCast(lst, List(Of SerieInfo))
                        Ids &= El.SeriesID.ToString & ","
                    Next
                    If Ids.EndsWith(",") Then
                        Ids = Ids.Substring(0, Ids.Length - 1)
                    End If
                    If Ids.Length > 0 Then
                        sql = "DELETE FROM SERIES WHERE [SeriesID] in " & "(" & Ids & ");"
                        sql &= "UPDATE BOOKS SET SeriesID=0 WHERE [SeriesID] in " & "(" & Ids & ");"
                        cmd = New SQLiteCommand(sql, cn)
                        cmd.ExecuteNonQuery()
                    End If

            End Select
        Catch ex As Exception
            Write2Log(ex.Message, "clsCatalog.EditListOfSeries" & " (" & FlagEdit.ToString & ")")
            Write2Log("sql=" & sql, "")
            m_LastError = "EditListOfSeries" & vbCrLf & ex.Message
        End Try

    End Sub
End Class
