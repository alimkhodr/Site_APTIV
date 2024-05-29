<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TPM.aspx.vb" Inherits="SGM_WEB.TPM" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="../Padrao.css" rel="stylesheet">
    <script src="../../Scripts/ShowImg.js"></script>
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
            height: 100%;
            width: 850px;
        }

        .container {
            border-radius: 0;
            background: #d4d4d4;
            display: flex;
        }

        .grid {
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .column {
            display: flex;
            flex-direction: column;
            border-radius: 0 0 0 15px;
            background-color: #e2e2e2;
            width: 150px;
            padding: 25px;
        }

        .img {
            max-width: 100%;
            padding: 5px;
        }

        .file {
            min-width: 99px;
            max-width: 99px;
            margin-bottom: 5px;
            font-size: 11px;
        }

        .main-container {
            display: flex;
            justify-content: space-between;
        }

        .grid-td {
            padding: 5px !important;
            text-align: center;
            width: 80px;
            padding: 8px;
            text-overflow: ellipsis;
            overflow: hidden;
            max-width: 70px;
            font-size: x-small;
        }

        .boxText {
            width: 100%;
        }

        .border-img {
            align-items: center;
            display: flex;
            flex-direction: column;
            border: dashed 1px #33333366;
            padding: 5px;
            margin-top: 8px;
            border-radius: 5px;
            width: 100%;
        }

        .x {
            font-size: Small;
            BACKGROUND-COLOR: red;
            border: none;
            color: white;
            padding: 0;
            border-radius: 50%;
            width: 15px;
            height: 15px;
            transition: 0.2s;
        }

            .x:hover {
                box-shadow: rgb(255 0 0 / 35%) 0px 0px 20px 3px;
            }
    </style>

    <asp:Panel ID="Panel3" runat="server" Style="width: 1050px">
        <div style="color: #f7f6f3; display: flex; align-items: center; justify-content: center; background: #333333; border-radius: 15PX 15PX 0 0;">
            <asp:Label ID="Label25" runat="server" Text="•" Style="font-size: 60px; color: #F84018;"></asp:Label>
            &nbsp;&nbsp;<asp:Label ID="txtconf" runat="server" Font-Bold="True" Font-Size="X-Large" Style="font-size: 32px" Text="FORMULÁRIO TPM"></asp:Label>&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text="•" Style="font-size: 60px; color: #F84018;"></asp:Label>
        </div>
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="container">
                    <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel16" TargetControlID="ORDEMP" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
                    <asp:Panel ID="Panel16" runat="server" CssClass="modalPopup" Style="display: none; font-weight: bold;" HorizontalAlign="center">
                        <br />
                        <asp:Label ID="ORDEMP" runat="server" Font-Size="Larger"></asp:Label>
                        <br />
                        <asp:Button ID="btnClose" Text="FECHAR" Height="25px" Width="80px" runat="server" Font-Size="Small" class="BtnStyle" />
                    </asp:Panel>

                    <asp:Panel ID="Panel1" runat="server" Height="57px" Width="100%" Style="display: flex; align-items: center;">
                        <asp:Panel ID="Panel4" runat="server" Style="margin-right: 20px;">
                            <asp:Label ID="Label2" runat="server" Text="Linha*" Font-Bold="True"></asp:Label><br />
                            <asp:DropDownList ID="txt_linha" runat="server" Height="28px" CssClass="boxText" AutoPostBack="True"></asp:DropDownList>
                        </asp:Panel>

                        <asp:Panel ID="Panel7" runat="server" Style="margin-right: 20px;">
                            <asp:Label ID="Label16" runat="server" Text="Vincula ao Setup?*" Font-Bold="True"></asp:Label><br />
                            <asp:DropDownList ID="txt_vincula" runat="server" CssClass="boxText" Height="28px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Sim</asp:ListItem>
                                <asp:ListItem>Não</asp:ListItem>
                            </asp:DropDownList>
                        </asp:Panel>

                        <asp:Panel ID="Panel5" runat="server" Style="margin-right: 20px;">
                            <asp:Label ID="Label15" runat="server" Text="Executante*" Font-Bold="True"></asp:Label><br />
                            <asp:DropDownList ID="txt_exe" runat="server" CssClass="boxText" Height="28px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Operador</asp:ListItem>
                                <asp:ListItem>Operador de Setup</asp:ListItem>
                            </asp:DropDownList>
                        </asp:Panel>

                        <asp:Panel ID="Panel2" runat="server" Style="margin-right: 20px;">
                            <asp:Label ID="Label4" runat="server" Text="Revisão" Font-Bold="True"></asp:Label><br />
                            <asp:TextBox ID="txt_rev" runat="server" Height="25px" Width="75px" CssClass="boxText" Enabled="false"></asp:TextBox>
                            <asp:Button ID="btn_salvaform" class="BtnStyle" Height="25px" Width="80px" runat="server" Text="Criar" Font-Size="Small" Style="margin-left: 10px;" />
                        </asp:Panel>
                    </asp:Panel>
                    <br />
                </div>
                <div class="main-container">
                    <asp:Panel ID="column" runat="server" CssClass="column" Enabled="false" DefaultButton="btn_salvar">
                        <div class="grid">
                            <asp:Label ID="Label14" runat="server" Text="N" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txt_n" runat="server" CssClass="boxText" Width="30px" Enabled="false" Height="25px" Style="text-align: center;"></asp:TextBox>
                        </div>
                        <br />
                        <div class="grid">
                            <asp:Label ID="Label6" runat="server" Text="ITEM*" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txt_item" runat="server" CssClass="boxText" Height="25px"></asp:TextBox>
                        </div>
                        <br />
                        <div class="grid">
                            <asp:Label ID="Label7" runat="server" Text="VISUAL" Font-Bold="true"></asp:Label>
                            <div class="border-img">
                                <asp:Label ID="Label1" runat="server" Text="Imagem 1" Font-Bold="true" Font-Size="X-Small"></asp:Label>
                                <asp:Image ID="img_visual1" CssClass="img" runat="server" />
                                <asp:Label ID="LabelUpload1" runat="server" Visible="false" Font-Size="X-Small"></asp:Label>
                                <asp:FileUpload ID="upload_visual1" CssClass="file" runat="server" />
                            </div>
                            <div class="border-img">
                                <asp:Label ID="Label17" runat="server" Text="Imagem 2" Font-Bold="true" Font-Size="X-Small"></asp:Label>
                                <asp:Image ID="img_visual2" CssClass="img" runat="server" />
                                 <asp:Label ID="LabelUpload2" runat="server" Visible="false" Font-Size="X-Small"></asp:Label>
                                <asp:FileUpload ID="upload_visual2" CssClass="file" runat="server" />
                            </div>
                        </div>
                        <br />
                        <div class="grid">
                            <asp:Label ID="Label8" runat="server" Text="PADRÃO*" Font-Bold="true"></asp:Label>
                            <div class="border-img">
                                <asp:Label ID="Label19" runat="server" Text="Imagem 1" Font-Bold="true" Font-Size="X-Small"></asp:Label>
                                <asp:Image ID="img_padrao" CssClass="img" runat="server" />
                                 <asp:Label ID="LabelUpload3" runat="server" Visible="false" Font-Size="X-Small"></asp:Label>
                                <asp:FileUpload ID="upload_padrao" CssClass="file" runat="server" />
                            </div>
                            <asp:TextBox ID="txt_padrao" runat="server" CssClass="boxText" Height="25px"></asp:TextBox>
                        </div>
                        <br />
                        <div class="grid">
                            <asp:Label ID="Label9" runat="server" Text="MÉTODO*" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txt_metodo" runat="server" CssClass="boxText" Height="25px"></asp:TextBox>
                        </div>
                        <br />
                        <div class="grid">
                            <asp:Label ID="Label10" runat="server" Text="MATERIAIS" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txt_materiais" runat="server" CssClass="boxText" Height="25px"></asp:TextBox>
                        </div>
                        <br />
                        <div class="grid">
                            <asp:Label ID="Label11" runat="server" Text="AÇÃO CORRETIVA" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txt_acao" runat="server" CssClass="boxText" Height="25px"></asp:TextBox>
                        </div>
                        <br />
                        <div class="grid">
                            <asp:Label ID="Label12" runat="server" Text="RESPONSÁVEL*" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="txt_resp" runat="server" CssClass="boxText" Height="28px">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>Operador</asp:ListItem>
                                <asp:ListItem>Operador de Setup</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <br />
                        <div class="grid">
                            <asp:Label ID="Label5" runat="server" Text="TEMPO" Font-Bold="true"></asp:Label>
                            <asp:TextBox ID="txt_tempo" runat="server" CssClass="boxText" Height="25px" onkeypress="return validateInput(event)"></asp:TextBox>
                            <script type="text/javascript">
                                function validateInput(evt) {
                                    var charCode = (evt.which) ? evt.which : event.keyCode;
                                    var dotCount = 0;
                                    var textBoxValue = evt.target.value;
                                    if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57)) {
                                        return false;
                                    }
                                    for (var i = 0; i < textBoxValue.length; i++) {
                                        if (textBoxValue[i] == '.') {
                                            dotCount++;
                                        }
                                    }
                                    if (dotCount > 1) {
                                        return false;
                                    }
                                    return true;
                                }
                            </script>
                        </div>
                        <br />
                        <div class="grid">
                            <asp:Label ID="Label13" runat="server" Text="FREQUÊNCIA*" Font-Bold="true"></asp:Label>
                            <asp:DropDownList ID="txt_freq" runat="server" CssClass="boxText" Height="28px" Width="100%">
                                <asp:ListItem></asp:ListItem>
                                <asp:ListItem>TURNO</asp:ListItem>
                                <asp:ListItem>DIÁRIO</asp:ListItem>
                                <asp:ListItem>SEMANAL</asp:ListItem>
                                <asp:ListItem>MENSAL</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <br />
                        <div class="grid">
                            <asp:Button ID="btn_salvar" class="BtnStyleDisable" Height="30px" Width="100%" runat="server" Text="Inserir" Font-Size="Small" />
                        </div>
                    </asp:Panel>

                    <div class="formulario-container" id="Painel2">
                        <div class="grid-container">
                            <asp:GridView ID="ListaTPM" runat="server" AutoGenerateColumns="False" BackColor="White" Font-Bold="True" Font-Size="Small" Font-Strikeout="False" GridLines="None" Height="33px" HorizontalAlign="Center" Width="100%">
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#284775" ForeColor="White" />
                                <RowStyle BackColor="#F7F6F3" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#333333" />
                                <Columns>
                                    <asp:BoundField DataField="ITEM_SEQUENCIA" HeaderText="N" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ITEM_NOME" HeaderText="ITEM" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="VISUAL">
                                        <ItemTemplate>
                                            <asp:Image ID="IMG1" runat="server" Style="max-width: 100%;" ImageUrl='<%# Eval("ITEM_PATH_VISUAL1") %>' />
                                            <asp:Label ID="LabelImg1" runat="server" Text='<%# Eval("ITEM_PATH_LABEL1") %>' Font-Size="X-Small" Visible="false"></asp:Label>
                                            <br />
                                            <asp:Image ID="IMG2" runat="server" Style="max-width: 100%;" ImageUrl='<%# Eval("ITEM_PATH_VISUAL2") %>' />
                                            <asp:Label ID="LabelImg2" runat="server" Text='<%# Eval("ITEM_PATH_LABEL2") %>' Font-Size="X-Small" Visible="false"></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="grid-th" />
                                        <ItemStyle CssClass="grid-td" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PADRÃO">
                                        <ItemTemplate>
                                            <asp:Image ID="IMG3" runat="server" Style="max-width: 100%;" ImageUrl='<%# Eval("ITEM_PATH_PADRAO") %>' />
                                            <asp:Label ID="LabelImg3" runat="server" Text='<%# Eval("ITEM_PATH_LABEL3") %>' Font-Size="X-Small" Visible="false"></asp:Label>
                                            <asp:Label ID="Label18" runat="server" Text='<%# Eval("ITEM_PADRAO") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle CssClass="grid-th" />
                                        <ItemStyle CssClass="grid-td" HorizontalAlign="Center" VerticalAlign="Middle" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ITEM_METODO" HeaderText="MÉTODO" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ITEM_MATERIAL" HeaderText="MATERIAL" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ITEM_ACAO" HeaderText="AÇÃO" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ITEM_RESP" HeaderText="RESP." HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ITEM_TEMPO" HeaderText="TEMPO" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ITEM_FREQUENCIA" HeaderText="FREQUÊNCIA" HeaderStyle-CssClass="grid-th">
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:BoundField>
                                    <asp:ButtonField ButtonType="Image" CommandName="EDITAR" ImageUrl="~/Images/editar.png" HeaderStyle-CssClass="grid-th">
                                        <ControlStyle CssClass="grid-img" />
                                        <ItemStyle CssClass="grid-td" />
                                    </asp:ButtonField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="Update1" runat="server">
            <ContentTemplate>
                <%--força a inserção do script no documento--%>
                <script type="text/javascript">
                    Sys.Application.add_load(function () {
                        var script = document.createElement("script");
                        script.type = "text/javascript";
                        script.src = "../../Scripts/ShowImg.js";
                        document.body.appendChild(script);
                    });
                </script>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btn_salvar" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
