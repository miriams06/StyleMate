using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http.Json;
using System.Text.RegularExpressions;
using StyleMateApp.Models;

namespace StyleMateApp.Services
{
    public class ApiService
    {
        private readonly HttpClient _http = new()
        {
            BaseAddress = new Uri("https://localhost:5001/api/")
        };

        public async Task<List<Roupa>> GetRoupasAsync(int idUtilizador)
        {
            var result = await _http.GetFromJsonAsync<List<Roupa>>($"Roupas/byUser/{idUtilizador}");
            return result ?? new List<Roupa>();
        }
    }
}


