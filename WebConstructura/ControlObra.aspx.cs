using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebConstructura {
    public partial class ControlObra : System.Web.UI.Page {

        ClassLogicaNegocio reglasNegocio = new ClassLogicaNegocio();

        protected void Page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                CargarObras();
                CargarProveedores();
                CargarMateriales();
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

        public void CargarProveedores() {
            string mensaje = "";
            List<string> ListTmp = null;
            List<int> idsTipos = new List<int>();

            ListTmp = reglasNegocio.CargarProveedores(ref mensaje, ref idsTipos);

            dropListProveedor.Items.Clear();
            for (int i = 0; i < ListTmp.Count; i++) {
                dropListProveedor.Items.Add(new ListItem(ListTmp[i].ToString(), idsTipos[i].ToString()));
            }
        }

        public void CargarMateriales() {
            string mensaje = "";
            List<string> ListTmp = null;
            List<int> idsTipos = new List<int>();

            ListTmp = reglasNegocio.CargarMateriales(ref mensaje, ref idsTipos);

            dropListMaterial.Items.Clear();
            for (int i = 0; i < ListTmp.Count; i++) {
                dropListMaterial.Items.Add(new ListItem(ListTmp[i].ToString(), idsTipos[i].ToString()));
            }
        }

        protected void botonAgregarObra_Click1(object sender, EventArgs e) {
            string mensaje = "";

            if (labelFecha.Text != "" && txtCantidad.Text != "" && txtEntrego.Text != "" && txtRecibio.Text != "" && txtPrecio.Text != "" && txtEtapa.Text != "") {
                reglasNegocio.InsertarRegistro(Convert.ToInt32(dropListObra.SelectedValue), Convert.ToInt32(dropListProveedor.SelectedValue), Convert.ToInt32(dropListMaterial.SelectedValue), labelFecha.Text, Convert.ToSingle(txtPrecio.Text), Convert.ToInt32(txtCantidad.Text), txtRecibio.Text, txtEntrego.Text, txtEtapa.Text, ref mensaje);
                this.Master.tituloModalMensajesMaster.Attributes.Add("class", "modal-header bg-success text-white");
            } else {
                mensaje = "Por favor ingrese todos los datos";
                this.Master.tituloModalMensajesMaster.Attributes.Add("class", "modal-header bg-danger text-white");
            }

            txtFecha.Text = "";
            txtCantidad.Text = "";
            txtEntrego.Text = "";
            txtRecibio.Text = "";
            txtPrecio.Text = "";
            txtEtapa.Text = "";

            //txtMensajes.Text = mensaje;
            this.Master.mensajeModalMaster.InnerHtml = mensaje;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalMensajesMaster').modal('show')", true);
        }

        protected void botonMostrarObras_Click(object sender, EventArgs e) {
            LlenarGrid();
        }

        public void LlenarGrid() {
            string mensaje = "";

            GridView1.DataSource = reglasNegocio.ListaRegistros(ref mensaje);
            GridView1.DataBind();
            this.Master.mensajeModalMaster.InnerHtml = mensaje;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalRegistros').modal('show')", true);
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e) {
            string fechaInicio = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            string fechaInicioText = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            txtFecha.Text = fechaInicioText;
            labelFecha.Text = fechaInicio;
            panelFecha.Update();
        }

        protected void botonFecha_Click(object sender, EventArgs e) {
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalCalendarFecha').modal('show')", true);
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
            string fecha, recibio, entrego, etapa, mensaje = "";
            float precio;
            int idControl, idObra, idProv, idMaterial, cantidad;

            fecha = (GridView1.Rows[e.RowIndex].FindControl("txtEditFecha") as TextBox).Text.Trim();
            recibio = (GridView1.Rows[e.RowIndex].FindControl("txtEditRecibio") as TextBox).Text.Trim();
            entrego = (GridView1.Rows[e.RowIndex].FindControl("txtEditEntrego") as TextBox).Text.Trim();
            etapa = (GridView1.Rows[e.RowIndex].FindControl("txtEditEtapa") as TextBox).Text.Trim();
            precio = Convert.ToSingle((GridView1.Rows[e.RowIndex].FindControl("txtEditPrecio") as TextBox).Text.Trim());
            cantidad = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("txtEditCantidad") as TextBox).Text.Trim());

            idObra = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("dropListEditObra") as DropDownList).SelectedValue);
            idProv = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("dropListEditProveedor") as DropDownList).SelectedValue);
            idMaterial = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("dropListEditMaterial") as DropDownList).SelectedValue);

            idControl = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            reglasNegocio.ActualizarControl(idControl,idObra, idProv,idMaterial, DateTime.Parse(fecha),precio,cantidad,entrego,recibio,etapa, ref mensaje);
            labelMensajesGrid.Text = mensaje;
            GridView1.EditIndex = -1;
            LlenarGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0) {
                    DropDownList ddListObra = (DropDownList)e.Row.FindControl("dropListEditObra");
                    DropDownList ddListProveedor = (DropDownList)e.Row.FindControl("dropListEditProveedor");
                    DropDownList ddListMaterial = (DropDownList)e.Row.FindControl("dropListEditMaterial");

                    string mensaje = "";
                    List<string> ListTmp = null;
                    List<int> idsTipos = new List<int>();

                    ListTmp = reglasNegocio.CargarObras(ref mensaje, ref idsTipos);

                    ddListObra.Items.Clear();
                    for (int i = 0; i < ListTmp.Count; i++) {
                        ddListObra.Items.Add(new ListItem(ListTmp[i].ToString(), idsTipos[i].ToString()));
                    }

                    ListTmp = null;
                    idsTipos = new List<int>();

                    ListTmp = reglasNegocio.CargarProveedores(ref mensaje, ref idsTipos);

                    ddListProveedor.Items.Clear();
                    for (int i = 0; i < ListTmp.Count; i++) {
                        ddListProveedor.Items.Add(new ListItem(ListTmp[i].ToString(), idsTipos[i].ToString()));
                    }

                    ListTmp = null;
                    idsTipos = new List<int>();

                    ListTmp = reglasNegocio.CargarMateriales(ref mensaje, ref idsTipos);

                    ddListMaterial.Items.Clear();
                    for (int i = 0; i < ListTmp.Count; i++) {
                        ddListMaterial.Items.Add(new ListItem(ListTmp[i].ToString(), idsTipos[i].ToString()));
                    }

                    string obraSeleccionada = DataBinder.Eval(e.Row.DataItem, "idObra").ToString();
                    ddListObra.Items.FindByValue(obraSeleccionada).Selected = true;
                    string proveedorSeleccionado = DataBinder.Eval(e.Row.DataItem, "idProv").ToString();
                    ddListProveedor.Items.FindByValue(proveedorSeleccionado).Selected = true;
                    string materialSeleccionado = DataBinder.Eval(e.Row.DataItem, "idMaterial").ToString();
                    ddListMaterial.Items.FindByValue(materialSeleccionado).Selected = true;
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            GridView1.PageIndex = e.NewPageIndex;
        }
    }
}