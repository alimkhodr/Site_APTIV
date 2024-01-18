Public Class ChamadoManutencao
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '################# BOTÃO DE LOG-OFF #################
        Try
            Dim BTN As System.Web.UI.HtmlControls.HtmlInputSubmit
            Dim reg, VALIDAR As Integer
            BTN = Master.FindControl("CmdSignOut")
            BTN.Value = "SAIR DO REGISTRO: " & User.Identity.Name
            reg = User.Identity.Name
            VALIDAR = ValidarTela(reg, 131)
            If VALIDAR = 1 Then
                Response.Redirect("~/SGM.aspx")
                CType(Master.FindControl("mp6"), AjaxControlToolkit.ModalPopupExtender).Show()
            End If
        Catch ex As Exception
            ORDEMP.Text = "USUÁRIO NÃO AUTORIZADO"
            mp1.Show()
            Response.Redirect("~/SGM.aspx")
        End Try
        '####################################################
        If Not IsPostBack Then
            'Preencher os tipos de chamados
            conectabdnew()
            comandoSQL.CommandText = "Select NOME_CHAMADO from TAB_CHAMADO_MANUTENCAO_TIPO"
            objDataReader = comandoSQL.ExecuteReader
            While objDataReader.Read()
                If objDataReader.HasRows Then
                    cbotipo.Items.Add(objDataReader(0))
                End If
            End While
            objDataReader.Close()
            PreencherChamado()
            fechabdnew()
        End If
    End Sub

    'Solicitar um chamado
    Protected Sub cmdsalvar_Click(sender As Object, e As EventArgs) Handles cmdsalvar.Click

        If txtlocal.Text = "" Then
            ORDEMP.Text = "Local não preenchido!"
            mp1.Show()
            Exit Sub
        End If

        If cbotipo.Text = "" Then
            ORDEMP.Text = "Tipo não preenchido!"
            mp1.Show()
            Exit Sub
        End If

        If txtdesc.Text = "" Then
            ORDEMP.Text = "Descreva a situação"
            mp1.Show()
            Exit Sub
        End If

        conectabdnew()
        comandoSQL.CommandText = "INSERT INTO TAB_CHAMADO_MANUTENCAO VALUES(@LOCAL, @TIPO, @REGISTRO_CHAMADO, @DESCRICAO, GETDATE(), NULL, NULL, NULL, NULL)"
        comandoSQL.Parameters.AddWithValue("@LOCAL", txtlocal.Text)
        comandoSQL.Parameters.AddWithValue("@TIPO", cbotipo.Text)
        comandoSQL.Parameters.AddWithValue("@REGISTRO_CHAMADO", User.Identity.Name)
        comandoSQL.Parameters.AddWithValue("@DESCRICAO", txtdesc.Text)
        comandoSQL.ExecuteNonQuery()
        ORDEMP.Text = "Chamado solicitado com sucesso!"
        mp1.Show()
        PreencherChamado()
        fechabdnew()
        ResetForm()
    End Sub

    'resetar formulario
    Private Sub ResetForm()
        txtlocal.Text = ""
        cbotipo.Text = ""
        txtdesc.Text = ""
    End Sub

    'Preencher lista de chamado
    Private Sub PreencherChamado()
        Dim SITUACAO As String
        ListaOrdems.DataSource = Nothing
        ListaOrdems.DataBind()
        conectabdnew()
        comandoSQL.CommandText = "SELECT TAB_CHAMADO_MANUTENCAO.*, FUNCIONARIO.FUN_NOME FROM TAB_CHAMADO_MANUTENCAO INNER JOIN FUNCIONARIO ON FUNCIONARIO.FUN_REGISTRO = TAB_CHAMADO_MANUTENCAO.REGISTRO_CHAMADO WHERE TAB_CHAMADO_MANUTENCAO.DATA_RESOLUCAO IS NULL AND REGISTRO_CHAMADO = @REGISTRO_CHAMADO"
        comandoSQL.Parameters.AddWithValue("@REGISTRO_CHAMADO", User.Identity.Name)
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.HasRows Then
            Dim dt As New DataTable()
            dt.Columns.Add("TIPO", GetType(String))
            dt.Columns.Add("LOCAL", GetType(String))
            dt.Columns.Add("DATA", GetType(DateTime))
            dt.Columns.Add("SITUACAO", GetType(String))
            While objDataReader.Read()
                If objDataReader("DATA_ANDAMENTO") Is DBNull.Value Then
                    SITUACAO = "AGUARDANDO"
                Else
                    SITUACAO = "EM ANDAMENTO"
                End If
                Dim row As DataRow = dt.NewRow()
                row("TIPO") = objDataReader("TIPO_CHAMADO")
                row("LOCAL") = objDataReader("LOCAL_CHAMADO")
                row("DATA") = Convert.ToDateTime(objDataReader("DATA_CHAMADO"))
                row("SITUACAO") = SITUACAO
                dt.Rows.Add(row)
            End While
            ListaOrdems.DataSource = dt
            ListaOrdems.DataBind()
        End If
        objDataReader.Close()
        fechabdnew()
    End Sub

End Class