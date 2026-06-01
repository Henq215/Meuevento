using System;
using Microsoft.Maui.Controls;

namespace Meuevento.Views;

public partial class Evento : ContentPage
{
    public Evento()
    {
        InitializeComponent();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}