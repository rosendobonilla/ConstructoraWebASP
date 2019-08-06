<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ControlObra.aspx.cs" Inherits="WebConstructura.ControlObra" %>

<%@ MasterType VirtualPath="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="content">

        <div class="contact1">
            <div class="container-contact1">

                <div class="contact1-form validate-form">
                    <span class="contact1-form-title">Agregar nuevo control
                    </span>
                    <label for="dropListObra" class="left">Obra</label>
                    <asp:DropDownList ID="dropListObra" CssClass="input1" runat="server" AutoPostBack="True" Height="45px" Width="100%">
                    </asp:DropDownList>

                    <label for="dropListProveedor" class="left">Proveedor</label>
                    <asp:DropDownList ID="dropListProveedor" CssClass="input1" runat="server" AutoPostBack="True" Height="45px" Width="100%">
                    </asp:DropDownList>

                    <label for="dropListMaterial" class="left">Material</label>
                    <asp:DropDownList ID="dropListMaterial" CssClass="input1" runat="server" AutoPostBack="True" Height="45px" Width="100%">
                    </asp:DropDownList>

                    <div class="container-contact1-form-btn mb-2 mt-3">
                        <asp:TextBox ID="txtPrecio" placeholder="Precio" runat="server" CssClass="input1"></asp:TextBox>
                    </div>

                    <div class="container-contact1-form-btn mb-2">
                        <asp:TextBox ID="txtCantidad" placeholder="Cantidad" runat="server" CssClass="input1"></asp:TextBox>
                    </div>

                    <div class="form-group">
                        <asp:TextBox ID="txtRecibio" placeholder="Recibió" runat="server" CssClass="input1"></asp:TextBox>
                    </div>

                    <div class="container-contact1-form-btn mb-2">
                        <asp:TextBox ID="txtEntrego" placeholder="Entregó" runat="server" CssClass="input1"></asp:TextBox>
                    </div>

                    <div class="container-contact1-form-btn mb-2">
                        <asp:TextBox ID="txtEtapa" placeholder="Etapa" runat="server" CssClass="input1"></asp:TextBox>
                    </div>

                    <br />

                    <div class="modal fade" id="modalCalendarFecha" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle"
                        aria-hidden="true">
                        <div class="modal-dialog modal-dialog-centered" role="document">
                            <div class="modal-content">
                                <div class="modal-body">
                                    <div class="form-group mt-3">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                            <ContentTemplate>
                                                <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="100%" OnSelectionChanged="Calendar1_SelectionChanged">
                                                    <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                                                    <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                                                    <OtherMonthDayStyle ForeColor="#999999" />
                                                    <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                                                    <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                                                    <TodayDayStyle BackColor="#CCCCCC" />
                                                </asp:Calendar>

                                            </ContentTemplate>
                                        </asp:UpdatePanel>

                                        <br />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>



                    <asp:UpdatePanel runat="server" ID="panelFecha" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="input-group mb-3">
                                <asp:TextBox ID="txtFecha" Enabled="false" runat="server" CssClass="form-control" placeholder="Fecha"></asp:TextBox>
                                <div class="input-group-append">
                                    <asp:Button ID="botonFecha" CssClass="btn btn-md btn-secondary m-0 px-3" runat="server" Text="Elegir fecha" data-toggle="modal" data-target="#modalCalendarFecha" OnClick="botonFecha_Click" />
                                </div>
                            </div>
                            <asp:Label ID="labelFecha" runat="server" Text="Label" Visible="False"></asp:Label>

                        </ContentTemplate>
                    </asp:UpdatePanel>


                    <br />
                    <br />
                    <div class="container-contact1-form-btn mb-2">

                        <asp:Button ID="botonAgregarRegistro" runat="server" Text="Agregar control de obra" CssClass="contact1-form-btn" OnClick="botonAgregarObra_Click1" />
                    </div>
                    <div class="container-contact1-form-btn mb-2">

                        <asp:Button ID="botonMostrarRegistros" data-toggle="modal" data-target="#modalRegistros" runat="server" Text="Mostrar registros de obras" CssClass="contact1-form-btn" OnClick="botonMostrarObras_Click" />
                    </div>


                </div>
            </div>
        </div>


        <div class="modal fade high" id="modalRegistros" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
            aria-hidden="true">
            <div class="modal-dialog modal-full-height modal-top" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title w-100">Lista de registros - Control de obras</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" CellPadding="4" GridLines="Horizontal" Width="100%" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px"
                                    AutoGenerateColumns="false" DataKeyNames="id_Control" OnRowDataBound="GridView1_RowDataBound"
                                    OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                                    OnRowUpdating="GridView1_RowUpdating" AllowPaging="true" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging">
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
                                        <asp:TemplateField HeaderText="Obra">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Nombre de la obra") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="dropListEditObra" Width="150" runat="server">
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Proveedor">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Nombre del proveedor") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="dropListEditProveedor" runat="server">
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Material">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Material utilizado") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="dropListEditMaterial" runat="server">
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Precio">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Precio") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditPrecio" Width="80" Text='<%# Eval("Precio") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Cantidad">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Cantidad") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditCantidad" Width="80" Text='<%# Eval("Cantidad") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Fecha">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Fecha") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditFecha" Width="80" Text='<%# Eval("Fecha") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Recibio">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Recibio") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditRecibio" Text='<%# Eval("Recibio") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Entrego">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Entrego") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditEntrego" Text='<%# Eval("Entrego") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Etapa">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Etapa de la obra") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditEtapa" Width="90" Text='<%# Eval("Etapa de la obra") %>' runat="server" />
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
