Namespace PhysicalFile

    Friend Class PhysicalFallback

        Private ReadOnly _paths As List(Of String)

        Public Sub New()
            _paths = New List(Of String)
        End Sub

        Public Sub Add(ByVal path As String)
            _paths.Add(path)
        End Sub

        Public Sub AddRange(ByVal ParamArray paths() As String)
            _paths.AddRange(paths)
        End Sub

        Function GetBestPath(ByVal path As String) As String

            Dim directory = IO.Path.GetDirectoryName(path)
            Dim filename = IO.Path.GetFileName(path)

            If String.IsNullOrWhiteSpace(directory) Then
                Return String.Empty
            End If

            If Not _paths.Contains(directory, StringComparer.OrdinalIgnoreCase) Then
                Return String.Empty
            End If

            Dim item = _paths.First(Function(p) ComparePaths(p, directory))
            Dim index = _paths.IndexOf(item)        'yuck

            If index <= -1 Then
                Return String.Empty
            End If

            index += 1

            If index = _paths.Count Then
                Return String.Empty
            End If

            Return IO.Path.Combine(_paths(index), filename)

        End Function

        Private Function ComparePaths(ByVal first As String, ByVal second As String) As Boolean

            Return String.Equals(IO.Path.GetFullPath(first).TrimEnd("\\"),
                             IO.Path.GetFullPath(second).TrimEnd("\\"),
                             StringComparison.OrdinalIgnoreCase)

        End Function


    End Class

End Namespace
