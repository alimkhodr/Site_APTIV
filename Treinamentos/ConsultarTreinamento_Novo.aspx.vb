Imports System.Data.SqlClient
Imports System.Data
Imports System.IO

Public Class ConsultarTreinamento_Novo
    Inherits System.Web.UI.Page
    Public COD_FORM As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '########## BOTÃO DE LOG-OFF ########################
        Try
            Dim BTN As System.Web.UI.HtmlControls.HtmlInputSubmit
            Dim reg, VALIDAR As Integer
            BTN = Master.FindControl("CmdSignOut")
            BTN.Value = "SAIR DO REGISTRO: " & User.Identity.Name
            reg = User.Identity.Name
            VALIDAR = ValidarTela(reg, 308)
            If VALIDAR = 1 Then
                Response.Redirect("~/SGM.aspx")
                CType(Master.FindControl("Label16"), Label).ForeColor = Drawing.Color.Red
                CType(Master.FindControl("mp6"), AjaxControlToolkit.ModalPopupExtender).Show()
            End If
        Catch ex As Exception
            Response.Redirect("~/Logon.aspx")
        End Try
        '####################################################
    End Sub

    'Procurar formulário
    Protected Sub btn_proc_Click(sender As Object, e As EventArgs) Handles btn_proc.Click
        If Trim(txtnform.Text) <> "" Then
            conectabdnew()
            comandoSQL.CommandText = "SELECT * FROM TAB_TREINAMENTO_FORMULARIO WHERE FORM_ID = " & Trim(txtnform.Text)
            objDataReader = comandoSQL.ExecuteReader
            If objDataReader.HasRows Then
                If objDataReader.Read Then
                    txt_nomet.Text = objDataReader("FORM_NOME_TREINADOR").ToString()
                    If objDataReader("FORM_REGISTRO_TREINADOR") = 0 Then
                        txt_regt.Text = ""
                        Chkexterno.Checked = True
                    Else
                        txt_regt.Text = objDataReader("FORM_REGISTRO_TREINADOR").ToString
                        Chkexterno.Checked = False
                    End If


                    txt_treino.Text = objDataReader("FORM_TREINAMENTO").ToString()
                    txt_subtitulo.Text = objDataReader("FORM_SUB_TITULO").ToString()
                    txt_data.Text = Convert.ToDateTime(objDataReader("FORM_DATA_INICIO")).ToString("dd/MM/yyyy")
                    txt_horai.Text = Convert.ToDateTime(objDataReader("FORM_DATA_INICIO")).ToString("HH:mm")
                    txt_horaf.Text = Convert.ToDateTime(objDataReader("FORM_DATA_FIM")).ToString("HH:mm")
                    txt_assunto.Text = objDataReader("FORM_ASSUNTO").ToString()
                    txt_local.Text = objDataReader("FORM_LOCAL").ToString()
                    txt_tipo.Text = objDataReader("FORM_TIPO").ToString()

                    If objDataReader("FORM_DOCUMENTO") IsNot Nothing AndAlso Not String.IsNullOrEmpty(objDataReader("FORM_DOCUMENTO").ToString()) Then
                        Dim pdfPath As String = "http://mfgsvr2/Treinamentos/" & objDataReader("FORM_DOCUMENTO").ToString()
                        pdfPreview.Attributes("src") = "about:blank"
                        pdfPreview.Attributes("src") = pdfPath
                    Else
                        pdfPreview.Attributes("src") = ""
                    End If
                End If
                objDataReader.Close()

                Lista.DataSource = Nothing ' Limpar os dados existentes na GridView
                Lista.DataBind() ' Atualizar a exibição
                comandoSQL.CommandText = "SELECT FTRE_REGISTRO, FUN_NOME FROM TAB_TREINAMENTO_FUNCIONARIO INNER JOIN FUNCIONARIO ON FUN_REGISTRO = FTRE_REGISTRO  WHERE FTRE_FORM = " & Trim(txtnform.Text)
                objDataReader = comandoSQL.ExecuteReader
                If objDataReader.HasRows Then
                    Dim dt As New DataTable()
                    dt.Columns.Add("FTRE_REGISTRO", GetType(Integer))
                    dt.Columns.Add("FUN_NOME", GetType(String))
                    While objDataReader.Read()
                        Dim row As DataRow = dt.NewRow()
                        row("FTRE_REGISTRO") = objDataReader("FTRE_REGISTRO")
                        row("FUN_NOME") = objDataReader("FUN_NOME")
                        dt.Rows.Add(row)
                    End While
                    COD_FORM = txtnform.Text
                    Lista.DataSource = dt
                    Lista.DataBind()
                End If
                objDataReader.Close()
            Else
                ORDEMP.Text = "Formulário " & txtnform.Text & " Não Encontrado"
                mp1.Show()
                ResetForm()
            End If
            fechabdnew()
        Else
            ResetForm()
        End If
    End Sub

    'resetar
    Private Sub ResetForm()
        txt_data.Text = ""
        txt_horai.Text = ""
        txt_horaf.Text = ""
        txt_subtitulo.Text = ""
        txt_local.Text = ""
        txt_treino.Text = ""
        txt_tipo.Text = ""
        txt_assunto.Text = ""
        txt_regt.Text = ""
        txt_nomet.Text = ""
        '''''''''''''''''''''''''''''''
        Lista.DataSource = Nothing
        Lista.DataBind()
        dt_lista.Clear()
        '''''''''''''''''''''''''''''''
        pdfPreview.Attributes("src") = ""
        '''''''''''''''''''''''''''''''
        Chkexterno.Checked = False
        '''''''''''''''''''''''''''''''
    End Sub

    Protected Sub cmdimprimir_Click(sender As Object, e As EventArgs) Handles cmdimprimir.Click
        Dim i As Integer = 0
        Dim RegistroLista As Integer

        Modulo.nometreinamento = txt_treino.Text & " - " & txt_subtitulo.Text
        Modulo.nometreinador = txt_nomet.Text
        Select Case txt_tipo.Text
            Case "Técnico"
                Modulo.grupo = 1
            Case "Qualidade"
                Modulo.grupo = 2
            Case "Comportamental"
                Modulo.grupo = 3
            Case "Segurança/Meio Ambiente"
                Modulo.grupo = 4
        End Select
        Select Case txt_assunto.Text
            Case "Integração"
                Modulo.assunto = 0
            Case "Reciclagem"
                Modulo.assunto = 1
            Case "Treinamento"
                Modulo.assunto = 2
            Case "Diálogo/Reunião"
                Modulo.assunto = 3
            Case "Kaizen"
                Modulo.assunto = 4
            Case "Workshop"
                Modulo.assunto = 5
            Case "Feiras/Visitas"
                Modulo.assunto = 6
            Case "Normas/Procedimentos"
                Modulo.assunto = 7
            Case "Outros"
                Modulo.assunto = 8
        End Select
        Modulo.localt = txt_local.Text
        Modulo.nformulario = txtnform.Text
        Modulo.hi = txt_horai.Text
        Modulo.hf = txt_horaf.Text
        Modulo.datat = txt_data.Text
        If Chkexterno.Checked = True Then
            Modulo.externo = 0
        Else
            Modulo.externo = 1
        End If

        For i = 0 To Lista.Rows.Count - 1
            RegistroLista = Lista.Rows(i).Cells(0).Text
            regpe(i) = RegistroLista
            ver_turno(RegistroLista, i)
            nomep(i) = Lista.Rows(i).Cells(1).Text
        Next
        npessoas = i - 1

        Response.Redirect("ImprimirTreinamento.aspx")
    End Sub
    Public Sub ver_turno(ByVal REGISTRO As Integer, ByVal I As Integer)
        conectabdnew()
        comandoSQL.CommandText = "Select TOP 1 FUN_TURNO from FUNCIONARIO where FUN_REGISTRO = '" & REGISTRO & "' "
        objDataReader = comandoSQL.ExecuteReader
        objDataReader.Read()
        Try
            Select Case objDataReader(0)
                Case "JAM-000 | 06h55as16h43 | SegSex |T*|_P16", "JAM-001 | 07h43as16h43 | SegSex |T*|_P16", "JAM-100 | 06h55as16h43 | SegSex |T1|_P16", "JAM-101 | 07h30as16h30 | SegSex |T1|_P16", "JAM-102 | 07h43as16h43 | SegSex |T1|_P16", "JAM-103 | 08h00as12h00 | SegSex |T1|_P16", "JAM-105 | 07h00as16h33 | SegSex |T1|_P16", "JAM-106 | 06h55as16h43 | QuaDom |T1|_P16", "JAM-400 | 06h55as16h43 | SegSex |TE|_P16", "JAM-500 | 06h55as16h43 | SegSex |TA|_P16 "
                    Modulo.turno(I) = 1
                Case "JAM-200 | 16h33as01h51 | SegSex |T2|_P16", "JAM-201 | 16h33as01h51 | QuaDom |T2|_P16", "JAM-203 | 13h00as22h33 | SegSex |T2|_P16"
                    Modulo.turno(I) = 2
                Case "JAM-300 | 22h07as07h05 | SegSex |T3|_P16", "JAM-301 | 22h07as07h05 | QuaDom |T3|_P16"
                    Modulo.turno(I) = 3
            End Select
        Catch ex As Exception
            Modulo.turno(I) = 0
        End Try
    End Sub
End Class