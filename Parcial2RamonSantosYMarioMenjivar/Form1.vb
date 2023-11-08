Imports System.Data.SqlClient

Public Class Form1
    Dim connectionString As String = "Data Source=PCLUIS;Initial Catalog=BDParcial2MarioMenjivarRamonSantos;Integrated Security=True;"
    Dim connection As New SqlConnection(connectionString)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' Abre la conexión a la base de datos
            connection.Open()

            ' Obtiene los datos del formulario
            Dim nombre As String = TextBox1.Text
            Dim apellido As String = TextBox2.Text
            Dim departamentoID As Integer = Convert.ToInt32(ComboBox1.SelectedValue)
            Dim municipioID As Integer = Convert.ToInt32(ComboBox2.SelectedValue)

            MessageBox.Show(departamentoID.ToString())
            MessageBox.Show(municipioID.ToString())

            ' Realiza la acción, por ejemplo, insertar datos en la base de datos
            Dim query As String = "INSERT INTO Clientes (Nombre, Apellido, IdDepartamento, IdMunicipio) VALUES (@Nombre, @Apellido, @IdDepartamento, @IdMunicipio)"
            Dim cmd As New SqlCommand(query, connection)

            cmd.Parameters.AddWithValue("@Nombre", nombre)
            cmd.Parameters.AddWithValue("@Apellido", apellido)
            cmd.Parameters.AddWithValue("@IdDepartamento", departamentoID)
            cmd.Parameters.AddWithValue("@IdMunicipio", municipioID)

            cmd.ExecuteNonQuery()

            ' Muestra un mensaje de éxito
            MessageBox.Show("Datos insertados con éxito en la base de datos.")

        Catch ex As Exception
            ' Maneja cualquier excepción que pueda ocurrir durante la operación
            MessageBox.Show("Ocurrió un error: " & ex.Message)

        Finally
            ' Cierra la conexión a la base de datos, independientemente de si hubo un error o no
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
                    ComboBox1.ValueMember = "IdDepartamento" ' Nombre de la columna con los IDs
                    ComboBox1.DisplayMember = "NombreDepartamento" ' Nombre de la columna con los nombres
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

                MessageBox.Show("Creado por Luis Mario y Liliana Guadalupe")
            End Using


        End Using
    End Sub
End Class
