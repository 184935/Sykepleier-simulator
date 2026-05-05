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
        var response = await _client.GetFromJsonAsync<Vitals>($"api/Case/vitals/{id}");
        return response;
    }
    public async Task<Debrief?> GetDebrief()
    {
        return await _client.GetFromJsonAsync<Debrief>("api/Case/lastdebrief");
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

    public async Task<List<Event>> GetEvents(int debid)
    {
        try
        {
            return await _client.GetFromJsonAsync<List<Event>>($"api/Case/events/{debid}");
        } catch (HttpRequestException ex)
        {
            return null;
        }
    }

    public async Task<object> AddComment(Comment comment, int debid)
    {
        await _client.PostAsJsonAsync($"api/Case/addcomment/{debid}", comment);
        return null;
    }
    public async Task<object> AddEvent(Event _event, int debid)
    {
        await _client.PostAsJsonAsync($"api/Case/addevent/{debid}", _event);
        return null;
    }

    public async Task<Case?> GetCase(int caseId)
    {
        try
        {
            return await _client.GetFromJsonAsync<Case>($"api/Case/{caseId}");
        }
        catch (HttpRequestException ex)
        {
            return null;
        }
    }
    public async Task<object> AddVitals(Vitals vitals)
    {
        await _client.PostAsJsonAsync("api/Case/addvitals", vitals);
        return null;
    }
    public async Task<object> ChangeVitals(Vitals vitals)
    {
        await _client.PostAsJsonAsync("api/Case/changevitals", vitals);
        return null;
    }

    public async Task<StartsimDTO?> StartSim(int caseId, Event eventStart) 
    {
        var response = await _client.PostAsJsonAsync($"api/Case/startsim/{caseId}", eventStart);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<StartsimDTO>();
        }
        return null;

    }
    public async Task<object> StopSim(int vitalsId, int debId, Event eventStop)
    {
        await _client.PostAsJsonAsync($"api/Case/stopsim/{vitalsId}/{debId}", eventStop);
        return null;
    }

}
