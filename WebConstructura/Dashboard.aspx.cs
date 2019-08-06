using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebConstructura {
    public partial class Dashboard : System.Web.UI.Page {

        ClassLogicaNegocio reglasNegocio = new ClassLogicaNegocio();

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                CargarTotales();
                CargarObras();
            }
        }

        public void CargarTotales() {
            string mensaje = "";
            string[] totales = reglasNegocio.obtenerTotales(ref mensaje);
            totalControl.InnerText = totales[0] + " control obras";
            totalDuenos.InnerText = totales[1] + " dueños";
            totalEmpleados.InnerText = totales[2] + " empleados";
            totalMateriales.InnerText = totales[3] + " materiales";
            totalObras.InnerText = totales[4] + " obras";
            totalProveedores.InnerText = totales[5] + " proveedores";
            totalSueldos.InnerText = totales[6] + " sueldos";
        }

        public void CargarObras() {
            string mensaje = "";
            List<string> ListTmp = null;
            List<int> idsTipos = new List<int>();

            ListTmp = reglasNegocio.CargarObras(ref mensaje, ref idsTipos);

            dropListObra.Items.Clear();
            for (int i = 0; i < ListTmp.Count; i++) {
                dropListObra.Items.Add(new ListItem(ListTmp[i].ToString(), idsTipos[i].ToString()));
            }
        }
        protected void botonFecha_Click(object sender, EventArgs e) {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalCalendarInicio').modal('show')", true);
        }

        protected void botonFechafin_Click(object sender, EventArgs e) {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalCalendarFin').modal('show')", true);
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e) {
            string fechaInicio = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            string fechaInicioText = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            txtFechaInicio.Text = fechaInicioText;
            labelFechaInicio.Text = fechaInicio;
            panelFechaInicio.Update();
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e) {
            string fechafin = Calendar2.SelectedDate.ToString("yyyy-MM-dd");
            string fechafinText = Calendar2.SelectedDate.ToString("dd/MM/yyyy");
            txtFechaFin.Text = fechafinText;
            labelFechaFin.Text = fechafin;
            panelFechaFin.Update();
        }

        protected void botonMostrarCosto_Click(object sender, EventArgs e) {
            LlenarGrids();
        }

        public void LlenarGrids() {
            string mensaje = "";
            float totalImporteMateriales = 0;
            float totalImporteSueldos = 0;
            if (txtFechaInicio.Text != "" && txtFechaFin.Text != "") {
                gridMateriales.DataSource = reglasNegocio.ListaMaterialesPorFecha(Convert.ToInt32(dropListObra.SelectedValue), labelFechaInicio.Text, labelFechaFin.Text, ref mensaje, ref totalImporteMateriales);
                gridMateriales.DataBind();
                gridSueldos.DataSource = reglasNegocio.ListasueldosPorFecha(Convert.ToInt32(dropListObra.SelectedValue), labelFechaInicio.Text, labelFechaFin.Text, ref mensaje, ref totalImporteSueldos);
                gridSueldos.DataBind();
                divTotalImporteMateriales.InnerText = "El importe total por concepto de materiales es $" + totalImporteMateriales;
                divTotalImporteSueldos.InnerText = "El importe total por concepto de sueldos es $" + totalImporteSueldos;
                divTotalGlobal.InnerText = "El gasto total de la obra en el periodo indicado es de $" + (totalImporteSueldos + totalImporteMateriales);

            }
        }

        protected void gridMateriales_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            gridMateriales.PageIndex = e.NewPageIndex;
        }

        protected void gridSueldos_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            gridSueldos.PageIndex = e.NewPageIndex;
            LlenarGrids();
        }
    }
}