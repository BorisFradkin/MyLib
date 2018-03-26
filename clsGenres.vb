Imports System.Data.SQLite
Imports System.IO

Public Class Genre
    Property GenreCode() As String
    Property ParentCode() As String
    Property FB2Code() As String
    Property GenreAlias() As String
    Property EditCode() As Integer '0-no edit,1-add,2-modify alias,3-delete

    Sub New(Gc As String, Pc As String, Fb2c As String, At As String)
        GenreCode = Gc
        ParentCode = Pc
        FB2Code = Fb2c
        GenreAlias = At
        EditCode = 0
    End Sub
    Function Contains(Txt As String) As Boolean
        Return (GenreAlias.ToLower.Contains(Txt.ToLower))
    End Function
    Function GetCodeMinor() As Integer
        Dim ret As Integer = 0
        If GenreCode.Length > 0 Then
            Dim Ar() As String = GenreCode.Split(".")
            Integer.TryParse(Ar(2), ret)
        End If
        Return ret
    End Function
End Class
Public Class Genres
    Public GList As List(Of Genre)
    Public ReadOnly Property GenresList As List(Of Genre)
        Get
            GenresList = GList
        End Get
    End Property
    Public Sub New(cn As SQLiteConnection)
        GList = New List(Of Genre)
        Dim cmd As SQLiteCommand = New SQLiteCommand("SELECT * FROM GENRES", cn)
        Dim rd As SQLiteDataReader = cmd.ExecuteReader
        While rd.Read
            Me.Add(rd("GenreCode"), rd("ParentCode"), rd("FB2Code"), rd("GenreAlias"))
        End While
        rd.Close()
    End Sub
    Public Sub New()
        GList = New List(Of Genre)()
        Dim ArGenre() As String = Split(My.Resources.Genres, ControlChars.CrLf)
        Dim ar() As String = {}
        For Each st In ArGenre
            ar = st.Split(",")
            If ar.Length >= 4 Then
                For i As Integer = 4 To ar.Length - 1
                    ar(3) &= ", " & ar(i).Trim
                Next
                Me.Add(ar(0).Trim, ar(1).Trim, ar(2).ToLower.Trim, ar(3).Trim)
            End If
        Next
        'ToDo Дополнить жанрами из файлов .grn in ApplicationPath
        'Структура строки .grn файла
        'parentCode;Fb2Code;Alias Genre
        'Sample:
        '0.2;det_maniac;Маньяки
        '0.99;литература 19века;Литература XIX Века
        Dim Di As DirectoryInfo = New DirectoryInfo(Application.StartupPath)
        Dim Fi() As FileInfo = Di.GetFiles("*.grn", SearchOption.TopDirectoryOnly)
        Dim sr As StreamReader = Nothing
        For Each Fl In Fi
            sr = New StreamReader(Fl.FullName)
            While Not sr.EndOfStream
                Dim st As String = sr.ReadLine
                If Not st.Trim.StartsWith(";") Then
                    ar = st.Trim.Split(";")
                    If ar.Length >= 3 Then
                        If ar(1).Trim.Length = 0 Then
                            If Not IsParentCodeExists(ar(0).Trim) Then
                                GList.Add(New Genre(ar(0), "0", "", ar(2)))
                            End If
                        Else
                            If Not IsFB2CodeExists(ar(1)) Then
                                Dim cd As Integer = Me.GetLastCode(ar(0)) + 1
                                GList.Add(New Genre(ar(0) & "." & cd.ToString, ar(0), ar(1).Trim.ToLower, ar(2)))
                            End If
                        End If
                    End If
                End If
            End While
        Next
    End Sub
    Public Function GetLastCode(pCode As String) As Integer
        Dim q As List(Of Genre) = (From el As Genre In GList
                                   Where el.ParentCode = pCode
                                   Order By el.GetCodeMinor Descending).ToList()
        If q.Count > 0 Then
            Return q(0).GetCodeMinor
        Else
            Return -1
        End If
    End Function
    Public Sub Add(gCode As String, pCode As String, Fb2Code As String, Txt As String)
        GList.Add(New Genre(gCode, pCode, Fb2Code, Txt))
    End Sub
    Private Function IsParentCodeExists(pCode As String) As Boolean
        For Each gr As Genre In GList
            If gr.ParentCode = pCode Then
                Return True
            End If
        Next
        Return False
    End Function
    Private Function IsFB2CodeExists(fCode As String) As Boolean
        For Each gr As Genre In GList
            If gr.FB2Code = fCode.Trim.ToLower Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Function GetGenreCode(fb2Code As String) As String
        Dim Gr As List(Of Genre) = (From el In GList
                                    Where el.FB2Code = fb2Code.ToLower
                                    Select el)
        If Gr.Count = 0 Then
            Return "nan"
        Else
            Return Gr(0).GenreCode
        End If
    End Function
End Class
