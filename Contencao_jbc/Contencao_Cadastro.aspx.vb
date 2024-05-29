Public Class Contencao_Cadastro_aspx
    Inherits System.Web.UI.Page


    Dim listLinha As ListItem
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Try
                Dim BTN As HtmlInputSubmit
                Dim reg, VALIDAR As Integer
                BTN = Master.FindControl("CmdSignOut")
                BTN.Value = "SAIR DO REGISTRO: " & User.Identity.Name
                reg = User.Identity.Name
                VALIDAR = ValidarTela(reg, 607) 'PEGA O CÓDIGO DA TELA
                If VALIDAR = 1 Then
                    CType(Master.FindControl("Label16"), Label).Text = "ACESSO NÃO AUTORIZADO!"
                    CType(Master.FindControl("Label16"), Label).ForeColor = Drawing.Color.Red
                    CType(Master.FindControl("mp6"), AjaxControlToolkit.ModalPopupExtender).Show()
                    Response.Redirect("~/Tela_Inicial.aspx")
                End If
                Paneladd.Visible = False
                Panel4.Visible = False
                Panel5.Visible = False
                ORDEMP.Text = "Selecione oque deseja fazer"
                mp1.Show()
            Catch ex As Exception

            End Try

        End If
    End Sub

    Sub Linhas()
        dropLista.Items.Clear()
        dropLista.Items.Add("")
        conectabdnew()
        comandoSQL.CommandText = "SELECT CAST(LIN_CT AS VARCHAR) +''+CAST(LIN_MAQUINA AS VARCHAR) +' - ' + LIN_NOME_LINHA as LINHA, LIN_CODIGO_LINHA from LINHA
        WHERE LIN_STATUS = 0 ORDER BY LIN_CT, LIN_MAQUINA ASC "
        objDataReader = comandoSQL.ExecuteReader
        While objDataReader.Read()
            listLinha = New ListItem(objDataReader(0), objDataReader(1))
            dropLista.Items.Add(listLinha)
        End While
        objDataReader.Close()
        fechabdnew()
    End Sub

    Sub Pn()
        listPN.Items.Clear()
        conectabdnew()
        comandoSQL.CommandText = "SELECT LP_PART_NUMBER FROM LINHA_PRODUTO WHERE LP_CODIGO_LINHA = '" & dropLista.SelectedItem.Value & "'"
        objDataReader = comandoSQL.ExecuteReader
        While objDataReader.Read()
            listPN.Items.Add(objDataReader(0))
        End While
        objDataReader.Close()
        fechabdnew()
    End Sub
    Sub jbc()

        dropJbc.Items.Clear()
        conectabdnew()
        comandoSQL.CommandText = "SELECT JBC FROM TAB_JBC"
        objDataReader = comandoSQL.ExecuteReader
        While objDataReader.Read()
            dropJbc.Items.Add(objDataReader(0))
        End While
        objDataReader.Close()
        fechabdnew()

    End Sub
    Protected Sub dropLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dropLista.SelectedIndexChanged
        Pn()
    End Sub

    Sub addSelecionados()
        conectabdnew()
        comandoSQL.CommandText = "INSERT INTO TAB_CONTENCAO_JBC (JBC,PARTNUMBER,FLAG, REGISTRO_VINCULO, DATA_VINCULO) VALUES ('" & dropJbc.Text & "', @pn, 1, '" & Session("Registro").ToString() & "', getdate())"
        For Each item As ListItem In listPN.Items
            If item.Selected = True Then
                comandoSQL.Parameters.Add("@pn", SqlDbType.VarChar).Value = item.Text
                comandoSQL.ExecuteNonQuery()
                comandoSQL.Parameters.Clear()
            End If
        Next
        fechabdnew()
        showVinculados()
    End Sub

    Sub showVinculados()
        conectabdnew()
        comandoSQL.CommandText = "SELECT ID, PARTNUMBER FROM TAB_CONTENCAO_JBC WHERE JBC = '" & dropJbc.Text & "' and flag = 1"
        objDataReader = comandoSQL.ExecuteReader
        While objDataReader.Read
            Dim lstVinculo = New ListItem(objDataReader(1), objDataReader(0))
            listavinculos.Items.Add(lstVinculo)
        End While
        objDataReader.Close()
        fechabdnew()
    End Sub

    Protected Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        addSelecionados()
    End Sub

    Protected Sub btnVincular_Click(sender As Object, e As EventArgs) Handles btnVincular.Click
        Paneladd.Visible = False
        Panel4.Visible = True
        Panel5.Visible = True
        Linhas()
        jbc()
    End Sub

    Protected Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Panel4.Visible = False
        Panel5.Visible = False
        Paneladd.Visible = True
    End Sub

    Protected Sub btnaddjbc_Click(sender As Object, e As EventArgs) Handles btnaddjbc.Click
        conectabdnew()
        comandoSQL.CommandText = "INSERT INTO TAB_JBC VALUES ('" & TextBox1.Text & "',1,'" & Session("Registro").ToString() & "',getdate())"
        comandoSQL.ExecuteNonQuery()
        fechabdnew()
    End Sub
End Class