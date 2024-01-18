<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChamadoTI_Resolver.aspx.vb" Inherits="SGM_WEB.ChamadoTI_Resolver" %>


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

    <asp:Panel ID="Panel3" runat="server" Height="877px" Width="1017px">
        <div class="title">
            <asp:Label ID="Label25" runat="server" class="dot-title" Text="•"></asp:Label>
            <asp:Label ID="txtconf" runat="server" class="text-title" Text="CHAMADO TI"></asp:Label>
            <asp:Label ID="Label5" runat="server" class="dot-title" Text="•"></asp:Label>
        </div>

        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="container">
                        <asp:Panel ID="Panel2" runat="server" Style="float: left;" Width="638px" Height="60px">
                            <asp:Label ID="Label2" runat="server" Text="Local do Chamado" Enabled="False" Font-Bold="True"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtlocal" runat="server" Width="615px" Height="24px" Enabled="False" CssClass="boxText"></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="Panel1" runat="server" Style="float: left;" Width="315px" Height="60px">
                            <asp:Label ID="Label3" runat="server" Text="Tipo chamado" Enabled="False" Font-Bold="True"></asp:Label>
                            <br />
                            <asp:TextBox ID="txttipo" runat="server" Width="312px" Height="24px" Enabled="False" CssClass="boxText"></asp:TextBox>
                        </asp:Panel>
                        <br />
                        <br />
                        <asp:Label ID="Label1" runat="server" Text="Descrição do Chamado" Enabled="False" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtdesc" runat="server" Width="953px" Height="24px" Enabled="False" CssClass="boxText"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Resolução" Enabled="False" Font-Bold="True"></asp:Label>
                        <br />
                        <asp:TextBox ID="txtres" runat="server" Width="952px" Height="24px" CssClass="boxText" Enabled="False"></asp:TextBox>
                        <br />
                        <br />
                        <asp:Button ID="cmdsalvar" Text="INICIAR" runat="server" Style="float: right; margin-left: 0px;" Font-Size="SMALL" Height="35px" Width="102px" CssClass="BtnStyle" />
                    <br /><br /><br /><br />

                    <asp:GridView ID="ListaOrdems" runat="server" AutoGenerateColumns="False" BackColor="White" Font-Bold="True" Font-Size="Small" Font-Strikeout="False" GridLines="None" Height="33px" HorizontalAlign="Center" Width="100%">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <PagerStyle HorizontalAlign="Center" VerticalAlign="Middle" BackColor="#284775" ForeColor="White" />
                        <RowStyle BackColor="#F7F6F3" HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="#333333" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" HeaderStyle-CssClass="grid-th">
                                <ItemStyle CssClass="grid-td" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TIPO" HeaderText="TIPO" HeaderStyle-CssClass="grid-th">
                                <ItemStyle CssClass="grid-td" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LOCAL" HeaderText="LOCAL" HeaderStyle-CssClass="grid-th">
                                <ItemStyle CssClass="grid-td" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FUN" HeaderText="FUNCIONÁRIO" HeaderStyle-CssClass="grid-th">
                                <ItemStyle CssClass="grid-td" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DATA" HeaderText="DATA" HeaderStyle-CssClass="grid-th">
                                <ItemStyle CssClass="grid-td" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SITUACAO" HeaderText="SITUAÇÃO" HeaderStyle-CssClass="grid-th">
                                <ItemStyle CssClass="grid-td" />
                            </asp:BoundField>
                            <asp:ButtonField ButtonType="Image" CommandName="EDITAR" ImageUrl="~/Images/play.png" HeaderStyle-CssClass="grid-th">
                                <ControlStyle CssClass="grid-img" />
                                <ItemStyle CssClass="grid-td" />
                            </asp:ButtonField>
                        </Columns>
                    </asp:GridView>

                    <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel16" TargetControlID="ORDEMP" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
                    <asp:Panel ID="Panel16" Style="display: none;"  runat="server" CssClass="modalPopup">
                        <asp:Label ID="ORDEMP" class="titulo-modal" runat="server"></asp:Label>
                        <br />
                        <asp:Button ID="btnClose" class="BtnStyle" Height="35px" Width="102px" runat="server" Text="FECHAR" />
                    </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>

