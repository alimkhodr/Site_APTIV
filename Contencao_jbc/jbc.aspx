<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="jbc.aspx.vb" Inherits="SGM_WEB.jbc" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <link href="../Padrao.css" rel="stylesheet">
    <style>
        .column {
            display: flex;
            flex-direction: column;
            border-radius: 0 0 15px 15px;
            background-color: #e2e2e2;
            width: 100%;
            padding: 25px;
        }

        .grid {
            display: flex;
            flex-direction: column;
        }

        .sub-grid {
            display: flex;
            flex-direction: row;
            margin-top: 8px;
            width: 100%;
        }

        .main-container {
            display: flex;
            justify-content: space-between;
        }

        .btn {
            display: flex;
        }

        .listPNStyle {
            height: 122px;
            width: 100%;
            border: none;
            margin: 8px 0;
            font-size: large;
            text-align: center;
        }

            .listPNStyle option {
                padding: 4px;
            }
    </style>

    <script type="text/javascript">
        function validateInput(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode;
            var textBoxValue = evt.target.value;
            if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                return false;
            }
            return true;
        }
    </script>

    <asp:Panel ID="Panel2" runat="server" Width="900px">
        <div class="title">
            <asp:Label ID="Label25" runat="server" class="dot-title" Text="•"></asp:Label>
            <asp:Label ID="txtconf" runat="server" class="text-title" Text="REGISTRO DE CONTENÇÃO"></asp:Label>
            <asp:Label ID="Label5" runat="server" class="dot-title" Text="•"></asp:Label>
        </div>
        <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel16" TargetControlID="ORDEMP" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="Panel16" runat="server" CssClass="modalPopup" Style="display: none; font-weight: bold;" HorizontalAlign="center">
            <br />
            <asp:Label ID="ORDEMP" runat="server" Font-Size="Larger"></asp:Label>
            <br />
            <asp:Button ID="btnClose" Text="FECHAR" Height="25px" Width="80px" runat="server" Font-Size="Small" class="BtnStyle" />
        </asp:Panel>
        <div class="main-container">
            <asp:Panel ID="column" runat="server" CssClass="column" DefaultButton="btn_salvar">
                <div class="grid">
                    <asp:Label ID="Label4" runat="server" Text="Pesquisar JBC" Font-Bold="true"></asp:Label>
                    <div class="sub-grid">
                        <asp:Panel ID="panel30" runat="server" Style="display: flex; flex-direction: column; width: 15%;" DefaultButton="btn_proc">
                            <asp:TextBox ID="txt_proc" runat="server" CssClass="boxText" Height="25px" onkeypress="return validateInput(event)"></asp:TextBox>
                        </asp:Panel>
                        &nbsp;
                            <div style="display: flex; align-items: flex-end;">
                                <asp:Button ID="btn_proc" class="BtnStyle" Height="25px" Width="80px" runat="server" Text="Pesquisar" Font-Size="Small" Style="margin-left: 10px;" />
                            </div>
                    </div>
                </div>
                <br />
                <div class="grid">
                    <div class="sub-grid">
                        <div style="display: flex; flex-direction: column; width: 15%;">
                            <asp:Label ID="Label3" runat="server" Text="N° JBC" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txt_nform" runat="server" CssClass="boxText" Height="25px" Enabled="false"></asp:TextBox>
                        </div>
                        &nbsp; &nbsp;
                        <div style="display: flex; flex-direction: column;">
                            <asp:Label ID="Label7" runat="server" Text="Data emissão" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txt_data" runat="server" Height="27px" Width="95px" CssClass="boxText" TextMode="Date"></asp:TextBox>
                        </div>
                        &nbsp; &nbsp;
                                <div style="display: flex; flex-direction: column; width: 100%;">
                                    <asp:Label ID="Label9" runat="server" Text="Tipo" Font-Bold="true"></asp:Label>
                                    <asp:DropDownList ID="cbo_tipo" runat="server" Height="28px" AutoPostBack="true" Width="100%" CssClass="boxText">
                                        <asp:ListItem></asp:ListItem>
                                        <asp:ListItem>Reativa</asp:ListItem>
                                        <asp:ListItem>Proativa</asp:ListItem>
                                        <asp:ListItem>CSI</asp:ListItem>
                                        <asp:ListItem>Desvio</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                    </div>
                </div>
                <br />
                <div class="grid">
                    <asp:Label ID="Label14" runat="server" Text="Descrição" Font-Bold="true"></asp:Label>
                    <asp:TextBox ID="txt_descricao" runat="server" CssClass="boxText" Height="25px" Style="height: 100px; max-height: 189px; max-width: 845px; width: 100%; background: #fbfafa;" TextMode="MultiLine"></asp:TextBox>
                </div>
                <br />
                <div class="grid">
                    <div class="sub-grid">
                        <div style="display: flex; flex-direction: column; width: 100%;">
                            <asp:Label ID="Label10" runat="server" Text="Linha (Família)" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="txt_familia" runat="server" CssClass="boxText" Height="28px" Width="100%"></asp:DropDownList>
                        </div>
                        &nbsp; &nbsp;&nbsp; &nbsp;
                        <div style="display: flex; flex-direction: column; width: 100%;">
                            <asp:Label ID="Label12" runat="server" Text="Forma de Identificação" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txt_indent" runat="server" CssClass="boxText" Height="25px" Width="100%" Text=""></asp:TextBox>
                        </div>
                    </div>
                </div>
                <br />
                <div class="grid">
                    <div class="sub-grid">
                        <div style="display: flex; flex-direction: column; width: 100%;">
                            <asp:Label ID="Label15" runat="server" Text="Razão" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="txt_razao" runat="server" CssClass="boxText" Height="28px" Width="100%">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Reclamação de Cliente</asp:ListItem>
                                <asp:ListItem>Reclamação Interna</asp:ListItem>
                                <asp:ListItem>Desvio</asp:ListItem>
                                <asp:ListItem>Lote Piloto</asp:ListItem>
                                <asp:ListItem>Kaizen</asp:ListItem>
                                <asp:ListItem>DPS</asp:ListItem>
                                <asp:ListItem>ECN</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        &nbsp; &nbsp;&nbsp; &nbsp;
                        <div style="display: flex; flex-direction: column; width: 100%;">
                            <asp:Label ID="Label8" runat="server" Text="Plano de Reação" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txt_reacao" runat="server" CssClass="boxText" Height="25px" Width="100%" Text="Segregar e tratar como produto não conforme."></asp:TextBox>
                        </div>
                    </div>
                </div>
                <br />
                <div class="grid">
                    <asp:Label ID="Label16" runat="server" Text="Responsável p/ Contenção" Font-Bold="true"></asp:Label>
                    <asp:DropDownList ID="cbo_responsavel" runat="server" Height="28px" AutoPostBack="true" Width="100%" CssClass="boxText">
                        <asp:ListItem></asp:ListItem>
                        <asp:ListItem>Manufatura</asp:ListItem>
                        <asp:ListItem>Qualidade</asp:ListItem>
                        <asp:ListItem>Outros</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <asp:Panel ID="panel_outros" runat="server" Visible="false">
                        <asp:Label ID="Outros" runat="server" Text="Descreva o responsável" Font-Bold="true" Font-Size="X-Small"></asp:Label>
                        <asp:TextBox ID="txt_outros" runat="server" CssClass="boxText" Height="25px" Width="100%"></asp:TextBox>
                    </asp:Panel>
                </div>
                <br />
                <div class="grid">
                    <asp:Label ID="Label1" runat="server" Text="Partnumber" Font-Bold="true"></asp:Label>
                    <div class="sub-grid">
                        <div style="display: flex; flex-direction: column; width: 100%;">
                            <div class="sub-grid">
                                <div style="display: flex; flex-direction: column; width: 100%;">
                                    <asp:Label ID="Label2" runat="server" Text="Linha" Font-Bold="true" Font-Size="X-Small"></asp:Label>
                                    <asp:DropDownList ID="cbo_linha" runat="server" SelectionMode="Multiple" Height="28px" AutoPostBack="true" Width="100%" CssClass="boxText">
                                    </asp:DropDownList>
                                </div>
                                &nbsp; &nbsp;
                                <asp:Panel ID="panel90" runat="server" Style="display: flex; flex-direction: column; width: 100%;" DefaultButton="btn_proc_pn">
                                    <asp:Label ID="Label6" runat="server" Text="PartNumber" Font-Bold="true" Font-Size="X-Small"></asp:Label>
                                    <asp:TextBox ID="txt_proc_pn" runat="server" CssClass="boxText" Height="25px" Width="100%"></asp:TextBox>
                                </asp:Panel>
                                &nbsp; &nbsp;
                                                            <div style="display: flex; align-items: flex-end;">
                                                                <asp:Button ID="btn_proc_pn" class="BtnStyle" Height="0" Width="0" runat="server" Text="O" Font-Size="Small" />
                                                            </div>
                            </div>
                            <asp:ListBox ID="listPN" runat="server" Rows="10" SelectionMode="Multiple" CssClass="listPNStyle"></asp:ListBox>
                            <asp:Button ID="btn_vincular_pn" class="BtnStyleGreen" Height="30px" Width="100%" runat="server" Text="Vincular PN" Font-Size="Small" />
                        </div>
                        &nbsp; &nbsp;
                                <div style="display: flex; flex-direction: column; width: 100%; justify-content: flex-end;">
                                    <asp:ListBox ID="ListPNvinculado" runat="server" Rows="10" SelectionMode="Multiple" CssClass="listPNStyle"></asp:ListBox>
                                    <asp:Button ID="btn_desvincular_pn" class="BtnStyleRed" Height="30px" Width="100%" runat="server" Text="Desvincular PN" Font-Size="Small" />
                                </div>
                    </div>
                </div>
                <br />
                <asp:Panel ID="panel_rev" runat="server" Visible="false">
                    <div class="grid">
                        <div class="sub-grid">
                            <div style="display: flex; flex-direction: column; width: 100%;">
                                <asp:Label ID="Label11" runat="server" Text="Motivo da revisão" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="txt_rev_motivo" runat="server" CssClass="boxText" Height="25px"></asp:TextBox>
                            </div>
                            <div style="display: flex; align-items: flex-end;">
                                <asp:FileUpload ID="FileUpload1" runat="server" Style="margin-left: 10px;" />
                            </div>
                            <div style="display: flex; align-items: flex-end;">
                                <asp:Button ID="btn_add_rev" class="BtnStyle" runat="server" Text="Adicionar" Height="25px" Width="80px" Font-Size="Small" Style="margin-left: 10px;" />
                            </div>
                        </div>
                        <asp:ListBox ID="ListRev" runat="server" Rows="10" SelectionMode="Multiple" CssClass="listPNStyle" Style="font-size: medium; text-align: left;"></asp:ListBox>
                    </div>
                </asp:Panel>
                <br />
                <div class="btn">
                    <asp:Button ID="btn_salvar" class="BtnStyle" Height="30px" Width="100%" runat="server" Text="Salvar" Font-Size="Small" />
                    <asp:Button ID="btn_concluir" class="BtnStyle" Height="30px" Width="100%" runat="server" Text="Finalizar JBC" Font-Size="Small" Visible="false" Style="margin-left: 5px" />
                </div>
            </asp:Panel>
        </div>
    </asp:Panel>
</asp:Content>
