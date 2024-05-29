Imports System.Data.SqlClient
Imports System.Data
Public Class Treinamento_Novo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '########## BOTÃO DE LOG-OFF ########################
        Try
            Dim BTN As System.Web.UI.HtmlControls.HtmlInputSubmit
            Dim reg, VALIDAR As Integer
            BTN = Master.FindControl("CmdSignOut")
            BTN.Value = "SAIR DO REGISTRO: " & User.Identity.Name
            reg = User.Identity.Name
            VALIDAR = ValidarTela(reg, 307)
            If VALIDAR = 1 Then
                Response.Redirect("~/SGM.aspx")
                CType(Master.FindControl("Label16"), Label).ForeColor = Drawing.Color.Red
                CType(Master.FindControl("mp6"), AjaxControlToolkit.ModalPopupExtender).Show()
            End If
        Catch ex As Exception
            Response.Redirect("~/Logon.aspx")
        End Try

        Lsbox()

        If Not IsPostBack Then
            PreencherComboboxTreinamento()
            PreencherComboboxAreaAdministrativa()
        End If

    End Sub

    Private Sub cboarea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboarea.SelectedIndexChanged
        If cboarea.Text <> "" Then
            ListaTreinamento.Items.Clear()
            conectabdnew()
            comandoSQL.CommandText = "SELECT TA.ID_AREA, TA.ID_TREINAMENTO, A.NOME AS NOME_AREA, T.NOME AS NOME_TREINAMENTO " &
                                 "FROM TAB_TREINAMENTO_AREA TA " &
                                 "JOIN TAB_AREA_ADMINISTRATIVA A ON TA.ID_AREA = A.ID " &
                                 "JOIN TAB_TREINAMENTO T ON TA.ID_TREINAMENTO = T.ID " &
                                 "WHERE A.NOME = @AreaNome " &
                                 "ORDER BY A.NOME ASC"
            comandoSQL.Parameters.AddWithValue("@AreaNome", cboarea.SelectedItem.ToString())
            objDataReader = comandoSQL.ExecuteReader
            If objDataReader.HasRows Then
                While objDataReader.Read()
                    Dim item As String = objDataReader("NOME_AREA").ToString() + " - " + objDataReader("NOME_TREINAMENTO").ToString()
                    ListaTreinamento.Items.Add(item)
                End While
            End If
            objDataReader.Close()
            fechabdnew()
        Else
            PreencherComboboxTreinamento()
            PreencherComboboxAreaAdministrativa()
        End If
    End Sub
    Private Sub Lsbox()
        ListaTreinamento.Items.Clear()
        conectabdnew()
        comandoSQL.CommandText = "SELECT TA.ID_AREA, TA.ID_TREINAMENTO, A.NOME AS NOME_AREA, T.NOME AS NOME_TREINAMENTO " & "FROM TAB_TREINAMENTO_AREA TA " & "JOIN TAB_AREA_ADMINISTRATIVA A ON TA.ID_AREA = A.ID " & "JOIN TAB_TREINAMENTO T ON TA.ID_TREINAMENTO = T.ID " & "ORDER BY A.NOME ASC"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.HasRows Then
            While objDataReader.Read()
                Dim item As String = objDataReader("NOME_AREA").ToString() + " - " + objDataReader("NOME_TREINAMENTO").ToString()
                ListaTreinamento.Items.Add(item)
            End While
        End If
        fechabdnew()
    End Sub

    Private Sub PreencherComboboxTreinamento()
        cbotreinamento.Items.Clear()
        cbotreinamento2.Items.Clear()
        cbotreinamento.Items.Add("")
        cbotreinamento2.Items.Add("")
        conectabdnew()
        comandoSQL.CommandText = "SELECT * FROM TAB_TREINAMENTO"
        objDataReader = comandoSQL.ExecuteReader
        While objDataReader.Read()
            Dim TREINAMENTO As String = objDataReader("NOME").ToString()
            cbotreinamento.Items.Add(TREINAMENTO)
            cbotreinamento2.Items.Add(TREINAMENTO)
        End While
        objDataReader.Close()
        fechabdnew()
    End Sub

    Private Sub PreencherComboboxAreaAdministrativa()
        cboarea.Items.Clear()
        cboarea2.Items.Clear()
        cboarea.Items.Add("")
        cboarea2.Items.Add("")
        conectabdnew()
        comandoSQL.CommandText = "SELECT * FROM TAB_AREA_ADMINISTRATIVA"
        objDataReader = comandoSQL.ExecuteReader
        While objDataReader.Read()
            Dim AREA As String = objDataReader("NOME").ToString()
            cboarea.Items.Add(AREA)
            cboarea2.Items.Add(AREA)
        End While
        objDataReader.Close()
        fechabdnew()
    End Sub

    Protected Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Txttreinamento.Text = "" Then
            ORDEMP.Text = "Treinamento não preenchido!"
            mp1.Show()
            Exit Sub
        End If
        Try
            conectabdnew()
            comandoSQL.CommandText = "INSERT INTO TAB_TREINAMENTO VALUES ('" & Txttreinamento.Text & "') "
            comandoSQL.ExecuteReader()
            fechabdnew()
            PreencherComboboxTreinamento()
            Lsbox()
            ORDEMP.Text = "Treinamento cadastrado com sucesso!"
            mp1.Show()
        Catch ex As Exception
            ORDEMP.Text = "Treinamento " & Txttreinamento.Text & " já cadastrado"
            mp1.Show()
        End Try
    End Sub

    Protected Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If Txtarea.Text = "" Then
            ORDEMP.Text = "Área não preenchida!"
            mp1.Show()
            Exit Sub
        End If
        Try
            conectabdnew()
            comandoSQL.CommandText = "INSERT INTO TAB_AREA_ADMINISTRATIVA VALUES ('" & Txtarea.Text & "') "
            comandoSQL.ExecuteReader()
            fechabdnew()
            PreencherComboboxAreaAdministrativa()
            Lsbox()
            ORDEMP.Text = "Área cadastrada com sucesso!"
            mp1.Show()
        Catch ex As Exception
            ORDEMP.Text = "Área " & Txtarea.Text & " já cadastrada"
            mp1.Show()
        End Try
    End Sub

    Protected Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If cbotreinamento.Text = "" Then
            ORDEMP.Text = "Treinamento não preenchido!"
            mp1.Show()
            Exit Sub
        End If
        If cboarea.Text = "" Then
            ORDEMP.Text = "Área não preenchida!"
            mp1.Show()
            Exit Sub
        End If
        Try
            Dim treinamentoNome As String = cbotreinamento.SelectedItem.Text
            Dim areaNome As String = cboarea.SelectedItem.Text
            conectabdnew()
            comandoSQL.CommandText = "SELECT ID FROM TAB_TREINAMENTO WHERE NOME = @TreinamentoNome"
            comandoSQL.Parameters.AddWithValue("@TreinamentoNome", treinamentoNome)
            Dim treinamentoID As Integer = Convert.ToInt32(comandoSQL.ExecuteScalar())
            comandoSQL.CommandText = "SELECT ID FROM TAB_AREA_ADMINISTRATIVA WHERE NOME = @AreaNome"
            comandoSQL.Parameters.AddWithValue("@AreaNome", areaNome)
            Dim areaID As Integer = Convert.ToInt32(comandoSQL.ExecuteScalar())
            comandoSQL.CommandText = "INSERT INTO TAB_TREINAMENTO_AREA (ID_AREA, ID_TREINAMENTO) VALUES (@AreaID, @TreinamentoID);"
            comandoSQL.Parameters.AddWithValue("@AreaID", areaID)
            comandoSQL.Parameters.AddWithValue("@TreinamentoID", treinamentoID)
            comandoSQL.ExecuteNonQuery()
            fechabdnew()
            Lsbox()
            ORDEMP.Text = "Treinamento adicionado a área"
            mp1.Show()
        Catch ex As Exception
            ORDEMP.Text = "Área já contém este treinamento "
            mp1.Show()
        End Try
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If cboarea2.Text = "" Then
            ORDEMP.Text = "Área não selecionada!"
            mp1.Show()
            Exit Sub
        End If
        Dim areaNome As String = cboarea2.SelectedItem.Text
        conectabdnew()
        comandoSQL.CommandText = "SELECT ID FROM TAB_AREA_ADMINISTRATIVA WHERE NOME = @AreaNome"
        comandoSQL.Parameters.AddWithValue("@AreaNome", areaNome)
        Dim areaID As Integer = Convert.ToInt32(comandoSQL.ExecuteScalar())
        comandoSQL.CommandText = "DELETE FROM TAB_AREA_ADMINISTRATIVA WHERE ID = @AreaID;"
        comandoSQL.Parameters.AddWithValue("@AreaID", areaID)
        comandoSQL.ExecuteNonQuery()
        fechabdnew()
        PreencherComboboxAreaAdministrativa()
        Lsbox()
        ORDEMP.Text = "Área excluida com sucesso!"
        mp1.Show()
    End Sub

    Protected Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If cbotreinamento2.Text = "" Then
            ORDEMP.Text = "Treinamento não selecionado!"
            mp1.Show()
            Exit Sub
        End If
        Dim treinamentoNome As String = cbotreinamento2.SelectedItem.Text
        conectabdnew()
        comandoSQL.CommandText = "SELECT ID FROM TAB_TREINAMENTO WHERE NOME = @TreinamentoNome"
        comandoSQL.Parameters.AddWithValue("@TreinamentoNome", treinamentoNome)
        Dim treinamentoID As Integer = Convert.ToInt32(comandoSQL.ExecuteScalar())
        comandoSQL.CommandText = "DELETE FROM TAB_TREINAMENTO WHERE ID = @TreinamentoID;"
        comandoSQL.Parameters.AddWithValue("@TreinamentoID", treinamentoID)
        comandoSQL.ExecuteNonQuery()
        fechabdnew()
        Lsbox()
        ORDEMP.Text = "Treinamento excluido com sucesso!"
        mp1.Show()
    End Sub
End Class