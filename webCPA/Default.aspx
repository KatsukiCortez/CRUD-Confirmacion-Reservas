<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="webCPA.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cusco Peru Adventure - ¡Explora las maravillas del Perú!</title>
    <link href="./Content/bootstrap.min.css" rel="stylesheet" />
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
        <div>
            <section class="row">
                <p class="lead">¡Libera a tu explorador interior con Cusco Perú Adventure! Ofrecemos tours y experiencias inolvidables en el corazón del antiguo Imperio Inca.</p>
            </section>

            <div class="row">
                <section class="col-md-4">
                    <h2 id="exploreMachuPicchuTitle">Explora Machu Picchu</h2>
                    <asp:Image ID="imgMachuPicchu" runat="server" ImageUrl="~/Images/machu-picchu.jpg" AlternateText="Machu Picchu" CssClass="img-fluid"  Width="400" Height="250" />
                    <p>Camina por el legendario Camino Inca o viaja en tren a la impresionante ciudad perdida de Machu Picchu. Ofrecemos una variedad de tours para satisfacer sus necesidades y presupuesto.</p>
                </section>
                <section class="col-md-4">
                    <h2 id="discoverSacredValleyTitle">Descubre el Valle Sagrado</h2>
                    <asp:Image ID="imgValleSagrado" runat="server" ImageUrl="~/Images/VALLE-SAGRADO1.jpg" AlternateText="Valle Sagrado" CssClass="img-fluid" Width="400" Height="250" />
                    <p>Sumérjase en la rica historia y cultura del Valle Sagrado. Visita ruinas antiguas, pueblos encantadores y paisajes impresionantes.</p>
                </section>
                <section class="col-md-4">
                    <h2 id="adventureAwaitsTitle">La aventura te espera</h2>
                    <asp:Image ID="imgAventura" runat="server" ImageUrl="~/Images/aventura.jpeg" AlternateText="Aventura en Cusco" CssClass="img-fluid" Width="400" Height="250" />
                    <p>Desde ciclismo de montaña hasta rafting, ofrecemos una variedad de aventuras emocionantes para los amantes de la adrenalina. ¡Explora la belleza del Perú de una manera completamente nueva!</p>
                </section>
            </div>

            <div class="row">
                <section class="col-md-4">
                    <h2 id="trekkingTreksTitle">Trekking y caminatas</h2>
                    <asp:Image ID="imgTrekking" runat="server" ImageUrl="~/Images/trekking.jpg" AlternateText="Caminatas" CssClass="img-fluid"   Width="400" Height="250" />
                    <p>Embárcate en épicas caminatas a través de impresionantes paisajes andinos. Desafía tus límites y disfruta de vistas panorámicas inolvidables.</p>
                </section>
                <section class="col-md-4">
                    <h2 id="culturalToursTitle">Tours culturales</h2>
                    <asp:Image ID="imgCulturalTours" runat="server" ImageUrl="~/Images/experiencia-cusco.jpg" AlternateText="Experiencias Culturales" CssClass="img-fluid" Width="400" Height="250" />
                    <p>Sumérjase en la rica cultura peruana a través de nuestros tours culturales. Visite museos, mercados locales y participe en actividades tradicionales.</p>
                </section>
                <section class="col-md-4">
                    <h2 id="gastronomicDelightsTitle">Deleites gastronómicos</h2>
                    <asp:Image ID="imgGastronomicDelights" runat="server" ImageUrl="~/Images/gastronomia-cusco.jpg" AlternateText="Gastronomía en Cusco" CssClass="img-fluid" Width="400" Height="250" />
                    <p>Saborea los sabores únicos de la cocina peruana. Disfruta de clases de cocina, degustaciones y experiencias culinarias memorables.</p>
                </section>
            </div>

            <div class="row">
                <section class="col-md-4">
                    <h2 id="sustainableTourismTitle">Turismo sostenible</h2>
                    <asp:Image ID="imgSustainableTourism" runat="server" ImageUrl="~/Images/turismo.jpg" AlternateText="Turismo en Cusco" CssClass="img-fluid" Width="400" Height="250" />
                    <p>Comprometidos con el turismo responsable. Apoyamos a las comunidades locales y protegemos el medio ambiente mientras exploras Perú.</p>
                </section>
                <section class="col-md-4">
                    <h2 id="ourStoryTitle">Nuestra historia</h2>
                    <asp:Image ID="imgOurStory" runat="server" ImageUrl="~/Images/historia.jpg" AlternateText="Historia del Cusco" CssClass="img-fluid" Width="400" Height="250" />
                    <p>Conoce nuestra pasión por el Perú y descubre cómo Cusco Perú Adventure nació para compartir experiencias inolvidables contigo.</p>
                </section>
                <section class="col-md-4">
                    <h2 id="contactUsTitle">Contáctanos</h2>
                    <asp:Image ID="imgLogo" runat="server" ImageUrl="~/Images/logo.png" AlternateText="Logo de la empresa" CssClass="img-fluid" Width="400" Height="250"  />
                    <p>¿Tienes preguntas o quieres reservar un tour? ¡No dudes en contactarnos! Estamos aquí para ayudarte a planificar tu aventura en Perú.</p>
                </section>
            </div>
        </div>
        <script src="~/Content/bootstrap.bundle.min.js"></script>
        <script src="~/Content/bootstrap.min.js"></script>
    </form>
</body>
</html>