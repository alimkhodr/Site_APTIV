Public Class Atestado
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
            VALIDAR = ValidarTela(reg, 222)
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
            PreencherComboboxMed()
        End If
    End Sub

    'aDICIONAR MEDICO NO BD
    Protected Sub btnaddmed_Click(sender As Object, e As EventArgs) Handles btnaddmed.Click
        If txtmed.Text = "" Then
            ORDEMP.Text = "Médico não preenchido vazio"
            mp1.Show()
        Else
            Try
                conectabdnew()
                comandoSQL.CommandText = "insert into TAB_ENFERMARIA_MEDICO (NOME,CRM) VALUES ('" & txtmed.Text & "','" & txtaddcrm.Text & "')"
            comandoSQL.ExecuteReader()
                fechabdnew()
                PreencherComboboxMed()
                ORDEMP.Text = "Médico " & txtmed.Text & " cadastrado com sucesso!"
                mp1.Show()
            Catch ex As Exception
            ORDEMP.Text = "Médico " & txtmed.Text & " já cadastrado"
            mp1.Show()
            Exit Sub
            End Try
        End If
    End Sub

    'Preencher cbomed com medicos do bd
    Private Sub PreencherComboboxMed()
        cbomed.Items.Clear()
        conectabdnew()
        cbomed.Items.Add("")
        comandoSQL.CommandText = "Select NOME from TAB_ENFERMARIA_MEDICO"
        objDataReader = comandoSQL.ExecuteReader
        While objDataReader.Read()
            If objDataReader.HasRows Then
                cbomed.Items.Add(objDataReader(0))
            End If
        End While
        objDataReader.Close()
        fechabdnew()
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


    Protected Sub cbomed_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbomed.SelectedIndexChanged
        conectabdnew()
        comandoSQL.CommandText = "SELECT CRM FROM TAB_ENFERMARIA_MEDICO WHERE NOME = @NOME"
        comandoSQL.Parameters.AddWithValue("@NOME", cbomed.Text)
        objDataReader = comandoSQL.ExecuteReader
        objDataReader.Read()

        If objDataReader.HasRows Then
            txtcrm.Text = objDataReader("CRM").ToString()
        Else
            txtcrm.Text = ""
        End If
        objDataReader.Close()
    End Sub

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

        If txtdata.Text = "" Then
            ORDEMP.Text = "Data não preechida"
            mp1.Show()
            Exit Sub
        End If

        If txtcid.Text = "" Then
            ORDEMP.Text = "CID não preechido"
            mp1.Show()
            Exit Sub
        End If

        If cbocid.Text = "" Then
            ORDEMP.Text = "CID não especificado"
            mp1.Show()
            Exit Sub
        End If

        If cbomed.Text = "" Then
            ORDEMP.Text = "Medico não selecionado"
            mp1.Show()
            Exit Sub
        End If

        If RbATEN.SelectedValue = 0 Then
            Try
                conectabdnew()
                comandoSQL.CommandText = " SELECT TOP 1 ID FROM TAB_ENFERMARIA_ATESTADOS ORDER BY ID DESC"
                objDataReader = comandoSQL.ExecuteReader
                If objDataReader.Read Then
                    COD_FORM = objDataReader(0) + 1
                Else
                    COD_FORM = 1
                End If
                objDataReader.Close()
                comandoSQL.CommandText = "INSERT INTO TAB_ENFERMARIA_ATESTADOS VALUES ('" & COD_FORM & "','" & cboreg.Text & "','" & txtdata.Text & "','" & txtdias.Text & "','" & hora & "','" & txtcid.Text & "','" & cbocid.Text & "','" & txtcrm.Text & "')"
                comandoSQL.ExecuteNonQuery()
            Catch ex As Exception
                ORDEMP.Text = "Erro!"
                mp1.Show()
                Exit Sub
                fechabdnew()
            End Try
            lblsv.Text = "Atestado N°" & COD_FORM & " Cadastrado com Sucesso!"
            mp2.Show()
        Else
            conectabdnew()
            objDataReader.Close()
            comandoSQL.CommandText = "UPDATE TAB_ENFERMARIA_ATESTADOS SET REGISTRO = '" & cboreg.Text & "', DATA = '" & txtdata.Text & "', DIAS = '" & txtdias.Text & "', HORAS = '" & hora & "', CID = '" & txtcid.Text & "', ESPECIFICACOES_CID = '" & cbocid.Text & "', CRM = '" & txtcrm.Text & "' WHERE ID = '" & cbonform.Text & "'"
            comandoSQL.ExecuteNonQuery()
            objDataReader.Close()
            lblsv.Text = "Atestado N°" & cbonform.Text & " Editado com Sucesso!"
            mp2.Show()
            fechabdnew()
        End If
        ResetForm()
    End Sub

    Private Sub ResetForm()
        cboreg.Text = ""
        txtnome.Text = ""
        txtarea.Text = ""
        txtturno.Text = ""
        txtmed.Text = ""
        txtcrm.Text = ""
        txtcid.Text = ""
        cbocid.Text = ""
        cbomed.Text = ""
        txtaddcrm.Text = ""
        cboh.Text = ""
        cbom.Text = ""
        txtdias.Text = ""
        txtdata.Text = DateTime.Now.ToString("dd/MM/yyyy")
    End Sub

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

    'Filtrar ID de atestaado pelo registro do funcionario
    Protected Sub cboformreg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboformreg.SelectedIndexChanged
        cbonform.Items.Clear()
        conectabdnew()
        comandoSQL.CommandText = "SELECT ID FROM TAB_ENFERMARIA_ATESTADOS WHERE REGISTRO = @Registro"
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

    'Preencher cboformreg/Registro e cbonform/atestados cadastrados na tabela atestados para filtrar e procurar atestados
    Private Sub PreencherComboboxNform()
        cbonform.Items.Clear()
        cboformreg.Items.Clear()

        conectabdnew()
        cbonform.Items.Add("")
        comandoSQL.CommandText = "Select ID from TAB_ENFERMARIA_ATESTADOS"
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
        comandoSQL.CommandText = "SELECT REGISTRO FROM TAB_ENFERMARIA_ATESTADOS ORDER BY REGISTRO"
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

    Protected Sub btnnform_Click(sender As Object, e As EventArgs) Handles btnnform.Click
        conectabdnew()
        comandoSQL.CommandText = "SELECT TOP 1 * FROM TAB_ENFERMARIA_ATESTADOS WHERE ID = '" & Trim(cbonform.Text) & "' ORDER BY DATA DESC"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.HasRows Then
            If objDataReader.Read Then
                cboreg.Text = objDataReader("REGISTRO").ToString()
                Dim data As DateTime = Convert.ToDateTime(objDataReader("DATA"))
                txtdata.Text = data.ToString("dd/MM/yyyy")
                txtdias.Text = objDataReader("DIAS").ToString()
                txtcid.Text = objDataReader("CID").ToString()
                cbocid.Text = objDataReader("ESPECIFICACOES_CID").ToString()
                txtcrm.Text = objDataReader("CRM").ToString()

                If objDataReader("HORAS").ToString() <> "" Then
                    Dim tempo As String = objDataReader("HORAS").ToString()
                    Dim partes() As String = tempo.Split(":"c)
                    Dim hora As String = partes(0)
                    Dim minuto As String = partes(1)
                    cboh.Text = hora
                    cbom.Text = minuto
                Else
                    cboh.Text = ""
                    cbom.Text = ""
                End If
            End If
            objDataReader.Close()
            comandoSQL.CommandText = "SELECT FUN_Nome,FUN_Turno, FUN_CR FROM Funcionario WHERE FUN_REGISTRO = (SELECT REGISTRO FROM TAB_ENFERMARIA_ATESTADOS WHERE ID = '" & Trim(cbonform.Text) & "')"
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
            objDataReader.Close()
            comandoSQL.CommandText = "SELECT NOME FROM TAB_ENFERMARIA_MEDICO WHERE CRM = (SELECT CRM FROM TAB_ENFERMARIA_ATESTADOS WHERE ID = '" & Trim(cbonform.Text) & "')"
            objDataReader = comandoSQL.ExecuteReader
            If objDataReader.Read Then
                cbomed.Text = objDataReader("NOME").ToString()
            End If
            COD_FORM = cbonform.Text
        Else
            ORDEMP.Text = "Formulário " & cbonform.Text & " Não Encontrado"
            mp1.Show()
        End If
        fechabdnew()
    End Sub
End Class