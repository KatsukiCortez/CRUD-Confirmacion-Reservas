<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarTour.aspx.cs" Inherits="reservaTour.conexion.AgregarTour1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Administrar Tours y Clientes</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Administrar Tours</h1>

            <!-- Formulario para agregar un nuevo tour -->
            <div style="margin-bottom: 20px;">
                <h2>Agregar Nuevo Tour</h2>
                <div>
                    <label for="txtNombre">Nombre del Tour:</label>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label for="txtDescripcion">Descripción:</label>
                    <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
                </div>
                <div>
                    <label for="txtPrecio">Precio:</label>
                    <asp:TextBox ID="txtPrecio" runat="server" TextMode="Number"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btnAgregarTour" runat="server" Text="Agregar Tour" OnClick="btnAgregarTour_Click" />
                </div>
                <!-- Control Literal para mostrar mensajes -->
                <asp:Literal ID="lblMensaje" runat="server" Visible="false" />
            </div>

            <!-- Lista de Tours (se mostrará después de agregar un nuevo tour) -->
            <h2>Listado de Tours</h2>
            <asp:GridView ID="GridViewTours" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                </Columns>
            </asp:GridView>
        </div>

        <div style="margin-top: 20px;">
            <h1>Administrar Clientes</h1>

            <!-- Formulario para agregar un nuevo cliente -->
            <div style="margin-bottom: 20px;">
                <h2>Agregar Nuevo Cliente</h2>
                <div>
                    <label for="txtIdCliente">ID Cliente:</label>
                    <asp:TextBox ID="txtIdCliente" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label for="txtNombreCliente">Nombre:</label>
                    <asp:TextBox ID="txtNombreCliente" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label for="txtEmail">Email:</label>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                </div>
                <div>
                    <label for="txtTelefono">Teléfono:</label>
                    <asp:TextBox ID="txtTelefono" runat="server"></asp:TextBox>
                </div>
                <div>
                    <asp:Button ID="btnAgregarCliente" runat="server" Text="Agregar Cliente" OnClick="btnAgregarCliente_Click" />
                </div>
                <!-- Control Literal para mostrar mensajes -->
                <asp:Literal ID="lblMensajeCliente" runat="server" Visible="false" />
            </div>

            <!-- Lista de Clientes (se mostrará después de agregar un nuevo cliente) -->
            <h2>Listado de Clientes</h2>
            <asp:GridView ID="GridViewClientes" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="IdCliente" HeaderText="ID Cliente" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Email" HeaderText="Email" />
                    <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
                </Columns>
            </asp:GridView>

        </div>

        <div style="margin-top: 20px;">
            <h1>Administrar Reservas</h1>

            <!-- Formulario para agregar una nueva reserva -->
            <div style="margin-bottom: 20px;">
                <h2>Agregar Nueva Reserva</h2>
                <div>
                    <label for="ddlTours">Tour:</label>
                    <asp:DropDownList ID="ddlTours" runat="server"></asp:DropDownList>
                </div>
                <div>
                    <label for="ddlClientes">Cliente:</label>
                    <asp:DropDownList ID="ddlClientes" runat="server"></asp:DropDownList>
                </div>
                <div>
                    <label for="txtCantidadPersonas">Cantidad de Personas:</label>
                    <asp:TextBox ID="txtCantidadPersonas" runat="server" TextMode="Number"></asp:TextBox>
                </div>
                <div>
                    <label for="calFechaReserva">Fecha de Reserva:</label>
                    <asp:Calendar ID="calFechaReserva" runat="server" />
                </div>
                <div>
                    <asp:Button ID="btnAgregarReserva" runat="server" Text="Agregar Reserva" OnClick="btnAgregarReserva_Click1"  />
                </div>
                
                <!-- Control Literal para mostrar mensajes -->
                <asp:Literal ID="lblMensajeReserva" runat="server" Visible="false" />
            </div>
            <h2>Reservas</h2>
    <asp:GridView ID="GridViewReservas" runat="server" AutoGenerateColumns="False" CssClass="table">
    <Columns>
        <asp:BoundField DataField="Tour" HeaderText="Tour" />
        <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
        <asp:BoundField DataField="FechaReserva" HeaderText="Fecha de Reserva" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="CantidadPersonas" HeaderText="Cantidad de Personas" />
    </Columns>
</asp:GridView>


        </div>
    </form>
</body>
</html>
