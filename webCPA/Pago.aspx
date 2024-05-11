<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pago.aspx.cs" Inherits="webCPA.Pago" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Pagos</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
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
                        <a href="./Cliente.aspx" class="nav-link">Clientes</a>
                    </li>
                    <li class="nav-item">
                        <a href="./Reserva.aspx" class="nav-link">Reserva</a>
                    </li>
                    <li class="nav-item">
                        <a href="./Pagos.aspx" class="nav-link">Pagos</a>
                    </li>
                </ul>
            </div>
        </header>
        <div class="container">
            <h1>Pagos</h1>
            <div class="form-group">
                <label for="ddlReserva">ID Reserva:</label>
                <asp:DropDownList runat="server" ID="ddlReserva" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="txtMonto">Monto:</label>
                <asp:TextBox runat="server" ID="txtMonto" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtFechaPago">Fecha de Pago:</label>
                <asp:TextBox runat="server" ID="txtFechaPago" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button Text="Agregar Pago" runat="server" ID="btnAgregarPago" CssClass="btn btn-primary" OnClick="btnAgregarPago_Click" />
            <asp:Button Text="Actualizar Pago" runat="server" ID="btnActualizarPago" CssClass="btn btn-primary" OnClick="btnActualizarPago_Click" Visible="false" />

            <!-- Campo oculto para almacenar el ID del pago en edición -->
            <asp:HiddenField ID="hfIdPago" runat="server" />

            <hr />

            <!-- Tabla para mostrar los pagos existentes -->
            <asp:GridView ID="GridViewPagos" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="id_pago" HeaderText="ID" />
                    <asp:BoundField DataField="reserva" HeaderText="ID Reserva" />
                    <asp:BoundField DataField="monto" HeaderText="Monto" />
                    <asp:BoundField DataField="fecha_pago" HeaderText="Fecha de Pago" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <!-- Botón de Eliminar -->
                            <asp:Button ID="btnEliminarPago" runat="server" Text="Eliminar" CommandName="EliminarPago" CommandArgument='<%# Eval("id_pago") %>' OnClick="btnEliminarPago_Click" CssClass="btn btn-danger" />
                
                            <!-- Botón de Editar -->
                            <asp:Button ID="btnEditarPago" runat="server" Text="Editar" CommandName="EditarPago" CommandArgument='<%# Eval("id_pago") %>' OnClick="btnEditarPago_Click" CssClass="btn btn-primary" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

        <!-- Scripts de Bootstrap y otros -->
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    </form>
</body>
</html>
