<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contencao_Cadastro.aspx.vb" Inherits="SGM_WEB.Contencao_Cadastro_aspx" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <link href="../Padrao.css" rel="stylesheet">

    <asp:Panel ID="Panel2" runat="server" Height="877px" Width="1030px">
        <div class="title">
            <asp:Label ID="Label25" runat="server" class="dot-title" Text="•"></asp:Label>
            <asp:Label ID="txtconf" runat="server" class="text-title" Text="APROVAÇÃO DE TRANSPORTE"></asp:Label>
            <asp:Label ID="Label5" runat="server" class="dot-title" Text="•"></asp:Label>
        </div>
        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="container">
                    <asp:Panel ID="Panel5" runat="server" Height="149px" Width="1008px" Style="margin-bottom: 12px; display: flex; align-items: center;">
                        <asp:Panel ID="panelProduto" runat="server" Height="59px" Width="180px" Style="float: left">
                            &nbsp;
                    <%--<asp:Label ID="lblProduto" runat="server" Font-Bold="true" Text="Filtrar IT's por PN"></asp:Label>--%>
                            <%--<br />--%>
                            <%--&nbsp;<asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True">
                        <asp:ListItem>Linha</asp:ListItem>
                        <asp:ListItem>Partnumber</asp:ListItem>
                    </asp:RadioButtonList>--%>

                            <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Selecione a JBC"></asp:Label>
                            <br />
                            &nbsp;<asp:DropDownList ID="dropJbc" runat="server" Height="30px" Width="150px" SelectionMode="Single" CssClass="boxText">
                            </asp:DropDownList>
                        </asp:Panel>

                        <asp:Panel ID="Panel7" runat="server" Height="57px" Width="161px" Style="float: left">
                            &nbsp;<asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Selecione a Linha"></asp:Label>
                            <br />
                            &nbsp;<asp:DropDownList ID="dropLista" runat="server" Height="30px" Width="150px" SelectionMode="Multiple" AutoPostBack="True" CssClass="boxText">
                            </asp:DropDownList>
                        </asp:Panel>
                        <asp:Panel ID="Panel10" runat="server" Height="150px" Width="302px" Style="float: left" Visible="True">
                            &nbsp;<asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Partnumber"></asp:Label>
                            <br />
                            &nbsp;<asp:ListBox ID="listPN" runat="server" Height="122px" Width="291px" Rows="10" SelectionMode="Multiple"></asp:ListBox>

                        </asp:Panel>



                        <asp:Panel ID="Panel3" runat="server" Height="148px" Width="349px" Style="float: left">
                            <asp:Label ID="Label11111" runat="server" Font-Bold="True" Text="Partnumbers vinculado" Visible="true"></asp:Label>

                            <br />
                            <asp:ListBox ID="listavinculos" runat="server" Height="121px" Width="339px"></asp:ListBox>

                        </asp:Panel>

                    </asp:Panel>

                    <asp:Panel ID="Paneladd" runat="server" Height="72px" Width="1008px" Style="margin-bottom: 12px;">
                        <asp:Panel ID="Panel11" runat="server" Height="59px" Width="168px" Style="float: left">
                            <asp:Label ID="lbladd" Text="Insira uma nova JBC" runat="server" Font-Bold="True"></asp:Label>
                            <br />
                            <asp:TextBox ID="TextBox1" Height="24px" Width="150px" runat="server" CssClass="boxText"></asp:TextBox>
                        </asp:Panel>
                        <asp:Panel ID="Panel9" runat="server" Height="59px" Width="102px" Style="float: left">
                            <br />
                            <asp:Button ID="btnaddjbc" runat="server" Font-Size="Small" Height="37px" Text="Adicionar" Width="93px" CssClass="BtnStyleGreen" />
                        </asp:Panel>
                    </asp:Panel>

                    <asp:Panel ID="Panel4" runat="server" Height="72px" Style="display: flex; justify-content: center;">
                        <asp:Panel ID="Panel1" runat="server" Height="59px" Width="102px" Style="float: left">
                            <br />
                            <asp:Button ID="button1" runat="server" Font-Size="Small" Height="37px" Text="Adicionar" Width="93px" CssClass="BtnStyleGreen" />
                        </asp:Panel>

                        <asp:Panel ID="Panel6" runat="server" Height="59px" Width="102px" Style="float: left">
                            <br />
                            <asp:Button ID="btnDesvincular" runat="server" Text="Remover" Height="37px" Width="93px" CssClass="BtnStyleRed" />
                        </asp:Panel>
                    </asp:Panel>

                    <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel24" TargetControlID="ORDEMP" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
                    <asp:Panel ID="Panel24" runat="server" Style="display: none;" CssClass="modalPopup">
                        <asp:Label ID="ORDEMP" runat="server" class="titulo-modal" Font-Size="Larger"></asp:Label>
                        <br />
                        <asp:Panel ID="Panel14" runat="server">
                            <asp:Button ID="btnVincular" runat="server" Text="Vincular" CssClass="BtnStyle" Height="30px" Width="90" Style="margin: 0;" />&nbsp;&nbsp;
                <asp:Button ID="btnAdd" runat="server" Text="Adicionar" CssClass="BtnStyle" Width="90" Height="30px" Style="margin: 0;" />
                        </asp:Panel>
                    </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
