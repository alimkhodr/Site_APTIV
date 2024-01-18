<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Atestado_Saude.aspx.vb" Inherits="SGM_WEB.Atestado_Saude" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
<link href="../Padrao.css" rel="stylesheet">
    <asp:Panel ID="Panel7" runat="server" Height="877px" Width="1017px">
        <div class="title">
            <asp:Label ID="Label25" runat="server" class="dot-title" Text="•"></asp:Label>
            <asp:Label ID="txtconf" runat="server" class="text-title" Text="ATESTADO OCUPACIONAL"></asp:Label>
            <asp:Label ID="Label2" runat="server" class="dot-title" Text="•"></asp:Label>
        </div>

        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="container">
                        <asp:Panel ID="Panel10" runat="server" Style="float: left;" Width="138px" Height="60px">
                            <asp:RadioButtonList ID="Rbaso" runat="server" Width="181px" Font-Bold="True" AutoPostBack="True" Height="51px">
                                <asp:ListItem Selected="True" Value="0">Novo ASO</asp:ListItem>
                                <asp:ListItem Value="1">Visualizar ASO</asp:ListItem>
                            </asp:RadioButtonList>
                        </asp:Panel>

                        <asp:Panel ID="Panel12" runat="server" Style="float: left;" Width="116px" Height="60px">
                            <asp:Label ID="Label1" runat="server" Text="Registro" Font-Bold="True"></asp:Label>
                            <asp:DropDownList ID="cboformreg" runat="server" Height="29px" Width="100px" AutoPostBack="True" Enabled="False" CssClass="boxText">
                            </asp:DropDownList>
                        </asp:Panel>

                        <asp:Panel ID="Panel13" runat="server" Style="float: left;" Width="111px" Height="60px" DefaultButton="btnnform">
                            <asp:Label ID="Label3" runat="server" Text="Nº ASO" Enabled="False" Font-Bold="True"></asp:Label><br />
                            <asp:DropDownList ID="cbonform" runat="server" Height="29px" Width="75px" AutoPostBack="True" Enabled="False" CssClass="boxText">
                            </asp:DropDownList>&nbsp;                       
                        </asp:Panel>
                        <br />
                        <asp:Button ID="btnnform" Text="Procurar" runat="server" Font-Size="SMALL" Height="32px" Width="102px" CssClass="BtnStyle" />
                        <br />
                        <br />
                        <br />
                        <hr />
                        <br />
                        <asp:Panel ID="Panel6" runat="server" Style="float: left;" Width="970px" Height="53px" DefaultButton="cmdsalvar">
                            <asp:Panel ID="Panel1" runat="server" Style="float: left;" Width="138px" Height="45px">
                                <asp:Label ID="lbltipo" runat="server" Text="Tipo" Font-Bold="True"></asp:Label><br />
                                <asp:DropDownList ID="cbotipo" runat="server" Height="29px" Width="130px" CssClass="boxText">
                                    <asp:ListItem></asp:ListItem>
                                    <asp:ListItem>ADMISSIONAL</asp:ListItem>
                                    <asp:ListItem>PERIÓDICO</asp:ListItem>
                                    <asp:ListItem>RETORNO AO TRABALHO</asp:ListItem>
                                    <asp:ListItem>MUDANÇA DE RISCO OPERACIONAL</asp:ListItem>
                                    <asp:ListItem>DEMISSIONAL</asp:ListItem>
                                </asp:DropDownList>
                            </asp:Panel>

                            <asp:Panel ID="Panel2" runat="server" Style="float: left;" Width="112px" Height="45px">
                                <asp:Label ID="lblreg" runat="server" Text="Registro" Font-Bold="True"></asp:Label><br />
                                <asp:DropDownList ID="cboreg" runat="server" Height="29px" Width="100px" AutoPostBack="True" CssClass="boxText">
                                </asp:DropDownList>
                            </asp:Panel>

                            <asp:Panel ID="Panel3" runat="server" Style="float: left;" Width="339px" Height="45px">
                                <asp:Label ID="lblnome" runat="server" Text="Nome" Font-Bold="True"></asp:Label><br />
                                <asp:TextBox ID="txtnome" runat="server" Width="318px" Height="25px" Enabled="False" CssClass="boxText"></asp:TextBox>
                            </asp:Panel>

                            <asp:Panel ID="Panel4" runat="server" Style="float: left;" Width="277px" Height="45px">
                                <asp:Label ID="lblcpf" runat="server" Text="CPF" Font-Bold="True"></asp:Label><br />
                                <asp:TextBox ID="txtcpf" runat="server" Width="253px" Height="25px" Enabled="False" CssClass="boxText"></asp:TextBox>
                            </asp:Panel>

                            <asp:Panel ID="Panel5" runat="server" Style="float: left;" Width="101px" Height="45px">
                                <asp:Label ID="lblidade" runat="server" Text="Idade" Font-Bold="True"></asp:Label><br />
                                <asp:TextBox ID="txtidade" runat="server" Height="25px" Width="95px" Enabled="False" CssClass="boxText"></asp:TextBox>
                            </asp:Panel>
                        </asp:Panel>
                        <br />
                        <br />
                        <br />
                        <br />
                        <hr />
                        <asp:Panel ID="Panel14" runat="server" Style="text-align: left;" Width="963px" Height="94px">
                            <asp:Label ID="Label6" runat="server" Text="Riscos" Font-Bold="True" Font-Size="12pt"></asp:Label>
                            <br />
                            <asp:Panel ID="Panel24" runat="server" Height="75px" Width="261px" Style="display: inline-block; text-align: left; vertical-align: top;">
                                <asp:CheckBox ID="cbagef" Text="AGENTES FÍSICOS" runat="server" Font-Size="12pt" AutoPostBack="True" /><br />
                                <asp:CheckBox ID="cbageb" Text="AGENTES BIOLÓGICOS" runat="server" Font-Bold="False" Font-Size="12pt" AutoPostBack="True" /><br />
                                <asp:CheckBox ID="cbaci" Text="ACIDENTES" runat="server" Font-Size="12pt" AutoPostBack="True" />
                            </asp:Panel>
                            <asp:Panel ID="Panel21" runat="server" Height="69px" Width="318px" Style="display: inline-block; text-align: left; vertical-align: top;">
                                <asp:CheckBox ID="cbageq" Text="AGENTES QUÍMICOS" runat="server" Font-Size="12pt" AutoPostBack="True" /><br />
                                <asp:CheckBox ID="cberg" Text="ERGONÔMICOS" runat="server" Font-Size="12pt" AutoPostBack="True" /><br />
                                <asp:CheckBox ID="cbausrisc" Text="AUSÊNCIA DE RISCOS ESPECÍFICOS" runat="server" Font-Size="12pt" AutoPostBack="True" />
                            </asp:Panel>
                        </asp:Panel>
                        <hr />

                        <asp:Panel ID="Panel15" runat="server" Style="text-align: left;" Width="963px" Height="183px">
                            <asp:Label ID="Label7" runat="server" Text="Exames" Font-Bold="True" Font-Size="12pt"></asp:Label>
                            <br />
                            <asp:Panel ID="Panel22" runat="server" Height="99px" Width="383px" Style="display: inline-block; text-align: left; vertical-align: top;">
                                <asp:CheckBox ID="cblab" Text="DOS LABORATORIAIS" runat="server" Font-Size="12pt" AutoPostBack="True" />&nbsp; &nbsp; 
                                <asp:TextBox ID="datalab" runat="server" Height="15px" Width="85px" CssClass="boxText" AutoPostBack="True" Visible="False"></asp:TextBox>
                                <asp:CalendarExtender
                                    ID="CalendarExtender1"
                                    TargetControlID="datalab"
                                    runat="server"
                                    Format="dd/MM/yyyy" />
                                <br />
                                <asp:CheckBox ID="cbtox" Text="DOS TOXICOLÓGICOS" runat="server" Font-Bold="False" Font-Size="12pt" AutoPostBack="True" />&nbsp; &nbsp; 
                                <asp:TextBox ID="datatox" runat="server" Height="15px" Width="85px" CssClass="boxText" Visible="False"></asp:TextBox>
                                <asp:CalendarExtender
                                    ID="CalendarExtender2"
                                    TargetControlID="datatox"
                                    runat="server"
                                    Format="dd/MM/yyyy" />
                                <br />
                                <asp:CheckBox ID="cbeeg" Text="EEG" runat="server" Font-Bold="False" Font-Size="12pt" AutoPostBack="True" />&nbsp; &nbsp; 
                                <asp:TextBox ID="dataeeg" runat="server" Height="15px" Width="85px" CssClass="boxText" Visible="False"></asp:TextBox>
                                <asp:CalendarExtender
                                    ID="CalendarExtender3"
                                    TargetControlID="dataeeg"
                                    runat="server"
                                    Format="dd/MM/yyyy" />
                                <br />
                                <asp:CheckBox ID="cbecg" Text="ECG" runat="server" Font-Bold="False" Font-Size="12pt" AutoPostBack="True" />&nbsp; &nbsp; 
                                <asp:TextBox ID="dataecg" runat="server" Height="15px" Width="85px" CssClass="boxText" Visible="False"></asp:TextBox>
                                <asp:CalendarExtender
                                    ID="CalendarExtender8"
                                    TargetControlID="dataecg"
                                    runat="server"
                                    Format="dd/MM/yyyy" />
                            </asp:Panel>

                            <asp:Panel ID="Panel23" runat="server" Height="99px" Width="329px" Style="display: inline-block; text-align: left; vertical-align: top;">
                                <asp:CheckBox ID="cbradio" Text="RADIOGRAFIA TORÁCICA" runat="server" Font-Size="12pt" AutoPostBack="True" />&nbsp; &nbsp; 
                                <asp:TextBox ID="dataradio" runat="server" Height="15px" Width="85px" CssClass="boxText" Visible="False"></asp:TextBox>
                                <asp:CalendarExtender
                                    ID="CalendarExtender5"
                                    TargetControlID="dataradio"
                                    runat="server"
                                    Format="dd/MM/yyyy" />
                                <br />
                                <asp:CheckBox ID="cbespiro" Text="ESPIROMETRIA" runat="server" Font-Size="12pt" AutoPostBack="True" />&nbsp; &nbsp; 
                                <asp:TextBox ID="dataespiro" runat="server" Height="15px" Width="85px" CssClass="boxText" Visible="False"></asp:TextBox>
                                <asp:CalendarExtender
                                    ID="CalendarExtender6"
                                    TargetControlID="dataespiro"
                                    runat="server"
                                    Format="dd/MM/yyyy" />
                                <br />
                                <asp:CheckBox ID="cbacui" Text="ACUIDADE VISUAL" runat="server" Font-Size="12pt" AutoPostBack="True" />&nbsp; &nbsp; 
                                <asp:TextBox ID="dataacui" runat="server" Height="15px" Width="85px" CssClass="boxText" Visible="False"></asp:TextBox>
                                <asp:CalendarExtender
                                    ID="CalendarExtender7"
                                    TargetControlID="dataacui"
                                    runat="server"
                                    Format="dd/MM/yyyy" />
                                <br />
                                <asp:CheckBox ID="cbaudio" Text="AUDIOMETRIA" runat="server" Font-Size="12pt" AutoPostBack="True" />
                                &nbsp; &nbsp; 
                                <asp:TextBox ID="dataaudio" runat="server" Height="15px" Width="85px" CssClass="boxText" Visible="False"></asp:TextBox>
                                <asp:CalendarExtender
                                    ID="CalendarExtender4"
                                    TargetControlID="dataaudio"
                                    runat="server"
                                    Format="dd/MM/yyyy" />
                            </asp:Panel>
                            <asp:Panel ID="Panel25" runat="server" Height="22px" Width="915px" Style="display: inline-block; text-align: left; vertical-align: top;">
                                <asp:CheckBox ID="cboutros" Text="OUTROS (ESPECIFICAR)" runat="server" Font-Size="12pt" AutoPostBack="True" />
                                &nbsp; &nbsp;                         
                                <asp:TextBox ID="txtoutros" runat="server" Height="25px" Width="506px" CssClass="boxText" Visible="False"></asp:TextBox>
                            </asp:Panel>
                        </asp:Panel>
                        <hr />
                        <br />
                        <asp:Panel ID="Panel17" runat="server" Style="float: left;" Width="97px" Height="70px" DefaultButton="cmdsalvar">
                            <asp:RadioButtonList ID="rbconsiderado" Font-Bold="True" runat="server" Width="155px">
                                <asp:ListItem>APTO</asp:ListItem>
                                <asp:ListItem>INAPTO</asp:ListItem>
                            </asp:RadioButtonList>
                        </asp:Panel>

                        <asp:Panel ID="Panel18" runat="server" Style="float: left;" Width="263px" Height="70px" DefaultButton="cmdsalvar">
                            <asp:Label ID="Label4" runat="server" Text="Para a Função" Font-Bold="True"></asp:Label>
                            <br />
                            <asp:DropDownList ID="txtfuncao" runat="server" Height="29px" Width="256px" CssClass="boxText"></asp:DropDownList>
                        </asp:Panel>

                        <asp:Panel ID="Panel19" runat="server" Style="float: left;" Width="243px" Height="70px">
                            <asp:Label ID="lblarea" runat="server" Text="Área" Font-Bold="True"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtarea" runat="server" Width="227px" Height="25px" Enabled="False" CssClass="boxText"></asp:TextBox>
                        </asp:Panel>

                        <asp:Panel ID="Panel20" runat="server" Style="float: left;" Width="360px" Height="70px" DefaultButton="cmdsalvar">
                            <asp:Label ID="Label5" runat="server" Text="Observação" Font-Bold="True"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtobs" runat="server" Width="356px" Height="25px" CssClass="boxText"></asp:TextBox>
                        </asp:Panel>
                        <br />
                        <br />
                        <br />
                        <asp:Button ID="cmdsalvar" Text="Salvar" runat="server" Style="float: right; margin-left: 0px;" Font-Size="SMALL" Height="32px" Width="102px" CssClass="BtnStyle" />
                        <asp:TextBox ID="txtdata" runat="server" Style="margin-bottom: 20px;" Height="25px" Width="131px" Enabled="False" CssClass="boxText"></asp:TextBox>
                        <ajaxToolkit:ModalPopupExtender ID="mp2" runat="server" PopupControlID="Panel11" TargetControlID="lblsv" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
                        <asp:Panel ID="Panel11" runat="server" Style="display: none;" CssClass="modalPopup">
                            <asp:Label ID="lblsv" runat="server" class="titulo-modal" ></asp:Label>
                            <br />
                            <asp:Button ID="cmdimprimir" runat="server" Text="IMPRIMIR" class="BtnStyle" Height="35px" Width="102px" />
                            <asp:Button ID="cmdfechar" runat="server" Text="FECHAR" class="BtnStyle" Height="35px" Width="102px" />
                        </asp:Panel>


                        <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel16" TargetControlID="ORDEMP" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
                        <asp:Panel ID="Panel16" runat="server" Style="display: none;" CssClass="modalPopup">
                            <asp:Label ID="ORDEMP" runat="server" class="titulo-modal"></asp:Label>
                            <br />
                            <asp:Button ID="btnClose" runat="server" Text="FECHAR" class="BtnStyle" Height="35px" Width="102px" />
                        </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>

