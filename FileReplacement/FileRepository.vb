'monostate pattern

Public Class FileRepository

    Private Shared _repository As FileRepositoryImpl

    Shared Sub New()
        _repository = New FileRepositoryImpl()
    End Sub

    Public Shared Sub AddPhysicalFallbacks(ByVal ParamArray paths() As String)
        _repository.AddPhysicalFallbacks(paths)
    End Sub

    Public Shared Function GetFileFromDisk(ByVal path As String) As FileDescriptor
        Return _repository.GetFileFromDisk(path)
    End Function

    Public Shared Function GetFileFromDatabase(ByVal reader As IDataReader) As FileDescriptor
        Return _repository.GetFileFromDatabase(reader)
    End Function

End Class
