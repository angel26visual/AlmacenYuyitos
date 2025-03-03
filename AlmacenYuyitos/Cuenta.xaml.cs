﻿using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls.Dialogs;
using System.Data;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using System.Drawing;

namespace AlmacenYuyitos
{
    /// <summary>
    /// Lógica de interacción para Cuenta.xaml
    /// </summary>
    public partial class Cuenta
    {
        OracleConnection con = null;
        string nomUsuario = string.Empty;
        public Cuenta(string usuario)
        {
            nomUsuario = usuario;
            this.setConnection();
            InitializeComponent();
            actualizarEstadoC();
            String sql = "SELECT NOMBRE_TRAB, APELLIDO_TRAB, CORREO, NOM_USUARIO, ESTADO_CIVIL_ID_ESTAC FROM TRABAJADOR WHERE NOM_USUARIO = :USUARIO";
            this.AUD(sql, 0);
        }

        private async void setConnection()
        {
            String connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            con = new OracleConnection(connectionString);
            try
            {
                con.Open();
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("Error", "No hay conexión con la base de datos");
            }
        }

        private async void AUD(String sql_stmt, int state)
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = sql_stmt;
            cmd.CommandType = CommandType.Text;
            try
            {
                switch (state)
                {
                    case 0:
                        string usuario = nomUsuario;
                        cmd.Parameters.Add("USUARIO", OracleDbType.Varchar2, 100).Value = usuario.ToString();
                        OracleDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            txtNombre.Text = reader["NOMBRE_TRAB"].ToString();
                            txtApellido.Text = reader["APELLIDO_TRAB"].ToString();
                            txtMail.Text = reader["CORREO"].ToString();
                            txtUsuario.Text = reader["NOM_USUARIO"].ToString();
                            cboEstadoCivil.SelectedValue = Convert.ToInt32(reader["ESTADO_CIVIL_ID_ESTAC"].ToString());
                        }
                        else
                        {
                            await this.ShowMessageAsync("Información de contacto", "No se a podido traer la información");
                        }
                            
                        break;
                    case 1:
                        //cmd.Parameters.Add("CORREO", OracleDbType.Varchar2, 100).Value = txtCorreo.Text;
                        OracleDataReader reader2 = cmd.ExecuteReader();
                        if (reader2.Read())
                        { }
                        break;

                }
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("Error", "Ha ocurrido un error");
            }

        }

        private async void actualizarEstadoC()
        {
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT ID_ESTAC, DESCRIP_ESTAC FROM ESTADO_CIVIL";
            cmd.CommandType = CommandType.Text;
            OracleDataReader reader = cmd.ExecuteReader();
            try
            {
                if (reader.Read())
                {
                    OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    cboEstadoCivil.ItemsSource = table.AsDataView();
                    cboEstadoCivil.DisplayMemberPath = "DESCRIP_ESTAC";
                    cboEstadoCivil.SelectedValuePath = "ID_ESTAC";
                }
                else
                {
                    await this.ShowMessageAsync("CARGA ESTADO CIVIL", "No se han obtenidos información de los estados");
                }
            }
            catch (Exception)
            {
                await this.ShowMessageAsync("Error", "Ha ocurrido un error");
            }
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow(nomUsuario);
            main.Show();
            this.Close();
        }

        private void txtConfirmarPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNuevaContrasena.Password == " ")
            {
                txtNuevaContrasena.Password = "";
            }else if(txtConfirmarPass.Password == " ")
            {
                txtConfirmarPass.Password = "";
            }
            if (txtNuevaContrasena.Password.Trim() != "" || txtConfirmarPass.Password.Trim() != "") {
                if (txtConfirmarPass.Password.Trim() != txtNuevaContrasena.Password.Trim())
                {
                    lbContrasena.Content = "Las contrañas son diferentes";
                    lbContrasena.Foreground = new SolidColorBrush(Colors.Red);
                    lbContrasena.Visibility = Visibility.Visible;
                }
                else
                {
                    lbContrasena.Content = "Las contrañas son iguales";
                    lbContrasena.Foreground = new SolidColorBrush(Colors.Green);
                    lbContrasena.Visibility = Visibility.Visible;
                }
            }
            else
            {
                lbContrasena.Visibility = Visibility.Hidden;
            }
            
        }

        private void txtConfirmarPass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int numKey = Convert.ToInt32(Convert.ToChar(e.Text));
            if (Convert.ToString(numKey) == "")
            {
                e.Handled = true;
                MessageBox.Show("funciono");
            }else
            {
                e.Handled = false;
            }
        }







        /*private void cboEstadoCivil_Loaded(object sender, RoutedEventArgs e)
        {
            actualizarEstadoC();
        }*/
    }
}
