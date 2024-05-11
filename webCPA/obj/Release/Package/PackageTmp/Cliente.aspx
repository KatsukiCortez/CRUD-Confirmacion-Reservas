<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cliente.aspx.cs" Inherits="webCPA.Cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Clientes</title>
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
                    <a href="./Cliente.aspx" class="nav-link">Clientes</a>
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
        <h1>Clientes</h1>
        <!-- Formulario para agregar un nuevo cliente -->
        <form id="form1" runat="server">
            <div class="form-group">
                <label for="nombre">Nombre:</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="email">Email:</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="telefono">Teléfono:</label>
                <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button Text="Agregar Cliente" runat="server" ID="btnAgregarCliente" CssClass="btn btn-primary" OnClick="btnAgregarCliente_Click" />
            <asp:Button Text="Actualizar Cliente" runat="server" ID="btnActualizarCliente" CssClass="btn btn-primary" OnClick="btnActualizarCliente_Click" Visible="false" />

            <!-- Campo oculto para almacenar el ID del cliente en edición -->
            <asp:HiddenField ID="hfIdCliente" runat="server" />

            <hr />

            <!-- Tabla para mostrar los clientes existentes -->
            <asp:GridView ID="GridViewClientes" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="id_cliente" HeaderText="ID" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="email" HeaderText="Email" />
                    <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <!-- Botón de Eliminar -->
                            <asp:Button ID="btnEliminarCliente" runat="server" Text="Eliminar" CommandName="EliminarCliente" CommandArgument='<%# Eval("id_cliente") %>' OnClick="btnEliminarCliente_Click" CssClass="btn btn-danger" />

                            <asp:Button ID="btnEditarCliente" runat="server" Text="Editar" CommandName="EditarCliente" CommandArgument='<%# Eval("id_cliente") %>' OnClick="btnEditarCliente_Click" CssClass="btn btn-primary" />

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </form>
    </div>

    <!-- Scripts de Bootstrap y otros -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
