Imports System.Data.SQLite
Imports System.IO
Imports System.Collections.Generic

Public Class clsCardBook
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
    Private m_Catalog As String
    Public Sub New()
        MyBase.New()
    End Sub

End Class
