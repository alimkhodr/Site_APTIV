Imports System.Data.SqlClient
Imports System.Data
Imports System.Management
Imports System.Net
Imports System.IO
Imports System.Net.NetworkInformation

Module Modulo
    Public conexaobd As New SqlConnection("server=10.251.24.11;database=SGM_ONE;uid=sa;pwd=P@ssw0rd")
    Public objDataReader As SqlDataReader
    Public comandoSQL As SqlCommand

    Public conexaobd2 As New SqlConnection("server=10.251.24.11;database=SGM_ONE;uid=sa;pwd=P@ssw0rd")
    Public objDataReader2 As SqlDataReader
    Public comandoSQL2 As SqlCommand
    Public nformulario, grupo, assunto, externo, npessoas As Integer
    Public nometreinamento, nometreinador, localt, datat, hi, hf, dataf As String
    Public tipoaso, regaso, nomeaso, cpfaso, idadeaso, dataaso, consideradoaso, funcaoaso, areaaso, obsaso, dataATEND As String
    Public cbagef, cbageb, cbaci, cbageq, cberg, cbausrisc, cblab, datalab, cbtox, datatox, cbeeg, dataeeg, cbecg, dataecg, txtoutros, dataoutros, cbradio, dataradio, cbespiro, dataespiro, cbacui, dataacui, cbaudio, dataaudio As String
    Public idchamado As String
    Public idcomunicado As String
    Public registrott, nomett, turnoAtualtt, enderecott, numerott, complementott, bairrott, cidadett, novoTurnott, datainiciott, datafimtt, tempo, cargott As String 'Troca de Turno
    Public dura As Double
    Public nomep(20) As String
    Public regpe(20) As Long
    Public turno(20) As Integer
    Public MESES() As String = {"Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"}

    Dim vPreenchimento As Integer = 0

    'MEMORANDO EXPORTAÇÃO
    Public form_memorando As Integer

    'VERIFICAÇÕES NECESSARIAS
    Public cadastroEmail

    'Desvios
    Public form As Integer
    Public n_formulario, dataD, tipoD, partnumberD, ferramentaD, areaD, descricaoD, abrangenciaD, validadeD, motivoD, propostoD, especificadoD, contencaoD, validadeGT, responsavelGT, departamentoGT, grupoGT, acaoGT, descricaoGT As String

    'conexao com banco do GT
    Public conexaogt As New SqlConnection()
    Public gtDataReader As SqlDataReader
    Public gtComandoSql As SqlCommand




    Function conectabd()
        Try
            If conexaobd.State = ConnectionState.Closed Then

            End If
            conexaobd.ConnectionString = "server=MFGSVR\SQLEXPRESS;database=SGM;uid=sa;pwd=jambeiro1011"
            conexaobd.Open()
            comandoSQL = New SqlCommand
            comandoSQL = conexaobd.CreateCommand
        Catch ex As Exception
            conexaobd.Close()
            conexaobd.ConnectionString = "server=MFGSVR\SQLEXPRESS;database=SGM;uid=sa;pwd=jambeiro1011"
            comandoSQL = New SqlCommand
            comandoSQL = conexaobd.CreateCommand
            conexaobd.Open()
        End Try
        Return True
    End Function
    Function conectabdnew() As Boolean
        Try
            'Dim strcon = ConfigurationManager.ConnectionStrings("SGM").ConnectionString
            If conexaobd.State = ConnectionState.Closed Then
                conexaobd.Open()
                comandoSQL = New SqlCommand
                comandoSQL = conexaobd.CreateCommand
            Else
                conexaobd.Close()

                conexaobd.Open()
                comandoSQL = New SqlCommand
                comandoSQL = conexaobd.CreateCommand
            End If

            Return True
        Catch ex As Exception
            'conexaobd.Close()
            '' Dim strcon = ConfigurationManager.ConnectionStrings("SGM").ConnectionString
            'conexaobd.Open()
            'comandoSQL = New SqlCommand
            'comandoSQL = conexaobd.CreateCommand
            Return True
        End Try
    End Function
    Function conectabdnew2() As Boolean
        Try
            If conexaobd2.State = ConnectionState.Closed Then
                conexaobd2.Open()
                comandoSQL2 = New SqlCommand
                comandoSQL2 = conexaobd2.CreateCommand
            Else
                conexaobd2.Close()
                conexaobd2.Open()
                comandoSQL2 = New SqlCommand
                comandoSQL2 = conexaobd2.CreateCommand
            End If
            Return True
        Catch ex As Exception
            'conexaobd2.Close()
            'conexaobd2.Open()
            'comandoSQL2 = New SqlCommand
            'comandoSQL2 = conexaobd2.CreateCommand
            Return False
        End Try
    End Function
    Public Sub fechabdnew2()
        Try
            conexaobd2.Close()
        Catch ex As Exception
        End Try
    End Sub
    Function fechabd()
        Try
            conexaobd.Close()
        Catch ex As Exception
        End Try
        Return True
    End Function
    Public Sub fechabdnew()
        Try
            conexaobd.Close()
        Catch ex As Exception
        End Try
    End Sub

    Function conectagt() As Boolean
        Try
            conexaogt.ConnectionString = "server=brspjam-ap07;database=db_gestao_tarefas;uid=sa;pwd=P@ssw0rd"
            conexaogt.Open()
            gtComandoSql = New SqlCommand
            gtComandoSql = conexaogt.CreateCommand
            Return True
        Catch ex As Exception
            conexaogt.Close()
            conexaogt.ConnectionString = "server=brspjam-ap07;database=db_gestao_tarefas;uid=sa;pwd=P@ssw0rd"
            conexaogt.Open()
            gtComandoSql = New SqlCommand
            gtComandoSql = conexaogt.CreateCommand
            Return False
        End Try
    End Function

    Public Sub fechagt()
        Try
            conexaogt.Close()
        Catch ex As Exception
        End Try
    End Sub


    Function horastd(ByVal pn As String)
        Dim HSTD As Double
        Dim erro As String
        conectabdnew()
        comandoSQL.CommandText = "Select PRO_OPE10 from Produto where PRO_Part_Number = '" & pn & "' "
        objDataReader = comandoSQL.ExecuteReader
        objDataReader.Read()
        Try
            HSTD = objDataReader(0)
        Catch ex As Exception
            erro = 123
            Return erro
            Exit Function
        End Try
        Return HSTD
    End Function
    '#############################################################
    'Retorna terça da próxima semana da Data passada no parâmetro
    '#############################################################

    Public Function ObterData(ByVal WeekDay As Date) As Date
        Dim data As Date
        Select Case WeekDay.DayOfWeek
            Case DayOfWeek.Sunday
                data = DateAdd("d", 2, FormatDateTime(WeekDay, DateFormat.ShortDate) & " 06:55:00")
            Case DayOfWeek.Monday
                data = DateAdd("d", 1, FormatDateTime(WeekDay, DateFormat.ShortDate) & " 06:55:00")
            Case DayOfWeek.Tuesday
                data = DateAdd("d", 7, FormatDateTime(WeekDay, DateFormat.ShortDate) & " 06:55:00")
            Case DayOfWeek.Wednesday
                data = DateAdd("d", 6, FormatDateTime(WeekDay, DateFormat.ShortDate) & " 06:55:00")
            Case DayOfWeek.Thursday
                data = DateAdd("d", 5, FormatDateTime(WeekDay, DateFormat.ShortDate) & " 06:55:00")
            Case DayOfWeek.Friday
                data = DateAdd("d", 4, FormatDateTime(WeekDay, DateFormat.ShortDate) & " 06:55:00")
            Case DayOfWeek.Saturday
                data = DateAdd("d", 3, FormatDateTime(WeekDay, DateFormat.ShortDate) & " 06:55:00")
        End Select
        Return data
    End Function

    Public Function ObterFuncao(ByVal Registro As Integer) As String
        conectabd()
        Dim funcao As String
        comandoSQL.CommandText = "Select FUN_Nome FROM Funcionarios "
        comandoSQL.CommandText &= "INNER JOIN Funcao_Funcionario "
        comandoSQL.CommandText &= "ON FF_Registro = EMP_Registro "
        comandoSQL.CommandText &= "INNER JOIN Funcao "
        comandoSQL.CommandText &= "ON FUN_Codigo_Funcao = FF_Codigo_Funcao "
        comandoSQL.CommandText &= "WHERE EMP_Registro = '" & Registro & "' "
        objDataReader = comandoSQL.ExecuteReader()
        objDataReader.Read()
        funcao = objDataReader(0)
        objDataReader.Close()
        fechabd()
        Return funcao
    End Function


    Public Function VerificarRegistro(ByVal Registro As Integer) As Integer
        Dim valor As Integer
        conectabdnew()
        comandoSQL.CommandText = "SELECT FUN_REGISTRO FROM FUNCIONARIO WHERE FUN_REGISTRO = '" & Registro & "' ;"
        objDataReader = comandoSQL.ExecuteReader
        If objDataReader.Read Then
            valor = 1
        Else
            valor = 0
        End If
        objDataReader.Close()
        fechabdnew()

        Return valor
    End Function
    Public Function ValidarTela(ByVal reg As Integer, ByVal num As Integer) As Integer
        Dim var As Integer
        var = 0
        conectabdnew()
        comandoSQL.CommandText = "SELECT ACE_TELA FROM ACESSO WHERE ACE_REGISTRO = '" & reg & "' AND (ACE_TELA = '" & num & "' or ACE_TELA = 99) "
        objDataReader = comandoSQL.ExecuteReader
        If Not objDataReader.Read Then
            var = 1
        End If
        objDataReader.Close()
        fechabdnew()
        Return var
    End Function
    'VERIFICA SE JÁ EXISTE UMA CONFIGURAÇÃO
    Public Function Existe_Configuracao(ByVal PN As String, ByVal Qtd_Pessoas As Integer, ByVal Codigo_Linha As Integer) As Boolean
        Dim var As Boolean
        Dim conexaobd3 As New SqlConnection()
        Dim comandoSQL3 As SqlCommand
        Dim objdatareader3 As SqlDataReader
        var = False
        Try
            conexaobd3.ConnectionString = "server=brspjam-ap07;database=SGM_ONE;uid=sa;pwd=P@ssw0rd"
            conexaobd3.Open()
            comandoSQL3 = New SqlCommand
            comandoSQL3 = conexaobd3.CreateCommand
        Catch ex As Exception
            conexaobd3.Close()
            conexaobd3.ConnectionString = "server=brspjam-ap07;database=SGM_ONE;uid=sa;pwd=P@ssw0rd"
            conexaobd3.Open()
            comandoSQL3 = New SqlCommand
            comandoSQL3 = conexaobd3.CreateCommand
        End Try
        comandoSQL3.CommandText = "SELECT * FROM CONFIGURACAO_LINHA WHERE CL_PART_NUMBER = '" & PN & "' AND CL_QTD_PESSOAS = '" & Qtd_Pessoas & "' AND CL_CODIGO_LINHA = '" & Codigo_Linha & "';"
        objdatareader3 = comandoSQL3.ExecuteReader()
        If objdatareader3.Read Then
            var = True
        End If
        objdatareader3.Close()
        conexaobd3.Close()
        Return var
    End Function

    Public Sub Update_Conf_Linha(ByVal PN As String, ByVal Codigo_Linha As Integer, ByVal Qtd As Integer, ByVal Pessoas As Integer, ByVal tipo As Integer)
        Dim conexaobd2 As New SqlConnection()
        Dim comandoSQL2 As SqlCommand
        Try
            conexaobd2.ConnectionString = "server=brspjam-ap07;database=SGM_ONE;uid=sa;pwd=P@ssw0rd"
            conexaobd2.Open()
            comandoSQL2 = New SqlCommand
            comandoSQL2 = conexaobd2.CreateCommand
        Catch ex As Exception
            conexaobd2.Close()
            conexaobd2.ConnectionString = "server=brspjam-ap07;database=SGM_ONE;uid=sa;pwd=P@ssw0rd"
            conexaobd2.Open()
            comandoSQL2 = New SqlCommand
            comandoSQL2 = conexaobd2.CreateCommand

        End Try
        If tipo = 0 Then
            comandoSQL2.CommandText = "UPDATE CONFIGURACAO_LINHA SET CL_QTD_PECAS = '" & Qtd & "' WHERE CL_CODIGO_LINHA = '" & Codigo_Linha & "' and CL_PART_NUMBER = '" & PN & "' and CL_QTD_PESSOAS = '" & Pessoas & "';"
            comandoSQL2.ExecuteNonQuery()
        Else
            comandoSQL2.CommandText = "INSERT INTO CONFIGURACAO_LINHA VALUES('" & Codigo_Linha & "','" & PN & "', '" & Pessoas & "', '" & Qtd & "','10007');"
            comandoSQL2.ExecuteNonQuery()
        End If
        conexaobd2.Close()

    End Sub
    Public Function PN_Atual(ByVal LINHA As Integer)

        conectabdnew2()

        comandoSQL2.CommandText = "SELECT TOP 1 ORD_PART_NUMBER FROM ORDEM_PRODUCAO WHERE ORD_CODIGO_PLANTA = @Planta AND ORD_CODIGO_LINHA = @Linha AND ORD_STATUS_ORDEM = 'PRODUZINDO';"
        comandoSQL2.Parameters.Add("@Planta", SqlDbType.Int).Value = 10007
        comandoSQL2.Parameters.Add("@Linha", SqlDbType.Int).Value = LINHA
        objDataReader2 = comandoSQL2.ExecuteReader()
        objDataReader2.Read()

        If objDataReader2.HasRows Then
            If Not IsDBNull(objDataReader2.Item(0)) Then
                Return objDataReader2.Item(0)
            Else
                Return "SEM PN"
            End If
        Else
            Return "SEM PN"
        End If
        fechabdnew2()
    End Function

    Public Function DiaDaSemana()
        Dim data As Integer
        conectabdnew()
        comandoSQL.CommandText = "select datepart(weekday,getdate())"
        objDataReader = comandoSQL.ExecuteReader
        objDataReader.Read()
        data = objDataReader(0).ToString()
        Return data
    End Function

    Public Function Mes()
        Dim data As DateTime
        data = DateTime.Now
        Dim mesNumero = data.Month.ToString()
        Dim mesString As String
        'Select Case mesNumero
        '    Case 1
        '        mesString = "Janeiro"
        '    Case 2
        '        mesString = "Janeiro"
        'End Select
        mesString = MESES(mesNumero - 1)



        Return mesString
    End Function

    Public Function gethora()
        conectabdnew2()
        comandoSQL2.CommandText = "select getdate() from Produto"
        objDataReader2 = comandoSQL2.ExecuteReader
        objDataReader2.Read()
        Dim hora = objDataReader2(0)
        objDataReader2.Close()
        Return hora
    End Function

    Public Sub ClearAll(controls As ControlCollection)
        For Each ctrl As Control In controls
            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Text = String.Empty
            ElseIf ctrl.HasControls
                ClearAll(ctrl.Controls)
            End If

            If TypeOf ctrl Is DropDownList Then
                Try
                    CType(ctrl, DropDownList).SelectedIndex = 0
                Catch EX As System.ArgumentOutOfRangeException
                    CType(ctrl, DropDownList).Items.Clear()
                    CType(ctrl, DropDownList).Enabled = False
                End Try
            ElseIf ctrl.HasControls
                ClearAll(ctrl.Controls)
            End If
        Next
    End Sub
    Public Sub EneableAll(controls As ControlCollection, tipo As Boolean)
        For Each ctrl As Control In controls
            If TypeOf ctrl Is DropDownList Then
                CType(ctrl, DropDownList).Enabled = tipo
            ElseIf ctrl.HasControls
                EneableAll(ctrl.Controls, tipo)
            End If

            If TypeOf ctrl Is TextBox Then
                CType(ctrl, TextBox).Enabled = tipo
            ElseIf ctrl.HasControls
                EneableAll(ctrl.Controls, tipo)
            End If
        Next
    End Sub

    Function PintaNãoPreenchido(controls As ControlCollection)

        For Each ctrl As Control In controls
            If TypeOf ctrl Is TextBox Then
                If String.IsNullOrEmpty(CType(ctrl, TextBox).Text) And CType(ctrl, TextBox).ID <> "txtpreg" Then
                    CType(ctrl, TextBox).BackColor = Drawing.Color.Salmon
                    vPreenchimento = 1
                Else
                    CType(ctrl, TextBox).BackColor = Drawing.Color.White
                End If
            ElseIf ctrl.HasControls
                PintaNãoPreenchido(ctrl.Controls)
            End If
        Next
        Return vPreenchimento
    End Function

    Function VerificaBusHE(reg)
        Dim BusHe As Boolean
        conectabdnew()
        comandoSQL.CommandText = "select * from funcionario join TAB_LINHA_HE lhf on FUN_BUS_HE = lhf.id where fun_registro = '" & reg & "'"
        objDataReader = comandoSQL.ExecuteReader()
        If objDataReader.HasRows() Then
            While objDataReader.Read()
                If Not IsDBNull(objDataReader.Item(0)) Then
                    BusHe = True
                Else
                    BusHe = False
                End If
            End While
        Else
            BusHe = False
        End If
        fechabdnew()
        Return BusHe
    End Function
    Function VerificaCadastroEmail(reg)
        conectabdnew()
        comandoSQL.CommandText = "SELECT FUN_EMAIL FROM FUNCIONARIO WHERE FUN_REGISTRO = " & reg
        objDataReader = comandoSQL.ExecuteReader()
        If objDataReader.HasRows() Then
            While objDataReader.Read()
                If Not IsDBNull(objDataReader.Item(0)) Then
                    cadastroEmail = True
                Else
                    cadastroEmail = False
                End If
            End While
        Else
            cadastroEmail = False
        End If
        fechabdnew()
        Return cadastroEmail
    End Function
    Function VerificaEmailFuncionario(reg)
        conectabdnew()
        comandoSQL.CommandText = "SELECT fun_email FROM funcionario WHERE fun_registro in ('" & reg & "')"
        objDataReader = comandoSQL.ExecuteReader()
        If objDataReader.HasRows() Then
            While objDataReader.Read()
                If Not IsDBNull(objDataReader.Item(0)) Then
                    cadastroEmail = True
                Else
                    cadastroEmail = False
                End If
            End While
        Else
            cadastroEmail = False
        End If
        fechabdnew()
        Return cadastroEmail
    End Function
    Public Sub DisparaEmail(ByVal Destinatario, ByVal corpo, ByVal assunto)
        conectabdnew()
        comandoSQL.CommandText = "INSERT INTO Email (EM_ASSUNTO,EM_CORPO,EM_Flag,EM_Destino,EM_Data,EM_Codigo_Planta) "
        comandoSQL.CommandText += "VALUES (@Assunto, @Corpo, 0, @Destinatarios,'" + DateTime.Now + "','10007'); "
        comandoSQL.Parameters.Add("@Corpo", SqlDbType.Text).Value = corpo
        comandoSQL.Parameters.Add("@Destinatarios", SqlDbType.Text).Value = Destinatario
        comandoSQL.Parameters.Add("@Assunto", SqlDbType.Text).Value = assunto
        comandoSQL.ExecuteNonQuery()
        fechabdnew()

    End Sub

    Public Function TipoFuncionario(ByVal registro)
        conectabdnew()
        comandoSQL.CommandText = "SELECT FUN_TIPO FROM FUNCIONARIO WHERE FUN_REGISTRO = '" & registro & "'"
        objDataReader = comandoSQL.ExecuteReader
        objDataReader.Read()
        Try
            Return objDataReader(0)
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Function VerificaPn(ByVal pn As String)
        conectabdnew()
        comandoSQL.CommandText = "SELECT PRO_PART_NUMBER FROM PRODUTO WHERE PRO_PART_NUMBER = '" & pn & "'"
        objDataReader = comandoSQL.ExecuteReader
        objDataReader.Read()
        If objDataReader.HasRows Then
            Return True
        End If
        Return False

    End Function


    'Public Function ItPendente(ByRef registro As Integer)
    '    conexaobd.Close()
    '    Dim area As String
    '    conectabdnew()

    '    comandoSQL.CommandText = "SELECT AREA FROM TAB_APROVA_IT WHERE REGISTRO = '" & registro & "'"
    '    objDataReader = comandoSQL.ExecuteReader
    '    objDataReader.Read()
    '    If objDataReader.HasRows Then
    '        area = objDataReader(0)
    '    Else
    '        Return False
    '    End If
    '    If area = "ENG PROCESSOS" Then
    '        area = area.Replace(" ", "_")
    '    ElseIf area = "SEGURANÇA" Then
    '        area = area.Replace("Ç", "C")
    '    End If
    '    objDataReader.Close()
    '    comandoSQL.CommandText = "SELECT * FROM TAB_AREA_IT WHERE " & area & " = 1"
    '    objDataReader = comandoSQL.ExecuteReader
    '    objDataReader.Read()
    '    If objDataReader.HasRows Then
    '        Return True
    '    End If
    '    Return False
    'End Function

    Public Function getCodigoLinha(ByVal linha As String)
        conectabdnew()
        comandoSQL.CommandText = "SELECT LIN_CODIGO_LINHA FROM LINHA WHERE LIN_STATUS = 0 AND (CONVERT(VARCHAR(4),LIN_CT) + '' + CONVERT(VARCHAR(4),LIN_MAQUINA)) = " + linha + ""
        objDataReader = comandoSQL.ExecuteReader
        If Not objDataReader.Read() Then
            objDataReader.Close()
            Return Nothing
        End If
        Dim codLinha = objDataReader(0)
        objDataReader.Close()
        Return codLinha
        fechabdnew()
    End Function

    Public Function getTurno(ByVal DATA As Date) As Integer
        Dim PERIODO As String = FormatDateTime(DATA, DateFormat.LongTime)
        If PERIODO >= "06:55:00" And PERIODO <= "16:42:59" Then
            Return 1
        ElseIf PERIODO >= "16:43:00" And PERIODO <= "23:59:59" Then
            Return 2
        ElseIf PERIODO >= "00:00:00" And PERIODO <= "01:50:59" Then
            Return 2
        Else
            Return 3
        End If
    End Function

    Public Function TestarConexao() As Boolean
        Dim hostname As String = "10.251.24.11"
        Dim ping As New Ping()

        Try
            Dim reply As PingReply = ping.Send(hostname)
            If reply.Status = IPStatus.Success Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function
End Module
