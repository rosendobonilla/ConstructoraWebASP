<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Dueno.aspx.cs" Inherits="WebConstructura.Dueno" %>

<%@ MasterType VirtualPath="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content">

        <div class="contact1">
            <div class="container-contact1">

                <div class="contact1-form validate-form">
                    <span class="contact1-form-title">Agregar nuevo dueño
                    </span>

                    <div class="wrap-input1 validate-input">
                        <asp:TextBox ID="txtNomDueno" placeholder="Nombre" runat="server" CssClass="input1"></asp:TextBox>
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
                        <asp:TextBox ID="txtTel1" placeholder="Teléfono 1" runat="server" CssClass="input1"></asp:TextBox>
                    </div>

                    <div class="wrap-input1 validate-input">
                        <asp:TextBox ID="txtTel2" placeholder="Teléfono 2" runat="server" CssClass="input1"></asp:TextBox>
                    </div>

                    <div class="container-contact1-form-btn mb-2">
                        <asp:Button ID="botonAgregarDueno" runat="server" Text="Agregar dueño" CssClass="contact1-form-btn" OnClick="botonAgregarDueno_Click" />
                    </div>

                    <div class="container-contact1-form-btn mb-2">
                        <asp:Button ID="botonMostrarDuenos" data-toggle="modal" data-target="#modalEmpleados" runat="server" Text="Mostrar dueños" CssClass="contact1-form-btn" OnClick="botonMostrarDuenos_Click" />
                    </div>

                </div>

            </div>
        </div>


        <div class="modal fade high" id="modalDuenos" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
            aria-hidden="true">
            <div class="modal-dialog modal-full-height modal-top" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title w-100">Lista de dueños</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <asp:ScriptManager runat="server" />
                        <asp:UpdatePanel runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" CellPadding="4" GridLines="Horizontal" Width="100%" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px"
                                    DataKeyNames="id_dueno" OnRowEditing="GridView1_RowEditing" AutoGenerateColumns="false"
                                    OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating"
                                    AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging">
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
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditNombre" Text='<%# Eval("Nombre") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="A. paterno">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Apellido paterno") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditPaterno" Text='<%# Eval("Apellido paterno") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="A. materno">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Apellido materno") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditMaterno" Text='<%# Eval("Apellido materno") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Dirección">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Direccion") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditDireccion" Text='<%# Eval("Direccion") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Correo">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Correo") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditCorreo" Text='<%# Eval("Correo") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Teléfono 1">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Telefono 1") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditTel1" Text='<%# Eval("Telefono 1") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Teléfono 2">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Telefono 2") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditTel2" Text='<%# Eval("Telefono 2") %>' runat="server" />
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

    </div>



</asp:Content>
