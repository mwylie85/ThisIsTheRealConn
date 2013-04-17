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

    Public Function getOneRow(ByVal sqlQuery As String) As List(Of IService1.eventDetails) Implements IService1.getOneRow
        Dim x As Object = Nothing
        Dim my_List As New List(Of IService1.eventDetails)
        Dim it As New IService1.eventDetails
        Dim con As New MySqlConnection(ConStr)
        Dim da As MySqlDataAdapter = Nothing
        Try
            'open conection
            con.Open()
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
                    it.event_Venue = .Item(4)
                    it.event_Address = .Item(5)
                    it.event_Lat = .Item(6)
                    it.event_Long = .Item(7)
                    it.event_StartDate = .Item(8).ToString
                    it.event_EndDate = .Item(9).ToString
                    my_List.Add(it)
                End With
            Next
            dSet.Dispose()
        Catch ex As Exception
            Console.WriteLine(ex.StackTrace)
        Finally
            da.Dispose()
            con.Close()
        End Try
        Return my_List
    End Function
End Class
