Friend Class FileRepositoryImpl

    Private ReadOnly _physicalFallbacks As PhysicalFallback

    Public Sub New()
        _physicalFallbacks = New PhysicalFallback()
    End Sub

    Public Sub AddPhysicalFallbacks(ByVal ParamArray paths() As String)
        _physicalFallbacks.AddRange(paths)
    End Sub

    Public Function GetFileFromDisk(ByVal path As String) As FileDescriptor

        While Not String.IsNullOrWhiteSpace(path)

            If IO.File.Exists(path) Then

                Try
                    Return New Descriptors.PhysicalFile(path)
                Catch ex As IO.IOException
                    Return New Descriptors.VoidFile(path)
                End Try

            End If

            path = _physicalFallbacks.GetBestPath(path)

        End While

        Return New Descriptors.VoidFile(path)


    End Function

    Public Function GetFileFromDatabase(ByVal reader As IDataReader) As FileDescriptor

        If reader Is Nothing Then
            Return New Descriptors.VoidFile()
        End If

        'Return New Descriptors.DatabaseFile(reader)
        Return New Descriptors.VoidFile()

    End Function

End Class
