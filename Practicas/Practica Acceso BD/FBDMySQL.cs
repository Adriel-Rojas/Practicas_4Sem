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
using MySql.Data.MySqlClient;


namespace Practicas
{
    public partial class FBDMySQL : Form
    {
        private string Servidor = "localhost";
        private string Basedatos = "ESCOLAR";
        private string UsuarioId = "root";
        private string Password = "Adriel26";
        public FBDMySQL()
        {
            InitializeComponent();
        }
        private void EjecutaComando(string ConsultaSQL)
        {
            try
            {
                string strConn = $"Server={Servidor};Database={Basedatos};User ID={UsuarioId};Password={Password};";
                using (MySqlConnection conn = new MySqlConnection(strConn))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(ConsultaSQL, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                llenarGrid();
            }
            catch (MySqlException Ex)
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
                string strConn = $"Server={Servidor};Database={Basedatos};User ID={UsuarioId};Password={Password};";
                using (MySqlConnection conn = new MySqlConnection(strConn))
                {
                    conn.Open();
                    string sqlQuery = "SELECT * FROM Alumnos";
                    MySqlDataAdapter adp = new MySqlDataAdapter(sqlQuery, conn);
                    DataSet ds = new DataSet();
                    adp.Fill(ds, "Alumnos");
                    dgvAlumnos.DataSource = ds.Tables[0];
                }
                dgvAlumnos.Refresh();
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema");
            }
        }

        private void btnCrearBD_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCreaTabla_Click(object sender, EventArgs e)
        {
  
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            
        }

        private void FBDMySQL_Load(object sender, EventArgs e)
        {
            
        }

        private void btnCrearBD_Click_1(object sender, EventArgs e)
        {
            try
            {
                string strConn = $"Server={Servidor};" +
                    //$"Database=master;" +
                    $"User Id={UsuarioId};" +
                    $"Password={Password}";

                //CODIGO ORIGINAL
                using (MySqlConnection conn = new MySqlConnection(strConn))
                {
                    //SqlConnection conn = new SqlConnection(strConn);
                    //conn.Open();

                    //MySqlCommand cmd = new MySqlCommand();
                    //cmd.Connection = conn;
                    //cmd.CommandText = "CREATE DATABASE ESCOLAR";
                    //cmd.ExecuteNonQuery();

                    conn.Open();
                    MessageBox.Show("Conexion al servidor establecida correctamente");

                    MySqlCommand cmd = new MySqlCommand("CREATE DATABASE IF NOT EXISTS ESCOLAR", conn);//Se creara una base de datos solo si no esta creada escolar
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Base de datos 'ESCOLAR' creada o ya existente.");
                }

            }
            catch (MySqlException Ex)
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

        private void btnInsertar_Click_1(object sender, EventArgs e)
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

                    MySqlConnection conn = new MySqlConnection(strConn);
                    conn.Open();

                    // Verificar si el numero de control ya existe
                    string consultaVerificar = "SELECT COUNT(*) FROM Alumnos WHERE NControl = '" + txtNoControl.Text + "'";
                    MySqlCommand cmdVerificar = new MySqlCommand(consultaVerificar, conn);
                    //int existe = (int)cmdVerificar.ExecuteScalar();
                    int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());//Convierte el dato ingresado a entero


                    if (existe > 0)
                    {
                        MessageBox.Show("El numero de control ya existe. No se puede insertar un duplicado.");
                        conn.Close();
                        return;
                    }
                    string insertQuery = "INSERT INTO Alumnos (NControl, nombre, carrera) VALUES (@nControl, @nombre, @carrera)";
                    MySqlCommand cmd = new MySqlCommand(insertQuery, conn);

                    cmd.Parameters.AddWithValue("@nControl", txtNoControl.Text);
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@carrera", txtCarrera.Text);
                    cmd.ExecuteNonQuery();

                    llenarGrid();
                }

            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema: " + Ex.Message);
            }
        }

        private void btnActualizar_Click_1(object sender, EventArgs e)
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

                    MySqlConnection conn = new MySqlConnection(strConn);
                    conn.Open();

                    // Verificar si el registro existe antes de actualizarlo
                    string consultaVerificar = "SELECT COUNT(*) FROM Alumnos WHERE NControl = '" + txtNoControl.Text + "'";
                    MySqlCommand cmdVerificar = new MySqlCommand(consultaVerificar, conn);
                    //int existe = (int)cmdVerificar.ExecuteScalar();
                    int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                    if (existe == 0)
                    {
                        MessageBox.Show("El numero de control no existe. No se puede actualizar.");
                        conn.Close();
                        return;
                    }

                    // Si el registro existe, proceder con la actualizacion
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE Alumnos SET " +
                                      "nombre = '" + txtNombre.Text + "', " +
                                      "carrera = " + txtCarrera.Text + " " +
                                      "WHERE NControl = '" + txtNoControl.Text + "'";
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    MessageBox.Show("Registro actualizado correctamente.");


                    llenarGrid(); // Refrescar el DataGridView
                }
                else
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                }
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema.");
            }
        }

        private void btnBorrar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length > 0)
                {
                    string strConn = $"Server={Servidor};" +
                        $"Database={Basedatos};" +
                        $"User Id={UsuarioId};" +
                        $"Password={Password}";

                    MySqlConnection conn = new MySqlConnection(strConn);
                    conn.Open();

                    // Verificar si el registro existe antes de intentar borrarlo
                    string consultaVerificar = "SELECT COUNT(*) FROM Alumnos WHERE NControl = '" + txtNoControl.Text + "'";
                    MySqlCommand cmdVerificar = new MySqlCommand(consultaVerificar, conn);
                    //int existe = (int)cmdVerificar.ExecuteScalar();
                    int existe = Convert.ToInt32(cmdVerificar.ExecuteScalar());

                    if (existe == 0)
                    {
                        MessageBox.Show("El numero de control no existe. No se puede borrar.");
                        conn.Close();
                        return;
                    }

                    // Si el registro existe, proceder con el DELETE
                    MySqlCommand cmd = new MySqlCommand();
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
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema.");
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtNoControl.Text.Trim().Length > 0)
                {
                    string strConn = $"Server={Servidor};" +
                        $"Database={Basedatos};" +
                        $"User Id={UsuarioId};" +
                        $"Password={Password}";

                    MySqlConnection conn = new MySqlConnection(strConn);
                    conn.Open();

                    // Buscar el registro por número de control
                    string consultaBuscar = "SELECT nombre, carrera FROM Alumnos WHERE NControl = '" + txtNoControl.Text + "'";
                    MySqlCommand cmdBuscar = new MySqlCommand(consultaBuscar, conn);
                    MySqlDataReader reader = cmdBuscar.ExecuteReader();

                    if (reader.Read()) // Si encuentra el registro
                    {
                        MessageBox.Show("Nombre: " + reader["nombre"].ToString() + ", Carrera: " + reader["carrera"].ToString());
                        // MessageBox.Show(reader["carrera"].ToString());
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el alumno con ese numero de control.");
                    }

                    reader.Close();
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un numero de control para buscar.");
                }
            }
            catch (MySqlException Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error en el sistema.");
            }
        }

        private void FBDMySQL_Load_1(object sender, EventArgs e)
        {
            llenarGrid();
        }

        private void btnRefrescar_Click_1(object sender, EventArgs e)
        {
            llenarGrid();
        }
    }
}
