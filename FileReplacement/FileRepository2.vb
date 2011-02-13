'monostate pattern

Public Class FileRepository2

    Private Shared _repository As FileRepositoryImpl

    Shared Sub New()
        _repository = New FileRepositoryImpl()
    End Sub

    Public Function GetFileFromDisk(ByVal path As String) As FileDescriptor
        Return _repository.GetFileFromDisk(path)
    End Function

    Public Function GetFileFromDatabase(ByVal reader As IDataReader) As FileDescriptor
        Return _repository.GetFileFromDatabase(reader)
    End Function

End Class
