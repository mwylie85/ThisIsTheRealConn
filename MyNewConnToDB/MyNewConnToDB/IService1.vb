' NOTE: You can use the "Rename" command on the context menu to change the interface name "IService1" in both code and config file together.
Imports System.ServiceModel
Imports System.Runtime.Serialization
<ServiceContract()>
Public Interface IService1
    Structure xxx
        Dim event_Id As Integer
        Dim event_Address As String
        Dim event_Info As String
        Dim event_Img() As Byte
    End Structure
    <OperationContract()> _
    Function MyOperation1(ByVal sqlQuery As String) As String
    <OperationContract()> _
    Function getOneRow(ByVal sqlQuery As String) As List(Of xxx)
    <OperationContract()> _
    Function getPic(ByVal getPicData As String) As Byte()

    'fjasf
    ' TODO: Add your service operations here

End Interface

' Use a data contract as illustrated in the sample below to add composite types to service operations.


Public Class getEventInfo
    Private _id As Integer

    Public Sub New(ByVal id As Integer)
        _id = id
    End Sub

    Public Property id() As Integer
        Get
            Return _id
        End Get
        Set(value As Integer)
            _id = value
        End Set
    End Property
End Class
'Public Class CompositeType

'    <DataMember()>
'    Public Property BoolValue() As Boolean

'    <DataMember()>
'    Public Property StringValue() As String


