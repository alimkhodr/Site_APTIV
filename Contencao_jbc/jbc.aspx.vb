Imports System.IO

Public Class jbc
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
            VALIDAR = ValidarTela(reg, 607)
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
            Linhas()
            Codigo_JBC()
        End If
    End Sub

    Sub Codigo_JBC()
        Try
            conectabdnew()
            comandoSQL.CommandText = "SELECT TOP 1 JBC_ID FROM TAB_JBC WHERE JBC_ID LIKE '%" & DateTime.Now.Year & "%' ORDER BY JBC_ID DESC"
            objDataReader = comandoSQL.ExecuteReader
            If objDataReader.Read() Then
                txt_nform.Text = (Convert.ToInt32(objDataReader("JBC_ID")) + 10000).ToString()
            Else
                txt_nform.Text = "1" & DateTime.Now.Year
            End If
            objDataReader.Close()
            fechabdnew()
        Catch ex As Exception
            ORDEMP.Text = ex.Message
            mp1.Show()
        End Try
    End Sub

    Sub Linhas()
        Try
            cbo_linha.Items.Clear()
            cbo_linha.Items.Add("")

            txt_familia.Items.Clear()
            txt_familia.Items.Add("")

            conectabdnew()

            comandoSQL.CommandText = "SELECT CAST(LIN_CT AS VARCHAR) +''+CAST(LIN_MAQUINA AS VARCHAR) +' - ' + LIN_NOME_LINHA as LINHA, LIN_CODIGO_LINHA from LINHA WHERE LIN_STATUS = 0 ORDER BY LIN_CT, LIN_MAQUINA ASC "
            objDataReader = comandoSQL.ExecuteReader
            While objDataReader.Read()
                listLinha = New ListItem(objDataReader(0), objDataReader(1))
                cbo_linha.Items.Add(listLinha)
            End While
            objDataReader.Close()

            comandoSQL.CommandText = "SELECT DISTINCT(LIN_DIVISAO) from LINHA WHERE LIN_STATUS = 0 ORDER BY LIN_DIVISAO ASC"
            objDataReader = comandoSQL.ExecuteReader
            While objDataReader.Read()
                txt_familia.Items.Add(objDataReader(0))
            End While
            objDataReader.Close()

            fechabdnew()
        Catch ex As Exception
            ORDEMP.Text = ex.Message
            mp1.Show()
        End Try
    End Sub

    Sub Pn()
        Try
            listPN.Items.Clear()
            conectabdnew()
            comandoSQL.CommandText = "SELECT DISTINCT(LP_PART_NUMBER) FROM LINHA_PRODUTO WHERE ('" & cbo_linha.SelectedItem.Value & "' = '' OR LP_CODIGO_LINHA = '" & cbo_linha.SelectedItem.Value & "') AND ('" & txt_proc_pn.Text & "' = '' OR LP_PART_NUMBER LIKE '" & txt_proc_pn.Text & "%' )"
            objDataReader = comandoSQL.ExecuteReader
            While objDataReader.Read()
                listPN.Items.Add(objDataReader(0))
            End While
            objDataReader.Close()
            fechabdnew()
        Catch ex As Exception
            ORDEMP.Text = ex.Message
            mp1.Show()
        End Try
    End Sub

    Protected Sub dropLista_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_linha.SelectedIndexChanged
        If cbo_linha.SelectedValue <> "" Then
            Pn()
        Else
            listPN.Items.Clear()
        End If
    End Sub

    Protected Sub btn_vincular_pn_Click(sender As Object, e As EventArgs) Handles btn_vincular_pn.Click
        Try
            If listPN.Items.Cast(Of ListItem)().Where(Function(item) item.Selected).Count() = 0 Then
                ORDEMP.Text = "Selecione ao menos um PN"
                mp1.Show()
                Return
            End If

            For Each item As ListItem In listPN.Items
                If item.Selected Then
                    AddPN(item.Text)
                End If
            Next
        Catch ex As Exception
            ORDEMP.Text = ex.Message
            mp1.Show()
        End Try
    End Sub
    Sub AddPN(PN As String)
        Dim Existente As Boolean = False

        For Each item As ListItem In ListPNvinculado.Items
            If PN = item.Text Then
                ORDEMP.Text = "PN já está na lista"
                mp1.Show()
                Existente = True
                Return
            End If
        Next

        If Not Existente Then
            ListPNvinculado.Items.Add(PN)
        End If
    End Sub

    Protected Sub btn_desvincular_pn_Click(sender As Object, e As EventArgs) Handles btn_desvincular_pn.Click
        Try
            Dim itemsToRemove As New List(Of ListItem)

            For Each item As ListItem In ListPNvinculado.Items
                If item.Selected Then
                    itemsToRemove.Add(item)
                End If
            Next

            For Each itemToRemove As ListItem In itemsToRemove
                ListPNvinculado.Items.Remove(itemToRemove)
            Next

        Catch ex As Exception
            ORDEMP.Text = ex.Message
            mp1.Show()
        End Try
    End Sub
    Protected Sub cbo_responsavel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbo_responsavel.SelectedIndexChanged
        If cbo_responsavel.SelectedValue = "Outros" Then
            panel_outros.Visible = True
        Else
            panel_outros.Visible = False
        End If
    End Sub

    Protected Sub btn_salvar_Click(sender As Object, e As EventArgs) Handles btn_salvar.Click
        ''verifica campos
        If cbo_tipo.Text = "" Then
            ORDEMP.Text = "Preencha o tipo."
            mp1.Show()
            Return
        End If
        If txt_descricao.Text = "" Then
            ORDEMP.Text = "Descreva a JBC."
            mp1.Show()
            Return
        End If
        If txt_razao.Text = "" Then
            ORDEMP.Text = "Preencha a razão."
            mp1.Show()
            Return
        End If
        If panel_outros.Visible = False Then
            If cbo_responsavel.Text = "" Then
                ORDEMP.Text = "Preencha o responsável."
                mp1.Show()
                Return
            End If
        Else
            If txt_outros.Text = "" Then
                ORDEMP.Text = "Preencha o responsável."
                mp1.Show()
                Return
            End If
        End If

        If btn_salvar.Text = "Salvar" Then
            Try
                ''insere jbc
                conectabdnew()
                comandoSQL.CommandText = "INSERT INTO TAB_JBC (JBC_ID, JBC_EMISSAO, JBC_EMITENTE, JBC_TIPO, JBC_DESCRICAO, JBC_RESPONSAVEL, JBC_LINHA, JBC_IDENTIFICACAO, JBC_RAZAO, JBC_REACAO) VALUES (" & txt_nform.Text & ", GETDATE(), '" & User.Identity.Name & "','" & cbo_tipo.Text & "',"
                comandoSQL.CommandText &= "'" & txt_descricao.Text & "', '" & If(panel_outros.Visible = False, cbo_responsavel.Text, txt_outros.Text) & "', '" & txt_familia.Text & "', '" & txt_indent.Text & "', '" & txt_razao.Text & "', '" & txt_reacao.Text & "')"
                comandoSQL.ExecuteNonQuery()
                ''insere pn vinculado a jbc
                For Each item As ListItem In ListPNvinculado.Items
                    If item.Text <> "" Then
                        comandoSQL.CommandText = "INSERT INTO TAB_JBC_PN (JBC_ID, PN_PARTNUMBER) VALUES (" & txt_nform.Text & ", '" & item.Text & "')"
                        comandoSQL.ExecuteNonQuery()
                    End If
                Next
                ORDEMP.Text = "JBC " & txt_nform.Text & " inserida com sucesso!"
                mp1.Show()

                panel_rev.Visible = True
                btn_salvar.Text = "Editar"
                btn_concluir.Visible = True
            Catch ex As Exception
                ORDEMP.Text = ex.Message
                mp1.Show()
            End Try
        Else
            Try
                ''edita jbc
                conectabdnew()
                comandoSQL.CommandText = "UPDATE TAB_JBC SET JBC_TIPO = '" & cbo_tipo.Text & "', JBC_EMISSAO = '" & Convert.ToDateTime(txt_data.Text).ToString("dd/MM/yyyy") & "', JBC_DESCRICAO = '" & txt_descricao.Text & "', JBC_RESPONSAVEL = '" & If(panel_outros.Visible = False, cbo_responsavel.Text, txt_outros.Text) & "', "
                comandoSQL.CommandText &= "JBC_LINHA = '" & txt_familia.Text & "', JBC_IDENTIFICACAO = '" & txt_indent.Text & "', JBC_RAZAO = '" & txt_razao.Text & "', JBC_REACAO = '" & txt_reacao.Text & "' WHERE JBC_ID = " & txt_nform.Text
                comandoSQL.ExecuteNonQuery()

                ''insere pn vinculado a jbc
                comandoSQL.CommandText = "DELETE TAB_JBC_PN WHERE JBC_ID = " & txt_nform.Text
                comandoSQL.ExecuteNonQuery()
                For Each item As ListItem In ListPNvinculado.Items
                    If item.Text <> "" Then
                        comandoSQL.CommandText = "INSERT INTO TAB_JBC_PN (JBC_ID, PN_PARTNUMBER) VALUES (" & txt_nform.Text & ", '" & item.Text & "')"
                        comandoSQL.ExecuteNonQuery()
                    End If
                Next

                ORDEMP.Text = "JBC " & txt_nform.Text & " editada com sucesso!"
                mp1.Show()

                fechabdnew()
            Catch ex As Exception
                ORDEMP.Text = ex.Message
                mp1.Show()
            End Try
        End If
    End Sub

    Sub Clear()
        'limpa codigo JBC
        Codigo_JBC()

        ' Limpar todos os campos
        cbo_tipo.Text = ""
        txt_descricao.Text = ""
        txt_razao.Text = ""
        cbo_responsavel.Text = ""
        txt_outros.Text = ""
        txt_rev_motivo.Text = ""
        cbo_linha.Text = ""
        txt_data.Text = ""
        txt_familia.Text = ""
        txt_indent.Text = ""
        txt_reacao.Text = "Segrgaar e tratar como produto não conforme"

        ' Ocultar controles
        panel_outros.Visible = False
        panel_rev.Visible = False
        btn_concluir.Visible = False

        ' Limpar ListBox
        listPN.Items.Clear()
        ListPNvinculado.Items.Clear()
        ListRev.Items.Clear()
        btn_salvar.Text = "Salvar"
    End Sub

    Protected Sub btn_proc_Click(sender As Object, e As EventArgs) Handles btn_proc.Click
        If txt_proc.Text.Length < 5 And txt_proc.Text <> "" Then
            ORDEMP.Text = "Número de JBC inválida."
            mp1.Show()
            Return
        End If
        If txt_proc.Text = "" Then
            Clear()
            Return
        Else
            Try
                Clear()
                conectabdnew()
                ''consulta jbc
                Dim ID As Integer = txt_proc.Text
                comandoSQL.CommandText = "SELECT * FROM TAB_JBC WHERE JBC_ID = " & ID
                objDataReader = comandoSQL.ExecuteReader
                If objDataReader.Read Then
                    If objDataReader("JBC_FIM") Is DBNull.Value Then
                        txt_nform.Text = objDataReader("JBC_ID").ToString
                        cbo_tipo.Text = objDataReader("JBC_TIPO").ToString
                        txt_descricao.Text = objDataReader("JBC_DESCRICAO").ToString
                        txt_razao.Text = objDataReader("JBC_RAZAO").ToString
                        txt_data.Text = Convert.ToDateTime(objDataReader("JBC_EMISSAO")).ToString("yyyy-MM-dd")
                        txt_reacao.Text = objDataReader("JBC_REACAO").ToString
                        txt_familia.Text = objDataReader("JBC_LINHA").ToString
                        txt_indent.Text = objDataReader("JBC_IDENTIFICACAO").ToString

                        If objDataReader("JBC_RESPONSAVEL") = "Manufatura" Or objDataReader("JBC_RESPONSAVEL") = "Qualidade" Then
                            cbo_responsavel.Text = objDataReader("JBC_RESPONSAVEL").ToString
                        Else
                            cbo_responsavel.Text = "Outros"
                            panel_outros.Visible = True
                            txt_outros.Text = objDataReader("JBC_RESPONSAVEL").ToString
                        End If

                        panel_rev.Visible = True
                        btn_salvar.Text = "Editar"
                        btn_concluir.Visible = True
                    Else
                        ORDEMP.Text = "JBC já finalizada."
                        mp1.Show()
                        Return
                    End If
                Else
                    ORDEMP.Text = "JBC não encontrada."
                    mp1.Show()
                    Return
                End If
                objDataReader.Close()

                comandoSQL.CommandText = "SELECT PN_PARTNUMBER FROM TAB_JBC_PN WHERE JBC_ID = " & ID
                objDataReader = comandoSQL.ExecuteReader
                While objDataReader.Read
                    AddPN(objDataReader("PN_PARTNUMBER"))
                End While
                objDataReader.Close()

                comandoSQL.CommandText = "SELECT REV_SEQUENCIA, REV_MOTIVO FROM TAB_JBC_REVISAO WHERE JBC_ID = " & ID
                objDataReader = comandoSQL.ExecuteReader
                While objDataReader.Read
                    ListRev.Items.Add(objDataReader("REV_SEQUENCIA") & (" - ") & objDataReader("REV_MOTIVO"))
                End While
                objDataReader.Close()

                fechabdnew()
            Catch ex As Exception
                ORDEMP.Text = ex.Message
                mp1.Show()
            End Try
        End If
    End Sub

    'faz um nome unico pro arquivo pdf
    Private Function GetUniqueFileName(folderPath As String, fileName As String) As String
        Dim uniqueFileName As String = fileName
        Dim counter As Integer = 1
        While File.Exists(Path.Combine(folderPath, uniqueFileName))
            Dim extension As String = Path.GetExtension(fileName)
            Dim fileNameWithoutExtension As String = Path.GetFileNameWithoutExtension(fileName)
            uniqueFileName = String.Format("{0}({1}){2}", fileNameWithoutExtension, counter, extension)
            counter += 1
        End While
        Return uniqueFileName
    End Function

    Protected Sub btn_add_rev_Click(sender As Object, e As EventArgs) Handles btn_add_rev.Click
        Dim lastItem As Integer = 0

        If ListRev.Items.Count > 0 Then
            Dim lastItemText As String = ListRev.Items(ListRev.Items.Count - 1).Text
            Dim parts() As String = lastItemText.Split(New String() {" - "}, StringSplitOptions.None)

            If parts.Length = 2 Then
                Integer.TryParse(parts(0), lastItem)
            End If
        End If

        lastItem += 1

        If FileUpload1.FileName <> "" Then
            Dim fileName As String = Path.GetFileName(FileUpload1.PostedFile.FileName)
            uniqueFileName = GetUniqueFileName("\\mfgsvr2\inetpub\wwwroot\Treinamentos\JBC\", fileName)
            Dim fileURL As String = "\\mfgsvr2\inetpub\wwwroot\Treinamentos\JBC\" & uniqueFileName

            ''insere revisão
            Try
                conectabdnew()
                comandoSQL.CommandText = "INSERT INTO TAB_JBC_REVISAO (REV_SEQUENCIA, JBC_ID, REV_RESPONSAVEL, REV_DATA, REV_MOTIVO,REV_PATH) VALUES (" & lastItem.ToString() & "," & txt_nform.Text & ", " & User.Identity.Name & ", GETDATE(), "
                comandoSQL.CommandText &= "'" & txt_rev_motivo.Text & "','" & uniqueFileName & "')"
                comandoSQL.ExecuteNonQuery()
                FileUpload1.PostedFile.SaveAs(fileURL)
                ORDEMP.Text = "Revisão adicionada a JBC " & txt_nform.Text & " com sucesso!"
                mp1.Show()
                ListRev.Items.Add(lastItem.ToString() + " - " + txt_rev_motivo.Text)
                fechabdnew()
                txt_rev_motivo.Text = ""
            Catch ex As Exception
                ORDEMP.Text = ex.Message
                mp1.Show()
            End Try
        Else
            ORDEMP.Text = "Selecione um PDF"
            mp1.Show()
        End If
    End Sub

    Protected Sub btn_concluir_Click(sender As Object, e As EventArgs) Handles btn_concluir.Click
        Try
            ''edita jbc
            conectabdnew()
            comandoSQL.CommandText = "UPDATE TAB_JBC SET JBC_FIM = GETDATE() WHERE JBC_ID = " & txt_nform.Text
            comandoSQL.ExecuteNonQuery()
            Clear()
            ORDEMP.Text = "JBC concluida com sucesso!"
            mp1.Show()

            fechabdnew()
        Catch ex As Exception
            ORDEMP.Text = ex.Message
            mp1.Show()
        End Try
    End Sub

    Protected Sub btn_proc_pn_Click(sender As Object, e As EventArgs) Handles btn_proc_pn.Click
        Pn()
    End Sub
End Class