' NOTE: You can use the "Rename" command on the context menu to change the class name "Service1" in code, svc and config file together.
Imports System.Collections.Generic
Imports System.Linq
Imports System.Runtime.Serialization
Imports System.ServiceModel
Imports System.Text
Imports System.Configuration
Imports System.Data
Imports MySql.Data.MySqlClient
Imports System.Data.SqlTypes
Imports System.Threading.Tasks
Imports System.IO

Public Class Service1
    Implements IService1
    Dim x As String = Nothing
    Dim ConStr As String = "Server=instance37057.db.xeround.com;Port=5273;Database=cityofculturedb;Uid=mwylie85;Pwd=Computer1"
    Dim dSet As DataSet = Nothing
    ' Dim sqlStatment As String = "SELECT * FROM derrycityevents Where Id=1"
    Public Structure getDetailsFromDB
        Dim eventID As Integer
        Dim eventName As String
        Dim eventInfo As String
        Dim eventPic As Byte
    End Structure
    Public eventInfo As New List(Of getDetailsFromDB)
    Dim eventItem As New getDetailsFromDB

    Dim myArray As Array()
    Public Function MyOperation1(ByVal sqlQuery As String) As String Implements IService1.MyOperation1
        Dim x As String = Nothing
        Try
            sqlQuery = "SELECT * FROM derrycityevents"
            Dim con As New MySqlConnection(ConStr)
            Dim da As MySqlDataAdapter
            con.Open()
            'cmd.ExecuteNonQuery()
            da = New MySqlDataAdapter(sqlQuery, con)
            dSet = New DataSet
            da.Fill(dSet)
            da.Dispose()
            con.Close()
            'x = dSet.Tables(0).Rows(0).Item(2).ToString
            Dim r As Integer = 0
            With dSet
                For Each i As DataRow In .Tables(0).Rows
                    For index As Integer = 0 To .Tables(0).Rows.Count - 2
                        ' x &= .Tables(0).Rows(r).Item(0) & "," & .Tables(0).Rows(r).Item(1) & "," & .Tables(0).Rows(r).Item(1) _
                        '& "," & .Tables(0).Rows(r).Item(2) & "," & .Tables(0).Rows(r).Item(3).ToString
                        With .Tables(0).Rows(r)
                            x &= .Item(0) & "," & .Item(1) & "," & .Item(2) & "," & .Item(3).ToString
                        End With

                        'eventItem.eventName &= .Tables(0).Rows(r).Item(1)
                        'eventItem.eventInfo &= .Tables(0).Rows(r).Item(2)
                        'eventItem.eventPic &= .Tables(0).Rows(r).Item(3)
                        r += 1
                    Next
                Next
            End With
        Catch ex As Exception
            Console.WriteLine(ex.StackTrace)
        End Try
        Return x
    End Function

    Public Function getOneRow(ByVal sqlQuery As String) As List(Of IService1.xxx) Implements IService1.getOneRow
        Dim x As Object = Nothing
        Dim my_List As New List(Of IService1.xxx)
        Dim it As New IService1.xxx
        Try
            'sqlQuery = "SELECT * FROM derrycityevents"
            Dim con As New MySqlConnection(ConStr)
            Dim da As MySqlDataAdapter
            con.Open()
            'cmd.ExecuteNonQuery()
            da = New MySqlDataAdapter(sqlQuery, con)
            dSet = New DataSet
            da.Fill(dSet)
            da.Dispose()
            con.Close()
            For i = 0 To dSet.Tables(0).Rows.Count - 1
                With dSet.Tables(0).Rows(i)
                    it.event_Id = .Item(0)
                    it.event_Name = .Item(1)
                    it.event_Info = .Item(2)
                    it.event_Img = .Item(3)
                    my_List.Add(it)
                    'my_List.Add(New getEventInfo(.Item(0)))
                    ' x = .Item(0) & "," & .Item(1) & "," & .Item(2) & "," & .Item(3).ToString
                End With
            Next
        Catch ex As Exception
            Console.WriteLine(ex.StackTrace)
        End Try
        Return my_List
    End Function

    Public Function getPic(ByVal getPicData As String) As Byte() Implements IService1.getPic
        Dim hasPicData() As Byte = Nothing
        Try
            'getPicData = "SELECT * FROM derrycityevents Where Id =1"
            Dim con As New MySqlConnection(ConStr)
            Dim da As MySqlDataAdapter
            con.Open()
            'cmd.ExecuteNonQuery()
            da = New MySqlDataAdapter(getPicData, con)
            dSet = New DataSet
            da.Fill(dSet)
            da.Dispose()
            con.Close()
            With dSet.Tables(0).Rows(0)
                hasPicData = .Item(3)
            End With
        Catch ex As Exception
            Console.WriteLine(ex.StackTrace)
        End Try
        Return hasPicData
    End Function

    'Public Function convertToByte(ByRef img As Object) As Byte()
    '    Dim fs As FileStream = New FileStream(img, FileMode.Open, FileAccess.Read)
    '    Dim br As BinaryReader = New BinaryReader(fs)
    '    Dim bm() As Byte = br.ReadBytes(fs.Length)
    '    br.Close()
    '    fs.Close()
    '    Return bm
    'End Function


End Class
