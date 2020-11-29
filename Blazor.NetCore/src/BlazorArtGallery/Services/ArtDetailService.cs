using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorArtGallery.Model;
using Microsoft.AspNetCore.Components;

namespace BlazorArtGallery.Services
{
  public class ArtDetailService : IArtDetailService
  {
    private readonly HttpClient _HttpClient;

    public ArtDetailService(HttpClient httpClient)
    {
      _HttpClient = httpClient;
    }

    public async Task<IEnumerable<ArtDetail>> GetArtDetails()
    {
      await Task.Delay(1000);
      return await _HttpClient.GetJsonAsync<IEnumerable<ArtDetail>>("api/ArtDetails");
    }

    public async Task<ArtDetail> GetArtDetails(int Id)
    {
      await Task.Delay(1000);
      return await _HttpClient.GetJsonAsync<ArtDetail>($"api/ArtDetails/{Id}");
    }
  }
}
