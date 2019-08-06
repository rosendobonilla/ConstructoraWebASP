<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WebConstructura.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="contact1">
        <div class="text-center mt-4 mb-3 titulo-dashboard">
            <h4><strong>Total de registros</strong></h4>
        </div>

        <div class="cards-list">

            <div class="card 1">
                <div class="card_image">
                    <asp:ImageButton CssClass="imagen" ImageUrl="imagenes/empleados.jpg" runat="server" />
                </div>
                <div class="card_title title-black">
                    <div id="totalEmpleados" runat="server">Empleados</div>
                </div>
            </div>

            <div class="card 1">
                <div class="card_image">
                    <asp:ImageButton CssClass="imagen" ImageUrl="imagenes/dueños.jpg" runat="server" />
                </div>
                <div class="card_title title-black">
                    <div id="totalDuenos" runat="server">Dueños</div>
                </div>
            </div>

            <div class="card 2">
                <div class="card_image">
                    <asp:ImageButton CssClass="imagen" ImageUrl="imagenes/materiales.png" runat="server" />
                </div>
                <div class="card_title title-black">
                    <div id="totalMateriales" runat="server">Materiales</div>
                </div>
            </div>

            <div class="card 3">
                <div class="card_image">
                    <asp:ImageButton CssClass="imagen" ImageUrl="imagenes/proveedor.png" runat="server" />
                </div>
                <div class="card_title">
                    <div id="totalProveedores" runat="server">Proveedores</div>
                </div>
            </div>

            <div class="card 4">
                <div class="card_image">
                    <asp:ImageButton CssClass="imagen" ImageUrl="imagenes/obras.jpg" runat="server" />
                </div>
                <div class="card_title title-black">
                    <div id="totalObras" runat="server">Obras</div>
                </div>
            </div>

            <div class="card 4">
                <div class="card_image">
                    <asp:ImageButton CssClass="imagen" ImageUrl="imagenes/sueldos.jpg" runat="server" />
                </div>
                <div class="card_title title-black">
                    <div id="totalSueldos" runat="server">Sueldos</div>
                </div>
            </div>

            <div class="card 4">
                <div class="card_image">
                    <asp:ImageButton CssClass="imagen" ImageUrl="imagenes/control.jpg" runat="server" />
                </div>
                <div class="card_title title-black">
                    <div id="totalControl" runat="server">Control obras</div>
                </div>
            </div>
        </div>

        <div class="container-contact2 mt-5">
            <span class="contact1-form-title">Consultar costo de la obra
            </span>

            <asp:DropDownList ID="dropListObra" CssClass="input1 mb-2" runat="server" AutoPostBack="True" Height="45px" Width="100%">
            </asp:DropDownList>

            <br />

            <div class="modal fade" id="modalCalendarInicio" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle"
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


            <div class="modal fade" id="modalCalendarFin" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle"
                aria-hidden="true">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-body">
                            <div class="form-group mt-3">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
                                    <ContentTemplate>
                                        <asp:Calendar ID="Calendar2" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="100%" OnSelectionChanged="Calendar2_SelectionChanged">
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



            <asp:UpdatePanel runat="server" ID="panelFechaInicio" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="input-group mb-3">
                        <asp:TextBox ID="txtFechaInicio" runat="server" CssClass="form-control" Enabled="false" placeholder="Fecha inicio"></asp:TextBox>
                        <div class="input-group-append">
                            <asp:Button ID="botonFechaInicio" CssClass="btn btn-md btn-secondary m-0 px-3" runat="server" Text="Elegir fecha" data-toggle="modal" data-target="#modalCalendarInicio" OnClick="botonFecha_Click" />
                        </div>
                    </div>
                    <asp:Label ID="labelFechaInicio" runat="server" Text="Label" Visible="False"></asp:Label>

                </ContentTemplate>
            </asp:UpdatePanel>

            <asp:UpdatePanel runat="server" ID="panelFechaFin" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="input-group mb-3">
                        <asp:TextBox ID="txtFechaFin" runat="server" CssClass="form-control" placeholder="Fecha fin" Enabled="false"></asp:TextBox>
                        <div class="input-group-append">
                            <asp:Button ID="botonFechafin" CssClass="btn btn-md btn-secondary m-0 px-3" runat="server" Text="Elegir fecha" data-toggle="modal" data-target="#modalCalendarFin" OnClick="botonFechafin_Click" />
                        </div>
                    </div>
                    <asp:Label ID="labelFechaFin" runat="server" Text="Label" Visible="False"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>

            <div class="container-contact1-form-btn">
                <asp:Button ID="botonMostrarCosto" runat="server" Text="Consultar costo" CssClass="contact1-form-btn" OnClick="botonMostrarCosto_Click" />
            </div>

        </div>


        <div class="resultados-costos mt-4">

            <div id="divTotalImporteMateriales" class="h5" runat="server"></div>

            <asp:GridView ID="gridMateriales" runat="server" BackColor="White" BorderColor="#CCCCCC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%"
                AllowPaging="true" PageSize="10" OnPageIndexChanging="gridMateriales_PageIndexChanging">
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>

            <br />
            <div id="divTotalImporteSueldos" class="h5" runat="server"></div>

            <asp:GridView ID="gridSueldos" runat="server" BackColor="White" BorderColor="#CCCCCC" 
                BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%"
                AllowPaging="true" PageSize="10" OnPageIndexChanging="gridSueldos_PageIndexChanging">
                <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F7F7F7" />
                <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                <SortedDescendingCellStyle BackColor="#E5E5E5" />
                <SortedDescendingHeaderStyle BackColor="#242121" />
            </asp:GridView>

            <br />
            <div id="divTotalGlobal" class="h5 text-danger" runat="server"></div>
        </div>


    </div>







</asp:Content>
