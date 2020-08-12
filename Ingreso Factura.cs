using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModuloFacturas
{
    public partial class IngresoFactura : Form
    {
        

        List<ClsFactura> Listafactura = new List<ClsFactura>();
       

        public IngresoFactura()
        {
            InitializeComponent();

            txtIva.Enabled = false;
            txtMontoN.Enabled = false;
            txtMontoT.Enabled = false;
            dateEmision.Enabled = false;
            txtProveedor.MaxLength = 12;
        

        }

        public void GuardarFactura()
        {

            string[] codigo = new string[5] { txtCod1.Text,txtCod2.Text,txtCod3.Text,txtCod4.Text,txtCod5.Text};

           

            string[] descripcion = new string[5] {txtDesc1.Text,txtDesc2.Text,txtDesc3.Text,txtDesc4.Text,txtDesc5.Text };
           

            int[] cantidad = new int[5] {int.Parse(txtCant1.Text),int.Parse(txtCant2.Text),int.Parse(txtCant3.Text),int.Parse(txtCant4.Text),int.Parse(txtCant5.Text)};
         

            int[] precio = new int[5] { int.Parse(txtPrecio1.Text), int.Parse(txtPrecio2.Text), int.Parse(txtPrecio3.Text), int.Parse(txtPrecio4.Text), int.Parse(txtPrecio5.Text) };
          
            int totalProducto1 = cantidad[0] * precio[0];
            int totalProducto2 = cantidad[1] * precio[1];
            int totalProducto3 = cantidad[2] * precio[2];
            int totalProducto4 = cantidad[3] * precio[3];
            int totalProducto5 = cantidad[4] * precio[4];

            double totalProducto = totalProducto1 + totalProducto2 + totalProducto3 + totalProducto4 + totalProducto5;
            double iva = totalProducto * 0.19;
            double montoNeto = totalProducto + iva;
            txtMontoN.Text = Math.Round(montoNeto,2).ToString(); 
            txtMontoT.Text = totalProducto.ToString();
            txtIva.Text = Math.Round(iva,2).ToString();
            
            ClsFactura factura = new ClsFactura(int.Parse(txtFactura.Text), txtProveedor.Text, txtRazonSocial.Text, txtGiro.Text, txtDireccion.Text,
                                                 codigo, descripcion, cantidad, precio, dateEmision.Text, dateEmision.Text, double.Parse(txtMontoN.Text),
                                                 double.Parse(txtMontoT.Text), double.Parse(txtIva.Text));
            
            
            Listafactura.Add(factura);

            foreach (var item in Listafactura)
            {
                MessageBox.Show("Factura Ingresada\nNúmero de Factura: "+item.Numero.ToString()+"\nMonto Neto: "+totalProducto+"\nMonto Iva: "+item.Iva+ "\nMonto Total: "+item.MontoNeto);


            }
            Listafactura.Clear();
        }


        private void txtFactura_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }


        public void SoloNumeros(KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Solo puede ingresar números", "Módulo Factura", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }




        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtFactura.Clear();
            txtRazonSocial.Clear();
            txtProveedor.Clear();
            txtGiro.Clear();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(dateEmision.Text) > int.Parse(dateVencimiento.Text))
                {
                    MessageBox.Show("La fecha de vencimiento no puede ser menor a la fecha de emisión", "Módulo Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }
                else if ((int.Parse(txtCant1.Text) == 0 || int.Parse(txtPrecio1.Text) == 0) || (int.Parse(txtCant2.Text) == 0 || int.Parse(txtPrecio2.Text) ==0) || (int.Parse(txtCant3.Text) ==0 || int.Parse(txtPrecio3.Text) ==0) || (int.Parse(txtCant4.Text) ==0 || int.Parse(txtPrecio4.Text) ==0) || (int.Parse(txtCant5.Text) ==0 || int.Parse(txtPrecio5.Text) ==0))
                {
                    DialogResult opcion = MessageBox.Show("Existen valores en 0, verifique los datos ingresados\n¿Desea guardar la factura?", "Módulo Factura", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (opcion == DialogResult.Yes)
                    {
                        GuardarFactura();
                    }
                    else
                    {
                        txtCant1.Focus();
                    }


                }
                else
                {
                    GuardarFactura();
                }





            }
            catch (Exception)
            {
                MessageBox.Show("Hay campos sin datos\nRecuerde completar con 0 cantidad y precio si no hay productos que ingresar","Módulo Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtCod1_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtCod2_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtCod3_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtCod4_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtCod5_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtCant1_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtCant2_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtCant3_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtCant4_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtCant5_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtPrecio1_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtPrecio2_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtPrecio3_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtPrecio4_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtPrecio5_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtFechaEmi_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void txtFechaVen_KeyPress(object sender, KeyPressEventArgs e)
        {
            SoloNumeros(e);
        }

        private void btnLimpiar_Click_1(object sender, EventArgs e)
        {
            limpiarTextBoxes(this);

            // Y opcionalmente…
            this.txtFactura.Focus();
        }

        private void limpiarTextBoxes(Control parent)
        {
            //Limpiar de manera rapida
            foreach (Control c in parent.Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
                if (c.Controls.Count > 0)
                {
                    limpiarTextBoxes(c);
                }
            }
        
        }

        private void lblDescripcion_Click(object sender, EventArgs e)
        {

        }

        private void IngresoFactura_Load(object sender, EventArgs e)
        {

        }
    }
   
}
