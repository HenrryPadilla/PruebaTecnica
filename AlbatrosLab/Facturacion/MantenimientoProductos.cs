using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mantenimiento_Impuestos;
using Mantenimiento_Productos;



namespace Facturacion
{
    public partial class MantenimientoProductos : Form
    {
        public MantenimientoProductos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblError.Visible = false;
            lblmensaje.Visible = false;
            CargaImpuestos();

            //cargar productos disponibles
            DataTable dtproducto = new DataTable();
            Mant_Productos prd = new Mant_Productos();

            dtproducto = prd.ObtenerProductos();
            dataGridView1.DataSource = dtproducto;


            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "Seleccionar";

            dataGridView1.Columns.Add(btn);
        }



        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //cuando oprima el boton se cargaran los datos en los textbox
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Seleccionar")
            {
                txtCodigoProducto.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txtDescripcionProducto.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

                //logica para colocar el impuesto

                DataTable dtimpuesto = new DataTable();

                Mant_Impuestos imp = new Mant_Impuestos();

                dtimpuesto = imp.ObtenerImpuestos();
                for (int i = 0; i < dtimpuesto.Rows.Count; i++)
                {
                    cmbImpuestos.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    if (cmbImpuestos.Text == dtimpuesto.Rows[i]["id_Impuesto"].ToString())
                    {
                        cmbImpuestos.Text = dtimpuesto.Rows[i]["descripcion_Impuesto"].ToString();
                        break;
                    }

                }
                lblmensaje.Visible = false;
                lblError.Visible = false;
            }

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoProducto.Text) ||
                string.IsNullOrEmpty(txtDescripcionProducto.Text) ||
                string.IsNullOrEmpty(txtPrecio.Text) ||
                string.IsNullOrEmpty(cmbImpuestos.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Favor llenar los campos faltantes para proceder a guardar";
            }
            else
            {


                int idImpuesto = ObtenerIdImpuesto();
                DataTable dtproducto = new DataTable();
                Mant_Productos prd = new Mant_Productos();

                dtproducto = prd.GuardarProducto(Convert.ToInt32(txtCodigoProducto.Text),
                                                   txtDescripcionProducto.Text,
                                                  Convert.ToDecimal(txtPrecio.Text),
                                                  idImpuesto);
                if (dtproducto.Rows[0]["Codigo"].ToString() == "1")
                {
                    lblmensaje.Visible = false;
                    lblError.Visible = true;
                    lblError.Text = "Id Producto ya existe, favor ingresar producto con un id nuevo";
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
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoProducto.Text) ||
                string.IsNullOrEmpty(txtDescripcionProducto.Text) ||
                string.IsNullOrEmpty(txtPrecio.Text) ||
                string.IsNullOrEmpty(cmbImpuestos.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Favor llenar los campos faltantes para proceder a modificar";
            }
            else
            {
                int idImpuesto = ObtenerIdImpuesto();
                DataTable dtproducto = new DataTable();
                Mant_Productos prd = new Mant_Productos();

                dtproducto = prd.ModificaProducto(Convert.ToInt32(txtCodigoProducto.Text),
                                                   txtDescripcionProducto.Text,
                                                  Convert.ToDecimal(txtPrecio.Text),
                                                  idImpuesto);
                if (dtproducto.Rows[0]["Codigo"].ToString() == "1")
                {
                    lblmensaje.Visible = false;
                    lblError.Visible = true;
                    lblError.Text = "Id Producto No existe, favor ingresar producto con un id que exista para modificarlo";
                }
                else
                {
                    lblError.Visible = false;
                    lblmensaje.Visible = true;
                    lblmensaje.Text = "Se modificó con exito";
                    CargaGrid();
                    LimpiarTexBox();
                }
            }
        }
        private void btnElimina_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCodigoProducto.Text))
            {
                lblError.Visible = true;
                lblError.Text = "Favor llenar el campo Id Prodcuto para proceder a eliminar";
            }
            else
            {
                DataTable dtproducto = new DataTable();
                Mant_Productos prd = new Mant_Productos();

                dtproducto = prd.EliminaProducto(Convert.ToInt32(txtCodigoProducto.Text));
                if (dtproducto.Rows[0]["Codigo"].ToString() == "1")
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

        public void CargaImpuestos() {
            //cargar lista de impuestos disponibles
            DataTable dtimpuesto = new DataTable();

            Mant_Impuestos imp = new Mant_Impuestos();

            dtimpuesto = imp.ObtenerImpuestos();
            for (int i = 0; i < dtimpuesto.Rows.Count; i++)
            {
                cmbImpuestos.Items.Add(dtimpuesto.Rows[i]["descripcion_Impuesto"].ToString());
            }
        }
        public void CargaGrid()
        {
            //cargar productos disponibles
            DataTable dtproducto = new DataTable();
            Mant_Productos prd = new Mant_Productos();

            dtproducto = prd.ObtenerProductos();
            dataGridView1.DataSource = dtproducto;
            dataGridView1.Columns.Remove("Seleccionar");

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "Seleccionar";

            dataGridView1.Columns.Add(btn);

        }
        public void LimpiarTexBox() {
            txtCodigoProducto.Text = "";
            txtPrecio.Text = "";
            txtDescripcionProducto.Text = "";
            cmbImpuestos.Text = "";
        }
        public int ObtenerIdImpuesto() {

            //logica para obtener el id del impuesto
            DataTable dtimpuesto = new DataTable();
            int idImpuesto = 0;
            Mant_Impuestos imp = new Mant_Impuestos();

            dtimpuesto = imp.ObtenerImpuestos();
            for (int i = 0; i < dtimpuesto.Rows.Count; i++)
            {

                if (cmbImpuestos.Text == dtimpuesto.Rows[i]["descripcion_Impuesto"].ToString())
                {
                    idImpuesto = Convert.ToInt32(dtimpuesto.Rows[i]["id_Impuesto"].ToString());
                    break;
                }

            }
            return idImpuesto;
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form form_Menu = new Menu();

            form_Menu.Show();
            
        }
    }
}
