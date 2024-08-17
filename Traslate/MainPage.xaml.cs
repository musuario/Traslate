using Microsoft.Maui.Controls;
using System;
using System.Linq;

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
                    var locales = await TextToSpeech.Default.GetLocalesAsync();
                    var spanishLocale = locales.FirstOrDefault(locale => locale.Language == "es");

                    if (spanishLocale != null)
                    {
                        var settings = new SpeechOptions
                        {
                            Locale = spanishLocale
                        };

                        await TextToSpeech.Default.SpeakAsync(text, settings);
                    }
                    else
                    {
                        await DisplayAlert("Error", "El dispositivo no soporta Text-to-Speech en español.", "OK");
                    }
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
