Imports System.Data.SqlClient
Imports System.Data
Imports System.Drawing.Printing
Imports System.Drawing
Imports System.Windows.Forms

Public Class Atestado_Saude
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
            VALIDAR = ValidarTela(reg, 221)
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
            'Preencher a cbocargo com os cargos
            conectabdnew()
            txtfuncao.Items.Add("")
            comandoSQL.CommandText = "SELECT fun_funcao FROM Funcionario WHERE fun_funcao IS NOT NULL AND fun_funcao <> '' ORDER BY fun_funcao ASC"
            objDataReader = comandoSQL.ExecuteReader
            While objDataReader.Read()
                If objDataReader.HasRows Then
                    txtfuncao.Items.Add(objDataReader("fun_funcao").ToString())
                End If
            End While
            objDataReader.Close()
            fechabdnew()
        End If
    End Sub

    'selecionar registro do funcionário e preencher a txtnome, txtcpf, txtidade e cbocargo de acordo com o registro
    Protected Sub cboreg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboreg.SelectedIndexChanged
        conectabdnew()
        comandoSQL.CommandText = "SELECT FUN_Nome, FUN_CPF, FUN_DATA_NASC, fun_funcao, fun_cr FROM Funcionario WHERE FUN_REGISTRO = @Registro"
        comandoSQL.Parameters.AddWithValue("@Registro", cboreg.Text)
        objDataReader = comandoSQL.ExecuteReader
        objDataReader.Read()

        If objDataReader.HasRows Then
            txtnome.Text = objDataReader("FUN_NOME").ToString()
            txtcpf.Text = objDataReader("FUN_CPF").ToString()
            txtfuncao.Text = objDataReader("fun_funcao").ToString()
            txtarea.Text = objDataReader("fun_cr").ToString()

            Dim dataNascimento As DateTime = Convert.ToDateTime(objDataReader("FUN_DATA_NASC"))
            Dim idade As Integer = CalcularIdade(dataNascimento)
            txtidade.Text = idade.ToString()
        Else
            txtnome.Text = ""
            txtcpf.Text = ""
            txtidade.Text = ""
            txtfuncao.Text = ""
            txtarea.Text = ""
        End If
        objDataReader.Close()
        fechabdnew()
    End Sub

    'calcular a idade
    Private Function CalcularIdade(ByVal dataNascimento As DateTime) As Integer
        Dim idade As Integer = DateTime.Now.Year - dataNascimento.Year
        If DateTime.Now < dataNascimento.AddYears(idade) Then
            idade -= 1
        End If
        Return idade
    End Function

    'salvar/Imprimir ASO
    Protected Sub cmdsalvar_Click(sender As Object, e As EventArgs) Handles cmdsalvar.Click
        Modulo.tipoaso = cbotipo.Text
        Modulo.regaso = cboreg.Text
        Modulo.nomeaso = txtnome.Text
        Modulo.cpfaso = txtcpf.Text
        Modulo.idadeaso = txtidade.Text
        Modulo.dataaso = txtdata.Text
        Modulo.consideradoaso = rbconsiderado.SelectedValue
        Modulo.funcaoaso = txtfuncao.Text
        Modulo.obsaso = txtobs.Text
        Modulo.areaaso = txtarea.Text

        If cbagef.Checked Then
            Modulo.cbagef = cbagef.Text
        End If

        If cbageb.Checked Then
            Modulo.cbageb = cbageb.Text
        End If

        If cbaci.Checked Then
            Modulo.cbaci = cbaci.Text
        End If

        If cbageq.Checked Then
            Modulo.cbageq = cbageq.Text
        End If

        If cberg.Checked Then
            Modulo.cberg = cberg.Text
        End If

        If cbausrisc.Checked Then
            Modulo.cbausrisc = cbausrisc.Text
        End If

        If cblab.Checked AndAlso datalab.Text <> "" Then
            Modulo.cblab = cblab.Text
            Modulo.datalab = datalab.Text
        End If

        If cbtox.Checked AndAlso datatox.Text <> "" Then
            Modulo.cbtox = cbtox.Text
            Modulo.datatox = datatox.Text
        End If

        If cbeeg.Checked AndAlso dataeeg.Text <> "" Then
            Modulo.cbeeg = cbeeg.Text
            Modulo.dataeeg = dataeeg.Text
        End If

        If cbecg.Checked AndAlso dataecg.Text <> "" Then
            Modulo.cbecg = cbecg.Text
            Modulo.dataecg = dataecg.Text
        End If

        If cboutros.Checked Then
            Modulo.txtoutros = txtoutros.Text
        End If

        If cbradio.Checked AndAlso dataradio.Text <> "" Then
            Modulo.cbradio = cbradio.Text
            Modulo.dataradio = dataradio.Text
        End If

        If cbespiro.Checked AndAlso dataespiro.Text <> "" Then
            Modulo.cbespiro = cbespiro.Text
            Modulo.dataespiro = dataespiro.Text
        End If

        If cbacui.Checked AndAlso dataacui.Text <> "" Then
            Modulo.cbacui = cbacui.Text
            Modulo.dataacui = dataacui.Text
        End If

        If cbaudio.Checked AndAlso dataaudio.Text <> "" Then
            Modulo.cbaudio = cbaudio.Text
            Modulo.dataaudio = dataaudio.Text
        End If

        If cbotipo.Text = "" Then
            ORDEMP.Text = "Selecione o tipo de exame"
            mp1.Show()
            Exit Sub
        End If

        If cboreg.Text = "" Then
            ORDEMP.Text = "Registro do funcionário não preenchido"
            mp1.Show()
            Exit Sub
        End If

        If rbconsiderado.SelectedValue = "" Then
            ORDEMP.Text = "Funcionário aptito ou inapto?"
            mp1.Show()
            Exit Sub
        End If

        If txtfuncao.Text = "" Then
            ORDEMP.Text = "Preencha a função do funcionário"
            mp1.Show()
            Exit Sub
        End If

        If txtarea.Text = "" Then
            ORDEMP.Text = "Preencha a área do funcionário"
            mp1.Show()
            Exit Sub
        End If

        If Rbaso.SelectedValue = 0 Then
            conectabdnew()
            comandoSQL.CommandText = "SELECT TOP 1 ID FROM TAB_ASO ORDER BY ID DESC"
            objDataReader = comandoSQL.ExecuteReader()
            If objDataReader.Read Then
                COD_FORM = objDataReader(0) + 1
            Else
                COD_FORM = 1
            End If
            objDataReader.Close()
            comandoSQL.Parameters.Clear()

            comandoSQL.CommandText = "INSERT INTO TAB_ASO VALUES (@COD_FORM, @cbotipo, @cboreg, @RBSELECIONADO, @txtobs, @txtdata)"
            comandoSQL.Parameters.AddWithValue("@COD_FORM", COD_FORM)
            comandoSQL.Parameters.AddWithValue("@cbotipo", cbotipo.Text)
            comandoSQL.Parameters.AddWithValue("@cboreg", cboreg.Text)
            comandoSQL.Parameters.AddWithValue("@RBSELECIONADO", rbconsiderado.SelectedValue)
            comandoSQL.Parameters.AddWithValue("@txtobs", txtobs.Text)
            comandoSQL.Parameters.AddWithValue("@txtdata", txtdata.Text)
            comandoSQL.ExecuteNonQuery()

            If cbagef.Checked Then
                comandoSQL.CommandText = "INSERT INTO TAB_ASO_RISCO VALUES (@codForm, @cbagef)"
                comandoSQL.Parameters.AddWithValue("@codForm", COD_FORM)
                comandoSQL.Parameters.AddWithValue("@cbagef", cbagef.Text)
                comandoSQL.ExecuteNonQuery()
                comandoSQL.Parameters.Clear()
            End If

            If cbageb.Checked Then
                comandoSQL.CommandText = "INSERT INTO TAB_ASO_RISCO VALUES (@codForm, @cbageb)"
                comandoSQL.Parameters.AddWithValue("@codForm", COD_FORM)
                comandoSQL.Parameters.AddWithValue("@cbageb", cbageb.Text)
                comandoSQL.ExecuteNonQuery()
                comandoSQL.Parameters.Clear()
            End If

            If cbageq.Checked Then
                comandoSQL.CommandText = "INSERT INTO TAB_ASO_RISCO VALUES (@codForm, @cbageq)"
                comandoSQL.Parameters.AddWithValue("@codForm", COD_FORM)
                comandoSQL.Parameters.AddWithValue("@cbageq", cbageq.Text)
                comandoSQL.ExecuteNonQuery()
                comandoSQL.Parameters.Clear()
            End If

            If cberg.Checked Then
                comandoSQL.CommandText = "INSERT INTO TAB_ASO_RISCO VALUES (@codForm, @cberg)"
                comandoSQL.Parameters.AddWithValue("@codForm", COD_FORM)
                comandoSQL.Parameters.AddWithValue("@cberg", cberg.Text)
                comandoSQL.ExecuteNonQuery()
                comandoSQL.Parameters.Clear()
            End If

            If cbausrisc.Checked Then
                comandoSQL.CommandText = "INSERT INTO TAB_ASO_RISCO VALUES (@codForm, @cbausrisc)"
                comandoSQL.Parameters.AddWithValue("@codForm", COD_FORM)
                comandoSQL.Parameters.AddWithValue("@cbausrisc", cbausrisc.Text)
                comandoSQL.ExecuteNonQuery()
                comandoSQL.Parameters.Clear()
            End If

            If cbaci.Checked Then
                comandoSQL.CommandText = "INSERT INTO TAB_ASO_RISCO VALUES (@codForm, @cbaci)"
                comandoSQL.Parameters.AddWithValue("@codForm", COD_FORM)
                comandoSQL.Parameters.AddWithValue("@cbaci", cbaci.Text)
                comandoSQL.ExecuteNonQuery()
                comandoSQL.Parameters.Clear()
            End If

            If cblab.Checked Then
                If datalab.Text = "" Then
                    ORDEMP.Text = "Preencha a data do exame"
                    mp1.Show()
                    Exit Sub
                End If
                comandoSQL.CommandText = "INSERT INTO TAB_ASO_EXAME VALUES (@codForm, @cblab, @datalab)"
                comandoSQL.Parameters.AddWithValue("@codForm", COD_FORM)
                comandoSQL.Parameters.AddWithValue("@cblab", cblab.Text)
                comandoSQL.Parameters.AddWithValue("@datalab", datalab.Text)
                comandoSQL.ExecuteNonQuery()
                comandoSQL.Parameters.Clear()
            End If

            If cbtox.Checked Then
                If datatox.Text = "" Then
                    ORDEMP.Text = "Preencha a data do exame"
                    mp1.Show()
                    Exit Sub
                End If
                comandoSQL.CommandText = "INSERT INTO TAB_ASO_EXAME VALUES (@codForm, @cbtox, @datatox)"
                comandoSQL.Parameters.AddWithValue("@codForm", COD_FORM)
                comandoSQL.Parameters.AddWithValue("@cbtox", cbtox.Text)
                comandoSQL.Parameters.AddWithValue("@datatox", datatox.Text)
                objDataReader = comandoSQL.ExecuteReader
                objDataReader.Close()
                comandoSQL.Parameters.Clear()
            End If

            If cbeeg.Checked Then
                If dataeeg.Text = "" Then
                    ORDEMP.Text = "Preencha a data do exame"
                    mp1.Show()
                    Exit Sub
                End If
                comandoSQL.CommandText = "INSERT INTO TAB_ASO_EXAME VALUES (@codForm, @cbeeg, @dataeeg)"
                comandoSQL.Parameters.AddWithValue("@codForm", COD_FORM)
                comandoSQL.Parameters.AddWithValue("@cbeeg", cbeeg.Text)
                comandoSQL.Parameters.AddWithValue("@dataeeg", dataeeg.Text)
                objDataReader = comandoSQL.ExecuteReader
                objDataReader.Close()
                comandoSQL.Parameters.Clear()
            End If

            If cbecg.Checked Then
                If dataecg.Text = "" Then
                    ORDEMP.Text = "Preencha a data do exame"
                    mp1.Show()
                    Exit Sub
                End If
                comandoSQL.CommandText = "INSERT INTO TAB_ASO_EXAME VALUES (@codForm, @cbecg, @dataecg)"
                comandoSQL.Parameters.AddWithValue("@codForm", COD_FORM)
                comandoSQL.Parameters.AddWithValue("@cbecg", cbecg.Text)
                comandoSQL.Parameters.AddWithValue("@dataecg", dataecg.Text)
                objDataReader = comandoSQL.ExecuteReader
                objDataReader.Close()
                comandoSQL.Parameters.Clear()
            End If

            If cboutros.Checked Then
                If txtoutros.Text = "" Then
                    ORDEMP.Text = "Preencha o exame"
                    mp1.Show()
                    Exit Sub
                End If
                comandoSQL.CommandText = "INSERT INTO TAB_ASO_EXAME VALUES (@codForm, @txtoutros, NULL)"
                comandoSQL.Parameters.AddWithValue("@codForm", COD_FORM)
                comandoSQL.Parameters.AddWithValue("@txtoutros", txtoutros.Text)
                objDataReader = comandoSQL.ExecuteReader
                objDataReader.Close()
                comandoSQL.Parameters.Clear()
            End If

            If cbradio.Checked Then
                If dataradio.Text = "" Then
                    ORDEMP.Text = "Preencha a data do exame"
                    mp1.Show()
                    Exit Sub
                End If
                comandoSQL.CommandText = "INSERT INTO TAB_ASO_EXAME VALUES (@codForm, @cbradio, @dataradio)"
                comandoSQL.Parameters.AddWithValue("@codForm", COD_FORM)
                comandoSQL.Parameters.AddWithValue("@cbradio", cbradio.Text)
                comandoSQL.Parameters.AddWithValue("@dataradio", dataradio.Text)
                objDataReader = comandoSQL.ExecuteReader
                objDataReader.Close()
                comandoSQL.Parameters.Clear()
            End If

            If cbespiro.Checked Then
                If dataespiro.Text = "" Then
                    ORDEMP.Text = "Preencha a data do exame"
                    mp1.Show()
                    Exit Sub
                End If
                comandoSQL.CommandText = "INSERT INTO TAB_ASO_EXAME VALUES (@codForm, @cbespiro, @dataespiro)"
                comandoSQL.Parameters.AddWithValue("@codForm", COD_FORM)
                comandoSQL.Parameters.AddWithValue("@cbespiro", cbespiro.Text)
                comandoSQL.Parameters.AddWithValue("@dataespiro", dataespiro.Text)
                objDataReader = comandoSQL.ExecuteReader
                objDataReader.Close()
                comandoSQL.Parameters.Clear()
            End If

            If cbacui.Checked Then
                If dataacui.Text = "" Then
                    ORDEMP.Text = "Preencha a data do exame"
                    mp1.Show()
                    Exit Sub
                End If
                comandoSQL.CommandText = "INSERT INTO TAB_ASO_EXAME VALUES (@codForm, @cbacui, @dataacui)"
                comandoSQL.Parameters.AddWithValue("@codForm", COD_FORM)
                comandoSQL.Parameters.AddWithValue("@cbacui", cbacui.Text)
                comandoSQL.Parameters.AddWithValue("@dataacui", dataacui.Text)
                objDataReader = comandoSQL.ExecuteReader
                objDataReader.Close()
                comandoSQL.Parameters.Clear()
            End If

            If cbaudio.Checked Then
                If dataaudio.Text = "" Then
                    ORDEMP.Text = "Preencha a data do exame"
                    mp1.Show()
                    Exit Sub
                End If
                comandoSQL.CommandText = "INSERT INTO TAB_ASO_EXAME VALUES (@codForm, @cbaudio, @dataaudio)"
                comandoSQL.Parameters.AddWithValue("@codForm", COD_FORM)
                comandoSQL.Parameters.AddWithValue("@cbaudio", cbaudio.Text)
                comandoSQL.Parameters.AddWithValue("@dataaudio", dataaudio.Text)
                objDataReader = comandoSQL.ExecuteReader
                objDataReader.Close()
                comandoSQL.Parameters.Clear()
            End If

            lblsv.Text = "ASO N°" & COD_FORM & " Cadastrado com Sucesso!"
            mp2.Show()
        Else
            conectabdnew()
            objDataReader.Close()
            comandoSQL.CommandText = "UPDATE TAB_ASO SET TIPO = '" & cbotipo.Text & "', REGISTRO_FUNCIONARIO = '" & cboreg.Text & "', CONSIDERADO = @RBSELECIONADO, OBSERVACAO = '" & txtobs.Text & "', DATA = '" & txtdata.Text & "' WHERE ID = '" & cbonform.Text & "'"
            comandoSQL.Parameters.AddWithValue("@RBSELECIONADO", rbconsiderado.SelectedValue)
            comandoSQL.ExecuteNonQuery()
            objDataReader.Close()
            lblsv.Text = "ASO N°" & cbonform.Text & " Editado com Sucesso!"
            mp2.Show()
        End If
        ResetForm()
    End Sub

    'btn imprimir
    Protected Sub cmdimprimir_Click(sender As Object, e As EventArgs) Handles cmdimprimir.Click
        Response.Redirect("ImprimirASO.aspx")
    End Sub

    'Preencher registro e ASOs cadastrados na tabela aso para filtrar e procurar ASOs
    Private Sub PreencherComboboxNform()
        cbonform.Items.Clear()
        cboformreg.Items.Clear()
        conectabdnew()
        cbonform.Items.Add("")
        comandoSQL.CommandText = "Select ID from TAB_ASO"
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
        comandoSQL.CommandText = "SELECT REGISTRO_FUNCIONARIO FROM TAB_ASO ORDER BY REGISTRO_FUNCIONARIO"
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

    ' Visualizar ASO
    Protected Sub btnnform_Click(sender As Object, e As EventArgs) Handles btnnform.Click
        If cbonform.Text = "" Then
            ORDEMP.Text = "Formulário não selecionado!"
            mp1.Show()
            Exit Sub
        End If

        conectabdnew()
        comandoSQL.CommandText = "SELECT TOP 1 * FROM TAB_ASO WHERE ID = '" & Trim(cbonform.Text) & "' ORDER BY DATA DESC"
        objDataReader = comandoSQL.ExecuteReader

        If objDataReader.HasRows Then
            If objDataReader.Read Then
                cbotipo.Text = objDataReader("TIPO").ToString()
                cboreg.Text = objDataReader("REGISTRO_FUNCIONARIO").ToString()
                rbconsiderado.SelectedValue = objDataReader("CONSIDERADO").ToString()
                txtobs.Text = objDataReader("OBSERVACAO").ToString()
                Dim data As DateTime = Convert.ToDateTime(objDataReader("DATA"))
                txtdata.Text = data.ToString("dd/MM/yyyy")
            End If
            objDataReader.Close()

            comandoSQL.CommandText = "SELECT NOME_RISCO FROM TAB_ASO_RISCO WHERE ID_ASO = '" & Trim(cbonform.Text) & "'"
            objDataReader = comandoSQL.ExecuteReader
            While objDataReader.Read
                Dim risco As String = objDataReader("NOME_RISCO").ToString()

                If risco = cbagef.Text Then
                    cbagef.Checked = True
                ElseIf risco = cbageb.Text Then
                    cbageb.Checked = True
                ElseIf risco = cbageq.Text Then
                    cbageq.Checked = True
                ElseIf risco = cberg.Text Then
                    cberg.Checked = True
                ElseIf risco = cbausrisc.Text Then
                    cbausrisc.Checked = True
                ElseIf risco = cbaci.Text Then
                    cbaci.Checked = True
                End If
            End While

            objDataReader.Close()

            comandoSQL.CommandText = "SELECT NOME_EXAME, DATA_EXAME FROM TAB_ASO_EXAME WHERE ID_ASO = '" & Trim(cbonform.Text) & "'"
            objDataReader = comandoSQL.ExecuteReader
            While objDataReader.Read
                Dim exame As String = objDataReader("NOME_EXAME").ToString()
                Dim dataExame As String = objDataReader("DATA_EXAME").ToString()

                If exame = cblab.Text Then
                    cblab.Checked = True
                    datalab.Text = dataExame
                    datalab.Visible = True
                ElseIf exame = cbtox.Text Then
                    cbtox.Checked = True
                    datatox.Text = dataExame
                    datatox.Visible = True
                ElseIf exame = cbeeg.Text Then
                    cbeeg.Checked = True
                    dataeeg.Text = dataExame
                    dataeeg.Visible = True
                ElseIf exame = cbecg.Text Then
                    cbecg.Checked = True
                    dataecg.Text = dataExame
                    dataecg.Visible = True
                ElseIf exame = cboutros.Text Then
                    cboutros.Checked = True
                    txtoutros.Text = exame
                ElseIf exame = cbradio.Text Then
                    cbradio.Checked = True
                    dataradio.Text = dataExame
                    dataradio.Visible = True
                ElseIf exame = cbespiro.Text Then
                    cbespiro.Checked = True
                    dataespiro.Text = dataExame
                    dataespiro.Visible = True
                ElseIf exame = cbacui.Text Then
                    cbacui.Checked = True
                    dataacui.Text = dataExame
                    dataacui.Visible = True
                ElseIf exame = cbaudio.Text Then
                    cbaudio.Checked = True
                    dataaudio.Text = dataExame
                    dataaudio.Visible = True
                Else
                    cboutros.Checked = True
                    txtoutros.Text = exame
                    txtoutros.Visible = True
                End If
            End While

            objDataReader.Close()

            comandoSQL.CommandText = "SELECT FUN_Nome, FUN_CPF, FUN_DATA_NASC, FUN_FUNCAO, FUN_CR FROM Funcionario WHERE FUN_REGISTRO = (SELECT REGISTRO_FUNCIONARIO FROM TAB_ASO WHERE ID = '" & Trim(cbonform.Text) & "')"
            objDataReader = comandoSQL.ExecuteReader

            If objDataReader.Read Then
                txtnome.Text = objDataReader("FUN_Nome").ToString()
                txtcpf.Text = objDataReader("FUN_CPF").ToString()
                txtarea.Text = objDataReader("FUN_CR").ToString()
                txtfuncao.Text = objDataReader("FUN_FUNCAO").ToString()
                Dim dataNascimento As DateTime = Convert.ToDateTime(objDataReader("FUN_DATA_NASC"))
                Dim idade As Integer = CalcularIdade(dataNascimento)
                txtidade.Text = idade.ToString()
            End If

            objDataReader.Close()

            COD_FORM = cbonform.Text
        Else
            ORDEMP.Text = "Formulário " & cbonform.Text & " Não Encontrado"
            mp1.Show()
        End If

        fechabdnew()
    End Sub

    'Resetar Form
    Private Sub ResetForm()
        cboreg.Text = ""
        txtnome.Text = ""
        txtcpf.Text = ""
        txtidade.Text = ""
        txtfuncao.Text = ""
        txtobs.Text = ""
        txtarea.Text = ""
        cbotipo.Text = ""

        cbagef.Checked = False
        cbageb.Checked = False
        cbaci.Checked = False
        cbageq.Checked = False
        cberg.Checked = False
        cbausrisc.Checked = False


        cblab.Checked = False
        datalab.Text = ""
        datalab.Visible = False

        cbtox.Checked = False
        datatox.Text = ""
        datatox.Visible = False

        cbeeg.Checked = False
        dataeeg.Text = ""
        dataeeg.Visible = False

        cbecg.Checked = False
        dataecg.Text = ""
        dataecg.Visible = False

        cbradio.Checked = False
        dataradio.Text = ""
        dataradio.Visible = False

        cboutros.Checked = False
        txtoutros.Text = ""
        txtoutros.Visible = False

        cbespiro.Checked = False
        dataespiro.Text = ""
        dataespiro.Visible = False

        cbacui.Checked = False
        dataacui.Text = ""
        dataacui.Visible = False

        cbaudio.Checked = False
        dataaudio.Text = ""
        dataaudio.Visible = False
    End Sub

    'RadioButton NovoASO/visualizarASO
    Protected Sub Rbaso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Rbaso.SelectedIndexChanged
        conectabdnew()
        If Rbaso.SelectedValue = 1 Then
            Panel14.Enabled = False
            Panel15.Enabled = False
            cbonform.Enabled = True
            cboformreg.Enabled = True
            Call Page_Load(sender, e)
            PreencherComboboxNform()
            ResetForm()
        Else
            Panel14.Enabled = True
            Panel15.Enabled = True
            txtdata.Text = DateTime.Now.ToString("dd/MM/yyyy")
            cbonform.Items.Clear()
            cboformreg.Items.Clear()
            cbonform.Enabled = False
            cboformreg.Enabled = False
            Call Page_Load(sender, e)
            ResetForm()
        End If
    End Sub

    'Filtrar ASOs pelo registro do funcionario
    Protected Sub cboformreg_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboformreg.SelectedIndexChanged
        cbonform.Items.Clear()
        conectabdnew()
        comandoSQL.CommandText = "SELECT ID FROM TAB_ASO WHERE REGISTRO_FUNCIONARIO = @Registro"
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

    Protected Sub cblab_CheckedChanged(sender As Object, e As EventArgs) Handles cblab.CheckedChanged
        If cblab.Checked Then
            datalab.Visible = True
        Else
            datalab.Visible = False
        End If
    End Sub

    Protected Sub cbtox_CheckedChanged(sender As Object, e As EventArgs) Handles cbtox.CheckedChanged
        If cbtox.Checked Then
            datatox.Visible = True
        Else
            datatox.Visible = False
        End If
    End Sub

    Protected Sub cbeeg_CheckedChanged(sender As Object, e As EventArgs) Handles cbeeg.CheckedChanged
        If cbeeg.Checked Then
            dataeeg.Visible = True
        Else
            dataeeg.Visible = False
        End If
    End Sub

    Protected Sub cbecg_CheckedChanged(sender As Object, e As EventArgs) Handles cbecg.CheckedChanged
        If cbecg.Checked Then
            dataecg.Visible = True
        Else
            dataecg.Visible = False
        End If
    End Sub

    Protected Sub cboutros_CheckedChanged(sender As Object, e As EventArgs) Handles cboutros.CheckedChanged
        If cboutros.Checked Then
            txtoutros.Visible = True
        Else
            txtoutros.Visible = False
        End If
    End Sub

    Protected Sub cbradio_CheckedChanged(sender As Object, e As EventArgs) Handles cbradio.CheckedChanged
        If cbradio.Checked Then
            dataradio.Visible = True
        Else
            dataradio.Visible = False
        End If
    End Sub

    Protected Sub cbespiro_CheckedChanged(sender As Object, e As EventArgs) Handles cbespiro.CheckedChanged
        If cbespiro.Checked Then
            dataespiro.Visible = True
        Else
            dataespiro.Visible = False
        End If
    End Sub

    Protected Sub cbacui_CheckedChanged(sender As Object, e As EventArgs) Handles cbacui.CheckedChanged
        If cbacui.Checked Then
            dataacui.Visible = True
        Else
            dataacui.Visible = False
        End If
    End Sub

    Protected Sub cbaudio_CheckedChanged(sender As Object, e As EventArgs) Handles cbaudio.CheckedChanged
        If cbaudio.Checked Then
            dataaudio.Visible = True
        Else
            dataaudio.Visible = False
        End If
    End Sub
End Class