Public Class ChamadoTI_Resolver
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '################# BOTÃO DE LOG-OFF #################
        Try
            Dim BTN As System.Web.UI.HtmlControls.HtmlInputSubmit
            Dim reg, VALIDAR As Integer
            BTN = Master.FindControl("CmdSignOut")
            BTN.Value = "SAIR DO REGISTRO: " & User.Identity.Name
            reg = User.Identity.Name
            VALIDAR = ValidarTela(reg, 230)
            If VALIDAR = 1 Then
                Response.Redirect("~/Tela_inicial.aspx")
                CType(Master.FindControl("mp6"), AjaxControlToolkit.ModalPopupExtender).Show()
            End If
        Catch ex As Exception
            ORDEMP.Text = "USUÁRIO NÃO AUTORIZADO"
            mp1.Show()
            Response.Redirect("~/SGM.aspx")
        End Try
        '####################################################
        If Not IsPostBack Then
            PreencherChamado()
        End If
    End Sub

    'Resolver um chamado
    Protected Sub cmdsalvar_Click(sender As Object, e As EventArgs) Handles cmdsalvar.Click
        If idchamado <> "" Then
            conectabdnew()
            comandoSQL.CommandText = "SELECT * FROM TAB_CHAMADO_TI WHERE ID = @ID"
            comandoSQL.Parameters.AddWithValue("@ID", idchamado)
            objDataReader = comandoSQL.ExecuteReader()

            If objDataReader.Read() Then
                If objDataReader("DATA_ANDAMENTO") Is DBNull.Value Then
                    objDataReader.Close()
                    comandoSQL.Parameters.Clear()
                    comandoSQL.CommandText = "UPDATE TAB_CHAMADO_TI SET DATA_ANDAMENTO = GETDATE() WHERE ID = @ID"
                    comandoSQL.Parameters.AddWithValue("@ID", idchamado)
                    comandoSQL.ExecuteNonQuery()
                    ORDEMP.Text = "Chamado em andamento"
                    mp1.Show()
                Else
                    If txtres.Text = "" Then
                        ORDEMP.Text = "Descreva a resolução!"
                        mp1.Show()
                    Else
                        objDataReader.Close()
                        comandoSQL.Parameters.Clear()
                        comandoSQL.CommandText = "UPDATE TAB_CHAMADO_TI Set RESOLUCAO = @RESOLUCAO, REGISTRO_RESOLUCAO = @REGISTRO_RESOLUCAO, DATA_RESOLUCAO = GETDATE() WHERE ID = @ID"
                        comandoSQL.Parameters.AddWithValue("@RESOLUCAO", txtres.Text)
                        comandoSQL.Parameters.AddWithValue("@REGISTRO_RESOLUCAO", User.Identity.Name)
                        comandoSQL.Parameters.AddWithValue("@ID", idchamado)
                        comandoSQL.ExecuteNonQuery()
                        ORDEMP.Text = "Chamado resolvido com sucesso!"
                        mp1.Show()
                    End If
                End If
            Else
                objDataReader.Close()
                fechabdnew()
                ORDEMP.Text = "Nenhum dado encontrado para o chamado selecionado."
                mp1.Show()
            End If
        Else
            ORDEMP.Text = "Selecione um chamado"
            mp1.Show()
        End If
        ResetForm()
        PreencherChamado()
        objDataReader.Close()
        fechabdnew()
    End Sub

    'resetar formulario
    Private Sub ResetForm()
        txtres.Text = ""
        txtlocal.Text = ""
        txttipo.Text = ""
        txtdesc.Text = ""
        idchamado = ""
        txtres.Enabled = False
        cmdsalvar.Text = "INICIAR"
    End Sub

    'Preencher lista de chamado
    Private Sub PreencherChamado()
        Dim SITUACAO As String
        ListaOrdems.DataSource = Nothing ' Limpar os dados existentes na GridView
        ListaOrdems.DataBind() ' Atualizar a exibição
        conectabdnew()
        comandoSQL.CommandText = "SELECT TAB_CHAMADO_TI.*, FUNCIONARIO.FUN_NOME FROM TAB_CHAMADO_TI INNER JOIN FUNCIONARIO ON FUNCIONARIO.FUN_REGISTRO = TAB_CHAMADO_TI.REGISTRO_CHAMADO WHERE TAB_CHAMADO_TI.DATA_RESOLUCAO IS NULL"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.HasRows Then
            Dim dt As New DataTable()
            dt.Columns.Add("ID", GetType(Integer))
            dt.Columns.Add("TIPO", GetType(String))
            dt.Columns.Add("LOCAL", GetType(String))
            dt.Columns.Add("FUN", GetType(String))
            dt.Columns.Add("DATA", GetType(DateTime))
            dt.Columns.Add("SITUACAO", GetType(String))
            While objDataReader.Read()
                If objDataReader("DATA_ANDAMENTO") Is DBNull.Value Then
                    SITUACAO = "AGUARDANDO"
                Else
                    SITUACAO = "EM ANDAMENTO"
                End If
                Dim row As DataRow = dt.NewRow()
                row("ID") = objDataReader("ID")
                row("TIPO") = objDataReader("TIPO_CHAMADO")
                row("LOCAL") = objDataReader("LOCAL_CHAMADO")
                row("FUN") = objDataReader("FUN_NOME")
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

    Protected Sub ListaOrdems_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles ListaOrdems.RowCommand
        ResetForm()
        If (e.CommandName = "EDITAR") Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            idchamado = ListaOrdems.Rows(index).Cells(0).Text
            conectabdnew()
            comandoSQL.CommandText = "SELECT * FROM TAB_CHAMADO_TI WHERE ID = @ID"
            comandoSQL.Parameters.AddWithValue("@ID", idchamado)
            objDataReader = comandoSQL.ExecuteReader
            If objDataReader.HasRows Then
                objDataReader.Read()
                txtlocal.Text = objDataReader("LOCAL_CHAMADO").ToString()
                txttipo.Text = objDataReader("TIPO_CHAMADO").ToString()
                txtdesc.Text = objDataReader("DESCRICAO_CHAMADO").ToString()
                If Not objDataReader.IsDBNull(objDataReader.GetOrdinal("DATA_ANDAMENTO")) Then
                    cmdsalvar.Text = "CONCLUIR"
                    txtres.Enabled = True
                End If
            End If
                objDataReader.Close()
            fechabdnew()
            PreencherChamado()
            cmdsalvar.Enabled = True
        End If
    End Sub

End Class