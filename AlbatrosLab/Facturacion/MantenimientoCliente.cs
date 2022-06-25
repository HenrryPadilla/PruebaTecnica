using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mantenimiento_Clientes;

namespace Facturacion
{
    public partial class MantenimientoCliente : Form
    {
        public MantenimientoCliente()
        {
            InitializeComponent();
        }

        private void MantenimientoCliente_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblmensaje.Visible = false;

            //cargar clientes disponibles
            DataTable dtclientes = new DataTable();
            Mant_Clientes cln = new Mant_Clientes();

            dtclientes = cln.ObtenerClientes();
            dataGridView1.DataSource = dtclientes;


            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "Seleccionar";

            dataGridView1.Columns.Add(btn);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //cuando oprima el boton se cargaran los datos en los textbox
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                txtCodigoCliente.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtNombreCliente.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtRtn.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtDireccion.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

                lblmensaje.Visible = false;
                lblError.Visible = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoCliente.Text) ||
                string.IsNullOrEmpty(txtDireccion.Text) ||
                string.IsNullOrEmpty(txtRtn.Text) ||
                string.IsNullOrEmpty(txtNombreCliente.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Favor llenar los campos faltantes para proceder a guardar";
            }
            else
            {


                
                DataTable dtcliente = new DataTable();
                Mant_Clientes cln = new Mant_Clientes();

                dtcliente = cln.GuardarClientes(txtCodigoCliente.Text,
                                                   txtNombreCliente.Text,
                                                  txtRtn.Text,
                                                  txtDireccion.Text);
                if (dtcliente.Rows[0]["Codigo"].ToString() == "1")
                {
                    lblmensaje.Visible = false;
                    lblError.Visible = true;
                    lblError.Text = "Id Cliente Ó RTN ya existen, favor ingresar Cliente con un id o RTN diferente";
                }
                else
                {
                    lblError.Visible = false;
                    lblmensaje.Visible = true;
                    lblmensaje.Text = "Se guardó con exito";
                    CargaGrid();
                    LimpiarTexBox();
                }

            }
        }
        public void CargaGrid()
        {
            // cargar clientes disponibles
            DataTable dtclientes = new DataTable();
            Mant_Clientes cln = new Mant_Clientes();

            dtclientes = cln.ObtenerClientes();
            dataGridView1.DataSource = dtclientes;
            dataGridView1.Columns.Remove("Seleccionar");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "Seleccionar";

            dataGridView1.Columns.Add(btn);

        }
        public void LimpiarTexBox()
        {
            txtCodigoCliente.Text = "";
            txtNombreCliente.Text = "";
            txtRtn.Text = "";
            txtDireccion.Text = "";
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoCliente.Text) ||
                string.IsNullOrEmpty(txtDireccion.Text) ||
                string.IsNullOrEmpty(txtRtn.Text) ||
                string.IsNullOrEmpty(txtNombreCliente.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Favor llenar los campos faltantes para proceder a Modificar";
            }
            else
            {

                DataTable dtcliente = new DataTable();
                Mant_Clientes cln = new Mant_Clientes();

                dtcliente = cln.ModificaClientes(txtCodigoCliente.Text,
                                                   txtNombreCliente.Text,
                                                  txtRtn.Text,
                                                  txtDireccion.Text);
                if (dtcliente.Rows[0]["Codigo"].ToString() == "1")
                {
                    lblmensaje.Visible = false;
                    lblError.Visible = true;
                    lblError.Text = "Id Cliente o RTN No existe, favor ingresar cliente con un id que exista para modificarlo";
                }
                else
                {
                    lblError.Visible = false;
                    lblmensaje.Visible = true;
                    lblmensaje.Text = "Se guardó con exito";
                    CargaGrid();
                    LimpiarTexBox();
                }

            }
        }

        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoCliente.Text) 
                || string.IsNullOrEmpty(txtRtn.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Favor llenar el campo Id cliente o RTN para proceder a eliminar";
            }
            else
            {
                DataTable dtcliente = new DataTable();
                Mant_Clientes cln = new Mant_Clientes();


                dtcliente = cln.EliminaClientes(txtCodigoCliente.Text,
                                                txtRtn.Text);
                if (dtcliente.Rows[0]["Codigo"].ToString() == "1")
                {
                    lblmensaje.Visible = false;
                    lblError.Visible = true;
                    lblError.Text = "Id Producto No existe, favor ingresar producto con un id que exista para Eliminarlo";
                }
                else
                {
                    lblError.Visible = false;
                    lblmensaje.Visible = true;
                    lblmensaje.Text = "Se Eliminó con exito";
                    CargaGrid();
                    LimpiarTexBox();
                }
            }
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form_Menu = new Menu();

            form_Menu.Show();
        }
    }
}
