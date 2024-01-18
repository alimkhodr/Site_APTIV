<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Atendimento.aspx.vb" Inherits="SGM_WEB.Atendimento" %>

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

    <asp:Panel ID="Panel2" runat="server" Height="877px" Width="1017px">
        <div class="title">
            <asp:Label ID="Label25" runat="server" class="dot-title" Text="•"></asp:Label>
            <asp:Label ID="Label12" runat="server" class="text-title" Text="ATENDIMENTO"></asp:Label>
            <asp:Label ID="Label13" runat="server" class="dot-title" Text="•"></asp:Label>
        </div>

        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="container">
                    <asp:Label ID="lblmed" runat="server" Text="Adicionar Medicamento" Enabled="False" Font-Bold="True"></asp:Label><br />
                    <asp:TextBox ID="txtmed" runat="server" Width="251px" Height="24px" CssClass="boxText" DefaultButton="btnaddmed"></asp:TextBox>&nbsp;
                                <asp:Button ID="btnaddmed" Text="Adicionar" runat="server" Font-Size="SMALL" Height="32px" Width="102px" CssClass="BtnStyle" />
                    <br />
                    <br />
                    <hr />
                    <br />
                    <br />
                    <asp:Panel ID="Panel1" runat="server" Style="float: left;" Width="187px" Height="46px">
                        <asp:RadioButtonList ID="RbATEN" runat="server" Width="209px" Font-Bold="True" AutoPostBack="True" Height="51px">
                            <asp:ListItem Selected="True" Value="0">Novo Atendimento</asp:ListItem>
                            <asp:ListItem Value="1">Editar Atendimento</asp:ListItem>
                        </asp:RadioButtonList>
                    </asp:Panel>
                    <asp:Panel ID="Panel3" runat="server" Style="float: left;" Width="118px" Height="46px">
                        <asp:Label ID="Label1" runat="server" Text="Registro" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:DropDownList ID="cboformreg" runat="server" Height="29px" Width="100px" AutoPostBack="True" Enabled="False" CssClass="boxText" DefaultButton="btnnform">
                        </asp:DropDownList>
                    </asp:Panel>
                    <asp:Panel ID="Panel4" runat="server" Style="float: left;" Width="147px" Height="46px">
                        <asp:Label ID="Label3" runat="server" Text="Nº Atendimento" Enabled="False" Font-Bold="True"></asp:Label>
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
                    <asp:Panel ID="Panel8" runat="server" Style="float: left;" Width="141px" Height="45px">
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
                    <asp:Panel ID="Panel9" runat="server" Style="float: left;" Width="130px" Height="45px">
                        <asp:Label ID="lblh" runat="server" Text="Hora" Font-Bold="True"></asp:Label><br />
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
                    <asp:Panel ID="Panel10" runat="server" Style="float: left;" Width="148px" Height="45px">
                        <asp:Label ID="Label8" runat="server" Text="Data" Font-Bold="True"></asp:Label><br />
                        <asp:TextBox ID="txtdata" runat="server" Height="25px" Width="130px" CssClass="boxText"></asp:TextBox>
                        <asp:CalendarExtender
                            ID="CalendarExtender1"
                            TargetControlID="txtdata"
                            runat="server"
                            Format="dd/MM/yyyy" />
                    </asp:Panel>
                    <asp:Panel ID="Panel12" runat="server" Style="float: left;" Width="166px" Height="45px">
                        <asp:Label ID="Label4" runat="server" Text="PA (mmHg)" Font-Bold="True"></asp:Label><br />
                        <asp:TextBox ID="txtpa" runat="server" Width="150px" Height="25px" CssClass="boxText"></asp:TextBox>
                    </asp:Panel>
                    <asp:Panel ID="Panel13" runat="server" Style="float: left;" Width="166px" Height="45px">
                        <asp:Label ID="Label5" runat="server" Text="BPM" Font-Bold="True"></asp:Label><br />
                        <asp:TextBox ID="txtbpm" runat="server" Width="150px" Height="25px" CssClass="boxText"></asp:TextBox>
                    </asp:Panel>
                    <asp:Panel ID="Panel14" runat="server" Style="float: left;" Width="166px" Height="45px">
                        <asp:Label ID="Label6" runat="server" Text="Temp. (°C)" Font-Bold="True"></asp:Label><br />
                        <asp:TextBox ID="txttemp" runat="server" Width="150px" Height="25px" CssClass="boxText"></asp:TextBox>
                    </asp:Panel>
                    <asp:Panel ID="Panel15" runat="server" Style="float: left;" Width="185px" Height="45px">
                        <asp:Label ID="Label7" runat="server" Text="SaO2 (%)" Font-Bold="True"></asp:Label><br />
                        <asp:TextBox ID="txtsa" runat="server" Width="182px" Height="25px" CssClass="boxText"></asp:TextBox>
                    </asp:Panel>
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Panel ID="Panel17" runat="server" Style="float: left;" Width="341px" Height="45px">
                        <asp:Label ID="Label9" runat="server" Text="Descrição" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtdesc" runat="server" Width="323px" Height="25px" CssClass="boxText"></asp:TextBox>
                        <br />
                    </asp:Panel>
                    <asp:Panel ID="Panel18" runat="server" Style="float: left;" Width="189px" Height="45px">
                        <asp:Label ID="Label11" runat="server" Text="Conduta de Enfermagem" Font-Bold="True"></asp:Label>
                        <asp:DropDownList ID="cboconduta" runat="server" Height="29px" Width="179px" CssClass="boxText">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>APENAS MEDICAMENTO</asp:ListItem>
                            <asp:ListItem>REPOUSO</asp:ListItem>
                            <asp:ListItem>ENCAMINHADO AO PS</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                    </asp:Panel>
                    <asp:Panel ID="Panel19" runat="server" Style="float: left;" Width="431px" Height="45px">
                        <asp:Label ID="Label10" runat="server" Text="Observação" Font-Bold="True"></asp:Label>
                        <asp:TextBox ID="txtobs" runat="server" Width="432px" Height="25px" CssClass="boxText"></asp:TextBox>
                        <br />
                    </asp:Panel>
                    <br />
                    <br />
                    <br />
                    <br />
                    <hr />
                    <br />
                    <asp:Label ID="Label19" runat="server" Text="Medicamento" Font-Bold="True"></asp:Label>
                    <br />
                    <asp:DropDownList ID="cbomed" runat="server" Height="29px" Width="369px" CssClass="boxText" DefaultButton="btnmed">
                    </asp:DropDownList>&nbsp;&nbsp;
                        <asp:Button ID="btnmed" Text="Adicionar" runat="server" Font-Size="SMALL" Height="32px" Width="102px" CssClass="BtnStyle" />
                    <asp:Button ID="cmddel" runat="server" Font-Size="SMALL" Height="32px" Width="102px" Text="Remover" CssClass="BtnStyle" />
                    <br />
                    <br />
                    <asp:ListBox ID="ListaMed" runat="server" Height="136px" Width="968px" Font-Bold="True" Font-Size="Medium" Enabled="False"></asp:ListBox>
                    <br />
                    <br />
                    <div style="height: 57px">
                        <asp:Label ID="Label2" runat="server" Text="ATENDIMENTOS NO MÊS ATUAL:" Font-Bold="True" Font-Size="13pt"></asp:Label>&nbsp;&nbsp;
                            <asp:Label ID="lblqtd" runat="server" Text="lblqtd" Font-Bold="False" Font-Size="12pt"></asp:Label>
                        <asp:Button ID="cmdsalvar" Text="Salvar" runat="server" Style="float: right;" Font-Size="SMALL" Height="32px" Width="102px" CssClass="BtnStyle" />
                    </div>


                    <ajaxToolkit:ModalPopupExtender ID="mp2" runat="server" PopupControlID="Panel11" TargetControlID="lblsv" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
                    <asp:Panel ID="Panel11" runat="server" Style="display: none;" CssClass="modalPopup">
                        <asp:Label ID="lblsv" runat="server" class="titulo-modal"></asp:Label>
                        <br />
                        <asp:Button ID="cmdfechar" runat="server" Text="FECHAR" class="BtnStyle" Height="35px" Width="102px" />
                    </asp:Panel>


                    <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel16" TargetControlID="ORDEMP" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
                    <asp:Panel ID="Panel16" runat="server" Style="display: none;" CssClass="modalPopup">
                        <asp:Label ID="ORDEMP" class="titulo-modal" runat="server"></asp:Label>
                        <br />
                        <asp:Button ID="btnClose" class="BtnStyle" Height="35px" Width="102px" runat="server" Text="FECHAR" />
                    </asp:Panel>
                </div>
                <br />

            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>



