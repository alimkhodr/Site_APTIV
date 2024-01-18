Imports System.Data.SqlClient
Imports System.IO
Imports Microsoft.Office.Interop.Excel

Public Class Atendimento
    Inherits System.Web.UI.Page
    Public COD_FORM As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '################# BOTÃO DE LOG-OFF #################
        Try
            Dim BTN As System.Web.UI.HtmlControls.HtmlInputSubmit
            Dim reg, VALIDAR As Integer
            BTN = Master.FindControl("CmdSignOut")
            BTN.Value = "SAIR DO REGISTRO: " & User.Identity.Name
            reg = User.Identity.Name
            VALIDAR = ValidarTela(reg, 220)
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
        Dim i As Integer
        If Not IsPostBack Then
            cbom.Items.Add("")
            For i = 0 To 59
                If i < 10 Then
                    cbom.Items.Add("0" & CStr(i))
                Else
                    cbom.Items.Add(CStr(i))
                End If
            Next
            txtdata.Text = DateTime.Now.ToString("dd/MM/yyyy")

            'Preencher a cboregistro com os funcionarios ativos
            conectabdnew()
            cboreg.Items.Add("")
            comandoSQL.CommandText = "Select FUN_Registro from Funcionario WHERE FUN_STATUS = 'ATIVO'  "
            objDataReader = comandoSQL.ExecuteReader
            While objDataReader.Read()
                If objDataReader.HasRows Then
                    cboreg.Items.Add(objDataReader(0))
                End If
            End While
            objDataReader.Close()
            fechabdnew()



            PreencherLblQtd()
            PreencherComboboxMed()
        End If
    End Sub

    'selecionar registro do funcionário e preencher a txtnome, txtcpf, txtidade e cbocargo de acordo com o registro
    Protected Sub cboreg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboreg.SelectedIndexChanged
        conectabdnew()
        comandoSQL.CommandText = "SELECT FUN_NOME, FUN_CR, FUN_TURNO FROM FUNCIONARIO WHERE FUN_REGISTRO = @Registro"
        comandoSQL.Parameters.AddWithValue("@Registro", cboreg.Text)
        objDataReader = comandoSQL.ExecuteReader
        objDataReader.Read()

        If objDataReader.HasRows Then
            txtnome.Text = objDataReader("FUN_NOME").ToString()
            txtarea.Text = objDataReader("FUN_CR").ToString()

            If objDataReader("FUN_TURNO").ToString().IndexOf("JAM-1") >= 0 Then
                txtturno.Text = "PRIMEIRO"
            End If
            If objDataReader("FUN_TURNO").ToString().IndexOf("JAM-2") >= 0 Then
                txtturno.Text = "SEGUNDO"
            End If
            If objDataReader("FUN_TURNO").ToString().IndexOf("JAM-3") >= 0 Then
                txtturno.Text = "TERCEIRO"
            End If
        Else
            txtnome.Text = ""
            txtturno.Text = ""
            txtarea.Text = ""
        End If
        objDataReader.Close()
    End Sub

    'cadastrar medicamentos
    Protected Sub btnaddmed_Click(sender As Object, e As EventArgs) Handles btnaddmed.Click
        If txtmed.Text = "" Then
            ORDEMP.Text = "Medicamento vazio"
            mp1.Show()
        Else
            Try
                conectabdnew()
                comandoSQL.CommandText = "INSERT INTO TAB_MEDICAMENTOS VALUES ('" & txtmed.Text & "') "
                comandoSQL.ExecuteReader()
                fechabdnew()
                PreencherComboboxMed()
                ORDEMP.Text = "Medicamento " & txtmed.Text & " cadastrado com sucesso!"
                mp1.Show()
            Catch ex As Exception
                ORDEMP.Text = "Medicamento " & txtmed.Text & " já cadastrado"
                mp1.Show()
                Exit Sub
            End Try
        End If

    End Sub

    'Preencher cbomed com medicamentos do bd
    Private Sub PreencherComboboxMed()
        cbomed.Items.Clear()
        conectabdnew()
        cbomed.Items.Add("")
        comandoSQL.CommandText = "Select MEDICAMENTO from TAB_MEDICAMENTOS"
        objDataReader = comandoSQL.ExecuteReader
        While objDataReader.Read()
            If objDataReader.HasRows Then
                cbomed.Items.Add(objDataReader(0))
            End If
        End While
        objDataReader.Close()
        fechabdnew()
    End Sub

    'Preencher a lblqtd com a quantidade de IDs cadastrados no banco que a data corresponde a atual
    Private Sub PreencherLblQtd()
        conectabdnew()
        lblqtd.Text = ""
        Dim mesAtual As Integer = DateTime.Now.Month
        comandoSQL.CommandText = "SELECT COUNT(ID) FROM TAB_ATEND WHERE MONTH(DATA) = '" & mesAtual & "' "
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.Read() Then
            lblqtd.Text = objDataReader.GetInt32(0).ToString()
        End If
        objDataReader.Close()
        fechabdnew()
    End Sub

    'Adicionar medicamento ao funcionario
    Protected Sub btnmed_Click(sender As Object, e As EventArgs) Handles btnmed.Click
        Dim MED As String
        Dim i, j, v As Integer
        i = ListaMed.Items.Count
        If i = 15 Then
            ORDEMP.Text = "Lista de medicamento limitado a 15 riscos"
            mp1.Show()
            Exit Sub
        End If
        i = i - 1
        j = 0
        v = 0
        While j <= i
            ListaMed.SelectedIndex = j
            MED = ListaMed.SelectedValue.ToString()
            If MED = cbomed.Text Then
                v = 1
                ORDEMP.Text = "Medicamento " & cbomed.Text & " já adicionado"
                mp1.Show()
                Exit Sub
            End If
            j = j + 1
        End While
        If cbomed.Text <> "" Then
            ListaMed.Items.Add(cbomed.Text)
        End If
    End Sub

    Protected Sub cmddel_Click(sender As Object, e As EventArgs) Handles cmddel.Click
        Dim str As String
        Dim i, j As Integer
        i = ListaMed.Items.Count
        i = i - 1
        j = 0
        While j <= i
            ListaMed.SelectedIndex = j
            str = ListaMed.SelectedValue
            ListaMed.Items.RemoveAt(j)
            ' No need for Exit Sub here
            j = j + 1
        End While
        ORDEMP.Text = "Medicamento apagado"
        mp1.Show()
    End Sub

    'Salvar ATEND
    Protected Sub cmdsalvar_Click(sender As Object, e As EventArgs) Handles cmdsalvar.Click
        Dim hora As String
        If cboh.Text <> "" And cbom.Text <> "" Then
            hora = cboh.Text + ":" + cbom.Text + ":00"
        Else
            hora = ""
        End If

        If cboreg.Text = "" Then
            ORDEMP.Text = "Registro do funcionário não preenchido"
            mp1.Show()
            Exit Sub
        End If

        If txtturno.Text = "" Then
            ORDEMP.Text = "Preencha o turno do funcionário"
            mp1.Show()
            Exit Sub
        End If

        If cboh.Text = "" Then
            ORDEMP.Text = "Hora do Atendimento não preenchida"
            mp1.Show()
            Exit Sub
        End If

        If cbom.Text = "" Then
            ORDEMP.Text = "Minutos do Atendimento não preenchido"
            mp1.Show()
            Exit Sub
        End If

        If txtdesc.Text = "" Then
            ORDEMP.Text = "Descreva a situação"
            mp1.Show()
            Exit Sub
        End If

        If cboconduta.Text = "" Then
            ORDEMP.Text = "Conduta da enfermagem vazia"
            mp1.Show()
            Exit Sub
        End If

        If RbATEN.SelectedValue = 0 Then

            Try
                conectabdnew()
                comandoSQL.CommandText = " SELECT TOP 1 ID FROM TAB_ATEND ORDER BY ID DESC"
                objDataReader = comandoSQL.ExecuteReader
                If objDataReader.Read Then
                    COD_FORM = objDataReader(0) + 1
                Else
                    COD_FORM = 1
                End If
                objDataReader.Close()

                comandoSQL.CommandText = "INSERT INTO TAB_ATEND VALUES ('" & COD_FORM & "','" & cboreg.Text & "','" & hora & "','" & txtbpm.Text & "','" & txtpa.Text & "','" & txttemp.Text & "','" & txtsa.Text & "','" & txtdesc.Text & "','" & cboconduta.Text & "','" & txtobs.Text & "','" & txtdata.Text & "')"
                comandoSQL.ExecuteNonQuery()

                Dim medArray(ListaMed.Items.Count - 1) As String
                For i As Integer = 0 To ListaMed.Items.Count - 1
                    Dim value As String = ListaMed.Items(i).Value
                    medArray(i) = value
                Next

                comandoSQL.CommandText = "INSERT INTO TAB_ATEND_MEDICAMENTOS VALUES (@codForm, @med)"
                For Each med As String In medArray
                    comandoSQL.Parameters.AddWithValue("@codForm", COD_FORM)
                    comandoSQL.Parameters.AddWithValue("@med", med)
                    comandoSQL.ExecuteNonQuery()
                    comandoSQL.Parameters.Clear()
                Next
                PreencherLblQtd()
                ResetForm()
            Catch ex As Exception
                ORDEMP.Text = "Erro!"
                mp1.Show()
                Exit Sub
            End Try
            lblsv.Text = "Atendimento N°" & COD_FORM & " Cadastrado com Sucesso!"
            mp2.Show()
            fechabdnew()
        Else
            Try
                objDataReader.Close()
                conectabdnew()
            comandoSQL.CommandText = "SELECT COUNT(*) FROM TAB_ATEND_MEDICAMENTOS WHERE ID_ATEND = '" & cbonform.Text & "'"
            Dim rowCount As Integer = Convert.ToInt32(comandoSQL.ExecuteScalar())
            If rowCount > 0 Then
                comandoSQL.CommandText = "DELETE FROM TAB_ATEND_MEDICAMENTOS WHERE ID_ATEND = '" & cbonform.Text & "'"
                comandoSQL.ExecuteNonQuery()
                comandoSQL.Parameters.Clear()
            End If
            Dim medArray(ListaMed.Items.Count - 1) As String
            For i As Integer = 0 To ListaMed.Items.Count - 1
                Dim value As String = ListaMed.Items(i).Value
                medArray(i) = value
            Next
            comandoSQL.CommandText = "INSERT INTO TAB_ATEND_MEDICAMENTOS VALUES ('" & cbonform.Text & "',@med)"
            For Each med As String In medArray
                comandoSQL.Parameters.AddWithValue("@med", med)
                comandoSQL.ExecuteNonQuery()
                comandoSQL.Parameters.Clear()
            Next
            comandoSQL.CommandText = "UPDATE TAB_ATEND SET REGISTRO_FUNCIONARIO = '" & cboreg.Text & "', HORA = '" & hora & "', BPM = '" & txtbpm.Text & "', PA = '" & txtpa.Text & "', TEMP = '" & txttemp.Text & "', SAO2 = '" & txtsa.Text & "', DESCRICAO_QUEIXA = '" & txtdesc.Text & "', CONDUTA_ENFERMAGEM = '" & cboconduta.Text & "', OBSERVACAO = '" & txtobs.Text & "', DATA = '" & txtdata.Text & "' WHERE ID = '" & cbonform.Text & "'"
            comandoSQL.ExecuteNonQuery()
            Catch ex As Exception
            ORDEMP.Text = "Erro!"
            mp1.Show()
            Exit Sub
            End Try
            lblsv.Text = "Atendimento N°" & cbonform.Text & " Editado com Sucesso!"
            mp2.Show()
            fechabdnew()
        End If
        ResetForm()
    End Sub

    'Visualizar ATEND
    Protected Sub btnnform_Click(sender As Object, e As EventArgs) Handles btnnform.Click
        conectabdnew()
        comandoSQL.CommandText = "SELECT TOP 1 * FROM TAB_ATEND WHERE ID = '" & Trim(cbonform.Text) & "' ORDER BY DATA DESC"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.HasRows Then
            If objDataReader.Read Then
                cboreg.Text = objDataReader("REGISTRO_FUNCIONARIO").ToString()
                txtbpm.Text = objDataReader("BPM").ToString()
                txtpa.Text = objDataReader("PA").ToString()
                txttemp.Text = objDataReader("TEMP").ToString()
                txtsa.Text = objDataReader("SAO2").ToString()
                txtdesc.Text = objDataReader("DESCRICAO_QUEIXA").ToString()
                cboconduta.Text = objDataReader("CONDUTA_ENFERMAGEM").ToString()
                txtobs.Text = objDataReader("OBSERVACAO").ToString()
                txtdata.Text = objDataReader("DATA").ToString()

                Dim tempo As String = objDataReader("HORA").ToString()
                Dim partes() As String = tempo.Split(":"c)
                Dim hora As String = partes(0)
                Dim minuto As String = partes(1)
                cboh.Text = hora
                cbom.Text = minuto

            End If
            objDataReader.Close()

            comandoSQL.CommandText = "SELECT ID_ATEND, NOME_MED FROM TAB_ATEND_MEDICAMENTOS WHERE ID_ATEND = '" & Trim(cbonform.Text) & "' "
            objDataReader = comandoSQL.ExecuteReader
            ListaMed.Items.Clear()
            While objDataReader.Read
                ListaMed.Items.Add(objDataReader("NOME_MED").ToString())
            End While
            objDataReader.Close()

            comandoSQL.CommandText = "SELECT FUN_Nome,FUN_Turno, FUN_CR FROM Funcionario WHERE FUN_REGISTRO = (SELECT REGISTRO_FUNCIONARIO FROM TAB_ATEND WHERE ID = '" & Trim(cbonform.Text) & "')"
            objDataReader = comandoSQL.ExecuteReader
            If objDataReader.Read Then
                txtnome.Text = objDataReader("FUN_NOME").ToString()
                txtarea.Text = objDataReader("FUN_CR").ToString()
                If objDataReader("FUN_TURNO").ToString().IndexOf("JAM-1") >= 0 Then
                    txtturno.Text = "PRIMEIRO"
                End If
                If objDataReader("FUN_TURNO").ToString().IndexOf("JAM-2") >= 0 Then
                    txtturno.Text = "SEGUNDO"
                End If
                If objDataReader("FUN_TURNO").ToString().IndexOf("JAM-3") >= 0 Then
                    txtturno.Text = "TERCEIRO"
                End If
            End If
            COD_FORM = cbonform.Text
        Else
            ORDEMP.Text = "Formulário " & cbonform.Text & " Não Encontrado"
            mp1.Show()
        End If
        fechabdnew()
    End Sub

    'Preencher cboformreg/Registro e cbonform/Atendimentos cadastrados na tabela atend para filtrar e procurar atendimentos
    Private Sub PreencherComboboxNform()
        cbonform.Items.Clear()
        cboformreg.Items.Clear()

        conectabdnew()
        cbonform.Items.Add("")
        comandoSQL.CommandText = "Select ID from TAB_ATEND"
        objDataReader = comandoSQL.ExecuteReader
        While objDataReader.Read()
            If objDataReader.HasRows Then
                cbonform.Items.Add(objDataReader(0))
            End If
        End While
        objDataReader.Close()
        fechabdnew()
        conectabdnew()
        cboformreg.Items.Add("")
        comandoSQL.CommandText = "SELECT REGISTRO_FUNCIONARIO FROM TAB_ATEND ORDER BY REGISTRO_FUNCIONARIO"
        objDataReader = comandoSQL.ExecuteReader
        Dim valoresUnicos As New HashSet(Of String)()
        While objDataReader.Read()
            If objDataReader.HasRows Then
                Dim valor As String = objDataReader(0).ToString()
                If Not valoresUnicos.Contains(valor) Then
                    cboformreg.Items.Add(valor)
                    valoresUnicos.Add(valor)
                End If
            End If
        End While
        objDataReader.Close()
        fechabdnew()
    End Sub

    'Resetar Form
    Private Sub ResetForm()
        cboreg.Text = ""
        txtnome.Text = ""
        txtmed.Text = ""
        txtarea.Text = ""
        txtturno.Text = ""
        cboh.Text = ""
        cbom.Text = ""
        txtpa.Text = ""
        txtbpm.Text = ""
        txttemp.Text = ""
        txtsa.Text = ""
        txtdesc.Text = ""
        cboconduta.Text = ""
        txtobs.Text = ""
        cbomed.Text = ""
        ListaMed.Items.Clear()
        txtdata.Text = DateTime.Now.ToString("dd/MM/yyyy")
    End Sub

    'RadioButton NovoATEND/visualizarATEND
    Protected Sub RbATEN_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RbATEN.SelectedIndexChanged
        If RbATEN.SelectedValue = 1 Then
            cbonform.Enabled = True
            cboformreg.Enabled = True
            btnnform.Enabled = True

            PreencherComboboxNform()
            ResetForm()
        Else
            cbonform.Enabled = False
            cboformreg.Enabled = False
            btnnform.Enabled = False
            cboformreg.Items.Clear()
            cbonform.Items.Clear()
            ResetForm()
        End If
    End Sub

    'Filtrar ID de Atendimentos pelo registro do funcionario
    Protected Sub cboformreg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboformreg.SelectedIndexChanged
        cbonform.Items.Clear()
        conectabdnew()
        comandoSQL.CommandText = "SELECT ID FROM TAB_ATEND WHERE REGISTRO_FUNCIONARIO = @Registro"
        comandoSQL.Parameters.AddWithValue("@Registro", cboformreg.Text)
        objDataReader = comandoSQL.ExecuteReader
        While objDataReader.Read()
            cbonform.Items.Add(objDataReader(0))
        End While
        If cbonform.Items.Count > 0 Then
            cbonform.SelectedIndex = 0
        End If
        If cbonform.Text = "" Then
            PreencherComboboxNform()
        End If
        objDataReader.Close()
    End Sub
End Class