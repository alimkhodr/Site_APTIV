Imports System.Data.SqlClient
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Drawing

Public Class Tela_inicial
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim reg As Integer
        Try
            conectabdnew()
            comandoSQL.CommandText = "SELECT FUN_NOME, FUN_REGISTRO FROM FUNCIONARIO WHERE FUN_REGISTRO = '" & User.Identity.Name & "'"
            objDataReader = comandoSQL.ExecuteReader
            objDataReader.Read()
            Session("Nome") = objDataReader(0)
            Session("Registro") = objDataReader(1)
            objDataReader.Close()
            fechabdnew()
            '########## BOTÃO DE LOG-OFF ########################
            Dim BTN1 As HtmlInputSubmit
            BTN1 = Master.FindControl("CmdSignOut")
            BTN1.Value = "SAIR DO REGISTRO: " & User.Identity.Name
            reg = User.Identity.Name
            '###################################################
        Catch ex As Exception
            Response.Redirect("Logon.aspx")
        End Try

        conectabdnew()
        comandoSQL.CommandText = "SELECT DATA FROM TAB_ACIDENTES WHERE TIPO = 'COM AFASTAMENTO' ORDER BY DATA DESC"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.Read() Then
            Dim dataAcidentes As DateTime = Convert.ToDateTime(objDataReader("DATA"))
            Dim dataAtualAcidente As DateTime = DateTime.Now
            Dim diasSemAcidentes As Integer = (dataAtualAcidente - dataAcidentes).Days
            txtacidentes1.Text = diasSemAcidentes
        Else
            txtreclamacoes1.Text = "N/A"
        End If
        objDataReader.Close()
        fechabdnew()

        conectabdnew()
        comandoSQL.CommandText = "SELECT DATA FROM TAB_RECLAMACOES ORDER BY DATA DESC"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.Read() Then
            Dim dataReclamacao As DateTime = Convert.ToDateTime(objDataReader("DATA"))
            Dim dataAtualReclamacao As DateTime = DateTime.Now
            Dim diasSemReclamacoes As Integer = (dataAtualReclamacao - dataReclamacao).Days
            txtreclamacoes1.Text = diasSemReclamacoes
        Else
            txtreclamacoes1.Text = "N/A"
        End If
        objDataReader.Close()
        fechabdnew()


        conectabdnew()
        comandoSQL.CommandText = "SELECT * FROM TAB_COMUNICADOS WHERE ID = 1"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.Read() Then
            img1.ImageUrl = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            If objDataReader("HREF").ToString() = "" Then
                A1.HRef = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            Else
                A1.HRef = objDataReader("HREF").ToString()
            End If
            If objDataReader("URL").ToString() = "" Then
                slide1.Visible = False
                dot1.Visible = False
            End If
        Else
            slide1.Visible = False
            dot1.Visible = False
        End If
        objDataReader.Close()
        fechabdnew()

        conectabdnew()
        comandoSQL.CommandText = "SELECT * FROM TAB_COMUNICADOS WHERE ID = 2"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.Read() Then
            img2.ImageUrl = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            If objDataReader("HREF").ToString() = "" Then
                A2.HRef = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            Else
                A2.HRef = objDataReader("HREF").ToString()
            End If
            If objDataReader("URL").ToString() = "" Then
                slide2.Visible = False
                dot2.Visible = False
            End If
        Else
            slide2.Visible = False
            dot2.Visible = False
        End If
        objDataReader.Close()
        fechabdnew()

        conectabdnew()
        comandoSQL.CommandText = "SELECT * FROM TAB_COMUNICADOS WHERE ID = 3"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.Read() Then
            img3.ImageUrl = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            If objDataReader("HREF").ToString() = "" Then
                A3.HRef = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            Else
                A3.HRef = objDataReader("HREF").ToString()
            End If
            If objDataReader("URL").ToString() = "" Then
                slide3.Visible = False
                dot3.Visible = False
            End If
        Else
            slide3.Visible = False
            dot3.Visible = False
        End If
        objDataReader.Close()
        fechabdnew()

        conectabdnew()
        comandoSQL.CommandText = "SELECT * FROM TAB_COMUNICADOS WHERE ID = 4"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.Read() Then
            img4.ImageUrl = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            If objDataReader("HREF").ToString() = "" Then
                A4.HRef = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            Else
                A4.HRef = objDataReader("HREF").ToString()
            End If
            If objDataReader("URL").ToString() = "" Then
                slide4.Visible = False
                dot4.Visible = False
            End If
        Else
            slide4.Visible = False
            dot4.Visible = False
        End If
        objDataReader.Close()
        fechabdnew()

        conectabdnew()
        comandoSQL.CommandText = "SELECT * FROM TAB_COMUNICADOS WHERE ID = 5"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.Read() Then
            img5.ImageUrl = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            If objDataReader("HREF").ToString() = "" Then
                A5.HRef = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            Else
                A5.HRef = objDataReader("HREF").ToString()
            End If
            If objDataReader("URL").ToString() = "" Then
                slide5.Visible = False
                dot5.Visible = False
            End If
        Else
            slide5.Visible = False
            dot5.Visible = False
        End If
        objDataReader.Close()
        fechabdnew()

        conectabdnew()
        comandoSQL.CommandText = "SELECT * FROM TAB_COMUNICADOS WHERE ID = 6"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.Read() Then
            img6.ImageUrl = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            If objDataReader("HREF").ToString() = "" Then
                A6.HRef = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            Else
                A6.HRef = objDataReader("HREF").ToString()
            End If
            If objDataReader("URL").ToString() = "" Then
                slide6.Visible = False
                dot6.Visible = False
            End If
        Else
            slide6.Visible = False
            dot6.Visible = False
        End If
        objDataReader.Close()
        fechabdnew()

        conectabdnew()
        comandoSQL.CommandText = "SELECT * FROM TAB_COMUNICADOS WHERE ID = 7"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.Read() Then
            img7.ImageUrl = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            If objDataReader("HREF").ToString() = "" Then
                A7.HRef = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            Else
                A7.HRef = objDataReader("HREF").ToString()
            End If
            If objDataReader("URL").ToString() = "" Then
                slide7.Visible = False
                dot7.Visible = False
            End If
        Else
            slide7.Visible = False
            dot7.Visible = False
        End If
        objDataReader.Close()
        fechabdnew()

        conectabdnew()
        comandoSQL.CommandText = "SELECT * FROM TAB_COMUNICADOS WHERE ID = 8"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.Read() Then
            img8.ImageUrl = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            If objDataReader("HREF").ToString() = "" Then
                A8.HRef = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            Else
                A8.HRef = objDataReader("HREF").ToString()
            End If
            If objDataReader("URL").ToString() = "" Then
                slide8.Visible = False
                dot8.Visible = False
            End If
        Else
            slide8.Visible = False
            dot8.Visible = False
        End If
        objDataReader.Close()
        fechabdnew()

        conectabdnew()
        comandoSQL.CommandText = "SELECT * FROM TAB_COMUNICADOS WHERE ID = 9"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.Read() Then
            img9.ImageUrl = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            If objDataReader("HREF").ToString() = "" Then
                A9.HRef = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            Else
                A9.HRef = objDataReader("HREF").ToString()
            End If
            If objDataReader("URL").ToString() = "" Then
                slide9.Visible = False
                dot9.Visible = False
            End If
        Else
            slide9.Visible = False
            dot9.Visible = False
        End If
        objDataReader.Close()
        fechabdnew()

        conectabdnew()
        comandoSQL.CommandText = "SELECT * FROM TAB_COMUNICADOS WHERE ID = 10"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.Read() Then
            img10.ImageUrl = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            If objDataReader("HREF").ToString() = "" Then
                A10.HRef = "http://mfgsvr2/Comunicados/" & objDataReader("URL").ToString()
            Else
                A10.HRef = objDataReader("HREF").ToString()
            End If
            If objDataReader("URL").ToString() = "" Then
                slide10.Visible = False
                dot10.Visible = False
            End If
        Else
            slide10.Visible = False
            dot10.Visible = False
        End If
        objDataReader.Close()
        fechabdnew()
    End Sub

    Private Function ObterMaiorDiferencaEntreDatas() As Integer
        Dim maiorDiferenca As Integer = 0
        conectabdnew()
        comandoSQL.CommandText = "SELECT DATA FROM TAB_RECLAMACOES ORDER BY DATA DESC"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.Read() Then
            Dim dataMaisAntiga As DateTime = objDataReader.GetDateTime(0)
            Dim dataAtual As DateTime = DateTime.Now
            maiorDiferenca = CInt((dataAtual - dataMaisAntiga).TotalDays)
            While objDataReader.Read()
                Dim data As DateTime = objDataReader.GetDateTime(0)
                Dim diferenca As Integer = CInt((dataAtual - data).TotalDays)
                If diferenca > maiorDiferenca Then
                    maiorDiferenca = diferenca
                End If
            End While
        Else
            maiorDiferenca = -1
        End If
        objDataReader.Close()
        fechabdnew()
        Return maiorDiferenca
    End Function

End Class