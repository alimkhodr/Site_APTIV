<%@ Page Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Treinamento_Novo.aspx.vb" Inherits="SGM_WEB.Treinamento_Novo" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <link href="../Padrao.css" rel="stylesheet">
    <asp:Panel ID="Panel4" runat="server" Height="877px" Width="1017px">
        <div class="title">
            <asp:Label ID="Label25" runat="server" class="dot-title" Text="•"></asp:Label>
            <asp:Label ID="txtconf" runat="server" class="text-title" Text="TREINAMENTO POR ÁREA"></asp:Label>
            <asp:Label ID="Label6" runat="server" class="dot-title" Text="•"></asp:Label>
        </div>

        <asp:UpdatePanel ID="Update" runat="server">
            <ContentTemplate>
                <div class="container">
                    <asp:Panel ID="Panel2" runat="server" Height="49px" Width="470px" Style="float: left" DefaultButton="Button3">
                        <asp:Label ID="Label2" runat="server" Text="Adicionar área administrativa" Enabled="False" Font-Bold="True"></asp:Label><br />
                        <asp:TextBox ID="Txtarea" runat="server" Width="322px" Height="24px" CssClass="boxText"></asp:TextBox>&nbsp
                                <asp:Button ID="Button3" Text="Adicionar" runat="server" Font-Size="SMALL" Height="35px" Width="102px" CssClass="BtnStyle" />
                    </asp:Panel>

                    <asp:Panel ID="Panel6" runat="server" Height="49px" Width="496px" Style="float: left" DefaultButton="Button2">
                        <asp:Label ID="lblnf" runat="server" Text="Adicionar treinamento" Enabled="False" Font-Bold="True"></asp:Label><br />
                        <asp:TextBox ID="Txttreinamento" runat="server" Width="370px" Height="24px" CssClass="boxText"></asp:TextBox>&nbsp
                                <asp:Button ID="Button2" Text="Adicionar" runat="server" Font-Size="SMALL" Height="35px" Width="102px" CssClass="BtnStyle" />
                    </asp:Panel>
                    <br />
                    <br />
                    <br />
                    <br />
                    <hr />
                    <br />
                    <asp:Panel ID="Panel5" runat="server" Height="49px" Width="470px" Style="float: left" DefaultButton="Button1">
                        <asp:Label ID="Label1" runat="server" Text="Área Administrativa" Enabled="False" Font-Bold="True"></asp:Label><br />
                        <asp:DropDownList ID="cboarea2" runat="server" Width="350px" AutoPostBack="True" Height="33px" CssClass="boxText">
                        </asp:DropDownList>&nbsp
                                <asp:Button ID="Button1" Text="Excluir" runat="server" Font-Size="SMALL" Height="35px" Width="102px" CssClass="BtnStyle" />
                    </asp:Panel>

                    <asp:Panel ID="Panel1" runat="server" Height="49px" Width="496px" Style="float: left">
                        <asp:Label ID="Label5" runat="server" Text="Treinamento" Enabled="False" Font-Bold="True"></asp:Label><br />
                        <asp:DropDownList ID="cbotreinamento2" runat="server" Width="378px" AutoPostBack="True" Height="33px" CssClass="boxText" DefaultButton="Button5">
                        </asp:DropDownList>&nbsp
                                <asp:Button ID="Button5" Text="Excluir" runat="server" Font-Size="SMALL" Height="35px" Width="102px" CssClass="BtnStyle" />
                    </asp:Panel>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Panel ID="Panel8" runat="server" Height="60px" Width="969px" Style="float: left" DefaultButton="Button4">
                        <asp:Panel ID="Panel3" runat="server" Height="49px" Width="398px" Style="float: left">
                            <asp:Label ID="Label3" runat="server" Text="Área Administrativa" Enabled="False" Font-Bold="True"></asp:Label><br />
                            <asp:DropDownList ID="cboarea" runat="server" Width="390px" AutoPostBack="True" Height="33px" CssClass="boxText">
                            </asp:DropDownList>
                        </asp:Panel>

                        <asp:Panel ID="Panel7" runat="server" Height="49px" Width="460px" Style="float: left">
                            <asp:Label ID="Label4" runat="server" Text="Treinamento" Enabled="False" Font-Bold="True"></asp:Label><br />
                            <asp:DropDownList ID="cbotreinamento" runat="server" Width="450px" AutoPostBack="True" Height="33px" CssClass="boxText">
                            </asp:DropDownList>
                        </asp:Panel>
                        <br />
                        <asp:Button ID="Button4" Text="Adicionar" runat="server" Font-Size="SMALL" Height="35px" Width="102px" CssClass="BtnStyle" />
                        <br />
                    </asp:Panel>
                    <br />
                    <asp:ListBox ID="ListaTreinamento" runat="server" Height="381px" Width="960px" Font-Bold="True" Font-Size="Medium" Style="margin-bottom: 15px;" Enabled="False"></asp:ListBox>
                    <ajaxToolkit:ModalPopupExtender ID="mp1" runat="server" PopupControlID="Panel106" TargetControlID="ORDEMP" BackgroundCssClass="modalBackground"></ajaxToolkit:ModalPopupExtender>
                    <asp:Panel ID="Panel9" runat="server" Style="display: none;" CssClass="modalPopup">
                        <asp:Label ID="ORDEMP" class="titulo-modal" runat="server"></asp:Label>
                        <br />
                        <asp:Button ID="btnClose" class="BtnStyle" Height="35px" Width="102px" runat="server" Text="FECHAR" />
                    </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
