using System;
using Microsoft.Maui.Controls;
using Meuevento.Models;

namespace Meuevento.Views;

public partial class Inicial : ContentPage
{
    public Inicial()
    {
        InitializeComponent();
    }

    private void OnComponentes_Changed(object sender, EventArgs e)
    {
        ValidarFormulario();
    }

    private void dtpck_checkin_DateSelected(object sender, DateChangedEventArgs e)
    {
        // Ajusta a data mínima de término baseado no início selecionado
        dtpck_checkout.MinimumDate = dtpck_checkin.Date.AddDays(1);
        ValidarFormulario();
    }

    private void ValidarFormulario()
    {
        if (txt_nome_evento == null || txt_endereco == null || txt_custo_participante == null || btn_avancar == null)
            return;

        bool datasValidas = dtpck_checkout.Date > dtpck_checkin.Date;
        bool participantesValidos = stp_adultos.Value > 0;
        bool nomeValido = !string.IsNullOrWhiteSpace(txt_nome_evento.Text);
        bool localValido = !string.IsNullOrWhiteSpace(txt_endereco.Text);
        bool custoValido = double.TryParse(txt_custo_participante.Text, out double custo) && custo > 0;

        btn_avancar.IsEnabled = datasValidas && participantesValidos && nomeValido && localValido && custoValido;
        btn_avancar.Opacity = btn_avancar.IsEnabled ? 1.0 : 0.5;
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (!double.TryParse(txt_custo_participante.Text, out double custoDigitado))
            {
                await DisplayAlert("Atenção", "Por favor, insira um valor de custo válido.", "Voltar");
                return;
            }

            logica h = new logica
            {
                NomeEvento = txt_nome_evento.Text,
                LocalEvento = txt_endereco.Text,
                QntAdultos = Convert.ToInt32(stp_adultos.Value),
                DataCheckIn = dtpck_checkin.Date,
                DataCheckOut = dtpck_checkout.Date,
                CustoPorParticipante = custoDigitado
            };

            await Navigation.PushAsync(new Evento()
            {
                BindingContext = h
            });
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}