Namespace Descriptors

    Public Class VoidFile
        Inherits FileDescriptor

        Public Sub New()
            MyBase.New()
            MyBase.Name = "This file is Temporarily unavailable"
        End Sub

        Public Sub New(ByVal path As String)
            MyBase.New()
            MyBase.Name = IO.Path.GetFileName(path)
        End Sub

        Public Overrides ReadOnly Property Type As FileDescriptor.FileTypes
            Get
                Return FileTypes.Void
            End Get
        End Property
        
    End Class

End Namespace