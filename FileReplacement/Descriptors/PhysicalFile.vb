Namespace Descriptors

    Public Class PhysicalFile
        Inherits FileDescriptor
        
        Private _path As String

        Public ReadOnly Property Directory() As String
            Get
                Return _path
            End Get
        End Property


        Public Overrides ReadOnly Property Type As FileDescriptor.FileTypes
            Get
                Return FileTypes.Physical
            End Get
        End Property

        Public Overrides Function Rename(ByVal newName As String) As Boolean

            If String.IsNullOrWhiteSpace(newName) Then Return False

            Dim source = IO.Path.Combine(_path, Me.Name)
            Dim dest = IO.Path.Combine(_path, newName)

            IO.File.Move(source, dest)
            Me.Name = newName

            Return True

        End Function

        Public Overrides Function Move(ByVal newPath As String) As Boolean

            If String.IsNullOrWhiteSpace(newPath) Then Return False

            Dim source = IO.Path.Combine(_path, Me.Name)

            IO.File.Move(source, newPath)

            Me.Name = IO.Path.GetFileName(newPath)
            _path = IO.Path.GetDirectoryName(newPath)

            Return True

        End Function

        Public Overrides Function Delete() As Boolean

            Dim path = IO.Path.Combine(Me.Directory, Me.Name)

            If Not IO.File.Exists(path) Then Return True

            IO.File.Delete(path)

            Return True

        End Function

    End Class

End Namespace