Imports System.IO

Public Class clsConfig
    Private xDoc As XDocument = Nothing
    Public Sub New()
        If Not File.Exists(Path.Combine(Application.StartupPath, "Config.xml")) Then
            Dim xEl As String = "<Setting>" &
                                      "<CatalogBase></CatalogBase>" &
                                      "<LogFile>CatalogsBook.txt</LogFile>" &
                                      "<TempPath></TempPath>" &
                                      "<Catalogs></Catalogs>" &
                                      "<Formats>fb2</Formats>" &
                                      "<LookZip>True</LookZip>" &
                                      "<Subfolders>True</Subfolders>" &
                                      "<PrefixFileName>HomeLib_</PrefixFileName>" &
                                      "<PostfixFileName>.cb</PostfixFileName>" &
                                      "<List2Read></List2Read>" &
                                      "<Reader></Reader>" &
                                      "<ShowSeriesOnTree>True</ShowSeriesOnTree>" &
                                      "<InterfaceLanguage>RU</InterfaceLanguage>" &
                                      "<GenresFromFiles>True</GenresFromFiles>" &
                                  "</Setting>"
            xDoc = XDocument.Parse(xEl)
            xDoc.Save(Path.Combine(Application.StartupPath, "Config.xml"))
        Else
            xDoc = XDocument.Load(Path.Combine(Application.StartupPath, "Config.xml"))
        End If
    End Sub
    Private Function GetCatalogsSting() As String
        Dim Ret As String = String.Empty
        If Config.Catalogs IsNot Nothing Then
            For Each St In Config.Catalogs
                Ret &= St & Chr(255)
            Next
        End If
        Return Ret
    End Function
    Public Property CatalogBase() As String
        Get
            CatalogBase = xDoc.Descendants("CatalogBase").Value
        End Get
        Set(value As String)
            xDoc.Descendants("CatalogBase").Value = value
        End Set
    End Property
    Public Property LogFile() As String
        Get
            LogFile = xDoc.Descendants("LogFile").Value
        End Get
        Set(value As String)
            xDoc.Descendants("LogFile").Value = value
        End Set
    End Property
    Public Property TempPath() As String
        Get
            TempPath = xDoc.Descendants("TempPath").Value
        End Get
        Set(value As String)
            xDoc.Descendants("TempPath").Value = value
        End Set
    End Property
    Public Property Catalogs() As String
        Get
            Catalogs = xDoc.Descendants("Catalogs").Value
        End Get
        Set(value As String)
            xDoc.Descendants("Catalogs").Value = value
        End Set
    End Property
    Public Property Formats() As String
        Get
            Formats = xDoc.Descendants("Formats").Value
        End Get
        Set(value As String)
            xDoc.Descendants("Formats").Value = value
        End Set
    End Property
    Public Property LookZip() As Boolean
        Get
            LookZip = Boolean.Parse(xDoc.Descendants("LookZip").Value)
        End Get
        Set(value As Boolean)
            xDoc.Descendants("LookZip").Value = value.ToString
        End Set
    End Property
    Public Property Subfolders() As Boolean
        Get
            Subfolders = Boolean.Parse(xDoc.Descendants("Subfolders").Value)
        End Get
        Set(value As Boolean)
            xDoc.Descendants("Subfolders").Value = value.ToString
        End Set
    End Property
    Public Property PrefixFileName() As String
        Get
            PrefixFileName = xDoc.Descendants("PrefixFileName").Value
        End Get
        Set(value As String)
            xDoc.Descendants("PrefixFileName").Value = value
        End Set
    End Property
    Public Property PostfixFileName() As String
        Get
            PostfixFileName = xDoc.Descendants("PostfixFileName").Value
        End Get
        Set(value As String)
            xDoc.Descendants("PostfixFileName").Value = value
        End Set
    End Property
    Public Property List2Read() As String
        Get
            List2Read = xDoc.Descendants("List2Read").Value
        End Get
        Set(value As String)
            xDoc.Descendants("List2Read").Value = value
        End Set
    End Property
    Public Property Reader() As String
        Get
            Reader = xDoc.Descendants("Reader").Value
        End Get
        Set(value As String)
            xDoc.Descendants("Reader").Value = value
        End Set
    End Property
    Public Property ShowSeriesOnTree() As Boolean
        Get
            ShowSeriesOnTree = Boolean.Parse(xDoc.Descendants("ShowSeriesOnTree").Value)
        End Get
        Set(value As Boolean)
            xDoc.Descendants("ShowSeriesOnTree").Value = value.ToString
        End Set
    End Property
    Public Property InterfaceLanguage() As String
        Get
            InterfaceLanguage = xDoc.Descendants("InterfaceLanguage").Value
        End Get
        Set(value As String)
            xDoc.Descendants("InterfaceLanguage").Value = value
        End Set
    End Property
    Public Property GenresFromFiles() As Boolean
        Get
            GenresFromFiles = Boolean.Parse(xDoc.Descendants("GenresFromFiles").Value)
        End Get
        Set(value As Boolean)
            xDoc.Descendants("GenresFromFiles").Value = value.ToString
        End Set
    End Property
    Public Sub Save()
        xDoc.Save(Path.Combine(Application.StartupPath, "Config.xml"))
    End Sub

End Class
