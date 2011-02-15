Public MustInherit Class FileDescriptor
    
    Private _name As String
    Private _directory As String
    Private _createdOn As DateTime
    Private _modifiedOn As DateTime
    Private _accessedOn As DateTime
    Private _bytes() As Byte
    
    Public Sub New()
        _name = String.Empty
        _directory = String.Empty
        _createdOn = DateTime.MinValue
        _modifiedOn = DateTime.MinValue
        _accessedOn = DateTime.MinValue
        _bytes = Nothing
    End Sub

    Public ReadOnly Property Bytes() As Byte()
        Get
            Return _bytes
        End Get
    End Property

    Public ReadOnly Property Size() As Long
        Get
            Return _bytes.Count()
        End Get
    End Property

    Public Property AccessedOn() As DateTime
        Get
            Return _accessedOn
        End Get
        Protected Set(ByVal value As DateTime)
            _accessedOn = value
        End Set
    End Property

    Public Property ModifiedOn() As DateTime
        Get
            Return _modifiedOn
        End Get
        Protected Set(ByVal value As DateTime)
            _modifiedOn = value
        End Set
    End Property

    Public Property CreatedOn() As DateTime
        Get
            Return _createdOn
        End Get
        Protected Set(ByVal value As DateTime)
            _createdOn = value
        End Set
    End Property

    Public Property Directory() As String
        Get
            Return _directory
        End Get
        Protected Set(ByVal value As String)
            _directory = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _name
        End Get
        Protected Set(ByVal value As String)
            _name = value
        End Set
    End Property
    

    Public MustOverride ReadOnly Property Type As FileTypes

    Public Sub WriteTo(ByVal stream As IO.Stream)

        If stream Is Nothing Then Throw New ArgumentNullException("stream")
        If Not stream.CanWrite Then Throw New InvalidOperationException("stream cannot be written to")

        Dim buffer = _bytes

        stream.Write(buffer, 0, buffer.Length)

    End Sub

    Public Sub ReadFrom(ByVal stream As IO.Stream)

        If stream Is Nothing Then Throw New ArgumentNullException("stream")
        If Not stream.CanRead Then Throw New InvalidOperationException("stream cannot be read from")


        Dim buffer(stream.Length) As Byte
        stream.Read(buffer, 0, stream.Length)

        _bytes = buffer
        
    End Sub

    Public Overridable Function Rename(ByVal newName As String) As Boolean
        Return False
    End Function

    Public Overridable Function Move(ByVal newPath As String) As Boolean
        Return False
    End Function

    Public Overridable Function Delete() As Boolean
        Return False
    End Function

    Public Enum FileTypes
        Physical
        Database
        Void
    End Enum

End Class

