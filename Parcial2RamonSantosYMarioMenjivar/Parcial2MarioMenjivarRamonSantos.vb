Imports System.Data.SqlClient

Public Class Form1
    Dim connectionString As String = "Data Source=ENRIQUE-PC;Initial Catalog=BDParcial2MarioMenjivarRamonSantos;Integrated Security=True;"
    Dim connection As New SqlConnection(connectionString)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try

            connection.Open()


            Dim nombre As String = TextBox1.Text
            Dim apellido As String = TextBox2.Text
            Dim departamentoID As Integer = Convert.ToInt32(ComboBox1.SelectedValue)
            Dim municipioID As Integer = Convert.ToInt32(ComboBox2.SelectedValue)

            MessageBox.Show(departamentoID.ToString())
            MessageBox.Show(municipioID.ToString())

            Dim query As String = "INSERT INTO Clientes (Nombre, Apellido, IdDepartamento, IdMunicipio) VALUES (@Nombre, @Apellido, @IdDepartamento, @IdMunicipio)"
            Dim cmd As New SqlCommand(query, connection)

            cmd.Parameters.AddWithValue("@Nombre", nombre)
            cmd.Parameters.AddWithValue("@Apellido", apellido)
            cmd.Parameters.AddWithValue("@IdDepartamento", departamentoID)
            cmd.Parameters.AddWithValue("@IdMunicipio", municipioID)

            cmd.ExecuteNonQuery()


            MessageBox.Show("Datos insertados con éxito en la base de datos.")

        Catch ex As Exception

            MessageBox.Show("Ocurrió un error: " & ex.Message)

        Finally

            If connection.State = ConnectionState.Open Then
                connection.Close()
            End If
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Dim queryDepartamentos As String = "SELECT IdDepartamento, NombreDepartamento FROM Departamentos"
            Using commandDepartamentos As New SqlCommand(queryDepartamentos, connection)
                Using adapter As New SqlDataAdapter(commandDepartamentos)
                    Dim dataTable As New DataTable()
                    adapter.Fill(dataTable)

                    ComboBox1.DataSource = dataTable
                    ComboBox1.ValueMember = "IdDepartamento"
                    ComboBox1.DisplayMember = "NombreDepartamento"
                End Using
            End Using

            Dim queryMunicipios As String = "SELECT IdMunicipio, NombreMunicipio FROM Municipios"
            Using commandMunicipios As New SqlCommand(queryMunicipios, connection)
                Using adapter2 As New SqlDataAdapter(commandMunicipios)
                    Dim dataTable2 As New DataTable()
                    adapter2.Fill(dataTable2)

                    ComboBox2.DataSource = dataTable2
                    ComboBox2.ValueMember = "IdMunicipio"
                    ComboBox2.DisplayMember = "NombreMunicipio"


                End Using

                MessageBox.Show("Parcial 2 - Programacion 2")
                MessageBox.Show("Ing. Jonthan Carballo")
                MessageBox.Show("Hecho por Mario Menjivar y Ramon Santos")
            End Using


        End Using
    End Sub
End Class
