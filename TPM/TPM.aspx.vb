Imports System.IO
Imports Microsoft.Win32

Public Class TPM
    Inherits System.Web.UI.Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '########## BOTÃO DE LOG-OFF ########################
        Try
            Dim BTN As System.Web.UI.HtmlControls.HtmlInputSubmit
            Dim reg, VALIDAR As Integer
            BTN = Master.FindControl("CmdSignOut")
            BTN.Value = "SAIR DO REGISTRO: " & User.Identity.Name
            reg = User.Identity.Name
            VALIDAR = ValidarTela(reg, 409)
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
            txt_rev.Text = DateTime.Now.ToString("dd/MM/yyyy")

            txt_linha.Items.Clear()
            txt_linha.Items.Add("")
            conectabdnew()
            comandoSQL.CommandText = "SELECT CAST(LIN_CT AS VARCHAR) +''+CAST(LIN_MAQUINA AS VARCHAR) +' - ' + LIN_NOME_LINHA as LINHA, LIN_CODIGO_LINHA from LINHA WHERE LIN_STATUS = 0 AND LIN_CT = 2030 ORDER BY LIN_CT, LIN_MAQUINA ASC"
            objDataReader = comandoSQL.ExecuteReader
            While objDataReader.Read()
                Dim listLinha As ListItem = New ListItem(objDataReader(0), objDataReader(1))
                txt_linha.Items.Add(listLinha)
            End While
            objDataReader.Close()
            fechabdnew()
        End If
    End Sub

    Sub codigo_item()
        conectabdnew()
        comandoSQL.CommandText = "SELECT TOP 1 ITEM_SEQUENCIA FROM TAB_TPM_ITEM WHERE ITEM_LINHA = " & txt_linha.SelectedItem.Value & " ORDER BY ITEM_SEQUENCIA DESC"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.Read Then
            txt_n.Text = objDataReader(0) + 1
        Else
            txt_n.Text = 1
        End If
        objDataReader.Close()
        fechabdnew()
    End Sub

    Sub PreencherForm()
        ListaTPM.DataSource = Nothing ' Limpar os dados existentes na GridView
        ListaTPM.DataBind() ' Atualizar a exibição
        conectabdnew()
        comandoSQL.CommandText = "SELECT * FROM TAB_TPM_ITEM WHERE ITEM_LINHA = " & txt_linha.SelectedItem.Value
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.HasRows Then
            Dim dt As New DataTable()
            dt.Columns.Add("ITEM_SEQUENCIA", GetType(Integer))
            dt.Columns.Add("ITEM_NOME", GetType(String))
            dt.Columns.Add("ITEM_PATH_PADRAO", GetType(String))
            dt.Columns.Add("ITEM_PATH_LABEL3", GetType(String))
            dt.Columns.Add("ITEM_PADRAO", GetType(String))
            dt.Columns.Add("ITEM_METODO", GetType(String))
            dt.Columns.Add("ITEM_MATERIAL", GetType(String))
            dt.Columns.Add("ITEM_ACAO", GetType(String))
            dt.Columns.Add("ITEM_RESP", GetType(String))
            dt.Columns.Add("ITEM_TEMPO", GetType(String))
            dt.Columns.Add("ITEM_FREQUENCIA", GetType(String))
            dt.Columns.Add("ITEM_PATH_VISUAL1", GetType(String))
            dt.Columns.Add("ITEM_PATH_LABEL1", GetType(String))
            dt.Columns.Add("ITEM_PATH_VISUAL2", GetType(String))
            dt.Columns.Add("ITEM_PATH_LABEL2", GetType(String))
            While objDataReader.Read()
                Dim row As DataRow = dt.NewRow()
                row("ITEM_SEQUENCIA") = objDataReader("ITEM_SEQUENCIA")
                row("ITEM_NOME") = objDataReader("ITEM_NOME").ToString()
                If objDataReader("ITEM_PATH_PADRAO").ToString() <> "" Then
                    row("ITEM_PATH_PADRAO") = "http://mfgsvr2/TPM/PADRAO/" & objDataReader("ITEM_PATH_PADRAO").ToString()
                    row("ITEM_PATH_LABEL3") = objDataReader("ITEM_PATH_PADRAO").ToString()
                End If
                row("ITEM_PADRAO") = objDataReader("ITEM_PADRAO").ToString()
                row("ITEM_METODO") = objDataReader("ITEM_METODO").ToString()
                row("ITEM_MATERIAL") = objDataReader("ITEM_MATERIAL").ToString()
                row("ITEM_ACAO") = objDataReader("ITEM_ACAO").ToString()
                row("ITEM_RESP") = objDataReader("ITEM_RESP").ToString()
                row("ITEM_TEMPO") = objDataReader("ITEM_TEMPO").ToString().Replace(",", ".")
                row("ITEM_FREQUENCIA") = objDataReader("ITEM_FREQUENCIA").ToString()
                If objDataReader("ITEM_PATH_VISUAL").ToString() <> "" Then
                    row("ITEM_PATH_VISUAL1") = "http://mfgsvr2/TPM/VISUAL_1/" & objDataReader("ITEM_PATH_VISUAL").ToString()
                    row("ITEM_PATH_LABEL1") = objDataReader("ITEM_PATH_VISUAL").ToString()
                End If
                If objDataReader("ITEM_PATH_VISUAL_2").ToString() <> "" Then
                    row("ITEM_PATH_VISUAL2") = "http://mfgsvr2/TPM/VISUAL_2/" & objDataReader("ITEM_PATH_VISUAL_2").ToString()
                    row("ITEM_PATH_LABEL2") = objDataReader("ITEM_PATH_VISUAL_2").ToString()
                End If
                dt.Rows.Add(row)
            End While
            ListaTPM.DataSource = dt
            ListaTPM.DataBind()
        End If
        objDataReader.Close()
        fechabdnew()
    End Sub

    Protected Sub ListaTPM_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles ListaTPM.RowCommand
        ResetColumn()
        If (e.CommandName = "EDITAR") Then
            Dim index As Integer = Convert.ToInt32(e.CommandArgument)
            txt_n.Text = ListaTPM.Rows(index).Cells(0).Text

            Dim LabelImg1 As Label = DirectCast(ListaTPM.Rows(index).FindControl("LabelImg1"), Label)
            If LabelImg1.Text <> "" Then
                img_visual1.ImageUrl = "http://mfgsvr2/TPM/VISUAL_1/" & LabelImg1.Text
                LabelUpload1.Text = LabelImg1.Text
            End If

            Dim LabelImg2 As Label = DirectCast(ListaTPM.Rows(index).FindControl("LabelImg2"), Label)
            If LabelImg2.Text <> "" Then
                img_visual2.ImageUrl = "http://mfgsvr2/TPM/VISUAL_2/" & LabelImg2.Text
                LabelUpload2.Text = LabelImg2.Text
            End If

            Dim LabelImg3 As Label = DirectCast(ListaTPM.Rows(index).FindControl("LabelImg3"), Label)
            If LabelImg3.Text <> "" Then
                img_padrao.ImageUrl = "http://mfgsvr2/TPM/PADRAO/" & LabelImg3.Text
                LabelUpload3.Text = LabelImg3.Text
            End If

            conectabdnew()
            comandoSQL.CommandText = "SELECT * FROM TAB_TPM_ITEM WHERE ITEM_LINHA = " & txt_linha.SelectedItem.Value & " AND ITEM_SEQUENCIA = " & txt_n.Text
            objDataReader = comandoSQL.ExecuteReader
            If objDataReader.HasRows Then
                objDataReader.Read()
                txt_item.Text = objDataReader("ITEM_NOME").ToString()
                txt_padrao.Text = objDataReader("ITEM_PADRAO").ToString()
                txt_metodo.Text = objDataReader("ITEM_METODO").ToString()
                txt_materiais.Text = objDataReader("ITEM_MATERIAL").ToString()
                txt_acao.Text = objDataReader("ITEM_ACAO").ToString()
                txt_resp.Text = objDataReader("ITEM_RESP").ToString()
                txt_freq.Text = objDataReader("ITEM_FREQUENCIA").ToString()
                txt_tempo.Text = objDataReader("ITEM_TEMPO").ToString().Replace(",", ".")
                btn_salvar.Text = "Editar"
            End If
            objDataReader.Close()
            fechabdnew()
        End If
    End Sub
    Sub ResetForm()
        ListaTPM.DataSource = Nothing
        ListaTPM.DataBind()
        txt_rev.Text = DateTime.Now.ToString("dd/MM/yyyy")
        txt_exe.Text = ""
        txt_vincula.Text = ""
        btn_salvaform.Text = "Criar"
    End Sub

    Sub ResetColumn()
        txt_n.Text = ""
        txt_n.Text = ""
        txt_item.Text = ""
        txt_padrao.Text = ""
        txt_metodo.Text = ""
        txt_materiais.Text = ""
        txt_acao.Text = ""
        txt_resp.Text = ""
        txt_tempo.Text = ""
        txt_freq.Text = ""

        LabelUpload1.Text = ""
        LabelUpload2.Text = ""
        LabelUpload3.Text = ""

        img_visual1.ImageUrl = Nothing
        img_visual2.ImageUrl = Nothing
        img_padrao.ImageUrl = Nothing
        btn_salvar.Text = "Inserir"
    End Sub

    Protected Sub btn_salvar_Click(sender As Object, e As EventArgs) Handles btn_salvar.Click
        Dim uniqueFileName As String = ""
        Dim uniqueFileName2 As String = ""
        Dim uniqueFileName3 As String = ""
        Dim materiais As String
        Dim acao As String

        If txt_item.Text = "" Or txt_padrao.Text = "" Or txt_metodo.Text = "" Or txt_resp.Text = "" Or txt_freq.Text = "" Then
            ORDEMP.Text = "Preencha os campos obrigatórios(*)."
            mp1.Show()
            Return
        End If

        If txt_materiais.Text = "" Then
            materiais = "N/A"
        Else
            materiais = txt_materiais.Text
        End If

        If txt_acao.Text = "" Then
            acao = "N/A"
        Else
            acao = txt_acao.Text
        End If

        conectabdnew()
        If btn_salvar.Text = "Inserir" Then
            Try
                'Salva a imagem no servidor
                If upload_visual1.FileName <> "" Then
                    If Not IsValidImage(upload_visual1.PostedFile) Then
                        ORDEMP.Text = "Selecione um arquivo de imagem válido (JPG, JPEG ou PNG)"
                        mp1.Show()
                        Return
                    End If

                    Dim fileName As String = Path.GetFileName(upload_visual1.PostedFile.FileName)
                    uniqueFileName = GetUniqueFileName("\\mfgsvr2\inetpub\wwwroot\TPM\VISUAL_1\", fileName) ' Get a unique file name with sequential number
                    Dim fileURL As String = "\\mfgsvr2\inetpub\wwwroot\TPM\VISUAL_1\" & uniqueFileName
                    upload_visual1.PostedFile.SaveAs(fileURL)
                End If

                If upload_visual2.FileName <> "" Then
                    If Not IsValidImage(upload_visual2.PostedFile) Then
                        ORDEMP.Text = "Selecione um arquivo de imagem válido (JPG, JPEG ou PNG)"
                        mp1.Show()
                        Return
                    End If

                    Dim fileName As String = Path.GetFileName(upload_visual2.PostedFile.FileName)
                    uniqueFileName2 = GetUniqueFileName("\\mfgsvr2\inetpub\wwwroot\TPM\VISUAL_2\", fileName) ' Get a unique file name with sequential number
                    Dim fileURL As String = "\\mfgsvr2\inetpub\wwwroot\TPM\VISUAL_2\" & uniqueFileName2
                    upload_visual2.PostedFile.SaveAs(fileURL)
                End If

                If upload_padrao.FileName <> "" Then
                    If Not IsValidImage(upload_padrao.PostedFile) Then
                        ORDEMP.Text = "Selecione um arquivo de imagem válido (JPG, JPEG ou PNG)"
                        mp1.Show()
                        Return
                    End If

                    Dim fileName As String = Path.GetFileName(upload_padrao.PostedFile.FileName)
                    uniqueFileName3 = GetUniqueFileName("\\mfgsvr2\inetpub\wwwroot\TPM\PADRAO\", fileName) ' Get a unique file name with sequential number
                    Dim fileURL As String = "\\mfgsvr2\inetpub\wwwroot\TPM\PADRAO\" & uniqueFileName3
                    upload_padrao.PostedFile.SaveAs(fileURL)
                End If

                'insere um item
                comandoSQL.CommandText = "INSERT INTO TAB_TPM_ITEM (ITEM_SEQUENCIA,ITEM_LINHA,ITEM_NOME" & If(uniqueFileName <> "", ",ITEM_PATH_VISUAL", "") & If(uniqueFileName2 <> "", ",ITEM_PATH_VISUAL_2", "") & ",ITEM_PADRAO" & If(uniqueFileName3 <> "", ",ITEM_PATH_PADRAO", "") & ",ITEM_METODO,ITEM_MATERIAL,ITEM_ACAO,ITEM_RESP,ITEM_TEMPO,ITEM_FREQUENCIA) "
                comandoSQL.CommandText &= "VALUES(" & txt_n.Text & "," & txt_linha.SelectedItem.Value & ",'" & txt_item.Text & "'" & If(uniqueFileName <> "", ",'" & uniqueFileName & "'", "") & If(uniqueFileName2 <> "", ",'" & uniqueFileName2 & "'", "") & ",'" & txt_padrao.Text & "'" & If(uniqueFileName3 <> "", ",'" & uniqueFileName3 & "'", "") & ",'" & txt_metodo.Text & "','" & materiais & "','" & acao & "','" & txt_resp.Text & "'," & If(txt_tempo.Text <> "", txt_tempo.Text, "NULL") & ",'" & txt_freq.Text & "')"
                comandoSQL.ExecuteNonQuery()
                ORDEMP.Text = "Item N°" & txt_n.Text & " adicionado a TPM da linha " & txt_linha.Text & " com sucesso!"
                mp1.Show()
            Catch ex As Exception
                ORDEMP.Text = ex.Message
                mp1.Show()
            End Try
        Else
            Try
                'Salva a imagem no servidor e apaga a que tinha antes (se tiver e se escolheu outra)
                If upload_visual1.FileName <> "" Then
                    If Not IsValidImage(upload_visual1.PostedFile) Then
                        ORDEMP.Text = "Selecione um arquivo de imagem válido (JPG, JPEG ou PNG)"
                        mp1.Show()
                        Return
                    End If

                    If LabelUpload1.Text <> "" Then
                        File.Delete("\\mfgsvr2\inetpub\wwwroot\TPM\VISUAL_1\" & LabelUpload1.Text)
                    End If

                    Dim fileName As String = Path.GetFileName(upload_visual1.PostedFile.FileName)
                    uniqueFileName = GetUniqueFileName("\\mfgsvr2\inetpub\wwwroot\TPM\VISUAL_1\", fileName) ' Get a unique file name with sequential number
                    Dim fileURL As String = "\\mfgsvr2\inetpub\wwwroot\TPM\VISUAL_1\" & uniqueFileName
                    upload_visual1.PostedFile.SaveAs(fileURL)
                End If

                If upload_visual2.FileName <> "" Then
                    If Not IsValidImage(upload_visual2.PostedFile) Then
                        ORDEMP.Text = "Selecione um arquivo de imagem válido (JPG, JPEG ou PNG)"
                        mp1.Show()
                        Return
                    End If

                    If LabelUpload2.Text <> "" Then
                        File.Delete("\\mfgsvr2\inetpub\wwwroot\TPM\VISUAL_2\" & LabelUpload2.Text)
                    End If

                    Dim fileName As String = Path.GetFileName(upload_visual2.PostedFile.FileName)
                    uniqueFileName2 = GetUniqueFileName("\\mfgsvr2\inetpub\wwwroot\TPM\VISUAL_2\", fileName) ' Get a unique file name with sequential number
                    Dim fileURL As String = "\\mfgsvr2\inetpub\wwwroot\TPM\VISUAL_2\" & uniqueFileName2
                    upload_visual2.PostedFile.SaveAs(fileURL)
                End If

                If upload_padrao.FileName <> "" Then
                    If Not IsValidImage(upload_padrao.PostedFile) Then
                        ORDEMP.Text = "Selecione um arquivo de imagem válido (JPG, JPEG ou PNG)"
                        mp1.Show()
                        Return
                    End If

                    If LabelUpload3.Text <> "" Then
                        File.Delete("\\mfgsvr2\inetpub\wwwroot\TPM\PADRAO\" & LabelUpload3.Text)
                    End If

                    Dim fileName As String = Path.GetFileName(upload_padrao.PostedFile.FileName)
                    uniqueFileName3 = GetUniqueFileName("\\mfgsvr2\inetpub\wwwroot\TPM\PADRAO\", fileName) ' Get a unique file name with sequential number
                    Dim fileURL As String = "\\mfgsvr2\inetpub\wwwroot\TPM\PADRAO\" & uniqueFileName3
                    upload_padrao.PostedFile.SaveAs(fileURL)
                End If

                'atualiza um item
                comandoSQL.CommandText = "UPDATE TAB_TPM_ITEM SET ITEM_NOME = '" & txt_item.Text & "'" & If(upload_visual1.FileName <> "", ",ITEM_PATH_VISUAL = '" & uniqueFileName & "' ", "") & If(upload_visual2.FileName <> "", ",ITEM_PATH_VISUAL_2 = '" & uniqueFileName2 & "' ", "") & ",ITEM_PADRAO = '" & txt_padrao.Text & "' " & If(upload_padrao.FileName <> "", ",ITEM_PATH_PADRAO = '" & uniqueFileName3 & "' ", "") & " ,ITEM_METODO = '" & txt_metodo.Text & "',"
                comandoSQL.CommandText &= "ITEM_MATERIAL = '" & materiais & "',ITEM_ACAO = '" & acao & "',ITEM_RESP = '" & txt_resp.Text & "',ITEM_TEMPO = " & If(txt_tempo.Text <> "", txt_tempo.Text, "NULL") & ",ITEM_FREQUENCIA = '" & txt_freq.Text & "' WHERE  ITEM_SEQUENCIA = " & txt_n.Text & " AND ITEM_LINHA = " & txt_linha.SelectedItem.Value
                comandoSQL.ExecuteNonQuery()
                Revisao()
                ORDEMP.Text = "ITEM N°" & txt_n.Text & " atualizado com sucesso!"
                mp1.Show()
            Catch ex As Exception
                ORDEMP.Text = ex.Message
                mp1.Show()
            End Try
        End If
        fechabdnew()
        ResetColumn()
        codigo_item()
        PreencherForm()
    End Sub

    Private Function IsValidImage(postedFile As HttpPostedFile) As Boolean
        Dim allowedExtensions As New List(Of String) From {".jpg", ".jpeg", ".png"}
        Dim fileExtension As String = Path.GetExtension(postedFile.FileName).ToLower()
        Return allowedExtensions.Contains(fileExtension)
    End Function


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

    Protected Sub btn_salvaform_Click(sender As Object, e As EventArgs) Handles btn_salvaform.Click
        If txt_linha.Text = "" Or txt_exe.Text = "" Or txt_vincula.Text = "" Then
            ORDEMP.Text = "Preencha os campos obrigatórios(*)."
            mp1.Show()
            Return
        End If

        Try
            conectabdnew()
            If btn_salvaform.Text = "Criar" Then
                comandoSQL.CommandText = "INSERT INTO TAB_TPM_FORMULARIO (FORM_LINHA,FORM_REV,FORM_EXECUTANTE,FORM_VINCULA) VALUES(" & txt_linha.SelectedItem.Value & ",'" & txt_rev.Text & "','" & txt_exe.Text & "','" & txt_vincula.Text & "')"
                comandoSQL.ExecuteNonQuery()
                column.Enabled = True
                btn_salvar.CssClass = "BtnStyle"
                txt_n.Text = "1"
                ORDEMP.Text = "TPM da linha " & txt_linha.Text & " cadastrado com sucesso!"
                mp1.Show()
            Else
                comandoSQL.CommandText = "UPDATE TAB_TPM_FORMULARIO SET FORM_EXECUTANTE = '" & txt_exe.Text & "',FORM_VINCULA = '" & txt_vincula.Text & "' WHERE FORM_LINHA = " & txt_linha.SelectedItem.Value
                comandoSQL.ExecuteNonQuery()
                Revisao()
                ORDEMP.Text = "TPM da linha " & txt_linha.Text & " editado com sucesso!"
                mp1.Show()
            End If
        Catch ex As Exception
            ORDEMP.Text = ex.Message
            mp1.Show()
        Finally
            fechabdnew()
        End Try
    End Sub

    Protected Sub Revisao()
        Try
            comandoSQL.CommandText = "UPDATE TAB_TPM_FORMULARIO SET FORM_REV = GETDATE() WHERE FORM_LINHA = " & txt_linha.SelectedItem.Value
            comandoSQL.ExecuteNonQuery()
            txt_rev.Text = DateTime.Now.ToString("dd/MM/yyyy")
        Catch ex As Exception
            ORDEMP.Text = ex.Message
            mp1.Show()
        End Try
    End Sub

    Protected Sub txt_linha_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txt_linha.SelectedIndexChanged
        If txt_linha.SelectedValue <> "" Then
            Dim selectedItemText As String = txt_linha.SelectedItem.ToString()
            Dim parts() As String = selectedItemText.Split(New String() {" - "}, StringSplitOptions.None)

            conectabdnew()
            Try
                comandoSQL.CommandText = "SELECT LIN_CODIGO_LINHA FROM LINHA WHERE LIN_CT = " & parts(0).Substring(0, 4) & " AND LIN_MAQUINA = " & parts(0).Substring(4)
                objDataReader = comandoSQL.ExecuteReader()
                If objDataReader.Read() Then
                    txt_linha.SelectedItem.Value = objDataReader("LIN_CODIGO_LINHA").ToString()
                End If
                objDataReader.Close()

                comandoSQL.CommandText = "SELECT TAB_TPM_FORMULARIO.*, (SELECT TOP 1 ITEM_SEQUENCIA FROM TAB_TPM_ITEM WHERE ITEM_LINHA = " & txt_linha.SelectedItem.Value & " ORDER BY ITEM_SEQUENCIA DESC) AS ITEM FROM TAB_TPM_FORMULARIO LEFT JOIN LINHA ON LIN_CODIGO_LINHA = FORM_LINHA WHERE FORM_LINHA = " & txt_linha.SelectedItem.Value
                objDataReader = comandoSQL.ExecuteReader
                If objDataReader.Read Then
                    column.Enabled = True
                    btn_salvar.CssClass = "BtnStyle"
                    btn_salvaform.Text = "Editar"
                    If objDataReader("ITEM") IsNot DBNull.Value Then
                        txt_n.Text = objDataReader("ITEM") + 1
                    Else
                        txt_n.Text = "1"
                    End If
                    txt_rev.Text = Convert.ToDateTime(objDataReader("FORM_REV")).ToString("dd/MM/yyyy")
                    txt_vincula.Text = objDataReader("FORM_VINCULA").ToString()
                    txt_exe.Text = objDataReader("FORM_EXECUTANTE").ToString()
                    PreencherForm()
                Else
                    ResetForm()
                    ResetColumn()
                    column.Enabled = False
                    btn_salvar.CssClass = "BtnStyleDisable"
                    btn_salvaform.Text = "Criar"
                End If
                objDataReader.Close()
            Catch ex As Exception
                ORDEMP.Text = ex.Message
                mp1.Show()
            End Try
            fechabdnew()
        Else
            ResetForm()
            ResetColumn()
            column.Enabled = False
            btn_salvar.CssClass = "BtnStyleDisable"
            btn_salvaform.Text = "Criar"
        End If
    End Sub
End Class