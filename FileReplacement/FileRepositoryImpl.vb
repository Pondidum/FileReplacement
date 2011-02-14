Friend Class FileRepositoryImpl

    Private ReadOnly _physicalFallbacks As PhysicalFallback

    Public Sub New()
        _physicalFallbacks = New PhysicalFallback()
    End Sub

    Public Sub AddPhysicalFallbacks(ByVal ParamArray paths() As String)
        _physicalFallbacks.AddRange(paths)
    End Sub

    Public Function GetFileFromDisk(ByVal path As String) As FileDescriptor

        If String.IsNullOrWhiteSpace(path) Then
            Return New Descriptors.VoidFile()
        End If

        If IO.File.Exists(path) Then
            Return New Descriptors.PhysicalFile(path)
        End If

        path = _physicalFallbacks.GetBestPath(path)  'this will need to be looped to try paths in succession.

        If Not IO.File.Exists(path) Then
            Return New Descriptors.VoidFile(path)
        End If

        Try
            Return New Descriptors.PhysicalFile(path)
        Catch ex As IO.IOException
            Return New Descriptors.VoidFile(path)
        End Try

    End Function

    Public Function GetFileFromDatabase(ByVal reader As IDataReader) As FileDescriptor

        If reader Is Nothing Then
            Return New Descriptors.VoidFile()
        End If

        'Return New Descriptors.DatabaseFile(reader)
        Return New Descriptors.VoidFile()

    End Function

End Class
