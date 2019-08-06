using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebConstructura {
    public partial class Dueno : System.Web.UI.Page {

        ClassLogicaNegocio reglasNegocio = new ClassLogicaNegocio();

        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void botonAgregarDueno_Click(object sender, EventArgs e) {
            string mensaje = "";

            if (txtNomDueno.Text != "" && txtPaterno.Text != "" && txtMaterno.Text != "" && txtDireccion.Text != "" && txtCorreo.Text != "" &&  txtTel1.Text != "" && txtTel2.Text != "") {
                reglasNegocio.InsertarDueno(txtNomDueno.Text, txtPaterno.Text, txtMaterno.Text, txtDireccion.Text, txtCorreo.Text, txtTel1.Text, txtTel2.Text, ref mensaje);
                this.Master.tituloModalMensajesMaster.Attributes.Add("class", "modal-header bg-success text-white");
            } else {
                mensaje = "Por favor ingrese todos los datos";
                this.Master.tituloModalMensajesMaster.Attributes.Add("class", "modal-header bg-danger text-white");
            }

            txtNomDueno.Text = "";
            txtPaterno.Text = "";
            txtMaterno.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtTel1.Text = "";
            txtTel2.Text = "";
            //txtMensajes.Text = mensaje;
            this.Master.mensajeModalMaster.InnerHtml = mensaje;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalMensajesMaster').modal('show')", true);
        }

        protected void botonMostrarDuenos_Click(object sender, EventArgs e) {
            LlenarGrid();
        }

        public void LlenarGrid() {
            string mensaje = "";

            GridView1.DataSource = reglasNegocio.ListaDuenos(ref mensaje);
            GridView1.DataBind();
            this.Master.mensajeModalMaster.InnerHtml = mensaje;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalDuenos').modal('show')", true);
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
            string nom, paterno, materno, direccion, correo, tel1, tel2, mensaje = "";

            int idEmp;

            nom = (GridView1.Rows[e.RowIndex].FindControl("txtEditNombre") as TextBox).Text.Trim();
            paterno = (GridView1.Rows[e.RowIndex].FindControl("txtEditPaterno") as TextBox).Text.Trim();
            materno = (GridView1.Rows[e.RowIndex].FindControl("txtEditMaterno") as TextBox).Text.Trim();
            direccion = (GridView1.Rows[e.RowIndex].FindControl("txtEditDireccion") as TextBox).Text.Trim();
            correo = (GridView1.Rows[e.RowIndex].FindControl("txtEditCorreo") as TextBox).Text.Trim();
            tel1 = (GridView1.Rows[e.RowIndex].FindControl("txtEditTel1") as TextBox).Text.Trim();
            tel2 = (GridView1.Rows[e.RowIndex].FindControl("txtEditTel2") as TextBox).Text.Trim();

            idEmp = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            reglasNegocio.ActualizarDueno(idEmp, nom, paterno, materno, direccion, correo, tel1, tel2, ref mensaje);
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