using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebConstructura {
    public partial class Empleado : System.Web.UI.Page {
        ClassLogicaNegocio reglasNegocio = new ClassLogicaNegocio();

        protected void Page_Load(object sender, EventArgs e) {
            if (!this.IsPostBack) {
                CargarTiposEmpleado();
            }
        }

        protected void botonAgregarMaterial_Click(object sender, EventArgs e) {
            string mensaje = "";

            if (txtNomEmpleado.Text != "" && txtPaterno.Text != "" && txtMaterno.Text != "" && txtDireccion.Text != "" && txtCorreo.Text != "" && txtNss.Text != "" && txtTel1.Text != "" && txtTel2.Text != "") {
                reglasNegocio.InsertarEmpleado(txtNomEmpleado.Text, txtPaterno.Text, txtMaterno.Text, txtDireccion.Text, txtCorreo.Text, txtNss.Text, Convert.ToInt32(dropListTipoEmpleado.SelectedValue), txtTel1.Text, txtTel2.Text, ref mensaje);
                this.Master.tituloModalMensajesMaster.Attributes.Add("class", "modal-header bg-success text-white");
            } else {
                mensaje = "Por favor ingrese todos los datos";
                this.Master.tituloModalMensajesMaster.Attributes.Add("class", "modal-header bg-danger text-white");
            }

            txtNomEmpleado.Text = "";
            txtPaterno.Text = "";
            txtMaterno.Text = "";
            txtDireccion.Text = "";
            txtCorreo.Text = "";
            txtNss.Text = "";
            txtTel1.Text = "";
            txtTel1.Text = "";

            this.Master.mensajeModalMaster.InnerHtml = mensaje;
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalMensajesMaster').modal('show')", true);
        }

        public void CargarTiposEmpleado() {
            string mensaje = "";
            List<string> ListTmp = null;
            List<int> idsTipos = new List<int>();

            ListTmp = reglasNegocio.CargarCategorias(ref mensaje, ref idsTipos, "Empleado");

            dropListTipoEmpleado.Items.Clear();
            for (int i = 0; i < ListTmp.Count; i++) {
                dropListTipoEmpleado.Items.Add(new ListItem(ListTmp[i].ToString(), idsTipos[i].ToString()));
            }

            //txtNomMaterial.Text = mensaje;
        }

        protected void botonMostrarMateriales_Click(object sender, EventArgs e) {
            LlenarGrid();
        }

        public void LlenarGrid() {
            string mensaje = "";
            GridView1.DataSource = reglasNegocio.ListaEmpleados(ref mensaje);
            GridView1.DataBind();
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "$('#modalEmpleados').modal('show')", true);
        }
        protected void botonAgregarCategoria_Click(object sender, EventArgs e) {
            string mensaje = "";
            if (txtNombreCategoria.Text != "") {
                reglasNegocio.InsertarCategoria(txtNombreCategoria.Text, ref mensaje, "Empleado");
            }

            CargarTiposEmpleado();
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
            string nom,paterno, materno, direccion, correo, nss, tel1, tel2,mensaje = "";

            int idEmp, tipo;

            nom = (GridView1.Rows[e.RowIndex].FindControl("txtEditNombre") as TextBox).Text.Trim();
            paterno = (GridView1.Rows[e.RowIndex].FindControl("txtEditPaterno") as TextBox).Text.Trim();
            materno = (GridView1.Rows[e.RowIndex].FindControl("txtEditMaterno") as TextBox).Text.Trim();
            direccion = (GridView1.Rows[e.RowIndex].FindControl("txtEditDireccion") as TextBox).Text.Trim();
            correo = (GridView1.Rows[e.RowIndex].FindControl("txtEditCorreo") as TextBox).Text.Trim();
            nss = (GridView1.Rows[e.RowIndex].FindControl("txtEditNSS") as TextBox).Text.Trim();
            tel1 = (GridView1.Rows[e.RowIndex].FindControl("txtEditTel1") as TextBox).Text.Trim();
            tel2 = (GridView1.Rows[e.RowIndex].FindControl("txtEditTel2") as TextBox).Text.Trim();

            tipo = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("dropListEditTipo") as DropDownList).SelectedValue);
            idEmp = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);

            reglasNegocio.ActualizarEmpleado(idEmp, nom, paterno, materno,direccion, correo, nss, tipo, tel1, tel2, ref mensaje);
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

                    ListTmp = reglasNegocio.CargarCategorias(ref mensaje, ref idsTipos, "Empleado");

                    ddList.Items.Clear();
                    for (int i = 0; i < ListTmp.Count; i++) {
                        ddList.Items.Add(new ListItem(ListTmp[i].ToString(), idsTipos[i].ToString()));
                    }

                    string empleadoSeleccionado = DataBinder.Eval(e.Row.DataItem, "idTipo").ToString();
                    ddList.Items.FindByValue(empleadoSeleccionado).Selected = true;
                }
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e) {
            GridView1.PageIndex = e.NewPageIndex;
            LlenarGrid();
        }
    }
}