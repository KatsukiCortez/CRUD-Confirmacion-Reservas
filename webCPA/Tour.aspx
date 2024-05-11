<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tour.aspx.cs" Inherits="webCPA.Tour" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tours</title>
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
        <h1>Tours</h1>
        <!-- Formulario para agregar un nuevo tour -->
        <form id="form1" runat="server">
            <div class="form-group">
                <label for="nombre">Nombre:</label>
                <asp:TextBox runat="server" ID="txtnombre" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="descripcion">Descripción:</label>
                <asp:TextBox runat="server" ID="txtdescripcion" TextMode="MultiLine" Rows="3" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="precio">Precio:</label>
                <asp:TextBox runat="server" ID="txtprecio" CssClass="form-control"></asp:TextBox>
            </div>
            <asp:Button Text="Agregar Tour" runat="server" ID="btnAgregarTour" CssClass="btn btn-primary" OnClick="btnAgregarTour_Click" />
            <asp:Button Text="Actualizar Tour" runat="server" ID="btnActualizarTour" CssClass="btn btn-primary" OnClick="btnActualizarTour_Click" Visible="false" />

            <!-- Campo oculto para almacenar el ID del tour en edición -->
            <asp:HiddenField ID="hfIdTour" runat="server" />
        
            <hr />

            <!-- Tabla para mostrar los tours existentes -->
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="id_tour" HeaderText="ID" />
                    <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="precio" HeaderText="Precio" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <!-- Botón de Eliminar -->
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="EliminarRegistro" CommandArgument='<%# Eval("id_tour") %>' OnClick="btnEliminar_Click" CssClass="btn btn-danger" />
                
                            <!-- Botón de Actualizar -->
                            <asp:Button ID="btnActualizar" runat="server" Text="Editar" CommandName="ActualizarRegistro" CommandArgument='<%# Eval("id_tour") %>' OnClick="btnActualizar_Click" CssClass="btn btn-primary" />
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
