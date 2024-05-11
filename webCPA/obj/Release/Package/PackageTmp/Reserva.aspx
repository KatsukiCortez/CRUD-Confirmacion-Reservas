<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reserva.aspx.cs" Inherits="webCPA.Reserva" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reservas</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <header class="navbar navbar-expand-lg navbar-dark bg-dark">
        <a href="Default.aspx" class="navbar-brand">Cusco Peru Adventure</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="true" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarCollapse">
            <ul class="navbar-nav me-auto">
                <li class="nav-item">
                    <a href="./Default.aspx" class="nav-link">Inicio</a>
                </li>
                <li class="nav-item">
                    <a href="./Tour.aspx" class="nav-link">Tour</a>
                </li>
                <li class="nav-item">
                    <a href="./Cliente.aspx" class="nav-link">Cliente</a>
                </li>
                <li class="nav-item">
                    <a href="./Reserva.aspx" class="nav-link">Reserva</a>
                </li>
                <li class="nav-item">
                    <a href="./Pago.aspx" class="nav-link">Pago</a>
                </li>
            </ul>
        </div>
    </header>
    <div class="container">
        <h1>Reservas</h1>
        <!-- Formulario para agregar una nueva reserva -->
        <form id="form1" runat="server">
            <div class="form-group custom-calendar-container">
                <label for="calFecha" class="custom-calendar-label">Fecha de Reserva:</label>
                <asp:Calendar runat="server" ID="calFecha" CssClass="custom-calendar"></asp:Calendar>
            </div>


            <div class="form-group">
                <label for="ddlTour">Tour:</label>
                <asp:DropDownList runat="server" ID="ddlTour" CssClass="form-control">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="ddlCliente">Cliente:</label>
                <asp:DropDownList runat="server" ID="ddlCliente" CssClass="form-control">
                </asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtCantidadPersonas">Cantidad de Personas:</label>
                <asp:TextBox runat="server" ID="txtCantidadPersonas" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button Text="Agregar Reserva" runat="server" ID="btnAgregarReserva" CssClass="btn btn-primary" OnClick="btnAgregarReserva_Click" />
            <asp:Button Text="Actualizar Reserva" runat="server" ID="btnActualizarReserva" CssClass="btn btn-primary" OnClick="btnActualizarReserva_Click" Visible="false" />

            <!-- Campo oculto para almacenar el ID de la reserva en edición -->
            <asp:HiddenField ID="hfIdReserva" runat="server" />

            <hr />

            <!-- Tabla para mostrar las reservas existentes -->
            <asp:GridView ID="GridViewReservas" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="id_reserva" HeaderText="ID" />
                    <asp:BoundField DataField="fecha_reserva" HeaderText="Fecha de Reserva" />
                    <asp:BoundField DataField="tour" HeaderText="Tour" />
                    <asp:BoundField DataField="cliente" HeaderText="Cliente" />
                    <asp:BoundField DataField="cantidad_personas" HeaderText="Cantidad de Personas" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <!-- Botón de Eliminar -->
                            <asp:Button ID="btnEliminarReserva" runat="server" Text="Eliminar" CommandName="EliminarReserva" CommandArgument='<%# Eval("id_reserva") %>' OnClick="btnEliminarReserva_Click" CssClass="btn btn-danger" />
                
                            <!-- Botón de Editar -->
                            <asp:Button ID="btnEditarReserva" runat="server" Text="Editar" CommandName="EditarReserva" CommandArgument='<%# Eval("id_reserva") %>' OnClick="btnEditarReserva_Click" CssClass="btn btn-primary" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </form>
    </div>
</body>

    <!-- Scripts de Bootstrap y otros -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</html>
