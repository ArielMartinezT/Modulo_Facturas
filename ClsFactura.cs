using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloFacturas
{
    class ClsFactura
    {
        private int numero;
        private string proveedor;
        private string razonSocial;
        private string giro;
        private string direccionProv;
        private string [] codigo = new string [4];
        private string [] descripcion = new string [5];
        private int [] cantidad = new int [5];
        private int [] precio = new int [5];
        private string fechaEmi;
        private string fechaVen;
        private double montoNeto;
        private double montoTotal;
        private double iva;


        public ClsFactura(int numero, string proveedor, string razonSocial, string giro, string direccionProv, string[]codigo, string [] descripcion,
                         int []cantidad, int [] precio, string fechaEmi, string fechaVen, double montoNeto, double MontoTotal, double iva )
        {
            this.Numero = numero;
            this.Proveedor = proveedor;
            this.RazonSocial = razonSocial;
            this.Giro = giro;
            this.DireccionProv = direccionProv;
            this.codigo = codigo;
            this.Descripcion = descripcion;
            this.Cantidad = cantidad;
            this.Precio = precio;
            this.FechaEmi = fechaEmi;
            this.FechaVen = fechaVen;
            this.MontoNeto = montoNeto;
            this.MontoTotal = this.MontoTotal;
            this.Iva = iva;
       
        }

        public int Numero { get => numero; set => numero = value; }
        public string Proveedor { get => proveedor; set => proveedor = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public string Giro { get => giro; set => giro = value; }
        public string DireccionProv { get => direccionProv; set => direccionProv = value; }
        public string[] Codigo { get => codigo; set => codigo = value; }
        public string[] Descripcion { get => descripcion; set => descripcion = value; }
        public int[] Cantidad { get => cantidad; set => cantidad = value; }
        public int[] Precio { get => precio; set => precio = value; }
        public string FechaEmi { get => fechaEmi; set => fechaEmi = value; }
        public string FechaVen { get => fechaVen; set => fechaVen = value; }
        public double MontoNeto { get => montoNeto; set => montoNeto = value; }
        public double MontoTotal { get => montoTotal; set => montoTotal = value; }
        public double Iva { get => iva; set => iva = value; }
    }



}
