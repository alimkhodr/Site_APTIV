Public Class TPM_Checklist
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '########## BOTÃO DE LOG-OFF ########################
        Try
            Dim BTN As System.Web.UI.HtmlControls.HtmlInputSubmit
            Dim reg, VALIDAR As Integer
            BTN = Master.FindControl("CmdSignOut")
            BTN.Value = "SAIR DO REGISTRO: " & User.Identity.Name
            reg = User.Identity.Name
            VALIDAR = ValidarTela(reg, 1107)
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

    Sub PreencherForm()
        Dim Turno As Integer
        Dim Inicio_Turno As DateTime
        Dim Fim_Turno As DateTime
        If DateTime.Now.ToString("HH:mm:ss") >= "06:55:01" AndAlso DateTime.Now.ToString("HH:mm") <= "16:43" Then
            Turno = 1
            Inicio_Turno = DateTime.Now.ToString("yyyy-MM-dd") & " 06:55:01"
            Fim_Turno = DateTime.Now.ToString("yyyy-MM-dd") & " 16:43:00"
        ElseIf DateTime.Now.ToString("HH:mm:ss") >= "16:43:01" AndAlso DateTime.Now.ToString("HH:mm:ss") <= "23:59:59" Or DateTime.Now.ToString("HH:mm") >= "00:00" AndAlso DateTime.Now.ToString("HH:mm") <= "01:51" Then
            Turno = 2
            If DateTime.Now.ToString("HH:mm") >= "00:00" AndAlso DateTime.Now.ToString("HH:mm") <= "01:51" Then
                Inicio_Turno = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd") & " 16:43:01"
                Fim_Turno = DateTime.Now.ToString("yyyy-MM-dd") & " 01:51"
            Else
                Inicio_Turno = DateTime.Now.ToString("yyyy-MM-dd") & " 16:43:01"
                Fim_Turno = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") & " 01:51"
            End If
        ElseIf DateTime.Now.ToString("HH:mm:ss") >= "01:51:01" AndAlso DateTime.Now.ToString("HH:mm") <= "06:55" Then
            Turno = 3
            Inicio_Turno = DateTime.Now.ToString("yyyy-MM-dd") & " 06:55:01"
            Fim_Turno = DateTime.Now.ToString("yyyy-MM-dd") & " 16:43:00"
        End If

        ListaTPM.DataSource = Nothing ' Limpar os dados existentes na GridView
        ListaTPM.DataBind() ' Atualizar a exibição
        conectabdnew()
        comandoSQL.CommandText = "SELECT TAB_TPM_ITEM.*,(SELECT TOP 1 LOG_DATA FROM TAB_TPM_LOG WHERE LOG_LINHA = ITEM_LINHA AND LOG_SEQUENCIA_ITEM = ITEM_SEQUENCIA ORDER BY LOG_DATA DESC) AS DATA_CHECKLIST FROM TAB_TPM_ITEM WHERE ITEM_LINHA = " & txt_linha.SelectedItem.Value
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
            dt.Columns.Add("ITEM_FREQUENCIA", GetType(String))
            dt.Columns.Add("ITEM_PATH_VISUAL1", GetType(String))
            dt.Columns.Add("ITEM_PATH_LABEL1", GetType(String))
            dt.Columns.Add("ITEM_PATH_VISUAL2", GetType(String))
            dt.Columns.Add("ITEM_PATH_LABEL2", GetType(String))
            dt.Columns.Add("ULTIMO_CHECKLIST", GetType(String))

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
                row("ITEM_FREQUENCIA") = objDataReader("ITEM_FREQUENCIA").ToString()
                If objDataReader("ITEM_PATH_VISUAL").ToString() <> "" Then
                    row("ITEM_PATH_VISUAL1") = "http://mfgsvr2/TPM/VISUAL_1/" & objDataReader("ITEM_PATH_VISUAL").ToString()
                    row("ITEM_PATH_LABEL1") = objDataReader("ITEM_PATH_VISUAL").ToString()
                End If
                If objDataReader("ITEM_PATH_VISUAL_2").ToString() <> "" Then
                    row("ITEM_PATH_VISUAL2") = "http://mfgsvr2/TPM/VISUAL_2/" & objDataReader("ITEM_PATH_VISUAL_2").ToString()
                    row("ITEM_PATH_LABEL2") = objDataReader("ITEM_PATH_VISUAL_2").ToString()
                End If
                row("ULTIMO_CHECKLIST") = objDataReader("DATA_CHECKLIST").ToString()

                If IsDBNull(objDataReader("DATA_CHECKLIST")) Then
                    dt.Rows.Add(row)
                Else
                    If objDataReader("ITEM_FREQUENCIA").ToString() = "TURNO" Then
                        If Turno = 1 Then
                            If Not Convert.ToDateTime(objDataReader("DATA_CHECKLIST")).ToString("yyyy-MM-dd HH:mm:ss") >= Inicio_Turno AndAlso Convert.ToDateTime(objDataReader("DATA_CHECKLIST")).ToString("yyyy-MM-dd HH:mm") <= Fim_Turno Then
                                dt.Rows.Add(row)
                            End If
                        ElseIf Turno = 2 Then
                            If Not Convert.ToDateTime(objDataReader("DATA_CHECKLIST")).ToString("yyyy-MM-dd HH:mm:ss") <= Inicio_Turno AndAlso Convert.ToDateTime(objDataReader("DATA_CHECKLIST")).ToString("yyyy-MM-dd HH:mm") <= Fim_Turno Then
                                dt.Rows.Add(row)
                            End If
                        ElseIf Turno = 3 Then
                            If Not Convert.ToDateTime(objDataReader("DATA_CHECKLIST")).ToString("yyyy-MM-dd HH:mm:ss") >= Inicio_Turno AndAlso Convert.ToDateTime(objDataReader("DATA_CHECKLIST")).ToString("yyyy-MM-dd HH:mm") <= Fim_Turno Then
                                dt.Rows.Add(row)
                            End If
                        End If
                    ElseIf objDataReader("ITEM_FREQUENCIA").ToString() = "DIÁRIO" Then
                        If Not Convert.ToDateTime(objDataReader("DATA_CHECKLIST")).ToString("dd") = DateTime.Now.Day Then
                            dt.Rows.Add(row)
                        End If
                    ElseIf objDataReader("ITEM_FREQUENCIA").ToString() = "SEMANAL" Then
                        Dim dataInicioSemana As DateTime = DateTime.Now.AddDays(-DirectCast(DateTime.Now.DayOfWeek, Integer)).AddDays(-1)
                        Dim dataFimSemana As DateTime = dataInicioSemana.AddDays(7)

                        If Not Convert.ToDateTime(objDataReader("DATA_CHECKLIST")) >= dataInicioSemana AndAlso Convert.ToDateTime(objDataReader("DATA_CHECKLIST")) <= dataFimSemana Then
                            dt.Rows.Add(row)
                        End If
                    ElseIf objDataReader("ITEM_FREQUENCIA").ToString() = "MENSAL" Then
                        If Not Convert.ToDateTime(objDataReader("DATA_CHECKLIST")).ToString("MM") = DateTime.Now.Month Then
                            dt.Rows.Add(row)
                        End If
                    End If
                End If
            End While
            ListaTPM.DataSource = dt
            ListaTPM.DataBind()
        End If
        objDataReader.Close()
        fechabdnew()
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
                PreencherForm()
                objDataReader.Close()
            Catch ex As Exception
                ORDEMP.Text = ex.Message
                mp1.Show()
            End Try
            fechabdnew()
        Else
            ListaTPM.DataSource = Nothing
            ListaTPM.DataBind()
        End If
    End Sub

    Protected Sub btn_salvar_Click(sender As Object, e As EventArgs)
        Dim button As Button = DirectCast(sender, Button)
        Dim row As GridViewRow = DirectCast(button.Parent.Parent, GridViewRow)
        Dim index As Integer = row.RowIndex
        Dim N_TPM As String = ListaTPM.Rows(index).Cells(0).Text

        Dim observacao As String = DirectCast(row.FindControl("txt_obs"), TextBox).Text

        conectabdnew()
        Try
            comandoSQL.CommandText = "INSERT INTO TAB_TPM_LOG (LOG_SEQUENCIA_ITEM, LOG_LINHA, LOG_REG_FUN, LOG_DATA, LOG_OBSERVACAO) VALUES (" & N_TPM & ", " & txt_linha.SelectedItem.Value & ", '" & User.Identity.Name & "', GETDATE(), '" & observacao & "')"
            comandoSQL.ExecuteNonQuery()
            ORDEMP.Text = "Checklist do item N°" & N_TPM & " da TPM da linha " & txt_linha.SelectedItem.Value & " realizado."
            mp1.Show()
        Catch ex As Exception
            ORDEMP.Text = ex.Message
            mp1.Show()
        End Try
        fechabdnew()
        PreencherForm()
    End Sub

End Class
