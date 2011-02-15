
Friend Class FileRepositoryImpl

    Private ReadOnly _physicalRepository As PhysicalFile.PhysicalRepository

    Public Sub New()
        _physicalRepository = New PhysicalFile.PhysicalRepository()
    End Sub


    '
    ' Physical redirects
    '
    Public Sub AddPhysicalFallbacks(ByVal ParamArray paths() As String)
        _physicalRepository.AddPhysicalFallbacks(paths)
    End Sub

    Public Function GetFileFromDisk(ByVal path As String) As FileDescriptor
        Return _physicalRepository.GetFileFromDisk(path)
    End Function


    '
    ' Database redirects
    '
    Public Function GetFileFromDatabase(ByVal reader As IDataReader) As FileDescriptor

        If reader Is Nothing Then
            Return New VoidFile()
        End If

        'Return New Descriptors.DatabaseFile(reader)
        Return New VoidFile()

    End Function

End Class
