Namespace Descriptors

    Public Class PhysicalFile
        Inherits FileDescriptor

        Private _path As String

        Public Sub New(ByVal path As String)
            MyBase.New()
            FromFile(path)
        End Sub

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

        Protected Sub FromFile(ByVal path As String)

            Dim fi = New IO.FileInfo(path)

            MyBase.Name = fi.Name
            _path = fi.DirectoryName

            MyBase.CreatedOn = fi.CreationTime
            MyBase.ModifiedOn = fi.LastWriteTime
            MyBase.AccessedOn = fi.LastAccessTime

            Using fs = fi.OpenRead()
                MyBase.ReadFrom(fs)
            End Using

            fi = Nothing

        End Sub

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