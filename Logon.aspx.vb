Imports System.Data.SqlClient
Imports System.Web.Security
Public Class WebForm

    Inherits System.Web.UI.Page
    Dim a As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.UserAgent.Contains("Trident") Then
                'cmdLogin1.Text = "ABRIR CHROME"
                Erro1.Text = "USAR O GOOGLE CHROME"
                Erro1.Font.Bold = True
                Erro1.Font.Size = 12
                'Formulario.Visible = False
                cmdLogin1.Visible = False
                txtUserPass.Visible = False
                txtUserName.Visible = False
                'user.Visible = False
                'Label2.Visible = False
            End If
        End If
    End Sub

    Private Function ValidateUser(ByVal userName As String, ByVal passWord As String) As Integer
        Dim retorno As Integer
        Dim UserExists As Integer
        Dim Planta As Integer
        '##############VERIFICAÇÃO BÁSICA#########################
        Dim lookupPassword As String
        lookupPassword = Nothing    ' Check for an invalid userName.         
        ' userName  must not be set to nothing and must be between one and 15 characters.         
        If ((userName Is Nothing)) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.")
            Return False
        End If
        If ((userName.Length = 0) Or (userName.Length > 15)) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of userName failed.")
            Return False
        End If
        ' Check for invalid passWord.         
        ' passWord must not be set to nothing and must be between one and 25 characters.         
        If (passWord Is Nothing) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.")
            Return False
        End If
        If ((passWord.Length = 0) Or (passWord.Length > 25)) Then
            System.Diagnostics.Trace.WriteLine("[ValidateUser] Input validation of passWord failed.")
            Return False
        End If
        '#########################################################

        Try
            '##############CONEXÃO COM BANCO DE DADOS#################
            If Modulo.conectabdnew() = True Then
                '---> DEFINE O COOKIE COM CÓDIGO PLANTA SELECIONADO <---
                'Session("Planta") = "10007"
                Planta = Request.Cookies("Planta").Value
                '---------------------------------------------------------

                '##############VERIFICAÇÃO DO USUÁRIO NO BD###############
                If (userName = 21385 Or userName = 2247) Then
                    Modulo.comandoSQL.CommandText = "SELECT FUN_REGISTRO, FUN_SENHA, FUN_CODIGO_PLANTA "
                    Modulo.comandoSQL.CommandText &= "FROM FUNCIONARIO "
                    Modulo.comandoSQL.CommandText &= "WHERE FUN_REGISTRO = '" & userName & "' AND (SUBSTRING(FUN_CPF, 1, 6) = '" & passWord & "' or FUN_SENHA = '" & passWord & "') AND FUN_STATUS = 'ATIVO'"
                    Modulo.objDataReader = Modulo.comandoSQL.ExecuteReader()
                    UserExists = objDataReader.HasRows
                    retorno = 0
                Else
                    Modulo.comandoSQL.CommandText = "SELECT FUN_REGISTRO, FUN_SENHA, FUN_CODIGO_PLANTA "
                    Modulo.comandoSQL.CommandText &= "FROM FUNCIONARIO "
                    Modulo.comandoSQL.CommandText &= "WHERE FUN_REGISTRO = '" & userName & "' AND (SUBSTRING(FUN_CPF, 1, 6) = '" & passWord & "' or FUN_SENHA = '" & passWord & "') AND FUN_CODIGO_PLANTA = '" & Planta & "' AND FUN_STATUS = 'ATIVO';"
                    Modulo.objDataReader = Modulo.comandoSQL.ExecuteReader()
                    UserExists = objDataReader.HasRows
                    retorno = 0
                End If
                If Not UserExists Then
                    fechabdnew()
                    conectabdnew()
                    Modulo.comandoSQL.CommandText = "SELECT FUN_REGISTRO, FUN_SENHA, FUN_CODIGO_PLANTA "
                    Modulo.comandoSQL.CommandText &= "FROM FUNCIONARIO "
                    'Modulo.comandoSQL.CommandText &= "WHERE FUN_REGISTRO = '" & userName & "' AND FUN_CODIN = '" & passWord & "'"
                    Modulo.comandoSQL.CommandText &= "WHERE FUN_REGISTRO = '" & userName & "' AND (SUBSTRING(FUN_CPF, 1, 6) = '" & passWord & "' or FUN_CODIN = '" & passWord & "') AND FUN_STATUS = 'ATIVO'"
                    Modulo.objDataReader = Modulo.comandoSQL.ExecuteReader()
                    UserExists = objDataReader.HasRows
                    retorno = 0
                End If
                If UserExists Then
                    retorno = 1
                End If
                '############################################################
            Else
                retorno = 0
            End If
            Modulo.objDataReader.Close()
            Modulo.fechabdnew()
        Catch ex As Exception
            retorno = 2
        Finally
            Modulo.objDataReader.Close()
            Modulo.fechabdnew()
        End Try

        Return retorno
    End Function

    Private Sub cmdLogin1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLogin1.Click
        Response.Cookies.Add(New HttpCookie("Planta", "10007"))

        If Request.UserAgent.Contains("Trident") Then

            'Process.Start("C:\Program Files (x86)\Google\Chrome\Application\chrome.exe")

        Else
            Dim Validacao As Integer
            Validacao = ValidateUser(txtUserName.Value, txtUserPass.Value.ToUpper)
            If Validacao = 1 Then 'Entrou
                'Session("Planta") = "10007"
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Value, True)
                Response.Redirect("Tela_inicial.aspx")
            ElseIf Validacao = 0 Then 'Nao entrou
                Erro.Text = "USUÁRIO/SENHA INVÁLIDO."
            ElseIf Validacao = 2 Then 'Erro
                Erro.Text = "ERRO AO ENTRAR."
            End If
        End If
    End Sub


    '#### ATIVA ALTERAÇÃO DE SENHA #### 
    'Protected Sub LinkButton1_Click(sender As Object, e As EventArgs) Handles lbtredsenha.Click
    '    Dim reg As String
    '    reg = txtUserName.Value
    '    If Modulo.conectabdnew() = True Then
    '        Modulo.comandoSQL.CommandText = "SELECT FUN_REGISTRO FROM FUNCIONARIO WHERE FUN_REGISTRO = '" & reg & "' "
    '        Modulo.objDataReader = Modulo.comandoSQL.ExecuteReader
    '        Try
    '            Modulo.objDataReader.Read()
    '            If objDataReader.HasRows Then
    '                mp1.Show()
    '            Else
    '                mp2.Show()
    '            End If
    '        Catch ex As Exception
    '            mp2.Show()
    '        End Try
    '    End If
    '    Modulo.objDataReader.Close()
    '    Modulo.fechabdnew()
    'End Sub

    'Protected Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

    'End Sub
    '#####  ALTERAÇÃO DE SENHA #######
    'Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    Dim UserExists As Integer
    '    Dim plan As String
    '    Dim UserName As String
    '    Dim oldpass, newpass, renewpass As String
    '    Dim lookupPassword As String
    '    lookupPassword = Nothing    ' Check for an invalid userName.         
    '    plan = "Jambeiro"
    '    oldpass = txtoldpass.Value.ToUpper
    '    newpass = txtnewpass.Value.ToUpper
    '    renewpass = txtrenewpass.Value.ToUpper
    '    UserName = txtUserName.Value
    '    If Modulo.conectabdnew() = True Then
    '        Modulo.comandoSQL.CommandText = "SELECT FUN_REGISTRO, FUN_SENHA, FUN_CODIGO_PLANTA "
    '        Modulo.comandoSQL.CommandText &= "FROM FUNCIONARIO "
    '        Modulo.comandoSQL.CommandText &= "WHERE FUN_REGISTRO = '" & UserName & "'"
    '        Modulo.objDataReader = Modulo.comandoSQL.ExecuteReader()
    '        UserExists = Modulo.objDataReader.HasRows
    '        If UserExists Then
    '            Modulo.objDataReader.Read()
    '            lookupPassword = Modulo.objDataReader.Item(1)
    '            'VERIFICA FUNÇÃO
    '            If lookupPassword = oldpass Then
    '                If newpass = renewpass Then
    '                    If Trim(newpass) = "" Then
    '                        mp5.Show()
    '                    End If
    '                    Modulo.objDataReader.Close()
    '                    Modulo.comandoSQL.CommandText = "UPDATE FUNCIONARIO SET FUN_SENHA = '" & newpass & "' WHERE FUN_REGISTRO = '" & UserName & "' "
    '                    Modulo.comandoSQL.ExecuteNonQuery()
    '                Else
    '                    mp4.Show()
    '                End If
    '            Else
    '                mp3.Show()
    '            End If
    '            Modulo.objDataReader.Close()
    '            Modulo.fechabdnew()
    '        End If
    '    End If
    'End Sub


End Class