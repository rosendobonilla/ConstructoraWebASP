<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master"  AutoEventWireup="true" CodeBehind="Materiales.aspx.cs" Inherits="WebConstructura.WebForm1" %>
<%@ MasterType VirtualPath="~/MasterPage.Master" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="page-content">
        <div class="contact1">
            <div class="container-contact1">

                <div class="contact1-form validate-form">
                    <span class="contact1-form-title">Agregar nuevo material
                    </span>

                    <div class="wrap-input1 validate-input">
                        <asp:TextBox ID="txtNomMaterial" placeholder="Nombre del material" runat="server" CssClass="input1"></asp:TextBox>
                        <span class="shadow-input1"></span>
                    </div>

                    <div class="wrap-input1 validate-input">
                        <asp:TextBox ID="txtMarca" placeholder="Marca" runat="server" CssClass="input1"></asp:TextBox>
                        <span class="shadow-input1"></span>
                    </div>

                    <div class="wrap-input1 validate-input">
                        <asp:TextBox ID="txtPresentacion" placeholder="Presentación" runat="server" CssClass="input1"></asp:TextBox>
                        <span class="shadow-input1"></span>
                    </div>

                    <div class="wrap-input1 validate-input">
                        <asp:TextBox ID="txtUnidad" placeholder="Unidad de medida" runat="server" CssClass="input1"></asp:TextBox>
                        <span class="shadow-input1"></span>
                    </div>

                    <div class="wrap-input1 validate-input">
                        <label for="dropListTipo" class="left">Tipo de material</label>
                        <asp:DropDownList ID="dropListTipo" CssClass="input1" runat="server" AutoPostBack="True" Height="45px" Width="100%" OnSelectedIndexChanged="dropListTipo_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>

                    <div class="container-contact1-form-btn mb-2">
                        <asp:Button ID="botonAgregarMaterial" runat="server" OnClick="botonAgregarMaterial_Click" Text="Agregar material" CssClass="contact1-form-btn" />
                    </div>
                    <div class="container-contact1-form-btn mb-2">
                        <asp:Button ID="botonMostrarMateriales" data-toggle="modal" data-target="#myModal" runat="server" OnClick="botonMostrarMateriales_Click" Text="Mostrar materiales" CssClass="contact1-form-btn" />
                    </div>
                    <div class="container-contact1-form-btn mb-2">
                        <button type="button" class="contact1-form-btn" data-toggle="modal" data-target="#modalTipoMaterial">
                            Agregar nueva categoría
                        </button>
                    </div>

                </div>
            </div>
        </div>




        <div class="modal fade high" id="modalMateriales" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
            aria-hidden="true">
            <div class="modal-dialog modal-full-height modal-top" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title w-100">Lista de materiales</h4>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                            <ContentTemplate>
                                <asp:GridView ID="GridView1" runat="server" CellPadding="4" GridLines="Horizontal" Width="100%" BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px"
                                    AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" 
                                    OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" 
                                    DataKeyNames="id_Material" OnRowDataBound="GridView1_RowDataBound" AllowPaging="True" 
                                    PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging">

                                    <FooterStyle BackColor="White" ForeColor="#333333" />
                                    <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" Wrap="false" VerticalAlign="Middle"/>
                                    <RowStyle BackColor="White" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                                    <SortedAscendingHeaderStyle BackColor="#487575" />
                                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                                    <SortedDescendingHeaderStyle BackColor="#275353" />

                                    <Columns>
                                        <asp:TemplateField HeaderText="Nombre del material">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Nombre") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditNombre" Text='<%# Eval("Nombre") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Marca">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Marca") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditMarca" Text='<%# Eval("Marca") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Presentación">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("Presentación") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditPresentacion" Text='<%# Eval("Presentación") %>' runat="server" />
                                            </EditItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Unidad de medida">
                                            <ItemTemplate>
                                                <asp:Label Text='<%# Eval("UnidadMedida") %>' runat="server" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox BackColor="#e1e6ed" BorderColor="Black" ID="txtEditUnidad" Text='<%# Eval("UnidadMedida") %>' runat="server" />
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

        <div class="modal fade bottom high" id="modalTipoMaterial" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">

            <div class="modal-dialog modal-full-height modal-bottom" role="document">


                <div class="modal-content">
                    <div class="modal-header">
                        <h4 class="modal-title w-100" id="myModalLabel">Nueva categoría de material</h4>
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

    </div>

</asp:Content>

