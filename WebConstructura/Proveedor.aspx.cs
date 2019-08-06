using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebConstructura {
    public partial class Proveedor : System.Web.UI.Page {

        ClassLogicaNegocio reglasNegocio = new ClassLogicaNegocio();

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void botonAgregarProveedor_Click(object sender, EventArgs e) {
            string mensaje = "";

            if (txtNomProveedor.Text != "" && txtContacto.Text != "" && txtDireccion.Text != "" && txtCorreo.Text != "" && txtTel1.Text != "" && txtTel2.Text != "" && txtPagina.Text != "") {
                reglasNegocio.InsertarProveedor(txtNomProveedor.Text, txtDireccion.Text, txtContacto.Text, txtTel1.Text, txtTel2.Text,txtCorreo.Text,txtPagina.Text, ref mensaje);
                this.Master.tituloModalMensajesMaster.Attributes.Add("class", "modal-header bg-success text-white");
            } else {
                mensaje = "Por favor ingrese todos los datos";
                this.Master.tituloModalMensajesMaster.Attributes.Add("class", "modal-header bg-danger text-white");
            }

            txtNomProveedor.Text = "";
            txtContacto.Text = "";
            txtDireccion.Text = "";
            txtTel1.Text = "";
            txtTel2.Text = "";
            txtCorreo.Text = "";
            txtPagina.Text = "";

            this.Master.mensajeModalMaster.InnerHtml = mensaje;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalMensajesMaster').modal('show')", true);
        }

        protected void botonMostrarProveedor_Click(object sender, EventArgs e) {
            LlenarGrid();
        }

        public void LlenarGrid() {
            string mensaje = "";

            GridView1.DataSource = reglasNegocio.ListaProveedores(ref mensaje);
            GridView1.DataBind();
            this.Master.mensajeModalMaster.InnerHtml = mensaje;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalProveedores').modal('show')", true);
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
            string nom, direccion, contacto, correo, pagina, tel1, tel2, mensaje = "";

            int idProv;

            nom = (GridView1.Rows[e.RowIndex].FindControl("txtEditNombre") as TextBox).Text.Trim();
            pagina = (GridView1.Rows[e.RowIndex].FindControl("txtEditPagina") as TextBox).Text.Trim();
            contacto = (GridView1.Rows[e.RowIndex].FindControl("txtEditContacto") as TextBox).Text.Trim();
            direccion = (GridView1.Rows[e.RowIndex].FindControl("txtEditDireccion") as TextBox).Text.Trim();
            correo = (GridView1.Rows[e.RowIndex].FindControl("txtEditCorreo") as TextBox).Text.Trim();
            tel1 = (GridView1.Rows[e.RowIndex].FindControl("txtEditTel1") as TextBox).Text.Trim();
            tel2 = (GridView1.Rows[e.RowIndex].FindControl("txtEditTel2") as TextBox).Text.Trim();

            idProv = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            reglasNegocio.ActualizarProveedor(idProv, nom, direccion,contacto,tel1, tel2,correo,pagina, ref mensaje);
            labelMensajesGrid.Text = mensaje;
            GridView1.EditIndex = -1;
            LlenarGrid();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            GridView1.PageIndex = e.NewPageIndex;
            LlenarGrid();
        }
    }
}