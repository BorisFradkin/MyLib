
' TODO Edit Genres - редактировать дерево жанров конкретного каталога , толко таблица  Genres
' TODO Help
' TODO settings добавить язык интерфейса и сообщений
' TODO В BookInfo добавить высветку типа файла 
' TODO Сформировать файлы сообщений и заголовков.
' TODO Форма About


Public Class Author
    Public Property AuthorID As Integer
    Public Property FirstName As String
    Public Property MiddleName As String
    Public Property LastName As String
    Public Property NumBooks As Integer
    Public Overrides Function ToString() As String
        Return LastName.Trim & " " & FirstName.Trim & " " & MiddleName.Trim
    End Function
    Public ReadOnly Property FullName() As String
        Get
            FullName = LastName.Trim & " " & FirstName.Trim & " " & MiddleName.Trim
        End Get
    End Property

    Public ReadOnly Property ToShow() As String
        Get
            ToShow = LastName.Trim & " " & If(FirstName.Length > 0, FirstName.Trim.Substring(0, 1) & ".", "") & If(MiddleName.Length > 0, MiddleName.Trim.Substring(0, 1) & ".", "") '& " (" & NumBooks.ToString & ")"
        End Get
    End Property
    Public ReadOnly Property ID() As Integer
        Get
            ID = AuthorID
        End Get
    End Property
End Class
Public Class MergeAuthors
    Public Property Auth As Author = New Author
    Public ListOfMerge As List(Of Author) = New List(Of Author)
    Public Sub Add(Auth As Author)
        ListOfMerge.Add(Auth)
    End Sub
End Class
Public Class CatalogInfo
    Public Property Version() As String = My.Application.Info.Version.ToString
    Public Property Name() As String
    Public Property FileName() As String
    Public Property Path2Books() As String
    Public Property Description() As String
End Class

Public Class SerieInfo
    Public Property SeriesID As Integer
    Public Property SeriesTitle As String
    Public Property SearchSeriesTitle As String
End Class

Public Class MergeSerieInfo
    Public Property Serie As SerieInfo = New SerieInfo
    Public Property ListOfMerge As List(Of SerieInfo) = New List(Of SerieInfo)
    Public Sub Add(cSerie As SerieInfo)
        ListOfMerge.Add(cSerie)
    End Sub
End Class

Public Class GenreInfo
    Public Property GenreCode As String
    Public Property GenreAllias As String
    Public Property TrvNode As TreeNode
End Class

Public Class DeletingBooks
    Public Property Tit As String
    Public Property ID As Integer
    Public Property FilePath As String
    Public Sub New(t As String, n As Integer)
        Tit = t
        ID = n
    End Sub
End Class

Module mdlMyLib
    Public Config As clsConfig = New clsConfig
    Public Catalog_Info As Dictionary(Of String, CatalogInfo) = New Dictionary(Of String, CatalogInfo)
    Public CurrentCatalog As clsCatalog = Nothing
    Public CurrentCatalogInfo As CatalogInfo = Nothing
    Public ListOfAuthors As List(Of Author) = New List(Of Author)
    Public ListOfSeries As List(Of SerieInfo) = New List(Of SerieInfo)
    Public stAlphabet As String = "*АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЭЮЯ"

    Public ListOfAddAuth As List(Of Author)
    Public ListOfEditAuth As List(Of Author)
    Public ListOfDeleteAuth As List(Of Author)
    Public ListOfMergeAuth As List(Of MergeAuthors)

    Public ListOfAddSeries = New List(Of SerieInfo)
    Public ListOfDeleteSeries = New List(Of SerieInfo)
    Public ListOfMergeSeries = New List(Of MergeSerieInfo)
    Public ListOfEditSeries = New List(Of SerieInfo)


    Public Sub FillListOfAuthors()
        ListOfAuthors = New List(Of Author)
        If CurrentCatalog IsNot Nothing Then
            ListOfAuthors = CurrentCatalog.GetListOfAthors()
        End If

    End Sub

    Public Sub FillListOfSeries()
        ListOfSeries = New List(Of SerieInfo)
        If CurrentCatalog IsNot Nothing Then
            ListOfSeries = CurrentCatalog.GetListOfSeries()
            ListOfSeries.Add(New SerieInfo With {.SeriesID = 0, .SeriesTitle = "Вне серий", .SearchSeriesTitle = "Вне серий".ToUpper})
        End If

    End Sub
    Public Sub editAuthorsList()
        'Public ListOfAddAuth As List(Of Author)
        'Public ListOfEditAuth As List(Of Author)
        'Public ListOfDeleteAuth As List(Of Author)
        'Public ListOfMergeAuth As List(Of MergeAuthors)
        If (ListOfAddAuth IsNot Nothing) AndAlso (ListOfAddAuth.Count > 0) Then
            CurrentCatalog.EditListOfAuthors(0, ListOfAddAuth)
        End If
        If (ListOfEditAuth IsNot Nothing) AndAlso (ListOfEditAuth.Count > 0) Then
            CurrentCatalog.EditListOfAuthors(1, ListOfEditAuth)
        End If
        If (ListOfMergeAuth IsNot Nothing) AndAlso (ListOfMergeAuth.Count > 0) Then
            CurrentCatalog.EditListOfAuthors(2, ListOfMergeAuth)
        End If
        If (ListOfDeleteAuth IsNot Nothing) AndAlso (ListOfDeleteAuth.Count > 0) Then
            CurrentCatalog.EditListOfAuthors(3, ListOfDeleteAuth)
        End If
        FillListOfAuthors()
    End Sub

    Public Sub editSeries()
        'Public ListOfAddSeries = New List(Of SerieInfo)
        'Public ListOfDeleteSeries = New List(Of SerieInfo)
        'Public ListOfMergeSeries = New List(Of MergeSerieInfo)
        'Public ListOfEditSeries = New List(Of SerieInfo)
        If (ListOfAddSeries IsNot Nothing) AndAlso (ListOfAddSeries.Count > 0) Then
            CurrentCatalog.EditListOfSeries(0, ListOfAddSeries)
        End If
        If (ListOfEditSeries IsNot Nothing) AndAlso (ListOfEditSeries.Count > 0) Then
            CurrentCatalog.EditListOfSeries(1, ListOfEditSeries)
        End If
        If (ListOfMergeSeries IsNot Nothing) AndAlso (ListOfMergeSeries.Count > 0) Then
            CurrentCatalog.EditListOfSeries(2, ListOfMergeSeries)
        End If
        If (ListOfDeleteSeries IsNot Nothing) AndAlso (ListOfDeleteSeries.Count > 0) Then
            CurrentCatalog.EditListOfSeries(3, ListOfDeleteSeries)
        End If
        FillListOfSeries()

    End Sub
    Public Sub editGenres()

    End Sub
End Module
