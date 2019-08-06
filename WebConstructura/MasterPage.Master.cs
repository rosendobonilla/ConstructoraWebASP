using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebConstructura {

    public partial class MasterPage : System.Web.UI.MasterPage {

        public HtmlGenericControl tituloModalMensajesMaster {
            get { return (HtmlGenericControl)FindControl("modalHeaderMensajes"); }
            set { modalHeaderMensajes = value; }
        }

        public HtmlGenericControl mensajeModalMaster {
            get { return (HtmlGenericControl)FindControl("mensajeModal"); }
            set { modalHeaderMensajes = value; }
        }
        protected void Page_Load(object sender, EventArgs e) {

        }
    }
}