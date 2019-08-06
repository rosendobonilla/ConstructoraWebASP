<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Empleado.aspx.cs" Inherits="WebConstructura.Empleado" %>
<%@ MasterType VirtualPath="~/MasterPage.Master" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contact1">
        <div class="container-contact1">

            <div class="contact1-form validate-form">
                <span class="contact1-form-title">Agregar nuevo empleado
                </span>

                <div class="wrap-input1 validate-input">
                    <asp:TextBox ID="txtNomEmpleado" placeholder="Nombre del empleado" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <div class="wrap-input1 validate-input">
                    <asp:TextBox ID="txtPaterno" placeholder="Apellido paterno" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <div class="wrap-input1 validate-input">
                    <asp:TextBox ID="txtMaterno" placeholder="Apellido materno" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <div class="wrap-input1 validate-input">
                    <asp:TextBox ID="txtDireccion" placeholder="Direccion" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <div class="wrap-input1 validate-input">
                    <asp:TextBox ID="txtCorreo" placeholder="Correo" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <div class="wrap-input1 validate-input">
                    <asp:TextBox ID="txtNss" placeholder="Número de seguridad social" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <div class="wrap-input1 validate-input">
                    <asp:TextBox ID="txtTel1" placeholder="Teléfono 1" runat="server" CssClass="input1"></asp:TextBox>
                </div>

                <div class="wrap-input1 validate-input">
                    <asp:TextBox ID="txtTel2" runat="server" placeholder="Teléfono 2" CssClass="input1"></asp:TextBox>
                </div>

                <label for="dropListTipoEmpleado" class="center">Categoría empleado</label>
                <asp:DropDownList ID="dropListTipoEmpleado" CssClass="input1" runat="server" AutoPostBack="True" Height="45px" Width="100%">
                </asp:DropDownList>

                <div class="container-contact1-form-btn mb-2 mt-3">
                    <asp:Button ID="botonAgregarMaterial" runat="server" Text="Agregar empleado" CssClass="contact1-form-btn" OnClick="botonAgregarMaterial_Click" />

                </div>
                <div class="container-contact1-form-btn mb-2">
                    <asp:Button ID="botonMostrarMateriales" data-toggle="modal" data-target="#modalEmpleados" runat="server" Text="Mostrar empleados" CssClass="contact1-form-btn" OnClick="botonMostrarMateriales_Click" />
                </div>

                <div class="container-contact1-form-btn mb-2 mt-3">
                    <button type="button" class="contact1-form-btn" data-toggle="modal" data-target="#modalTipoEmpleado">
                        Agregar nueva categoria
                    </button>
                </div>

            </div>
        </div>
    </div>


    <div class="modal fade high" id="modalEmpleados" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
        aria-hidden="true">
        <div class="modal-dialog modal-full-height modal-top" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title w-100">Lista de empleados</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                        <ContentTemplate>
                            <asp:GridView ID="GridView1" runat="server" CellPadding="4" GridLines="Horizontal" Width="100%" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px"
                                DataKeyNames="id_Empleado" AutoGenerateColumns="false" OnRowEditing="GridView1_RowEditing"
                                OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" 
                                OnRowDataBound="GridView1_RowDataBound" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging">
                                <FooterStyle BackColor="White" ForeColor="#333333" />
                                <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                                <RowStyle BackColor="White" ForeColor="#333333" />
                                <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                <SortedAscendingHeaderStyle BackColor="#487575" />
                                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                <SortedDescendingHeaderStyle BackColor="#275353" />

                                <Columns>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("Nombre") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditNombre" Text='<%# Eval("Nombre") %>' Width="70" runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="A. paterno">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("Apellido paterno") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditPaterno" Text='<%# Eval("Apellido paterno") %>' Width="70" runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="A. materno">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("Apellido materno") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditMaterno" Text='<%# Eval("Apellido materno") %>' Width="70" runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Dirección">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("Direccion") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditDireccion" Text='<%# Eval("Direccion") %>' Width="100" runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Correo">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("Correo") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditCorreo" Text='<%# Eval("Correo") %>' Width="100" runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="NSS">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("NSS") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditNSS" Text='<%# Eval("NSS") %>' Width="70" runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Tipo">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("Tipo") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:DropDownList ID="dropListEditTipo" runat="server">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Teléfono 1">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("Telefono 1") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditTel1" Text='<%# Eval("Telefono 1") %>' Width="70" runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Teléfono 2">
                                        <ItemTemplate>
                                            <asp:Label Text='<%# Eval("Telefono 2") %>' runat="server" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditTel2" Text='<%# Eval("Telefono 2") %>' Width="70" runat="server" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <asp:ImageButton ImageUrl="~/icons/edit.png" runat="server" CommandName="Edit" ToolTip="Editar registro" />
                                            <%--                                        <asp:ImageButton ImageUrl="~/icons/delete.png" runat="server" CommandName="Delete" ToolTip="Eliminar registro" />--%>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:ImageButton ImageUrl="~/icons/save.png" runat="server" CommandName="Update" ToolTip="Guardar cambios" />
                                            <asp:ImageButton ImageUrl="~/icons/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancelar" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>


                                </Columns>

                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <asp:Label ID="labelMensajesGrid" runat="server" />


                </div>
            </div>
        </div>
    </div>

    <div class="modal fade bottom high" id="modalTipoEmpleado" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
        aria-hidden="true">

        <div class="modal-dialog modal-full-height modal-bottom" role="document">


            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title w-100" id="myModalLabel">Nueva categoría de empleado</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="txtNombreCategoria">Nombre</label>
                        <asp:TextBox ID="txtNombreCategoria" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="modal-footer justify-content-center">
                    <button type="button" class="btn btn-secondary btn-sm" data-dismiss="modal">Cancelar</button>
                    <asp:Button ID="botonAgregarCategoria" runat="server" Text="Agregar categoría" CssClass="btn btn-secondary btn-sm" OnClick="botonAgregarCategoria_Click" />
                </div>
            </div>
        </div>
    </div>
                            

</asp:Content>
