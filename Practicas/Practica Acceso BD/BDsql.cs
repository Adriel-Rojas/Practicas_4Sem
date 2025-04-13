using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practicas
{
    public partial class BDsql : Form
    {

        private string Servidor = "DESKTOP-QQ8SGJN";
        private string Basedatos = "ESCOLAR";
        private string UsuarioId = "sa";
        private string Password = "ADRIEL026";


        private void EjecutaComando(string ConsultaSQL)
        {
            try
            {
                string strConn = $"Server={Servidor};" +
                    $"Database={Basedatos};" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";


                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = ConsultaSQL;
                cmd.ExecuteNonQuery();


                llenarGrid();

            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }

        private void llenarGrid()
        {
            try
            {
                string strConn = $"Server={Servidor};" +
                    $"Database={Basedatos};" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";

                SqlConnection conn = new SqlConnection(strConn);
                conn.Open();

                string sqlQuery = "select * from Alumnos";
                SqlDataAdapter adp = new SqlDataAdapter(sqlQuery, conn);

                DataSet ds = new DataSet();
                adp.Fill(ds, "Alumnos");
                dgvAlumnos.DataSource = ds.Tables[0];


                dgvAlumnos.Refresh();
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }


        public BDsql()
        {
            InitializeComponent();
        }



        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnCrearBD_Click(object sender, EventArgs e)
        {
            try
            {
                string strConn = $"Server={Servidor};" +
                    $"Database=master;" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";

                //CODIGO ORIGINAL

                strConn = $"Server={Servidor};Database=master;User Id={UsuarioId};Password={Password};";
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    //SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "CREATE DATABASE ESCOLAR";
                    cmd.ExecuteNonQuery();
                }

            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }

        private void btnCrearTabla_Click(object sender, EventArgs e)
        {
            EjecutaComando("CREATE TABLE " +
                    "Alumnos (NControl varchar(10), nombre varchar(50), carrera int)");
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length > 0 &&
                    txtNombre.Text.Trim().Length > 0 &&
                    txtCarrera.Text.Trim().Length > 0)
                {
                    string strConn = $"Server={Servidor};" +
                        $"Database={Basedatos};" +
                        $"User Id={UsuarioId};" +
                        $"Password={Password}";

                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();

                    // Verificar si el número de control ya existe
                    string consultaVerificar = "SELECT COUNT(*) FROM Alumnos WHERE NControl = '" + txtNoControl.Text + "'";
                    SqlCommand cmdVerificar = new SqlCommand(consultaVerificar, conn);
                    int existe = (int)cmdVerificar.ExecuteScalar();

                    if (existe > 0)
                    {
                        MessageBox.Show("El numero de control ya existe. No se puede insertar un duplicado.");
                        conn.Close();
                        return;
                    }

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO " +
                        "Alumnos (NControl, nombre, carrera) " +
                        "VALUES ('" + txtNoControl.Text +
                        "', '" + txtNombre.Text +
                        "', " + txtCarrera.Text + ")";
                    cmd.ExecuteNonQuery();

                    llenarGrid();
                }

            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }

        private void BDsql_Load(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length > 0 &&
                    txtNombre.Text.Trim().Length > 0 &&
                    txtCarrera.Text.Trim().Length > 0)
                {
                    string strConn = $"Server={Servidor};" +
                        $"Database={Basedatos};" +
                        $"User Id={UsuarioId};" +
                        $"Password={Password}";

                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();

                    // Verificar si el registro existe antes de actualizarlo
                    string consultaVerificar = "SELECT COUNT(*) FROM Alumnos WHERE NControl = '" + txtNoControl.Text + "'";
                    SqlCommand cmdVerificar = new SqlCommand(consultaVerificar, conn);
                    int existe = (int)cmdVerificar.ExecuteScalar();

                    if (existe == 0)
                    {
                        MessageBox.Show("El numero de control no existe. No se puede actualizar.");
                        conn.Close();
                        return;
                    }

                    // Si el registro existe, proceder con la actualización
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Alumnos SET " +
                                      "nombre = '" + txtNombre.Text + "', " +
                                      "carrera = " + txtCarrera.Text + " " +
                                      "WHERE NControl = '" + txtNoControl.Text + "'";
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Registro actualizado correctamente.");


                    llenarGrid(); //Refrescar el DataGridView
                }
                else
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                }
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema.");
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length > 0)
                {
                    string strConn = $"Server={Servidor};" +
                        $"Database={Basedatos};" +
                        $"User Id={UsuarioId};" +
                        $"Password={Password}";

                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();

                    // Verificar si el registro existe antes de intentar borrarlo
                    string consultaVerificar = "SELECT COUNT(*) FROM Alumnos WHERE NControl = '" + txtNoControl.Text + "'";
                    SqlCommand cmdVerificar = new SqlCommand(consultaVerificar, conn);
                    int existe = (int)cmdVerificar.ExecuteScalar();

                    if (existe == 0)
                    {
                        MessageBox.Show("El numero de control no existe. No se puede borrar.");
                        conn.Close();
                        return;
                    }

                    // Si el registro existe, proceder con el DELETE
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "DELETE FROM Alumnos WHERE NControl = '" + txtNoControl.Text + "'";
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Registro eliminado correctamente.");

                    llenarGrid(); // Actualizar el DataGridView
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un numero de control.");
                }
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema.");
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length > 0)
                {
                    string strConn = $"Server={Servidor};" +
                        $"Database={Basedatos};" +
                        $"User Id={UsuarioId};" +
                        $"Password={Password}";

                    SqlConnection conn = new SqlConnection(strConn);
                    conn.Open();

                    // Buscar el registro por número de control
                    string consultaBuscar = "SELECT nombre, carrera FROM Alumnos WHERE NControl = '" + txtNoControl.Text + "'";
                    SqlCommand cmdBuscar = new SqlCommand(consultaBuscar, conn);
                    SqlDataReader reader = cmdBuscar.ExecuteReader();

                    if (reader.Read()) // Si encuentra el registro
                    {
                        MessageBox.Show("Nombre: " + reader["nombre"].ToString() + ", Carrera: " + reader["carrera"].ToString());
                        // MessageBox.Show(reader["carrera"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("No se encontro el alumno con ese numero de control.");
                    }

                    reader.Close();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un numero de control para buscar.");
                }
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema.");
            }
        }
    }
}
