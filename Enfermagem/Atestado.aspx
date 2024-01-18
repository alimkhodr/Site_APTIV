<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Atestado.aspx.vb" Inherits="SGM_WEB.Atestado" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="../Padrao.css" rel="stylesheet">

    <script type="text/javascript">
        function handleKeyPress(e) {
            var key = e.keyCode || e.which;
            if (key === 13) {
                e.preventDefault();
                document.getElementById('<%= cmdsalvar.ClientID %>').click();
            }
        }
        document.addEventListener('keypress', handleKeyPress);
    </script>


    <asp:Panel ID="Panel17" runat="server" Height="877px" Width="1017px">
        <div class="title">
            <asp:Label ID="Label25" runat="server" class="dot-title" Text="•"></asp:Label>
            <asp:Label ID="txtconf" runat="server" class="text-title" Text="ATESTADOS"></asp:Label>
            <asp:Label ID="Label9" runat="server" class="dot-title" Text="•"></asp:Label>
        </div>

        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="container">
                    <asp:Panel ID="Panel21" runat="server" Style="float: left;" Width="267px" Height="46px">
                        <asp:Label ID="lblmed" runat="server" Text="Adicionar Médico" Enabled="False" Font-Bold="True"></asp:Label><br />
                        <asp:TextBox ID="txtmed" runat="server" Width="251px" Height="24px" CssClass="boxText" DefaultButton="btnaddmed"></asp:TextBox>
                    </asp:Panel>
                    <asp:Panel ID="Panel20" runat="server" Style="float: left;" Width="169px" Height="46px">
                        <asp:Label ID="Label13" runat="server" Text="CRM" Enabled="False" Font-Bold="True"></asp:Label><br />
                        <asp:TextBox ID="txtaddcrm" runat="server" Width="150px" Height="25px" CssClass="boxText"></asp:TextBox>
                    </asp:Panel>
                    <br />
                    <asp:Button ID="btnaddmed" Text="Adicionar" runat="server" Font-Size="SMALL" Height="32px" Width="102px" CssClass="BtnStyle" />
                    <br />
                    <br />
                    <hr />
                    <br />
                    <asp:Panel ID="Panel1" runat="server" Style="float: left;" Width="187px" Height="46px">
                        <asp:RadioButtonList ID="RbATEN" runat="server" Width="209px" Font-Bold="True" AutoPostBack="True" Height="51px">
                            <asp:ListItem Selected="True" Value="0">Novo Atestado</asp:ListItem>
                            <asp:ListItem Value="1">Editar Atestado</asp:ListItem>
                        </asp:RadioButtonList>
                    </asp:Panel>
                    <asp:Panel ID="Panel3" runat="server" Style="float: left;" Width="118px" Height="46px">
                        <asp:Label ID="Label1" runat="server" Text="Registro" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:DropDownList ID="cboformreg" runat="server" Height="29px" Width="100px" AutoPostBack="True" Enabled="False" CssClass="boxText" DefaultButton="btnnform">
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="Panel4" runat="server" Style="float: left;" Width="105px" Height="46px">
                        <asp:Label ID="Label3" runat="server" Text="Nº Atestado" Enabled="False" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:DropDownList ID="cbonform" runat="server" Height="29px" Width="75px" AutoPostBack="True" Enabled="False" CssClass="boxText" DefaultButton="btnnform">
                        </asp:DropDownList>
                    </asp:Panel>
                    <br />
                    <asp:Button ID="btnnform" Text="Procurar" runat="server" Font-Size="SMALL" Height="32px" Width="102px" CssClass="BtnStyle" />
                    <br />
                    <br />
                    <hr />
                    <br />
                    <asp:Panel ID="Panel5" runat="server" Style="float: left;" Width="84px" Height="45px">
                        <asp:Label ID="lblreg" runat="server" Text="Registro" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:DropDownList ID="cboreg" runat="server" Height="29px" Width="75px" AutoPostBack="True" CssClass="boxText">
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="Panel6" runat="server" Style="float: left;" Width="334px" Height="45px">
                        <asp:Label ID="lblnome" runat="server" Text="Nome" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtnome" runat="server" Width="318px" Height="25px" Enabled="False" CssClass="boxText"></asp:TextBox>
                    </asp:Panel>
                    <asp:Panel ID="Panel7" runat="server" Style="float: left;" Width="372px" Height="45px">
                        <asp:Label ID="lblarea" runat="server" Text="Área" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtarea" runat="server" Width="352px" Height="25px" Enabled="False" CssClass="boxText"></asp:TextBox>
                    </asp:Panel>
                    <asp:Panel ID="Panel8" runat="server" Style="float: left;" Width="173px" Height="45px">
                        <asp:Label ID="lblturno" runat="server" Text="Turno" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtturno" runat="server" Width="171px" Height="25px" Enabled="False" CssClass="boxText"></asp:TextBox>
                    </asp:Panel>
                    <br />
                    <br />
                    <br />
                    <br />
                    <hr />
                    <br />
                    <asp:Panel ID="Panel10" runat="server" Style="float: left;" Width="159px" Height="45px">
                        <asp:Label ID="Label8" runat="server" Text="Data" Font-Bold="True"></asp:Label><br />
                        <asp:TextBox ID="txtdata" runat="server" Height="25px" Width="130px" CssClass="boxText"></asp:TextBox>
                        <asp:CalendarExtender
                            ID="CalendarExtender1"
                            TargetControlID="txtdata"
                            runat="server"
                            Format="dd/MM/yyyy" />
                    </asp:Panel>
                    <asp:Panel ID="Panel12" runat="server" Style="float: left;" Width="130px" Height="45px">
                        <asp:Label ID="Label4" runat="server" Text="Dias de Atestado" Font-Bold="True"></asp:Label><br />
                        <asp:TextBox ID="txtdias" runat="server" Width="103px" Height="25px" CssClass="boxText"></asp:TextBox>
                    </asp:Panel>
                    <asp:Panel ID="Panel9" runat="server" Style="float: left;" Width="139px" Height="45px">
                        <asp:Label ID="lblh" runat="server" Text="Horas de Atestado" Font-Bold="True"></asp:Label><br />
                        <asp:DropDownList ID="cboh" runat="server" Height="29px" Width="60px" CssClass="boxText">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem Value="12"></asp:ListItem>
                            <asp:ListItem Value="13"></asp:ListItem>
                            <asp:ListItem Value="14"></asp:ListItem>
                            <asp:ListItem Value="15"></asp:ListItem>
                            <asp:ListItem Value="16"></asp:ListItem>
                            <asp:ListItem Value="17"></asp:ListItem>
                            <asp:ListItem Value="18"></asp:ListItem>
                            <asp:ListItem Value="19"></asp:ListItem>
                            <asp:ListItem Value="20"></asp:ListItem>
                            <asp:ListItem Value="21">21</asp:ListItem>
                            <asp:ListItem Value="22"></asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                        </asp:DropDownList>
                        <asp:DropDownList ID="cbom" runat="server" Height="29px" Width="60px" CssClass="boxText">
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="Panel14" runat="server" Style="float: left;" Width="89px" Height="45px">
                        <asp:Label ID="Label6" runat="server" Text="CID" Font-Bold="True"></asp:Label><br />
                        <asp:TextBox ID="txtcid" runat="server" Width="65px" Height="25px" CssClass="boxText"></asp:TextBox>
                    </asp:Panel>
                    <asp:Panel ID="Panel15" runat="server" Style="float: left;" Width="276px" Height="45px">
                        <asp:Label ID="Label7" runat="server" Text="Especificações de CID" Font-Bold="True"></asp:Label><br />
                        <asp:DropDownList ID="cbocid" runat="server" Height="29px" Width="260px" CssClass="boxText">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>SISTEMA DIGESTÓRIO</asp:ListItem>
                            <asp:ListItem>SIST. OSTEOMUSCULAR</asp:ListItem>
                            <asp:ListItem>SISTEMA RESPIRATÓRIO</asp:ListItem>
                            <asp:ListItem>SISTEMA NERVOSO</asp:ListItem>
                            <asp:ListItem>EXAMES</asp:ListItem>
                            <asp:ListItem>SISTEMA GENITURINÁRIO</asp:ListItem>
                            <asp:ListItem>SISTEMA CIRCULATÓRIO</asp:ListItem>
                            <asp:ListItem>PELE E TECIDO SUBCUTÂNEO</asp:ListItem>
                            <asp:ListItem>DOENÇAS DO OLHO E ANEXOS</asp:ListItem>
                            <asp:ListItem>TRANSTORNOS MENTAIS E COMPORTAMENTAIS</asp:ListItem>
                            <asp:ListItem>GRAVIDEZ, PARTO E PUERPÉRIO</asp:ListItem>
                            <asp:ListItem>DOENÇAS DO OUVIDO</asp:ListItem>
                            <asp:ListItem>DOENÇAS ENDÓCRINAS, NUTRICIONAIS E METABÓLICAS</asp:ListItem>
                            <asp:ListItem>DOENÇAS DO SANGUE</asp:ListItem>
                            <asp:ListItem>NEOPLASIAS</asp:ListItem>
                            <asp:ListItem>OUTROS</asp:ListItem>
                        </asp:DropDownList>
                    </asp:Panel>
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Panel ID="Panel2" runat="server" Style="float: left;" Width="289px" Height="45px">
                        <asp:Label ID="Label2" runat="server" Text="Médico" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:DropDownList ID="cbomed" runat="server" Height="29px" Width="265px" AutoPostBack="True" CssClass="boxText">
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="Panel13" runat="server" Style="float: left;" Width="88px" Height="45px">
                        <asp:Label ID="Label5" runat="server" Text="CRM" Font-Bold="True"></asp:Label><br />
                        <asp:TextBox ID="txtcrm" runat="server" Width="81px" Height="25px" CssClass="boxText" Enabled="False"></asp:TextBox>
                    </asp:Panel>
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Panel ID="Panel18" runat="server" Height="50px" Width="972px">
                        <asp:Button ID="cmdsalvar" Text="SALVAR" runat="server" Style="float: right; margin-left: 0px;" Font-Size="SMALL" Height="35px" Width="102px" CssClass="BtnStyle" />
                    </asp:Panel>

                    <ajaxToolkit:ModalPopupExtender ID="mp2" runat="server" PopupControlID="Panel11" TargetControlID="lblsv" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
                    <asp:Panel ID="Panel11" runat="server" Style="display: none;" CssClass="modalPopup">
                        <asp:Label ID="lblsv" runat="server" class="titulo-modal"></asp:Label>
                        <br />
                        <asp:Button ID="cmdfechar" runat="server" Text="FECHAR" Font-Size="Larger" />
                    </asp:Panel>


                    <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel16" TargetControlID="ORDEMP" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
                    <asp:Panel ID="Panel16" runat="server" Style="display: none;" CssClass="modalPopup">
                        <asp:Label ID="ORDEMP" class="titulo-modal" runat="server"></asp:Label>
                        <br />
                        <asp:Button ID="btnClose" class="BtnStyle" Height="35px" Width="102px" runat="server" Text="FECHAR" />
                    </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>


