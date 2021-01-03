Imports System.Data.SqlClient

Public Class Form1

    Dim bd As New SqlConnection(My.Settings.DocenteConnectionString)
    Dim dv As New DataView

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'llenamos el DataGridView
        cargaDGV()


    End Sub

    'creamos un método para cargar el DataGridView
    Private Sub cargaDGV()
        Dim dt As New DataSet
        Dim at As New SqlDataAdapter("Select id, apellidos, nombre, tipo_doc, num_doc from Docentes", bd)
        at.Fill(dt)
        dv.Table = dt.Tables(0)
        DataGridView1.DataSource = dv

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'creamos la búsqueda DataGridView
        dv.RowFilter = String.Format("apellidos like '%{0}%' ", TextBox1.Text)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

End Class
