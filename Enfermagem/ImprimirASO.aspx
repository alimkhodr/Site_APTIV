<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ImprimirASO.aspx.vb" Inherits="SGM_WEB.ImprimirASO" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .auto-style2 {
            width: 896px;
            height: 97px;
        }

        .auto-style3 {
            width: 898px;
            height: 94px;
        }
    </style>
</head>
<body>

    <script type="text/jscript">
        function imprimePanel() {
            var printContent = document.getElementById("<%=Principal.ClientID%>");
            var windowUrl = 'about:blank';
            var uniqueName = new Date();
            var windowName = 'Print' + uniqueName.getTime();
            var printWindow = window.open(windowUrl, windowName, 'left=60000,top=60000,width=0,height=0');

            printWindow.document.write(printContent.innerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }

    </script>

    <form id="form1" runat="server">
        <asp:Panel ID="Principal" runat="server" Style="margin-right: 9px;" Width="911px">
            <asp:Panel ID="Panel212" runat="server" Style="text-align: center;" Width="900px" Height="38px">
            </asp:Panel>
            <asp:Panel ID="Panel1" runat="server" Style="text-align: center; margin-bottom: 0px;" Width="900px" Height="97px">
                <asp:Image ID="Image2" runat="server" Height="88px" ImageUrl="~/Images/imprimirASO.png" Width="832px" Style="margin-bottom: 5px; margin-right: 0px;" />

            </asp:Panel>
            <br />
            <br />
            <asp:Panel ID="Panel2" runat="server" Style="text-align: center; margin-left: 37px;" Width="826px" Height="52px">
                <span style="color: rgb(0, 0, 0); font-family: Arial, sans-serif; font-size: 28px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 700; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; text-decoration-thickness: initial; text-decoration-style: initial; text-decoration-color: initial; display: inline !important; float: none;">ATESTADO DE SAÚDE OCUPACIONAL</span>
            </asp:Panel>
            <br />
            <asp:Panel ID="Panel3" runat="server" Style="text-align: center; margin-left: 37px;" Width="826px" Height="33px">
                <asp:Label ID="Label2" runat="server" Text="EM CUMPRIMENTO A PORTARIA 3214/78, NR-7 DO MINISTÉRIO DO TRABALHO PARA FINS DE EXAME:" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="Panel27" runat="server" Style="text-align: center; margin-left: 37px;" Width="825px" Height="44px">
                <asp:Panel ID="Panel4" runat="server" Height="61px" Width="814px" Style="display: inline-block; text-align: left; vertical-align: top;" BackColor="White">
                    <asp:CheckBox ID="cbadmi" Text="ADMISSIONAL" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" />&nbsp;&nbsp;
        <asp:CheckBox ID="cbperi" Text="PERIÓDICO" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" />&nbsp;&nbsp;
        <asp:Panel ID="Panel15" runat="server" Height="38px" Width="133px" Style="display: inline-block; text-align: center; vertical-align: top;" BackColor="White">
            <asp:CheckBox ID="cbreturn" Text="RETORNO AO TRABALHO" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" />
        </asp:Panel>
                    &nbsp;&nbsp;
        <asp:Panel ID="Panel16" runat="server" Height="36px" Width="186px" Style="display: inline-block; text-align: center; vertical-align: top;" BackColor="White">
            <asp:CheckBox ID="cbmud" Text="MUDANÇA DE RISCO OCUPACIONAL" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" />
        </asp:Panel>
                    &nbsp;&nbsp;
        <asp:CheckBox ID="cbdemi" Text="DEMISSIONAL" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" />
                </asp:Panel>
            </asp:Panel>
            <br />

            <asp:Panel ID="Panel5" runat="server" Style="text-align: center; margin-left: 37px;" Width="826px" Height="44px">
                <asp:Label ID="Label3" runat="server" Text="ATESTO QUE O (A) SR. (A):" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;"></asp:Label>&nbsp;
                        <asp:Label ID="lblnome" runat="server" Text="lblnome" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Bold="True" Font-Size="15pt"></asp:Label>&nbsp;
                        <asp:Label ID="Label5" runat="server" Text="REG.:" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;"></asp:Label>&nbsp;
                        <asp:Label ID="lblreg" runat="server" Text="lblreg" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Bold="True" Font-Size="15pt"></asp:Label>&nbsp;
                        <asp:Label ID="Label6" runat="server" Text="PORTADOR DO CPF Nº:" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;"></asp:Label>&nbsp;
                        <asp:Label ID="lblcpf" runat="server" Text="lblcpf" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Bold="True" Font-Size="15pt"></asp:Label>&nbsp;
                        <asp:Label ID="Label9" runat="server" Text="COM IDADE DE:" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;"></asp:Label>&nbsp;
                        <asp:Label ID="lblidade" runat="server" Text="lblidade" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Bold="True" Font-Size="15pt"></asp:Label>&nbsp;
                        <asp:Label ID="Label1" runat="server" Text="ANOS" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;"></asp:Label>&nbsp;
            </asp:Panel>
            <br />
            <asp:Panel ID="Panel6" runat="server" Style="text-align: center; margin-left: 37px;" Width="826px" Height="46px">
                <asp:Label ID="Label4" runat="server" Text="FOI CLINICAMENTE EXAMINADO (A) ESTANDO EXPOSTO (A) AOS POSSÍVEIS RISCOS OCUPACIONAIS CONFORME NR-5, TABELA I - ANEXO IV" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="Panel7" runat="server" Style="text-align: center; margin-left: 37px;" Width="825px" Height="84px">
                <asp:Panel ID="Panel24" runat="server" Height="61px" Width="343px" Style="display: inline-block; text-align: left; vertical-align: top;" BackColor="White">
                    <asp:CheckBox ID="cbagef" Text="AGENTES FÍSICOS" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" /><br />
                    <asp:CheckBox ID="cbageb" Text="AGENTES BIOLÓGICOS" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" /><br />
                    <asp:CheckBox ID="cbaci" Text="ACIDENTES" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" />
                </asp:Panel>
                <asp:Panel ID="Panel21" runat="server" Height="87px" Width="318px" Style="display: inline-block; text-align: left; vertical-align: top;" BackColor="White">
                    <asp:CheckBox ID="cbageq" Text="AGENTES QUÍMICOS" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" /><br />
                    <asp:CheckBox ID="cberg" Text="ERGONÔMICOS" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" /><br />
                    <asp:CheckBox ID="cbausrisc" Text="AUSÊNCIA DE RISCOS ESPECÍFICOS" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" />
                </asp:Panel>
            </asp:Panel>
            <br />

            <asp:Panel ID="Panel8" runat="server" Style="text-align: center; margin-left: 37px;" Width="826px" Height="58px">
                <asp:Label ID="Label7" runat="server" Text="CONFORME APONTADO NOS MAPAS DE RISCOS AMBIENTAIS, LAUDOS TÉCNICOS AMBIENTAIS E ERGONÔMICOS DOS SETORES E DETALHADOS NO PCMSO - PGR - PPRE - PCA – PCMAT, TENDO REALIZADO OS SEGUINTES EXAMES COMPLEMENTARES:" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="Panel9" runat="server" Style="text-align: center; margin-left: 37px;" Width="825px" Height="139px">
                <asp:Panel ID="Panel17" runat="server" Height="100px" Width="343px" Style="display: inline-block; text-align: left;" BackColor="White">
                    <asp:CheckBox ID="cblab" Text="DOS LABORATORIAIS" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" />
                    &nbsp;&nbsp;<asp:Label ID="datalab" runat="server" Text="__/__/__" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Size="15pt"></asp:Label><br />
                    <asp:CheckBox ID="cbtox" Text="DOS TOXICOLÓGICOS" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" />
                    &nbsp;&nbsp;<asp:Label ID="datatox" runat="server" Text="__/__/__" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Size="15pt"></asp:Label><br />
                    <asp:CheckBox ID="cbeeg" Text="EEG" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" />
                    &nbsp;&nbsp;<asp:Label ID="dataeeg" runat="server" Text="__/__/__" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Size="15pt"></asp:Label><br />
                    <asp:CheckBox ID="cbecg" Text="ECG" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" />
                    &nbsp;&nbsp;<asp:Label ID="dataecg" runat="server" Text="__/__/__" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" Font-Size="15pt"></asp:Label>
                </asp:Panel>

                <asp:Panel ID="Panel19" runat="server" Height="98px" Width="318px" Style="display: inline-block; text-align: left; vertical-align: top;" BackColor="White">
                    <asp:CheckBox ID="cbradio" Text="RADIOGRAFIA TORÁCICA" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" />
                    &nbsp;&nbsp;<asp:Label ID="dataradio" runat="server" Text="__/__/__" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Size="15pt"></asp:Label><br />
                    <asp:CheckBox ID="cbespiro" Text="ESPIROMETRIA" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" />
                    &nbsp;&nbsp;<asp:Label ID="dataespiro" runat="server" Text="__/__/__" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Size="15pt"></asp:Label><br />
                    <asp:CheckBox ID="cbacui" Text="ACUIDADE VISUAL" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" />
                    &nbsp;&nbsp;<asp:Label ID="dataacui" runat="server" Text="__/__/__" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Size="15pt"></asp:Label><br />
                    <asp:CheckBox ID="cbaudio" Text="AUDIOMETRIA" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" />
                    &nbsp;&nbsp;<asp:Label ID="dataaudio" runat="server" Text="__/__/__" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Size="15pt"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="Panel22" runat="server" Height="20px" Width="669px" Style="display: inline-block; text-align: left;" BackColor="White">
                    <asp:CheckBox ID="cboutros" Text="OUTROS (ESPECIFICAR)" runat="server" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 17px;" />
                    &nbsp;<asp:Label ID="txtoutros" runat="server" Text="___________________________________" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Bold="True" Font-Size="15pt"></asp:Label>
                </asp:Panel>
            </asp:Panel>

            <br />

            <asp:Panel ID="Panel10" runat="server" Style="text-align: center; margin-left: 37px;" Width="826px" Height="24px">
                <asp:Label ID="Label10" runat="server" Text="SENDO CONSIDERADO:" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;"></asp:Label>&nbsp;
             <asp:Label ID="lblconsiderado" runat="server" Text="lblconsiderado" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Bold="True" Font-Size="15pt"></asp:Label>
            </asp:Panel>

            <asp:Panel ID="Panel11" runat="server" Style="text-align: center; margin-left: 37px;" Width="826px" Height="69px">
                <asp:Label ID="Label8" runat="server" Text="PARA EXERCER A FUNÇÃO DE:" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;"></asp:Label>&nbsp;
                        <asp:Label ID="lblfuncao" runat="server" Text="lblfuncao" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Bold="True" Font-Size="15pt"></asp:Label>&nbsp;
                        <asp:Label ID="Label20" runat="server" Text="PARA A ÁREA DE:" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;"></asp:Label>&nbsp;
                        <asp:Label ID="lblarea" runat="server" Text="lblarea" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Bold="True" Font-Size="15pt"></asp:Label>&nbsp;<br />
                <asp:Label ID="Label12" runat="server" Text="OBS.:" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;"></asp:Label>&nbsp;
                        <asp:Label ID="lblobs" runat="server" Text="___________________________________" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Bold="True" Font-Size="15pt"></asp:Label>&nbsp;
            </asp:Panel>
            <br />
            <asp:Panel ID="Panel12" runat="server" Style="text-align: center; margin-left: 37px;" Width="826px" Height="60px">
                <asp:Label ID="Label11" runat="server" Text="ESTE ATESTADO É VÁLIDO PELO PERÍODO DE" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;"></asp:Label>&nbsp;
                    <asp:Label ID="Label19" runat="server" Text="12 MESES" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Bold="True" Font-Size="14pt"></asp:Label>&nbsp;
                    <asp:Label ID="Label21" runat="server" Text="A PARTIR DA PRESENTE DATA, DESDE QUE NÃO APRESENTE QUAISQUER RASURAS E /OU RESSALVAS EM DESACORDO COM O PRONTUÁRIO MÉDICO OCUPACIONAL." Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;"></asp:Label>
            </asp:Panel>
            <br />
            <asp:Panel ID="Panel14" runat="server" Style="text-align: center; margin-left: 37px;" Width="826px" Height="118px">
                <asp:Panel ID="Panel18" runat="server" Height="112px" Width="279px" BackColor="White" Style="float: left; margin-left: 143px;">
                    <asp:Label ID="Label13" runat="server" Text="Nome / Assinatura / Carimbo" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 8px;" Font-Size="10pt"></asp:Label><br />
                    <br />
                    <br />
                    <asp:Label ID="Label15" runat="server" Text="___________________________" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 10px;"></asp:Label><br />
                    <br />
                    <asp:Label ID="Label17" runat="server" Text="Ricardo Quidiquimo Lima – CRM148856 Médico Coordenador do PCMSO" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 8px;"></asp:Label>
                </asp:Panel>
                <asp:Panel ID="Panel20" runat="server" Height="113px" Width="295px" BackColor="White" Style="float: left">
                    <asp:Label ID="Label14" runat="server" Text="Recebi a 2ª via (Assinatura do Funcionário (a))" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 8px;" Font-Size="10pt"></asp:Label><br />
                    <br />
                    <br />
                    <asp:Label ID="Label16" runat="server" Text="___________________________" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 10px;"></asp:Label><br />
                    <br />
                    <asp:Label ID="Label18" runat="server" Text="DATA:" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;"></asp:Label>&nbsp;
            <asp:Label ID="lbldata" runat="server" Text="lbldata" Style="font-family: &quot; arial mt&quot; , sans-serif; font-size: 15px;" Font-Bold="True" Font-Size="15pt"></asp:Label>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>
        <asp:Panel ID="Panel13" runat="server" Style="text-align: center;" Width="900px" Height="38px">
        </asp:Panel>
        <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" OnClientClick="javascript:imprimePanel()" />
        <br />
        <br />
    </form>
</body>
</html>
