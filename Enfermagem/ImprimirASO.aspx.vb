Public Class ImprimirASO
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lbltipo.Text = Modulo.tipoaso
        lblreg.Text = Modulo.regaso
        lblnome.Text = Modulo.nomeaso
        lblcpf.Text = Modulo.cpfaso
        lblidade.Text = Modulo.idadeaso
        lblconsiderado.Text = Modulo.consideradoaso
        lblfuncao.Text = Modulo.funcaoaso
        lblobs.Text = Modulo.obsaso
        lblarea.Text = Modulo.areaaso
        lbldata.Text = Modulo.dataaso

        If Modulo.tipoaso = "DEMISSIONAL" Then
            Panel12.Visible = False
            cbdemi.Checked = True
        End If

        If Modulo.tipoaso = "PERIÓDICO" Then
            cbperi.Checked = True
        End If

        If Modulo.tipoaso = "RETORNO AO TRABALHO" Then
            cbreturn.Checked = True
        End If

        If Modulo.tipoaso = "MUDANÇA DE RISCO OPERACIONAL" Then
            cbmud.Checked = True
        End If

        If Modulo.cbageb = cbageb.Text Then
            cbageb.Checked = True
        End If

        If Modulo.cbaci = cbaci.Text Then
            cbaci.Checked = True
        End If

        If Modulo.cbageq = cbageq.Text Then
            cbageq.Checked = True
        End If

        If Modulo.cberg = cberg.Text Then
            cberg.Checked = True
        End If

        If Modulo.cbausrisc = cbausrisc.Text Then
            cbausrisc.Checked = True
        End If

        If Modulo.cblab = cblab.Text Then
            cblab.Checked = True
            datalab.Text = Modulo.datalab
        End If

        If Modulo.cbtox = cbtox.Text Then
            cbtox.Checked = True
            datatox.Text = Modulo.datatox
        End If

        If Modulo.cbeeg = cbeeg.Text Then
            cbeeg.Checked = True
            dataeeg.Text = Modulo.dataeeg
        End If

        If Modulo.cbecg = cbecg.Text Then
            cbecg.Checked = True
            dataecg.Text = Modulo.dataecg
        End If

        If Modulo.txtoutros > "" Then
            cboutros.Checked = True
            txtoutros.Text = Modulo.txtoutros
        End If

        If Modulo.cbradio = cbradio.Text Then
            cbradio.Checked = True
            dataradio.Text = Modulo.dataradio
        End If

        If Modulo.cbespiro = cbespiro.Text Then
            cbespiro.Checked = True
            dataespiro.Text = Modulo.dataespiro
        End If

        If Modulo.cbacui = cbacui.Text Then
            cbacui.Checked = True
            dataacui.Text = Modulo.dataacui
        End If

        If Modulo.cbaudio = cbaudio.Text Then
            cbaudio.Checked = True
            dataaudio.Text = Modulo.dataaudio
        End If
    End Sub

End Class