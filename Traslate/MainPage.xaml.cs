using Microsoft.Maui.Controls;
using System;

namespace Traslate
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnReadButtonClicked(object sender, EventArgs e)
        {
            string text = TextEditor.Text;

            if (!string.IsNullOrWhiteSpace(text))
            {
                try
                {
                    await TextToSpeech.Default.SpeakAsync(text);
                }
                catch (Exception ex)
                {
                    await DisplayAlert("Error", $"Text-to-Speech no es compatible o ocurrió un error: {ex.Message}", "OK");
                }
            }
            else
            {
                await DisplayAlert("Aviso", "Por favor, ingresa un texto.", "OK");
            }
        }
    }
}
