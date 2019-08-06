using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebConstructura {
    public partial class Obra : System.Web.UI.Page {

        ClassLogicaNegocio reglasNegocio = new ClassLogicaNegocio();

        protected void Page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                CargarEmpleados();
                CargarDuenos();
            }
        }

        public void CargarEmpleados() {
            string mensaje = "";
            List<string> ListTmp = null;
            List<int> idsTipos = new List<int>();

            ListTmp = reglasNegocio.CargarEmpleados(ref mensaje, ref idsTipos);

            dropListEncargado.Items.Clear();
            for (int i = 0; i < ListTmp.Count; i++) {
                dropListEncargado.Items.Add(new ListItem(ListTmp[i].ToString(), idsTipos[i].ToString()));
            }
        }

        public void CargarDuenos() {
            string mensaje = "";
            List<string> ListTmp = null;
            List<int> idsTipos = new List<int>();

            ListTmp = reglasNegocio.CargarDuenos(ref mensaje, ref idsTipos);

            dropListDueno.Items.Clear();
            for (int i = 0; i < ListTmp.Count; i++) {
                dropListDueno.Items.Add(new ListItem(ListTmp[i].ToString(), idsTipos[i].ToString()));
            }
        }

        protected void botonFecha_Click(object sender, EventArgs e) {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalCalendarInicio').modal('show')", true);
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e) {
            string fechaInicio = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            string fechaInicioText = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            txtFechaInicio.Text = fechaInicioText;
            labelFechaInicio.Text = fechaInicio;
            panelFechaInicio.Update();
        }

        protected void botonFechafin_Click(object sender, EventArgs e) {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalCalendarFin').modal('show')", true);
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e) {
            string fechafin = Calendar2.SelectedDate.ToString("yyyy-MM-dd");
            string fechafinText = Calendar2.SelectedDate.ToString("dd/MM/yyyy");
            txtFechaFin.Text = fechafinText;
            labelFechaFin.Text = fechafin;
            panelFechaFin.Update();
        }

        protected void botonAgregarObra_Click1(object sender, EventArgs e) {
            string mensaje = "";

            if (txtNomObra.Text != "" && txtDireccion.Text != "" && labelFechaInicio.Text != "" && labelFechaFin.Text != "") {
                reglasNegocio.InsertarObra(txtNomObra.Text, txtDireccion.Text, Convert.ToInt32(dropListEncargado.SelectedValue), Convert.ToInt32(dropListDueno.SelectedValue), labelFechaInicio.Text, labelFechaFin.Text, ref mensaje);
                this.Master.tituloModalMensajesMaster.Attributes.Add("class", "modal-header bg-success text-white");
            } else {
                mensaje = "Por favor ingrese todos los datos";
                this.Master.tituloModalMensajesMaster.Attributes.Add("class", "modal-header bg-danger text-white");
            }

            txtNomObra.Text = "";
            txtDireccion.Text = "";
            txtFechaInicio.Text = "";
            txtFechaFin.Text = "";

            //txtMensajes.Text = mensaje;
            this.Master.mensajeModalMaster.InnerHtml = mensaje;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalMensajesMaster').modal('show')", true);
        }

        protected void botonMostrarObras_Click(object sender, EventArgs e) {
            LlenarGrid();
        }

        public void LlenarGrid() {
            string mensaje = "";

            GridView1.DataSource = reglasNegocio.ListaObras(ref mensaje);
            GridView1.DataBind();
            this.Master.mensajeModalMaster.InnerHtml = mensaje;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalObras').modal('show')", true);
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e) {
            GridView1.EditIndex = e.NewEditIndex;
            LlenarGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e) {
            GridView1.EditIndex = -1;
            LlenarGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e) {
            string nom, direccion, fechaInicio, fechaFin, mensaje = "";
            int idObra, idEmpleado, idDueno;

            nom = (GridView1.Rows[e.RowIndex].FindControl("txtEditNombre") as TextBox).Text.Trim();
            direccion = (GridView1.Rows[e.RowIndex].FindControl("txtEditDireccion") as TextBox).Text.Trim();
            fechaInicio = (GridView1.Rows[e.RowIndex].FindControl("txtEditFechaInicio") as TextBox).Text.Trim();
            fechaFin = (GridView1.Rows[e.RowIndex].FindControl("txtEditFechaFin") as TextBox).Text.Trim();
            idEmpleado = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("dropListEditEncargado") as DropDownList).SelectedValue);
            idDueno = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("dropListEditDueno") as DropDownList).SelectedValue);
            idObra = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            reglasNegocio.ActualizarObra(idObra, nom, direccion, idEmpleado, idDueno, DateTime.Parse(fechaInicio), DateTime.Parse(fechaFin), ref mensaje);
            labelMensajesGrid.Text = mensaje;
            GridView1.EditIndex = -1;
            LlenarGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0) {
                    DropDownList ddListEncargado = (DropDownList)e.Row.FindControl("dropListEditEncargado");
                    DropDownList ddListDueno = (DropDownList)e.Row.FindControl("dropListEditDueno");

                    string mensaje = "";
                    List<string> ListTmp = null;
                    List<int> idsTipos = new List<int>();

                    ListTmp = reglasNegocio.CargarEmpleados(ref mensaje, ref idsTipos);

                    ddListEncargado.Items.Clear();
                    for (int i = 0; i < ListTmp.Count; i++) {
                        ddListEncargado.Items.Add(new ListItem(ListTmp[i].ToString(), idsTipos[i].ToString()));
                    }

                    ListTmp = null;
                    idsTipos = new List<int>();

                    ListTmp = reglasNegocio.CargarDuenos(ref mensaje, ref idsTipos);

                    ddListDueno.Items.Clear();
                    for (int i = 0; i < ListTmp.Count; i++) {
                        ddListDueno.Items.Add(new ListItem(ListTmp[i].ToString(), idsTipos[i].ToString()));
                    }

                    string empleadoSeleccionado = DataBinder.Eval(e.Row.DataItem, "idEncargado").ToString();
                    ddListEncargado.Items.FindByValue(empleadoSeleccionado).Selected = true;
                    string duenoSeleccionado = DataBinder.Eval(e.Row.DataItem, "idDueno").ToString();
                    ddListDueno.Items.FindByValue(duenoSeleccionado).Selected = true;
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            GridView1.PageIndex = e.NewPageIndex;
            LlenarGrid();
        }

    }
}