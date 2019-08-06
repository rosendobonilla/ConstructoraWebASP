using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebConstructura {
    public partial class Sueldos : System.Web.UI.Page {

        ClassLogicaNegocio reglasNegocio = new ClassLogicaNegocio();


        protected void Page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                CargarObras();
                CargarEmpleados();
            }
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

        public void CargarEmpleados() {
            string mensaje = "";
            List<string> ListTmp = null;
            List<int> idsTipos = new List<int>();

            ListTmp = reglasNegocio.CargarEmpleados(ref mensaje, ref idsTipos);

            dropListEmpleado.Items.Clear();
            for (int i = 0; i < ListTmp.Count; i++) {
                dropListEmpleado.Items.Add(new ListItem(ListTmp[i].ToString(), idsTipos[i].ToString()));
            }
        }

        protected void botonAgregarSueldo_Click(object sender, EventArgs e) {
            string mensaje = "";

            if (labelFecha.Text != "" && txtDescripcion.Text != "" && txtImporte.Text != "") {
                reglasNegocio.InsertarSueldo(Convert.ToInt32(dropListEmpleado.SelectedValue), Convert.ToSingle(txtImporte.Text), labelFecha.Text, txtDescripcion.Text, Convert.ToInt32(dropListObra.SelectedValue), ref mensaje);
                this.Master.tituloModalMensajesMaster.Attributes.Add("class", "modal-header bg-success text-white");
            } else {
                mensaje = "Por favor ingrese todos los datos";
                this.Master.tituloModalMensajesMaster.Attributes.Add("class", "modal-header bg-danger text-white");
            }

            txtFecha.Text = "";
            txtDescripcion.Text = "";
            txtImporte.Text = "";

            //txtMensajes.Text = mensaje;
            this.Master.mensajeModalMaster.InnerHtml = mensaje;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalMensajesMaster').modal('show')", true);
        }

        protected void botonMostrarSueldos_Click(object sender, EventArgs e) {
            LlenarGrid();
        }

        public void LlenarGrid() {
            string mensaje = "";

            GridView1.DataSource = reglasNegocio.ListaSueldos(ref mensaje);
            GridView1.DataBind();
            this.Master.mensajeModalMaster.InnerHtml = mensaje;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalSueldos').modal('show')", true);
        }

        protected void botonFecha_Click(object sender, EventArgs e) {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalCalendarFecha').modal('show')", true);

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e) {
            string fechaInicio = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            string fechaInicioText = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            txtFecha.Text = fechaInicioText;
            labelFecha.Text = fechaInicio;
            panelFecha.Update();
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
            string fecha, descripcion, mensaje = "";
            float importe;
            int idSueldo, idObra, idEmpleado;

            fecha = (GridView1.Rows[e.RowIndex].FindControl("txtEditFecha") as TextBox).Text.Trim();
            descripcion = (GridView1.Rows[e.RowIndex].FindControl("txtEditDescripcion") as TextBox).Text.Trim();
            importe = Convert.ToSingle((GridView1.Rows[e.RowIndex].FindControl("txtEditImporte") as TextBox).Text.Trim());
            idObra = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("dropListEditEmpleado") as DropDownList).SelectedValue);
            idEmpleado = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("dropListEditObra") as DropDownList).SelectedValue);
            idSueldo = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            reglasNegocio.ActualizarSueldo(idSueldo,idObra,idEmpleado,importe,DateTime.Parse(fecha),descripcion, ref mensaje);
            labelMensajesGrid.Text = mensaje;
            GridView1.EditIndex = -1;
            LlenarGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0) {
                    DropDownList ddListEmpleado = (DropDownList)e.Row.FindControl("dropListEditEmpleado");
                    DropDownList ddListObra = (DropDownList)e.Row.FindControl("dropListEditObra");

                    string mensaje = "";
                    List<string> ListTmp = null;
                    List<int> idsTipos = new List<int>();

                    ListTmp = reglasNegocio.CargarEmpleados(ref mensaje, ref idsTipos);

                    ddListEmpleado.Items.Clear();
                    for (int i = 0; i < ListTmp.Count; i++) {
                        ddListEmpleado.Items.Add(new ListItem(ListTmp[i].ToString(), idsTipos[i].ToString()));
                    }

                    ListTmp = null;
                    idsTipos = new List<int>();

                    ListTmp = reglasNegocio.CargarObras(ref mensaje, ref idsTipos);

                    ddListObra.Items.Clear();
                    for (int i = 0; i < ListTmp.Count; i++) {
                        ddListObra.Items.Add(new ListItem(ListTmp[i].ToString(), idsTipos[i].ToString()));
                    }

                    string empleadoSeleccionado = DataBinder.Eval(e.Row.DataItem, "idEmpleado").ToString();
                    ddListEmpleado.Items.FindByValue(empleadoSeleccionado).Selected = true;
                    string obraSeleccionada = DataBinder.Eval(e.Row.DataItem, "idObra").ToString();
                    ddListObra.Items.FindByValue(obraSeleccionada).Selected = true;
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            GridView1.PageIndex = e.NewPageIndex;
            LlenarGrid();
        }
    }
}