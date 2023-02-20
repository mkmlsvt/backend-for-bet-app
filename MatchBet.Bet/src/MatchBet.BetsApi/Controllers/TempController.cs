using System.Runtime.InteropServices;
using MatchBet.BetsApi.Entities;
using MatchBet.BetsApi.Entities.Bet;
using MatchBet.BetsApi.Helper;
using MatchBet.BetsApi.Options;
using MatchBet.BetsApi.Repositories;
using MatchBet.BetsApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace MatchBet.BetsApi.Controllers;

[ApiController]
[Route("temp")]
public class TempController : ControllerBase
{
    public TempController()
    {
    }

    [Route("")]
    [HttpGet]
    public async Task<IActionResult> GetFixturesByDate()
    {
        var client = new RestClient("http://player-app-lb:2424");
        var request = new RestRequest("players/temp");
        var response = await client.GetAsync(request).ConfigureAwait(false);
        Console.WriteLine(response.StatusCode);
        if (response.IsSuccessful is false)
        {
            return Ok("lele "+  response.Content);
        }
        return Ok("Bağlantı Başarılı. Response ===> "+ response.Content);
    }
}