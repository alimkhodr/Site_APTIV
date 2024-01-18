    <%@ Page Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tela_inicial.aspx.vb" Inherits="SGM_WEB.Tela_inicial" Title="TELA INICIAL" %>


<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script type="text/javascript"></script>
    <link href="css/TelaInicial.css" rel="stylesheet" />
    
        <div class="container3">
        <asp:Label ID="Label4" runat="server" Text="Comunicados" Style="color: black; font-size: 35px; margin-top: 15px;"></asp:Label>
        <asp:Label ID="Label6" runat="server" Text="Recursos Humanos" Style="color: #A6A6A6; font-size: 16px; margin-top:-9px; margin-bottom: -20px;"></asp:Label>
        <div class="slideshow-container">
            <div id="slide1" class="mySlides fade" runat="server">
                <a id="A1" runat="server" href="#" target="_blank">
                    <asp:Image ID="img1" runat="server" Style="width: 100%" CssClass="img" />
                </a>
            </div>

            <div id="slide2" class="mySlides fade" runat="server">
                <a id="A2" runat="server" href="#" target="_blank">
                    <asp:Image ID="img2" runat="server" Style="width: 100%" CssClass="img" />
                </a>
            </div>

            <div id="slide3" class="mySlides fade" runat="server">
                <a id="A3" runat="server" href="#" target="_blank">
                    <asp:Image ID="img3" runat="server" Style="width: 100%" CssClass="img" />
                </a>
            </div>

            <div id="slide4" class="mySlides fade" runat="server">
                <a id="A4" runat="server" href="#" target="_blank">
                    <asp:Image ID="img4" runat="server" Style="width: 100%" CssClass="img" />
                </a>
            </div>

            <div id="slide5" class="mySlides fade" runat="server">
                <a id="A5" runat="server" href="#" target="_blank">
                    <asp:Image ID="img5" runat="server" Style="width: 100%" CssClass="img" />
                </a>
            </div>

            <div id="slide6" class="mySlides fade" runat="server">
                <a id="A6" runat="server" href="#" target="_blank">
                    <asp:Image ID="img6" runat="server" Style="width: 100%" CssClass="img" />
                </a>
            </div>

            <div id="slide7" class="mySlides fade" runat="server">
                <a id="A7" runat="server" href="#" target="_blank">
                    <asp:Image ID="img7" runat="server" Style="width: 100%" CssClass="img" />
                </a>
            </div>

            <div id="slide8" class="mySlides fade" runat="server">
                <a id="A8" runat="server" href="#" target="_blank">
                    <asp:Image ID="img8" runat="server" Style="width: 100%" CssClass="img" />
                </a>
            </div>

            <div id="slide9" class="mySlides fade" runat="server">
                <a id="A9" runat="server" href="#" target="_blank">
                    <asp:Image ID="img9" runat="server" Style="width: 100%" CssClass="img" />
                </a>
            </div>

            <div id="slide10" class="mySlides fade" runat="server">
                <a id="A10" runat="server" href="#" target="_blank">
                    <asp:Image ID="img10" runat="server" Style="width: 100%" CssClass="img" />
                </a>
            </div>

            <a class="prev" onclick="plusSlides(-1)">&#10094;</a>
            <a class="next" onclick="plusSlides(1)">&#10095;</a>

            <div style="text-align: center">
                <span id="dot1" class="dot" onclick="currentSlide(1)" runat="server"></span>
                <span id="dot2" class="dot" onclick="currentSlide(2)" runat="server"></span>
                <span id="dot3" class="dot" onclick="currentSlide(3)" runat="server"></span>
                <span id="dot4" class="dot" onclick="currentSlide(4)" runat="server"></span>
                <span id="dot5" class="dot" onclick="currentSlide(4)" runat="server"></span>
                <span id="dot6" class="dot" onclick="currentSlide(4)" runat="server"></span>
                <span id="dot7" class="dot" onclick="currentSlide(4)" runat="server"></span>
                <span id="dot8" class="dot" onclick="currentSlide(4)" runat="server"></span>
                <span id="dot9" class="dot" onclick="currentSlide(4)" runat="server"></span>
                <span id="dot10" class="dot" onclick="currentSlide(4)" runat="server"></span>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
    <div class="container2">
        <asp:Panel ID="Panel1" runat="server" class="caixa1">
            <asp:Panel ID="Panel4" runat="server" Height="210px" Width="327px">
                <asp:Label ID="txtacidentes1" runat="server" Text="0" CssClass="txt1"></asp:Label>
            </asp:Panel>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Dias sem acidentes" CssClass="txt2" Style="color: black;"></asp:Label>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Com afastamento" CssClass="txt3" Style="color: #A6A6A6;"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="Panel2" runat="server" class="caixa2">
            <asp:Panel ID="Panel3" runat="server" Height="225px" Width="327px">
                <asp:Label ID="txtacidentes2" runat="server" Text="1810" CssClass="txt1"></asp:Label><br />
            </asp:Panel>
            <asp:Label ID="Label2" runat="server" Text="Maior período sem acidentes" CssClass="txt2" Style="color: white;"></asp:Label>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Com afastamento" CssClass="txt3" Style="color: #A6A6A6;"></asp:Label>
        </asp:Panel>
    </div>
    <br />
    <br />
    <div class="container2">
        <asp:Panel ID="Panel15" runat="server" class="caixa2">
            <asp:Panel ID="Panel14" runat="server" Height="210px" Width="327px">
                <asp:Label ID="txtreclamacoes1" runat="server" Text="0" CssClass="txt1"></asp:Label>
            </asp:Panel>
            <br />
            <asp:Label ID="Label17" runat="server" Text="Dias sem reclamações" CssClass="txt2" Style="color: white;"></asp:Label>
            <br />
            <asp:Label ID="Label18" runat="server" Text="De clientes" CssClass="txt3" Style="color: #A6A6A6;"></asp:Label>
        </asp:Panel>
        <asp:Panel ID="Panel13" runat="server" class="caixa1">
            <asp:Panel ID="Panel16" runat="server" Height="225px" Width="327px">
                <asp:Label ID="txtreclamacoes2" runat="server" Text="98" CssClass="txt1"></asp:Label><br />
            </asp:Panel>
            <asp:Label ID="Label20" runat="server" Text="Maior período sem reclamações" CssClass="txt2" Style="color: black;"></asp:Label>
            <br />
            <asp:Label ID="Label21" runat="server" Text="De clientes" CssClass="txt3" Style="color: #A6A6A6;"></asp:Label>
        </asp:Panel>
    </div>
<div class="container"></div>

    
<script>
    let slideIndex = 1;
    showSlides(slideIndex);
    function plusSlides(n) {
        showSlides(slideIndex += n);
    }
    function currentSlide(n) {
        showSlides(slideIndex = n);
    }
    function showSlides(n) {
        let i;
        let slides = document.getElementsByClassName("mySlides");
        let dots = document.getElementsByClassName("dot");
        if (n > slides.length) { slideIndex = 1; }
        if (n < 1) { slideIndex = slides.length; }
        for (i = 0; i < slides.length; i++) {
            slides[i].style.display = "none";
        }
        for (i = 0; i < dots.length; i++) {
            dots[i].className = dots[i].className.replace(" active", "");
        }
        slides[slideIndex - 1].style.display = "block";
        dots[slideIndex - 1].className += " active";
    }
    function autoSlide() {
        plusSlides(1);
    }
    setInterval(autoSlide, 7000);
</script>

</asp:Content>

