using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using SharedLibrary.Models;

namespace SharedLibrary.Models;

public class Apiservice
{
    private readonly HttpClient _client;

    public Apiservice()
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7091/")
        };
    }
    public async Task<Case?> Login(LoginDTO loginDTO)
    {
        var response = await _client.PostAsJsonAsync("api/auth/login", loginDTO);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<Case?>();

        }
        return null;
    }
}
