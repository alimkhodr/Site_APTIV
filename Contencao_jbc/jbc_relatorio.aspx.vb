Imports System.IO

Public Class jbc_relatorio
    Inherits System.Web.UI.Page
    Dim listLinha As ListItem
    Public uniqueFileName As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '########## BOTÃO DE LOG-OFF ########################
        Try
            Dim BTN As System.Web.UI.HtmlControls.HtmlInputSubmit
            Dim reg, VALIDAR As Integer
            BTN = Master.FindControl("CmdSignOut")
            BTN.Value = "SAIR DO REGISTRO: " & User.Identity.Name
            reg = User.Identity.Name
            VALIDAR = ValidarTela(reg, 611)
            If VALIDAR = 1 Then
                Response.Redirect("~/SGM.aspx")
                CType(Master.FindControl("Label16"), Label).ForeColor = Drawing.Color.Red
                CType(Master.FindControl("mp6"), AjaxControlToolkit.ModalPopupExtender).Show()
            End If
        Catch ex As Exception
            Response.Redirect("~/Logon.aspx")
        End Try
        '####################################################
        If Not IsPostBack Then

        End If
    End Sub

    Sub Clear()
        ' Limpar todos os campos
        txt_nform.Text = ""
        txt_data.Text = ""
        txt_data_fim.Text = ""
        txt_tipo.Text = ""
        txt_descricao.Text = ""
        txt_linha.Text = ""
        txt_indent.Text = ""
        txt_razao.Text = ""
        txt_reacao.Text = ""
        txt_responsavel.Text = ""
        txt_emitente.Text = ""

        ListaContencao.DataSource = Nothing ' Limpar os dados existentes na GridView
        ListaContencao.DataBind() ' Atualizar a exibição

        ListaPN.DataSource = Nothing ' Limpar os dados existentes na GridView
        ListaPN.DataBind() ' Atualizar a exibição

        ListaREV.DataSource = Nothing ' Limpar os dados existentes na GridView
        ListaREV.DataBind() ' Atualizar a exibição
    End Sub

    Protected Sub btn_proc_Click(sender As Object, e As EventArgs) Handles btn_proc.Click
        If txt_proc.Text <> "" Then
            PreencherForm()
        Else
            Clear()
        End If
    End Sub

    Sub PreencherForm()
        conectabdnew()

        ListaContencao.DataSource = Nothing ' Limpar os dados existentes na GridView
        ListaContencao.DataBind() ' Atualizar a exibição
        comandoSQL.CommandText = "SELECT J.JBC_ID, J.JBC_EMISSAO, F2.FUN_NOME AS 'EMITENTE', J.JBC_TIPO, J.JBC_DESCRICAO, J.JBC_RESPONSAVEL, J.JBC_RAZAO, J.JBC_LINHA, J.JBC_IDENTIFICACAO, J.JBC_REACAO, J.JBC_FIM, "
        comandoSQL.CommandText &= "C.CON_SAIDA,C.CON_CAIXA, C.PN_PARTNUMBER, C.CON_QUANTIDADE, C.CON_AREA, C.CARTAO_ID, F.FUN_NOME, C.CON_ENTRADA, "
        comandoSQL.CommandText &= "(CASE WHEN C.CON_SAIDA IS NOT NULL THEN DATEDIFF(DAY, C.CON_ENTRADA, C.CON_SAIDA) ELSE DATEDIFF(DAY, C.CON_ENTRADA, GETDATE()) END) AS 'DIAS', "
        comandoSQL.CommandText &= "(CASE WHEN C.CON_INS_INICIO IS NULL THEN NULL ELSE C.CON_ENTRADA END) AS 'INICIO', "
        comandoSQL.CommandText &= "(CASE WHEN C.CON_SAIDA IS NOT NULL THEN DATEDIFF(MINUTE, C.CON_ENTRADA, C.CON_SAIDA) ELSE DATEDIFF(MINUTE, C.CON_ENTRADA, GETDATE()) END) AS 'TEMPO', "
        comandoSQL.CommandText &= "(CASE WHEN C.CON_SAIDA Is NULL THEN 'EM ESTOQUE' ELSE 'CONTENÇÃO FEITA' END) AS 'STATUS', S.COD_ID, S.SC_MOTIVO, S.SC_QUANTIDADE "
        comandoSQL.CommandText &= "FROM TAB_JBC J LEFT JOIN TAB_JBC_CONTENCAO C ON J.JBC_ID = C.JBC_ID LEFT JOIN FUNCIONARIO F ON C.FUN_REGISTRO = F.FUN_REGISTRO LEFT JOIN FUNCIONARIO F2 ON JBC_EMITENTE = F2.FUN_REGISTRO "
        comandoSQL.CommandText &= "LEFT JOIN TAB_JBC_SCRAP S ON C.CON_ID = S.CON_ID WHERE J.JBC_ID = " & txt_proc.Text
        comandoSQL.CommandText &= "GROUP BY C.CON_CAIXA, C.PN_PARTNUMBER, C.CON_QUANTIDADE, C.CON_AREA, C.CARTAO_ID, F.FUN_NOME, C.CON_ENTRADA, C.CON_SAIDA, C.CON_INS_INICIO,S.COD_ID, S.SC_MOTIVO,S.SC_QUANTIDADE, "
        comandoSQL.CommandText &= "J.JBC_ID, J.JBC_EMISSAO, J.JBC_EMITENTE, J.JBC_TIPO, J.JBC_DESCRICAO, J.JBC_RESPONSAVEL, J.JBC_RAZAO, J.JBC_LINHA, J.JBC_IDENTIFICACAO, J.JBC_REACAO, J.JBC_FIM,F2.FUN_NOME"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.Read() Then
            txt_nform.Text = objDataReader("JBC_ID").ToString()
            txt_data.Text = Convert.ToDateTime(objDataReader("JBC_EMISSAO")).ToString("dd/MM/yyyy")
            txt_data_fim.Text = If(objDataReader("JBC_FIM") Is DBNull.Value, "Em andamento.", Convert.ToDateTime(objDataReader("JBC_FIM")).ToString("dd/MM/yyyy"))
            txt_tipo.Text = objDataReader("JBC_TIPO").ToString()
            txt_descricao.Text = objDataReader("JBC_DESCRICAO").ToString()
            txt_linha.Text = objDataReader("JBC_LINHA").ToString()
            txt_indent.Text = objDataReader("JBC_IDENTIFICACAO").ToString()
            txt_razao.Text = objDataReader("JBC_RAZAO").ToString()
            txt_reacao.Text = objDataReader("JBC_REACAO").ToString()
            txt_responsavel.Text = objDataReader("JBC_RESPONSAVEL").ToString()
            txt_emitente.Text = objDataReader("EMITENTE").ToString()

            Dim dt As New DataTable()
            dt.Columns.Add("CON_CAIXA", GetType(String))
            dt.Columns.Add("PN_PARTNUMBER", GetType(String))
            dt.Columns.Add("CON_QUANTIDADE", GetType(String))
            dt.Columns.Add("CON_AREA", GetType(String))
            dt.Columns.Add("CARTAO_ID", GetType(String))
            dt.Columns.Add("FUN_NOME", GetType(String))
            dt.Columns.Add("CON_ENTRADA", GetType(String))
            dt.Columns.Add("DIAS", GetType(String))
            dt.Columns.Add("INICIO", GetType(String))
            dt.Columns.Add("CON_SAIDA", GetType(String))
            dt.Columns.Add("TEMPO", GetType(String))
            dt.Columns.Add("STATUS", GetType(String))
            dt.Columns.Add("COD_ID", GetType(String))
            dt.Columns.Add("SC_MOTIVO", GetType(String))
            dt.Columns.Add("SC_QUANTIDADE", GetType(String))

            Do
                If (objDataReader("CON_CAIXA") IsNot DBNull.Value) Then
                    Dim row As DataRow = dt.NewRow()
                    row("CON_CAIXA") = objDataReader("CON_CAIXA").ToString()
                    row("PN_PARTNUMBER") = objDataReader("PN_PARTNUMBER").ToString()
                    row("CON_QUANTIDADE") = objDataReader("CON_QUANTIDADE").ToString()
                    row("CON_AREA") = objDataReader("CON_AREA").ToString()
                    row("CARTAO_ID") = objDataReader("CARTAO_ID").ToString()
                    row("FUN_NOME") = objDataReader("FUN_NOME").ToString()
                    row("CON_ENTRADA") = Convert.ToDateTime(objDataReader("CON_ENTRADA")).ToString("dd/MM/yyyy")
                    row("DIAS") = objDataReader("DIAS").ToString()
                    row("INICIO") = If(objDataReader("INICIO") Is DBNull.Value, DBNull.Value, Convert.ToDateTime(objDataReader("INICIO")).ToString("dd/MM/yyyy"))
                    row("CON_SAIDA") = If(objDataReader("CON_SAIDA") Is DBNull.Value, DBNull.Value, Convert.ToDateTime(objDataReader("CON_SAIDA")).ToString("dd/MM/yyyy"))
                    row("TEMPO") = objDataReader("TEMPO").ToString()
                    row("STATUS") = objDataReader("STATUS").ToString()
                    row("COD_ID") = objDataReader("COD_ID").ToString()
                    row("SC_MOTIVO") = objDataReader("SC_MOTIVO").ToString()
                    row("SC_QUANTIDADE") = objDataReader("SC_QUANTIDADE").ToString()
                    dt.Rows.Add(row)
                End If
            Loop While objDataReader.Read()

            ListaContencao.DataSource = dt
            ListaContencao.DataBind()
        Else
            ORDEMP.Text = "JBC não encontrada."
            mp1.Show()
            objDataReader.Close()
            fechabdnew()
            Return
        End If
        objDataReader.Close()


        ListaPN.DataSource = Nothing
        ListaPN.DataBind()
        comandoSQL.CommandText = "SELECT PN_PARTNUMBER FROM TAB_JBC_PN WHERE JBC_ID = " & txt_proc.Text
        objDataReader = comandoSQL.ExecuteReader
        Dim dtPN As New DataTable()
        dtPN.Columns.Add("PN", GetType(String))

        While objDataReader.Read()
            Dim row As DataRow = dtPN.NewRow()
            row("PN") = objDataReader("PN_PARTNUMBER").ToString()
            dtPN.Rows.Add(row)
        End While

        ListaPN.DataSource = dtPN
        ListaPN.DataBind()
        objDataReader.Close()

        ListaREV.DataSource = Nothing
        ListaREV.DataBind()
        comandoSQL.CommandText = "SELECT REV_SEQUENCIA,FUN_NOME,REV_DATA,REV_MOTIVO,REV_PATH FROM TAB_JBC_REVISAO INNER JOIN FUNCIONARIO ON REV_RESPONSAVEL = FUN_REGISTRO WHERE JBC_ID = " & txt_proc.Text
        objDataReader = comandoSQL.ExecuteReader
        Dim dtREV As New DataTable()
        dtREV.Columns.Add("REV_SEQUENCIA", GetType(String))
        dtREV.Columns.Add("REV_RESPONSAVEL", GetType(String))
        dtREV.Columns.Add("REV_DATA", GetType(String))
        dtREV.Columns.Add("REV_MOTIVO", GetType(String))
        dtREV.Columns.Add("REV_PATH", GetType(String))

        While objDataReader.Read()
            Dim row As DataRow = dtREV.NewRow()
            row("REV_SEQUENCIA") = objDataReader("REV_SEQUENCIA").ToString()
            row("REV_RESPONSAVEL") = objDataReader("FUN_NOME").ToString()
            row("REV_DATA") = Convert.ToDateTime(objDataReader("REV_DATA")).ToString("dd/MM/yyyy")
            row("REV_MOTIVO") = objDataReader("REV_MOTIVO").ToString()
            row("REV_PATH") = objDataReader("REV_PATH").ToString()
            dtREV.Rows.Add(row)
        End While

        ListaREV.DataSource = dtREV
        ListaREV.DataBind()

        objDataReader.Close()
        fechabdnew()
    End Sub

    Protected Sub ListaREV_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles ListaREV.RowCommand
        If (e.CommandName = "DOWNLOAD") Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            Dim arquivo As String = ListaREV.Rows(index).Cells(4).Text

            Dim filePath As String = "//mfgsvr2/inetpub/wwwroot/Treinamentos/JBC/" & arquivo

            If System.IO.File.Exists(filePath) Then
                Response.Clear()
                Response.ContentType = "application/octet-stream"
                Response.AddHeader("Content-Disposition", "attachment; filename=" & System.IO.Path.GetFileName(filePath))
                Response.WriteFile(filePath)
                Response.End()
            Else
                Response.Write("File not found.")
            End If
        End If
    End Sub
End Class