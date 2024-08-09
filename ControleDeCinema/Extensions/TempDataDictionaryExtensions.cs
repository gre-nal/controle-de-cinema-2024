using System.Text.Json;
using ControleDeCinema.WebApp.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ControleDeCinema.WebApp.Extensions
{
    public static class TempDataDictionaryExtensions
    {
        public static void SerializarMensagemViewModel
        (
            this ITempDataDictionary dicionario, MensagemViewModel mensagemVm
        )
        {
            dicionario["Mensagem"] = JsonSerializer.Serialize(mensagemVm);
        }

        public static MensagemViewModel ? DesserializarMensagemViewModel(this ITempDataDictionary dicionario)
        {
            string ? mensagemStr = dicionario["Mensagem"]?.ToString();

            if (mensagemStr is null) return null;

            return JsonSerializer.Deserialize<MensagemViewModel>(mensagemStr);
        }
    }
}
