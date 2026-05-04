using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using Microsoft.IdentityModel.Tokens;
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

    public async Task<List<Debrief>> Debriefs()
    {
        var response = await _client.GetFromJsonAsync<List<Debrief>>("api/Case/debriefs");
        if (response.IsNullOrEmpty()) { return null; }
        return response;
    }

    public async Task<Vitals> Vitals(int id)
    {
        var response = await _client.GetFromJsonAsync<Vitals>($"api/vitals/{id}");
        return response;
    }

    public async Task<ChecksimDTO?> Checksim()
    {
        try
        {
            return await _client.GetFromJsonAsync<ChecksimDTO>("api/Case/checksim");
        }
        catch (HttpRequestException ex)
        {
            return null;
        }
    }

    public async void AddComment(Comment comment, int debid)
    {
        await _client.PostAsJsonAsync($"api/Case/addcomment/{debid}", comment);
    }
    public async void AddEvent(Event _event, int debid)
    {
        await _client.PostAsJsonAsync($"api/Case/addevent/{debid}", _event);
    }
}
