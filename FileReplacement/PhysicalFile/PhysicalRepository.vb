Namespace PhysicalFile

    Public Class PhysicalRepository

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
                        Return New PhysicalFile(path)
                    Catch ex As IO.IOException
                        Return New VoidFile(path)
                    End Try

                End If

                path = _physicalFallbacks.GetBestPath(path)

            End While

            Return New VoidFile(path)
            
        End Function

    End Class

End Namespace
