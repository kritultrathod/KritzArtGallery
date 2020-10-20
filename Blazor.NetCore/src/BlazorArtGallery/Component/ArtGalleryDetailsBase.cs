using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using BlazorArtGallery.Model;
using BlazorArtGallery.Services;
using Microsoft.AspNetCore.Components;

namespace BlazorArtGallery.Component
{
  public class ArtGalleryDetailsBase : ComponentBase
  {
    public ArtDetail ArtDetail { get; set; } = new ArtDetail();

    [Inject]
    public IArtDetailService ArtDetailService { get; set; }

    [Parameter]
    public string Id { get; set; }

    protected override async Task OnInitializedAsync()
    {
      Id = Id ?? "1";
      ArtDetail = await ArtDetailService.GetArtDetails(int.Parse(Id));
    }
  }
}
