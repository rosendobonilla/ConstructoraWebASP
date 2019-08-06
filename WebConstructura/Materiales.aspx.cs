using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Data;

namespace WebConstructura {
    public partial class WebForm1 : System.Web.UI.Page {

        ClassLogicaNegocio reglasNegocio = new ClassLogicaNegocio();
        protected void Page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                CargarTiposMaterial();
            }
        }

        protected void botonAgregarMaterial_Click(object sender, EventArgs e) {
            string mensaje = "";

            if(txtNomMaterial.Text != "" && txtMarca.Text != "" && txtPresentacion.Text != "" && txtUnidad.Text != "") {
                reglasNegocio.InsertarMaterial(txtNomMaterial.Text, txtMarca.Text, txtPresentacion.Text, txtUnidad.Text, Convert.ToInt32(dropListTipo.SelectedValue), ref mensaje);
                this.Master.tituloModalMensajesMaster.Attributes.Add("class", "modal-header bg-success text-white");
            } else {
                mensaje = "Por favor ingrese todos los datos";
                this.Master.tituloModalMensajesMaster.Attributes.Add("class","modal-header bg-danger text-white");
            }

            txtNomMaterial.Text = "";
            txtMarca.Text = "";
            txtPresentacion.Text = "";
            txtUnidad.Text = "";
            //txtMensajes.Text = mensaje;
            this.Master.mensajeModalMaster.InnerHtml = mensaje;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalMensajesMaster').modal('show')", true);
        }

        protected void dropListTipo_SelectedIndexChanged(object sender, EventArgs e) {
            /*txtMarca.Text = "Id asociaddo: " + dropListTipo.SelectedValue;
            divMensajes.InnerHtml = "Id asociaddo: " + dropListTipo.SelectedValue;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalMensajes').modal('show')", true);*/
        }

        public void CargarTiposMaterial() {
            string mensaje = "";
            List<string> ListTmp = null;
            List<int> idsTipos = new List<int>();

            ListTmp = reglasNegocio.CargarCategorias(ref mensaje, ref idsTipos, "Material");

            dropListTipo.Items.Clear();
            for (int i = 0; i < ListTmp.Count; i++) {
                dropListTipo.Items.Add(new ListItem(ListTmp[i].ToString(), idsTipos[i].ToString()));
            }

            //txtNomMaterial.Text = mensaje;
        }

        protected void botonMostrarMateriales_Click(object sender, EventArgs e) {
            LlenarGrid();
        }

        public void LlenarGrid() {
            string mensaje = "";

            GridView1.DataSource = reglasNegocio.ListaMateriales(ref mensaje);
            GridView1.DataBind();
            this.Master.mensajeModalMaster.InnerHtml = mensaje;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalMateriales').modal('show')", true);
        }

        protected void botonAgregarCategoria_Click(object sender, EventArgs e) {
            string mensaje = "";
            if(txtNombreCategoria.Text != "") {
                reglasNegocio.InsertarCategoria(txtNombreCategoria.Text, ref mensaje,"Material");
                this.Master.tituloModalMensajesMaster.Attributes.Add("class", "modal-header bg-success text-white");
            } else {
                this.Master.tituloModalMensajesMaster.Attributes.Add("class", "modal-header bg-danger text-white");
                mensaje = "Ingrese el nombre de la categoria";
            }

            CargarTiposMaterial();
            txtNombreCategoria.Text = "";
            this.Master.mensajeModalMaster.InnerHtml = mensaje;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalMensajesMaster').modal('show')", true);
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
            string nom, marca, pres, unidad, mensaje="";
            int idMat, tipo;

            nom = (GridView1.Rows[e.RowIndex].FindControl("txtEditNombre") as TextBox).Text.Trim();
            marca = (GridView1.Rows[e.RowIndex].FindControl("txtEditMarca") as TextBox).Text.Trim();
            pres = (GridView1.Rows[e.RowIndex].FindControl("txtEditPresentacion") as TextBox).Text.Trim();
            unidad = (GridView1.Rows[e.RowIndex].FindControl("txtEditUnidad") as TextBox).Text.Trim();
            tipo = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("dropListEditTipo") as DropDownList).SelectedValue);
            idMat = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            reglasNegocio.ActualizarMaterial(idMat,nom, marca, pres, unidad, tipo, ref mensaje);
            labelMensajesGrid.Text = mensaje;
            GridView1.EditIndex = -1;
            LlenarGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.DataRow) {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0) {
                    DropDownList ddList = (DropDownList)e.Row.FindControl("dropListEditTipo");

                    string mensaje = "";
                    List<string> ListTmp = null;
                    List<int> idsTipos = new List<int>();

                    ListTmp = reglasNegocio.CargarCategorias(ref mensaje, ref idsTipos, "Material");

                    ddList.Items.Clear();
                    for (int i = 0; i < ListTmp.Count; i++) {
                        ddList.Items.Add(new ListItem(ListTmp[i].ToString(), idsTipos[i].ToString()));
                    }

                    string materialSeleccionado = DataBinder.Eval(e.Row.DataItem, "idTipo").ToString();
                    ddList.Items.FindByValue(materialSeleccionado).Selected = true;
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            GridView1.PageIndex = e.NewPageIndex;
            LlenarGrid();
        }
    }
}