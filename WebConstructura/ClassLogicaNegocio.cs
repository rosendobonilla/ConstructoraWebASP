using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using ClassADO_001;
using System.Configuration;
using System.Data;

namespace WebConstructura {
    public class ClassLogicaNegocio {

        private UsaSql manejaInterno = new UsaSql();

        public ClassLogicaNegocio() {
            manejaInterno.CadenaConexion = ConfigurationManager.ConnectionStrings["conexion1"].ToString();
        }
        public List<string> CargarCategorias(ref string mensaje, ref List<int> idsTipos, string tabla) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);
            SqlDataReader atrapa = null;
            List<string> tipos = new List<string>();
            idsTipos.Clear();

            atrapa = manejaInterno.ConsultaReader(abierta, "SELECT * FROM Tipo_" + tabla, ref mensaje);

            if (atrapa != null) {
                while (atrapa.Read()) {
                    tipos.Add(atrapa[1].ToString());
                    idsTipos.Add((int)atrapa[0]);
                }
            }

            return tipos;
        }

        public List<string> CargarEmpleados(ref string mensaje, ref List<int> idsTipos) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);
            SqlDataReader atrapa = null;
            List<string> tipos = new List<string>();
            idsTipos.Clear();

            atrapa = manejaInterno.ConsultaReader(abierta, "select id_Empleado, Nombre + ' ' + ApP + ' ' + ApM as 'Nombre completo' from Empleado;", ref mensaje);

            if (atrapa != null) {
                while (atrapa.Read()) {
                    tipos.Add(atrapa[1].ToString());
                    idsTipos.Add((int)atrapa[0]);
                }
            }

            return tipos;
        }

        public List<string> CargarDuenos(ref string mensaje, ref List<int> idsTipos) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);
            SqlDataReader atrapa = null;
            List<string> tipos = new List<string>();
            idsTipos.Clear();

            atrapa = manejaInterno.ConsultaReader(abierta, "select id_dueno, Nombre + ' ' + ApP + ' ' + ApM as 'Nombre completo' from Dueno;", ref mensaje);

            if (atrapa != null) {
                while (atrapa.Read()) {
                    tipos.Add(atrapa[1].ToString());
                    idsTipos.Add((int)atrapa[0]);
                }
            }

            return tipos;
        }

        public List<string> CargarProveedores(ref string mensaje, ref List<int> idsTipos) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);
            SqlDataReader atrapa = null;
            List<string> tipos = new List<string>();
            idsTipos.Clear();

            atrapa = manejaInterno.ConsultaReader(abierta, "select id_Prove, Nombre from Proveedor;", ref mensaje);

            if (atrapa != null) {
                while (atrapa.Read()) {
                    tipos.Add(atrapa[1].ToString());
                    idsTipos.Add((int)atrapa[0]);
                }
            }

            return tipos;
        }

        public List<string> CargarObras(ref string mensaje, ref List<int> idsTipos) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);
            SqlDataReader atrapa = null;
            List<string> tipos = new List<string>();
            idsTipos.Clear();

            atrapa = manejaInterno.ConsultaReader(abierta, "select Id_Obra, Nombre from Obra;", ref mensaje);

            if (atrapa != null) {
                while (atrapa.Read()) {
                    tipos.Add(atrapa[1].ToString());
                    idsTipos.Add((int)atrapa[0]);
                }
            }

            return tipos;
        }

        public List<string> CargarMateriales(ref string mensaje, ref List<int> idsTipos) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);
            SqlDataReader atrapa = null;
            List<string> tipos = new List<string>();
            idsTipos.Clear();

            atrapa = manejaInterno.ConsultaReader(abierta, "select id_Material, Nombre from Material;", ref mensaje);

            if (atrapa != null) {
                while (atrapa.Read()) {
                    tipos.Add(atrapa[1].ToString());
                    idsTipos.Add((int)atrapa[0]);
                }
            }

            return tipos;
        }

        public List<string> CargarEtapas(ref string mensaje, ref List<int> idsTipos) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);
            SqlDataReader atrapa = null;
            List<string> tipos = new List<string>();
            idsTipos.Clear();

            atrapa = manejaInterno.ConsultaReader(abierta, "select id_TipoEtapa, CategoriaEtapa from Tipo_Etapa;", ref mensaje);

            if (atrapa != null) {
                while (atrapa.Read()) {
                    tipos.Add(atrapa[1].ToString());
                    idsTipos.Add((int)atrapa[0]);
                }
            }

            return tipos;
        }
        public void InsertarMaterial(string nom, string marca, string pres, string unidad, int idTipo, ref string mensaje) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);

            string cadenaInsert = "INSERT INTO Material(Nombre, Marca, Presentación, UnidadMedida, Tipo) VALUES('" + nom + "','" + marca + "','" + pres + "','" + unidad + "'," + idTipo + ")";
            manejaInterno.modificarBD(abierta, cadenaInsert, ref mensaje);

            abierta.Close();
        }

        public void InsertarRegistro(int obra, int prov, int mat, string fecha, float precio, int cantidad, string recibio, string entrego, string etapa, ref string mensaje) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);

            string cadenaInsert = "INSERT INTO Control_Obra(Obra, Proveedor, Material, Fecha, Precio, Cantidad, Recibio, Entrego, Etapa) VALUES(" + obra + "," + prov + "," + mat + ",'" + fecha + "'," + precio + "," + cantidad + ",'" + recibio + "','" + entrego + "','" + etapa + "')";
            manejaInterno.modificarBD(abierta, cadenaInsert, ref mensaje);

            abierta.Close();
        }

        public void InsertarSueldo(int empleado, float importe, string fecha, string descripcion, int obra, ref string mensaje) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);

            string cadenaInsert = "INSERT INTO Sueldo(id_Empleado, importe, fecha, descripcion, id_Obra) VALUES(" + empleado + "," + importe + ",'" + fecha + "','" + descripcion + "'," + obra + ")";
            manejaInterno.modificarBD(abierta, cadenaInsert, ref mensaje);

            abierta.Close();
        }

        public void InsertarEmpleado(string nom, string paterno, string materno, string direccion, string correo, string nss, int idTipo, string tel1, string tel2,ref string mensaje) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);

            string cadenaInsert = "INSERT INTO Empleado(Nombre, ApP, ApM, Direccion, correo, NSS, Tipo, tel1, tel2) VALUES('" + nom + "','" + paterno + "','" + materno + "','" + direccion + "','" + correo + "','" + nss + "'," + idTipo + ",'" + tel1 + "','" + tel2 + "')";
            manejaInterno.modificarBD(abierta, cadenaInsert, ref mensaje);

            abierta.Close();
        }

        public void InsertarDueno(string nom, string paterno, string materno, string direccion, string correo, string tel1, string tel2, ref string mensaje) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);

            string cadenaInsert = "INSERT INTO Dueno(Nombre, ApP, ApM, Direccion, correo, tel1, tel2) VALUES('" + nom + "','" + paterno + "','" + materno + "','" + direccion + "','" + correo + "','" + tel1 + "','" + tel2 + "')";
            manejaInterno.modificarBD(abierta, cadenaInsert, ref mensaje);

            abierta.Close();
        }

        public void InsertarProveedor(string nom, string direccion, string contacto, string tel1, string tel2, string correo, string pagina,ref string mensaje) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);

            string cadenaInsert = "INSERT INTO Proveedor(Nombre, Direccion, Contacto, tel1, tel2, correo, pagina) VALUES('" + nom + "','" + direccion + "','" + contacto + "','" + tel1 + "','" + tel2 + "','" + correo + "','" + pagina + "')";
            manejaInterno.modificarBD(abierta, cadenaInsert, ref mensaje);

            abierta.Close();
        }

        public void InsertarObra(string nom, string direccion, int encargado, int dueno, string fechainicio, string fechafin, ref string mensaje) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);

            string cadenaInsert = "INSERT INTO Obra(Nombre, Direccion, Encargado, Dueno, Fecha_inicio, Fecha_fin) VALUES('" + nom + "','" + direccion + "'," + encargado + "," + dueno + ",'" + fechainicio + "','" + fechafin + "')";
            manejaInterno.modificarBD(abierta, cadenaInsert, ref mensaje);

            abierta.Close();
        }

        public void InsertarCategoria(string nom, ref string mensaje, string tabla) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);

            string cadenaInsert = "INSERT INTO Tipo_" + tabla + "(Categoria"+ tabla + ") VALUES('" + nom + "')";
            manejaInterno.modificarBD(abierta, cadenaInsert, ref mensaje);

            abierta.Close();
        }

        public DataTable ListaMateriales(ref string mensaje) {
            DataSet atrapaMat = null;
            SqlConnection con = manejaInterno.Conectar(ref mensaje);
            string consulta = "select id_Material, Nombre, Marca, Presentación, UnidadMedida, Tipo as 'idTipo', CategoriaMaterial as Tipo from Material, Tipo_Material where Tipo=Id_TipoMaterial;";
            atrapaMat =  manejaInterno.ConsultaDataset(con, consulta, ref mensaje);

            con.Close();

            return atrapaMat.Tables[0];
        }

        public DataTable ListaDuenos(ref string mensaje) {
            DataSet atrapaMat = null;
            SqlConnection con = manejaInterno.Conectar(ref mensaje);
            string consulta = "select id_dueno, Nombre, ApP as 'Apellido paterno', ApM as 'Apellido materno', Direccion, correo as Correo, tel1 as 'Telefono 1', tel2 as 'Telefono 2'  from Dueno";
            atrapaMat = manejaInterno.ConsultaDataset(con, consulta, ref mensaje);

            con.Close();

            return atrapaMat.Tables[0];
        }

        public DataTable ListaProveedores(ref string mensaje) {
            DataSet atrapaMat = null;
            SqlConnection con = manejaInterno.Conectar(ref mensaje);
            string consulta = "select id_Prove, Nombre, Direccion, Contacto, tel1 as 'Teléfono 1', tel2 as 'Teléfono 2', correo as Correo, Pagina as 'Sitio Web' from Proveedor";
            atrapaMat = manejaInterno.ConsultaDataset(con, consulta, ref mensaje);

            con.Close();

            return atrapaMat.Tables[0];
        }
        public DataTable ListaEmpleados(ref string mensaje) {
            DataSet atrapaMat = null;
            SqlConnection con = manejaInterno.Conectar(ref mensaje);
            string consulta = "select id_Empleado, Nombre, ApP as 'Apellido paterno', ApM as 'Apellido materno', Direccion, correo as Correo, NSS, Tipo as 'idTipo', CategoriaEmpleado as Tipo, tel1 as 'Telefono 1', tel2 as 'Telefono 2'  from Empleado, Tipo_Empleado where Tipo=id_TipoEmpleado;";
            atrapaMat = manejaInterno.ConsultaDataset(con, consulta, ref mensaje);

            con.Close();

            return atrapaMat.Tables[0];
        }

        public DataTable ListaObras(ref string mensaje) {
            DataSet atrapaMat = null;
            SqlConnection con = manejaInterno.Conectar(ref mensaje);
            string consulta = "Select o.Id_Obra, o.Nombre, o.Direccion, e.Nombre + ' ' + e.ApP + ' ' + e.ApM as Encargado, o.Encargado as 'idEncargado', o.Dueno as 'idDueno',d.Nombre + ' ' + d.ApP + ' ' + d.ApM as Dueño, FORMAT(o.Fecha_Inicio, 'dd/MM/yyyy') as 'Fecha de inicio', FORMAT(o.Fecha_Fin, 'dd/MM/yyyy') as 'Fecha de finalización' from (Obra o join Empleado e on o.Encargado = e.id_Empleado) join Dueno d on o.Dueno=d.id_dueno;";
            atrapaMat = manejaInterno.ConsultaDataset(con, consulta, ref mensaje);

            con.Close();

            return atrapaMat.Tables[0];
        }

        public DataTable ListaRegistros(ref string mensaje) {
            DataSet atrapaMat = null;
            SqlConnection con = manejaInterno.Conectar(ref mensaje);
            string consulta = "Select c.id_Control, c.Proveedor as 'idProv', c.Obra as 'idObra', c.Material as 'idMaterial' ,o.Nombre as 'Nombre de la obra', p.Nombre as 'Nombre del proveedor', m.Nombre as 'Material utilizado', FORMAT(c.Fecha, 'dd/MM/yyyy') as Fecha, c.Precio, c.Cantidad, c.Recibio, c.Entrego, c.Etapa as 'Etapa de la obra' from (((Control_Obra c join Obra o on c.Obra = o.Id_Obra) join Proveedor p on c.Proveedor=p.id_Prove) join Material m on c.Material=m.id_Material);";
            atrapaMat = manejaInterno.ConsultaDataset(con, consulta, ref mensaje);

            con.Close();

            return atrapaMat.Tables[0];
        }

        public DataTable ListaSueldos(ref string mensaje) {
            DataSet atrapaMat = null;
            SqlConnection con = manejaInterno.Conectar(ref mensaje);
            string consulta = "Select s.id_Sueldo, s.id_Obra as 'idObra', s.id_Empleado as 'idEmpleado',o.Nombre as 'Nombre de la obra', e.Nombre + ' ' + e.ApP + ' ' + e.ApM as 'Nombre del empleado', FORMAT(s.Fecha, 'dd/MM/yyyy') as 'Fecha de pago', s.importe as 'Importe',s.descripcion as 'Descripcion del pago' from (Sueldo s join Obra o on s.id_Obra=o.Id_Obra) join Empleado e on s.id_Empleado=e.id_Empleado";
            atrapaMat = manejaInterno.ConsultaDataset(con, consulta, ref mensaje);

            con.Close();

            return atrapaMat.Tables[0];
        }

        public DataTable ListaMaterialesPorFecha(int obra, string fechaInicio, string fechaFin, ref string mensaje, ref float totalImporteMateriales) {
            DataSet atrapaMat = null;
            SqlConnection con = manejaInterno.Conectar(ref mensaje);
            string consulta = "Select m.Nombre as 'Nombre de material', m.Marca, m.Presentación, c.Precio as 'Precio unitario', c.Cantidad, c.Precio * c.Cantidad as 'Importe total', FORMAT(c.Fecha, 'dd/MM/yyyy') as 'Fecha de compra' from Control_Obra c join Material m on c.Material=m.id_Material where Obra =" + obra +" and (c.Fecha between '" + fechaInicio + "' and '" + fechaFin + "');";
            atrapaMat = manejaInterno.ConsultaDataset(con, consulta, ref mensaje);

            foreach (DataRow campo in atrapaMat.Tables[0].Rows) {
                totalImporteMateriales += Convert.ToSingle(campo[5]);
            }

            //atrapaMat.Tables[0].Rows.Add("TOTAL", "", "", 0, 0, total);

            con.Close();

            return atrapaMat.Tables[0];
        }

        public DataTable ListasueldosPorFecha(int obra, string fechaInicio, string fechaFin, ref string mensaje, ref float totalImporteSueldos) {
            DataSet atrapaMat = null;
            SqlConnection con = manejaInterno.Conectar(ref mensaje);
            string consulta = "select e.Nombre + ' ' + e.ApP + ' ' + e.ApM as 'Nombre del empleado', s.importe as 'Sueldo pagado', s.descripcion as 'Descripcion', FORMAT(s.fecha, 'dd/MM/yyyy') as 'Fecha de pago' from (Sueldo s join Obra o on s.id_Obra = o.Id_Obra) join Empleado e on s.id_Empleado = e.id_Empleado where s.id_Obra = " + obra + " and (s.Fecha between '" + fechaInicio + "' and '" + fechaFin + "');";
            atrapaMat = manejaInterno.ConsultaDataset(con, consulta, ref mensaje);

            foreach (DataRow campo in atrapaMat.Tables[0].Rows) {
                totalImporteSueldos += Convert.ToSingle(campo[1]);
            }

            //atrapaMat.Tables[0].Rows.Add("TOTAL", "", "", 0, 0, total);
            con.Close();

            return atrapaMat.Tables[0];
        }

        public string[] obtenerTotales(ref string mensaje) {
            SqlDataReader atrapa = null;
            string[] totales = new string[7];
            SqlConnection con = manejaInterno.Conectar(ref mensaje);
            string consulta = "SELECT sysobjects.name, sysindexes.Rows FROM sysobjects INNER JOIN sysindexes ON sysobjects.id = sysindexes.id WHERE type = 'U' AND sysindexes.IndId < 2 AND(sysobjects.name not like 'Tipo%' and sysobjects.name not like '%sys%') ORDER BY sysobjects.name";
            int indice = 0;
            atrapa = manejaInterno.ConsultaReader(con, consulta,ref mensaje);

            if(atrapa != null) {
                while (atrapa.Read()) {
                    totales[indice] = atrapa[1].ToString();
                    indice++;
                }
            }

            return totales;
        }

        //Actualizar registros

        public void ActualizarMaterial(int id,string nom, string marca, string pres, string unidad, int idTipo, ref string mensaje) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);

            string cadenaInsert = "UPDATE Material SET Nombre='" + nom + "', Marca='" + marca + "', Presentación='" + pres + "', UnidadMedida='" + unidad + "', Tipo=" + idTipo + " where id_Material=" + id;
            manejaInterno.modificarBD(abierta, cadenaInsert, ref mensaje);

            abierta.Close();
        }

        public void ActualizarEmpleado(int idEmp, string nom, string paterno, string materno, string direccion, string correo, string nss, int idTipo, string tel1, string tel2, ref string mensaje) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);

            string cadenaInsert = "UPDATE Empleado SET Nombre='" + nom + "',ApP='" + paterno + "',ApM='" + materno + "',Direccion='" + direccion + "', correo='" + correo + "',NSS='" + nss + "',Tipo=" + idTipo + ",tel1='" + tel1 + "',tel2='" + tel2 + "' where id_Empleado=" + idEmp;
            manejaInterno.modificarBD(abierta, cadenaInsert, ref mensaje);

            abierta.Close();
        }

        public void ActualizarDueno(int idDueno, string nom, string paterno, string materno, string direccion, string correo, string tel1, string tel2, ref string mensaje) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);

            string cadenaInsert = "UPDATE Dueno SET Nombre='" + nom + "',ApP='" + paterno + "',ApM='" + materno + "',Direccion='" + direccion + "', correo='" + correo + "',tel1='" + tel1 + "',tel2='" + tel2 + "' where id_dueno=" + idDueno;
            manejaInterno.modificarBD(abierta, cadenaInsert, ref mensaje);

            abierta.Close();
        }

        public void ActualizarProveedor(int idProv, string nom, string direccion, string contacto, string tel1, string tel2, string correo, string pagina, ref string mensaje) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);

            string cadenaInsert = "UPDATE Proveedor SET Nombre='" + nom + "',Direccion='" + direccion + "',Contacto='" + contacto + "',tel1='" + tel1 + "', tel2='" + tel2 + "',correo='" + correo + "',pagina='" + pagina + "' where id_Prove=" + idProv;
            manejaInterno.modificarBD(abierta, cadenaInsert, ref mensaje);

            abierta.Close();
        }

        public void ActualizarObra(int obra, string nom, string direccion, int idEmp, int idDueno, DateTime fechaInicio, DateTime fechaFin, ref string mensaje) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);

            string cadenaInsert = "UPDATE Obra SET Nombre='" + nom + "', Direccion='" + direccion + "', Encargado=" + idEmp + ", Dueno=" + idDueno + ", Fecha_inicio='" + fechaInicio.ToString("yyyy-MM-dd") + "', Fecha_fin='" + fechaFin.ToString("yyyy-MM-dd") +"' where Id_Obra=" + obra;
            manejaInterno.modificarBD(abierta, cadenaInsert, ref mensaje);

            abierta.Close();
        }

        public void ActualizarControl(int control, int obra, int prov, int mat, DateTime fecha, float precio, int cantidad, string entrego, string recibio, string etapa, ref string mensaje) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);

            string cadenaInsert = "UPDATE Control_Obra SET Obra=" + obra + ", Proveedor=" + prov + ", Material=" + mat + ", Fecha='" + fecha.ToString("yyyy-MM-dd") + "', Precio=" + precio + ", Cantidad=" + cantidad + ",Entrego='" + entrego + "', Recibio='" + recibio + "' where id_Control=" + control;
            manejaInterno.modificarBD(abierta, cadenaInsert, ref mensaje);

            abierta.Close();
        }

        public void ActualizarSueldo(int sueldo, int obra, int empleado, float importe, DateTime fecha, string descripcion, ref string mensaje) {
            SqlConnection abierta = manejaInterno.Conectar(ref mensaje);

            string cadenaInsert = "UPDATE Sueldo SET id_Obra=" + obra + ", id_Empleado=" + empleado + ", importe=" + importe + ", fecha='" + fecha.ToString("yyyy-MM-dd") + "', descripcion='" + descripcion + "' where id_Sueldo=" + sueldo;
            manejaInterno.modificarBD(abierta, cadenaInsert, ref mensaje);

            abierta.Close();
        }


    }
}