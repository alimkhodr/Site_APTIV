<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultarTreinamento_Novo.aspx.vb" Inherits="SGM_WEB.ConsultarTreinamento_Novo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <link href="../Padrao.css" rel="stylesheet">

    <style>
        .formulario-container {
            background: #d4d4d4;
            display: flex;
            flex-direction: column;
            border-radius: 0px 0 15px 0px;
            height: auto;
        }

        .grid-container {
            overflow-y: scroll;
            overflow-x: hidden;
            height: 250px;
        }

        span input {
            margin: 0px 4px;
        }

        .grid-img {
            width: 20px;
        }
    </style>

    <script type="text/javascript">
        function handleKeyPress(e) {
            var key = e.keyCode || e.which;
            if (key === 13) {
                e.preventDefault();
                document.getElementById('<%= cmdimprimir.ClientID %>').click();
            }
        }
        document.addEventListener('keypress', handleKeyPress);
    </script>

    <asp:Panel ID="Panel20" runat="server" Width="1017px">
        <div class="title">
            <asp:Label ID="Label25" runat="server" class="dot-title" Text="•"></asp:Label>
            <asp:Label ID="txtconf" runat="server" class="text-title" Text="CONSULTAR TREINAMENTO"></asp:Label>
            <asp:Label ID="Label5" runat="server" class="dot-title" Text="•"></asp:Label>
        </div>

        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="container">
                    <asp:Panel ID="Panel8" runat="server" Height="57px" Style="display: flex; justify-content: space-between; margin: 15px 0;">
                        <asp:Panel ID="Panel9" runat="server" Height="57px" DefaultButton="btn_proc">
                            <asp:Label ID="lblnf" runat="server" Text="Nº Formulario" Enabled="False" Font-Bold="True"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtnform" runat="server" Width="84px" Height="25px" CssClass="boxText"></asp:TextBox>
                            <asp:Button ID="btn_proc" class="BtnStyle" Height="25px" Width="80px" runat="server" Text="Pesquisar" Font-Size="Small" Style="margin-left: 10px;" /><br />
                        </asp:Panel>
                        <asp:Panel ID="panel_treinador" runat="server" Height="57px" Style="display: flex; justify-content: flex-end;">
                            <asp:Panel ID="Panel2" runat="server" Style="margin-left: 10px;">
                                <asp:Label ID="Label2" runat="server" Text="Registro" Font-Bold="True"></asp:Label><br />
                                <asp:TextBox ID="txt_regt" runat="server" Width="99px" Height="25px" Enabled="False" CssClass="boxText"></asp:TextBox>
                            </asp:Panel>

                            <asp:Panel ID="Panel21" runat="server" Style="margin-left: 10px;">
                                <asp:Label ID="lblnomet" runat="server" Text="Treinador" Font-Bold="True"></asp:Label>
                                <asp:CheckBox ID="Chkexterno" runat="server" Font-Bold="True" Style="margin-left: 9px" Height="16px" Width="105px" Text="Externo" AutoPostBack="True" Enabled="False" />
                                <br />
                                <asp:TextBox ID="txt_nomet" runat="server" Width="326px" Height="25px" Enabled="False" CssClass="boxText"></asp:TextBox>
                            </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>

                    <hr />

                    <asp:Panel ID="panel_treinamento" runat="server" Style="margin: 15px 0;">
                        <asp:Panel ID="Panel1" runat="server" Style="display: flex;">
                            <asp:Panel ID="Panel11" runat="server">
                                <asp:Label ID="lblTreinamento" runat="server" Text="Treinamento" Font-Bold="True"></asp:Label>
                                <br />
                                <asp:TextBox ID="txt_treino" runat="server" CssClass="boxText" Height="25px" Width="240px" Enabled="False"></asp:TextBox>
                            </asp:Panel>
                            <asp:Panel ID="Panel12" runat="server" Style="margin-left: 10px;">
                                <asp:Label ID="lbltipo" runat="server" Text="Tipo" Font-Bold="True"></asp:Label>
                                <br />
                                <asp:TextBox ID="txt_tipo" runat="server" Height="25px" Width="95px" CssClass="boxText" Enabled="False"></asp:TextBox>
                            </asp:Panel>

                            <asp:Panel ID="Panel13" runat="server" Style="margin-left: 10px;">
                                <asp:Label ID="lblassunto" runat="server" Text="Assunto" Font-Bold="True"></asp:Label>
                                <br />
                                <asp:TextBox ID="txt_assunto" runat="server" Height="25px" Width="95px" CssClass="boxText" Enabled="False"></asp:TextBox>
                            </asp:Panel>
                            <asp:Panel ID="Panel19" runat="server" Style="margin-left: 10px;">
                                <asp:Label ID="Subtitulo1" runat="server" Text="Subtítulo de Treinamento" Font-Bold="True"></asp:Label>
                                <br />
                                <asp:TextBox ID="txt_subtitulo" runat="server" Height="25px" Width="327px" CssClass="boxText" Enabled="False"></asp:TextBox>
                            </asp:Panel>
                        </asp:Panel>
                        <br />
                        <asp:Panel ID="Panel3" runat="server" Style="display: flex;">
                            <asp:Panel ID="Panel14" runat="server">
                                <asp:Label ID="lbllocal" runat="server" Text="Local" Font-Bold="True"></asp:Label>
                                <br />
                                <asp:TextBox ID="txt_local" runat="server" Width="240px" Height="25px" CssClass="boxText" Enabled="False"></asp:TextBox>
                            </asp:Panel>

                            <asp:Panel ID="Panel15" runat="server" Style="margin-left: 10px;">
                                <asp:Label ID="lbDatai" runat="server" Text="Data Início" Font-Bold="True"></asp:Label>
                                <br />
                                <asp:TextBox ID="txt_data" runat="server" Height="25px" Width="95px" CssClass="boxText" Enabled="False"></asp:TextBox>
                            </asp:Panel>

                            <asp:Panel ID="Panel16" runat="server" Style="margin-left: 10px;">
                                <asp:Label ID="lblhi" runat="server" Text="Hora Início" Font-Bold="True"></asp:Label>
                                <br />
                                <asp:TextBox ID="txt_horai" runat="server" Width="99px" Height="25px" Enabled="False" CssClass="boxText"></asp:TextBox>
                            </asp:Panel>

                            <asp:Panel ID="Panel17" runat="server" Style="margin-left: 10px;">
                                <asp:Label ID="lblhf" runat="server" Text="Hora Fim" Font-Bold="True"></asp:Label>
                                <br />
                                <asp:TextBox ID="txt_horaf" runat="server" Width="99px" Height="25px" Enabled="False" CssClass="boxText"></asp:TextBox>
                            </asp:Panel>
                        </asp:Panel>
                    </asp:Panel>
                    <hr />
                    <asp:Panel ID="panel_pdf" runat="server" Style="margin: 15px 0;">
                        <iframe id="pdfPreview" runat="server" style="width: 100%; height: 400px; border: none; background: #d4d4d4;"></iframe>
                    </asp:Panel>
                    <hr />
                    <asp:Panel ID="Panel25" runat="server" Style="margin: 15px 0;">
                        <asp:Label ID="Label17" runat="server" Text="Lista de Presença" Font-Bold="True" Font-Size="Large"></asp:Label>
                        <br />
                        <br />
                        <div class="formulario-container" id="Painel2">
                            <div class="grid-container">
                                <asp:GridView ID="Lista" runat="server" AutoGenerateColumns="False" BackColor="White" Font-Bold="True" Font-Size="Small" Font-Strikeout="False" GridLines="None" Height="33px" HorizontalAlign="Center" Width="100%">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#284775" ForeColor="White" />
                                    <RowStyle BackColor="#F7F6F3" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#333333" />
                                    <Columns>
                                        <asp:BoundField DataField="FTRE_REGISTRO" HeaderText="REGISTRO" HeaderStyle-CssClass="grid-th">
                                            <ItemStyle CssClass="grid-td" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FUN_NOME" HeaderText="NOME" HeaderStyle-CssClass="grid-th">
                                            <ItemStyle CssClass="grid-td" />
                                        </asp:BoundField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <br />
                        <asp:Panel ID="Panel4" runat="server" Style="display: flex; justify-content: flex-end;">
                            <asp:Button ID="cmdimprimir" Text="IMPRIMIR" runat="server" Style="margin-left: 0px;" Font-Size="SMALL" Height="35px" Width="102px" CssClass="BtnStyle" />
                        </asp:Panel>
                    </asp:Panel>
                    <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel5" TargetControlID="ORDEMP" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
                    <asp:Panel ID="Panel5" runat="server" Style="display: none;" CssClass="modalPopup">
                        <asp:Label ID="ORDEMP" class="titulo-modal" runat="server"></asp:Label>
                        <br />
                        <asp:Button ID="btnClose" class="BtnStyle" Height="35px" Width="102px" runat="server" Text="FECHAR" />
                    </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>

