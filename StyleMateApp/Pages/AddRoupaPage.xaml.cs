using Microsoft.Maui.Media;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace StyleMateApp.Pages;

public partial class AddRoupaPage : ContentPage
{
    private FileResult _fotoSelecionada;
    private readonly HttpClient _http = new();

    public AddRoupaPage()
    {
        InitializeComponent();
        _http.BaseAddress = new Uri("https://teu-backend.azurewebsites.net/");
    }
    private async void SelecionarImagem_Clicked(object sender, EventArgs e)
    {
        var foto = await MediaPicker.PickPhotoAsync();

        if (foto != null)
        {
            _fotoSelecionada = foto;
            PreviewImage.Source = ImageSource.FromFile(foto.FullPath);
        }
    }
    private async void Guardar_Clicked(object sender, EventArgs e)
    {
        if (_fotoSelecionada == null)
        {
            await DisplayAlert("Erro", "Selecione uma imagem primeiro.", "OK");
            return;
        }

        // 1. Upload da imagem
        using var stream = await _fotoSelecionada.OpenReadAsync();

        var content = new MultipartFormDataContent();
        var fileContent = new StreamContent(stream);
        fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

        content.Add(fileContent, "file", _fotoSelecionada.FileName);

        var uploadResponse = await _http.PostAsync("api/roupa/upload", content);
        if (!uploadResponse.IsSuccessStatusCode)
        {
            await DisplayAlert("Erro", "Falha ao enviar a imagem.", "OK");
            return;
        }

        var result = JsonSerializer.Deserialize<Dictionary<string, string>>(
            await uploadResponse.Content.ReadAsStringAsync());

        string imageUrl = result["url"];

        // 2. Guardar na BD

        var roupa = new
        {
            Nome = NomeEntry.Text,
            CorUser = CorEntry.Text,
            Foto = imageUrl,
            IdUtilizador = 1
        };

        var json = new StringContent(JsonSerializer.Serialize(roupa), Encoding.UTF8, "application/json");

        var response = await _http.PostAsync("api/roupa", json);

        if (response.IsSuccessStatusCode)
        {
            await DisplayAlert("OK", "Roupa guardada!", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Erro", "Erro ao guardar roupa.", "OK");
        }
    }
}

