<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TPM_Checklist.aspx.vb" Inherits="SGM_WEB.TPM_Checklist" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="../Padrao.css" rel="stylesheet">
    <script src="../../Scripts/ShowImg.js"></script>
    <style>
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

        .img {
            transition: transform 0.4s ease;
            max-width: 100%;
        }
            .img:hover {
                transform: scale(1.04);
            }
    </style>

    <asp:Panel ID="Panel3" runat="server" Style="width: 1050px">
        <div style="color: #f7f6f3; display: flex; align-items: center; justify-content: center; background: #333333; border-radius: 15PX 15PX 0 0;">
            <asp:Label ID="Label25" runat="server" Text="•" Style="font-size: 60px; color: #F84018;"></asp:Label>
            &nbsp;&nbsp;<asp:Label ID="txtconf" runat="server" Font-Bold="True" Font-Size="X-Large" Style="font-size: 32px" Text="CHECKLIST TPM"></asp:Label>&nbsp;&nbsp;
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
                        <asp:Panel ID="PanelPesquisa" runat="server">
                            <asp:Label ID="Label15" runat="server" Text="Formulário" Font-Bold="True"></asp:Label><br />
                            <asp:DropDownList ID="txt_linha" runat="server" CssClass="boxText" Height="28px" AutoPostBack="true"></asp:DropDownList>
                        </asp:Panel>
                    </asp:Panel>
                    <br />
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
                                    <a href='<%# Eval("ITEM_PATH_VISUAL1") %>' target="_blank">
                                        <asp:Image ID="IMG1" runat="server" CssClass="img" ImageUrl='<%# Eval("ITEM_PATH_VISUAL1") %>' />
                                    </a>
                                    <asp:Label ID="LabelImg1" runat="server" Text='<%# Eval("ITEM_PATH_LABEL1") %>' Font-Size="X-Small" Visible="false"></asp:Label>
                                    <br />
                                    <a href='<%# Eval("ITEM_PATH_VISUAL2") %>' target="_blank">
                                        <asp:Image ID="IMG2" runat="server" CssClass="img" ImageUrl='<%# Eval("ITEM_PATH_VISUAL2") %>' />
                                    </a>
                                    <asp:Label ID="LabelImg2" runat="server" Text='<%# Eval("ITEM_PATH_LABEL2") %>' Font-Size="X-Small" Visible="false"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle CssClass="grid-th" />
                                <ItemStyle CssClass="grid-td" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PADRÃO">
                                <ItemTemplate>
                                    <a href='<%# Eval("ITEM_PATH_PADRAO") %>' target="_blank">
                                        <asp:Image ID="IMG3" runat="server" CssClass="img" ImageUrl='<%# Eval("ITEM_PATH_PADRAO") %>' />
                                    </a>
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
                            <asp:BoundField DataField="ITEM_FREQUENCIA" HeaderText="FREQUÊNCIA" HeaderStyle-CssClass="grid-th">
                                <ItemStyle CssClass="grid-td" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ULTIMO_CHECKLIST" HeaderText="ÚLTIMO CHECKLIST" HeaderStyle-CssClass="grid-th">
                                <ItemStyle CssClass="grid-td" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="lbl1" runat="server" Text="Observação" Font-Size="X-Small"></asp:Label>
                                    <asp:TextBox ID="txt_obs" runat="server" Style="margin: 5px 0; height: 25px; width: 90%; padding: 0; border: solid 1px #c5c4c4; border-radius: 5px;"></asp:TextBox>
                                    <asp:Button ID="btn_salvar" class="BtnStyle" Height="20px" Width="90%" Style="margin: 0; border-radius: 5px;" runat="server" Text="Salvar" Font-Size="Small" OnClick="btn_salvar_Click" />
                                </ItemTemplate>
                                <HeaderStyle CssClass="grid-th" />
                                <ItemStyle CssClass="grid-td" HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
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
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
