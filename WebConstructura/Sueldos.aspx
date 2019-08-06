<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Sueldos.aspx.cs" Inherits="WebConstructura.Sueldos" %>
<%@ MasterType VirtualPath="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="content">

        <div class="contact1">
            <div class="container-contact1">

                <div class="contact1-form validate-form">
                    <span class="contact1-form-title">Agregar nuevo sueldo
                    </span>

                    <label for="dropListObra" class="left">Obra</label>
                    <asp:DropDownList ID="dropListObra" CssClass="input1" runat="server" AutoPostBack="True" Height="45px" Width="100%">
                    </asp:DropDownList>

                    <label for="dropListEmpleado" class="left">Empleado</label>
                    <asp:DropDownList ID="dropListEmpleado" CssClass="input1" runat="server" AutoPostBack="True" Height="45px" Width="100%">
                    </asp:DropDownList>

                    <div class="wrap-input1 validate-input">
                        <asp:TextBox ID="txtImporte" placeholder="Importe" runat="server" CssClass="input1 mt-3"></asp:TextBox>
                    </div>

                    <div class="wrap-input1 validate-input">
                        <asp:TextBox ID="txtDescripcion" placeholder="Descripcion del pago" runat="server" CssClass="input1"></asp:TextBox>
                    </div>

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


                    <div class="container-contact1-form-btn mb-2">
                        <asp:Button ID="botonAgregarSueldo" runat="server" Text="Agregar sueldo" CssClass="contact1-form-btn" OnClick="botonAgregarSueldo_Click" />
                    </div>

                    <div class="container-contact1-form-btn mb-2">
                        <asp:Button ID="botonMostrarSueldos" data-toggle="modal" data-target="#modalSueldos" runat="server" Text="Mostrar sueldos" CssClass="contact1-form-btn" OnClick="botonMostrarSueldos_Click" />
                    </div>

                </div>
            </div>
        </div>


        <div class="modal fade high" id="modalSueldos" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
            aria-hidden="true">
            <div class="modal-dialog modal-full-height modal-top" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title w-100">Lista de sueldos de los empleados</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <asp:UpdatePanel runat="server" ChildrenAsTriggers="true" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" CellPadding="4" GridLines="Horizontal" Width="100%" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px"
                                    AutoGenerateColumns="false" DataKeyNames="id_Sueldo" OnRowDataBound="GridView1_RowDataBound"
                                    OnRowEditing="GridView1_RowEditing" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
                                    OnRowUpdating="GridView1_RowUpdating" AllowPaging="true" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging">
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
                                                <asp:DropDownList ID="dropListEditObra" runat="server">
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Empleado">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Nombre del empleado") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:DropDownList ID="dropListEditEmpleado" runat="server">
                                                </asp:DropDownList>
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Fecha">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Fecha de pago") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditFecha" Text='<%# Eval("Fecha de pago") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Importe">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Importe") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditImporte" Text='<%# Eval("Importe") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Descripcion">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Descripcion del pago") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditDescripcion" Text='<%# Eval("Descripcion del pago") %>' runat="server" />
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
