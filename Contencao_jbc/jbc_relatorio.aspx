<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="jbc_relatorio.aspx.vb" Inherits="SGM_WEB.jbc_relatorio" %>

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
            height: 280px;
        }

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

        .boxText {
            border: 1px solid #bfbfbf;
            border-radius: 5px;
            background-color: #ededed;
            transition: all .3s ease-out;
            outline: none;
            margin-right: 0px;
            margin-top: 6px;
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
            <asp:Label ID="txtconf" runat="server" class="text-title" Text="RELATÓRIO JBC"></asp:Label>
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
            <asp:Panel ID="column" runat="server" CssClass="column">
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
                <asp:Panel ID="Panel1" runat="server" Enabled="false">
                    <div class="grid">
                        <div class="sub-grid">
                            <div style="display: flex; flex-direction: column; width: 15%;">
                                <asp:Label ID="Label3" runat="server" Text="N° JBC" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="txt_nform" runat="server" CssClass="boxText" Height="25px" Enabled="false"></asp:TextBox>
                            </div>
                            &nbsp; &nbsp;
                        <div style="display: flex; flex-direction: column;">
                            <asp:Label ID="Label7" runat="server" Text="Data emissão" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txt_data" runat="server" Height="25px" Width="95px" CssClass="boxText"></asp:TextBox>
                        </div>
                            &nbsp; &nbsp;
                        <div style="display: flex; flex-direction: column;">
                            <asp:Label ID="Label1" runat="server" Text="Data fim" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txt_data_fim" runat="server" Height="25px" Width="95px" CssClass="boxText"></asp:TextBox>
                        </div>
                            &nbsp; &nbsp;
                                <div style="display: flex; flex-direction: column; width: 100%;">
                                    <asp:Label ID="Label9" runat="server" Text="Tipo" Font-Bold="true"></asp:Label>
                                    <asp:TextBox ID="txt_tipo" runat="server" Height="25px" Width="100%" CssClass="boxText"></asp:TextBox>
                                </div>
                        </div>
                    </div>
                    <br />
                    <div class="grid">
                        <asp:Label ID="Label14" runat="server" Text="Descrição" Font-Bold="true"></asp:Label>
                        <asp:TextBox ID="txt_descricao" runat="server" CssClass="boxText" Height="25px" Style="height: 100px; max-height: 189px; max-width: 845px; width: 100%" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <br />
                    <div class="grid">
                        <div class="sub-grid">
                            <div style="display: flex; flex-direction: column; width: 100%;">
                                <asp:Label ID="Label10" runat="server" Text="Linha (Família)" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="txt_linha" runat="server" CssClass="boxText" Height="25px" Width="100%"></asp:TextBox>
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
                                <asp:TextBox ID="txt_razao" runat="server" CssClass="boxText" Height="25px" Width="100%"></asp:TextBox>
                            </div>
                            &nbsp; &nbsp;&nbsp; &nbsp;
                        <div style="display: flex; flex-direction: column; width: 100%;">
                            <asp:Label ID="Label8" runat="server" Text="Plano de Reação" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txt_reacao" runat="server" CssClass="boxText" Height="25px" Width="100%"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                    <br />
                    <div class="grid">
                        <div class="sub-grid">
                            <div style="display: flex; flex-direction: column; width: 100%;">
                                <asp:Label ID="Label11" runat="server" Text="Emitente" Font-Bold="true"></asp:Label>
                                <asp:TextBox ID="txt_emitente" runat="server" Height="25px" AutoPostBack="true" Width="100%" CssClass="boxText"></asp:TextBox>
                            </div>
                            &nbsp; &nbsp;&nbsp; &nbsp;
                        <div style="display: flex; flex-direction: column; width: 100%;">
                            <asp:Label ID="Label16" runat="server" Text="Responsável p/ Contenção" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txt_responsavel" runat="server" Height="25px" AutoPostBack="true" Width="100%" CssClass="boxText"></asp:TextBox>
                        </div>
                        </div>
                    </div>
                </asp:Panel>
                <br />
                <div class="grid">
                    <asp:Label ID="Label6" runat="server" Text="PartNumber's" Font-Bold="true"></asp:Label><br />
                    <div class="formulario-container" id="Painel20">
                        <div class="grid-container" style="height: 150px;">
                            <asp:GridView ID="ListaPN" runat="server" AutoGenerateColumns="False" BackColor="White" Font-Bold="True" Font-Size="Small" Font-Strikeout="False" GridLines="None" Height="33px" HorizontalAlign="Center" Width="100%">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#284775" ForeColor="White" />
                                <RowStyle BackColor="#F7F6F3" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="PN" HeaderText="PN" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <br />
                <div class="grid">
                    <asp:Label ID="Label13" runat="server" Text="Revisões" Font-Bold="true"></asp:Label><br />
                    <div class="formulario-container" id="Painel30">
                        <div class="grid-container" style="height: 150px;">
                            <asp:GridView ID="ListaREV" runat="server" AutoGenerateColumns="False" BackColor="White" Font-Bold="True" Font-Size="Small" Font-Strikeout="False" GridLines="None" Height="33px" HorizontalAlign="Center" Width="100%">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#284775" ForeColor="White" />
                                <RowStyle BackColor="#F7F6F3" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="REV_SEQUENCIA" HeaderText="SEQUÊNCIA" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="REV_RESPONSAVEL" HeaderText="RESPONSÁVEL" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="REV_DATA" HeaderText="DATA" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="REV_MOTIVO" HeaderText="MOTIVO" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="REV_PATH" HeaderText="ARQUIVO" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="Image" CommandName="DOWNLOAD" ImageUrl="~/Images/mingcute--file-download-fill.png" HeaderStyle-CssClass="grid-th">
                                        <ControlStyle CssClass="grid-img" />
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:ButtonField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <br />
                <div class="grid">
                    <asp:Label ID="Label2" runat="server" Text="Contenções" Font-Bold="true"></asp:Label><br />
                    <div class="formulario-container" id="Painel2">
                        <div class="grid-container">
                            <asp:GridView ID="ListaContencao" runat="server" AutoGenerateColumns="False" BackColor="White" Font-Bold="True" Font-Size="XX-Small" Font-Strikeout="False" GridLines="None" Height="33px" HorizontalAlign="Center" Width="100%">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#284775" ForeColor="White" />
                                <RowStyle BackColor="#F7F6F3" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="CON_CAIXA" HeaderText="CAIXA" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PN_PARTNUMBER" HeaderText="PN" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CON_QUANTIDADE" HeaderText="QUANTIDADE" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CON_AREA" HeaderText="ÁREA" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CARTAO_ID" HeaderText="CARTÃO." HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FUN_NOME" HeaderText="FUNCIONÁRIO" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CON_ENTRADA" HeaderText="ENTRADA" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="DIAS" HeaderText="DIAS" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="INICIO" HeaderText="INÍCIO" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CON_SAIDA" HeaderText="SAÍDA" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TEMPO" HeaderText="TEMPO (M)" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="STATUS" HeaderText="STATUS" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="COD_ID" HeaderText="CODIGO DEFEITO" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SC_MOTIVO" HeaderText="MOTIVO DEFEITO" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SC_QUANTIDADE" HeaderText="QTD. DEFEITO" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </asp:Panel>
</asp:Content>
