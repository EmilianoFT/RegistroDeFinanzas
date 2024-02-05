using AccesoADatos;
using RegistroDeFinanzas.commons;
using RegistroDeFinanzas.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RegistroDeFinanzas.forms
{
    public partial class FrmCargaDatos : Form
    {
        private List<OkxOrder>? datos;
        private List<OkxOrder> datosCompra = new List<OkxOrder>();
        private List<OkxOrder> datosVenta = new List<OkxOrder>();
        private mdbAccess DB = new mdbAccess(Environment.CurrentDirectory, "RegistroDeFinanzas");
        public FrmCargaDatos()
        {
            InitializeComponent();
            datos = OkxCsvProcessor.AbrirDirectorio(Environment.CurrentDirectory + "\\Datos");
            datos.Sort((x, y) => y.FechaCreacion.CompareTo(x.FechaCreacion));
            cargarTGrillas();
        }

        private void btnOfd_Click(object sender, EventArgs e)
        {
            this.Ofd.ShowDialog();
        }

        private void Ofd_FileOk(object sender, CancelEventArgs e)
        {

            txtPath.Text = this.Ofd.FileName;
            if (datos == null)
            {
                datos = new List<OkxOrder>();
            }
            List<OkxOrder>? listaTemporal = OkxCsvProcessor.Abrir(txtPath.Text);

            if (listaTemporal != null)
            {
                datos = datos.Concat(listaTemporal).Distinct().ToList();
            }
            cargarTGrillas();
        }

        private void FrmCargaDatos_Load(object sender, EventArgs e)
        {

        }

        private void dgCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveCSV();
        }
        private void saveCSV()
        {
            Dictionary<string, List<OkxOrder>> lista = new Dictionary<string, List<OkxOrder>>();
            datos.ForEach(o =>
            {
                if (o != null)
                {
                    string key = "OKX" + o.FechaCreacion.Month + o.FechaCreacion.Year;
                    if (!lista.ContainsKey(key))
                    {
                        lista.Add(key, new List<OkxOrder>());
                    }
                    lista[key].Add(o);
                }
            });

            lista.Keys.ToList().ForEach(k =>
            {
                OkxCsvProcessor.guardar(Environment.CurrentDirectory + "\\Datos\\" + k + ".csv", lista[k]);
            });
        }
        private void inserDB()
        {
            List<string> tablas = new List<string>();
            if (!DB.IsConnected())
            {
                DB.Connect();
            }

            datos.ForEach(o =>
            {
                if (o != null)
                {
                    string tabla = "OKX" + o.FechaCreacion.Month + o.FechaCreacion.Year;
                    if (!tablas.Contains(tabla) && !DB.TableExists(tabla))
                    {
                        DB.CreateSampleTable(tabla, typeof(OkxOrder));
                        tablas.Add(tabla);
                    }
                    else if (!tablas.Contains(tabla))
                    {
                        tablas.Add(tabla);
                    }
                    DB.InsertData(tabla, typeof(OkxOrder), o);
                }
            });
        }
        private void cargarTGrillas()
        {
            decimal totalCompraARS = 0;
            decimal totalCompraUSDT = 0;
            decimal totalVentaARS = 0;
            decimal totalVentaUSDT = 0;
            if (datos == null)
            {
                return;
            }
            datos.ForEach(o =>
            {
                if (o != null && o.TipoOrden.Equals("Comprar") && o.Estado.Equals("Cumplido"))
                {
                    datosCompra.Add(o);
                    totalCompraARS += o.Monto;
                    totalCompraUSDT += o.Volumen;
                }
                else if (o != null && o.TipoOrden.Equals("Vender") && o.Estado.Equals("Cumplido"))
                {
                    datosVenta.Add(o);
                    totalVentaARS += o.Monto;
                    totalVentaUSDT += o.Volumen;
                }
            });

            if (datosVenta.Count > 0)
            {
                lblVMTARS.Text = "$ " + totalVentaARS;
                lblVMTUDST.Text = "$ " + totalVentaUSDT;
                lblVPM.Text = "$ " + Math.Round(totalVentaARS / totalVentaUSDT, 2);
                dgVentas.DataSource = datosVenta;
            }

            if (datosCompra.Count > 0)
            {
                dgCompras.DataSource = datosCompra;
                lblCMTARS.Text = "$ " + totalCompraARS;
                lblCMTUDST.Text = "$ " + totalCompraUSDT;
                lblCPM.Text = "$ " + Math.Round(totalCompraARS / totalCompraUSDT, 2);
            }
        }

        private void FrmCargaDatos_Activated(object sender, EventArgs e)
        {

            
        }
    }
}
