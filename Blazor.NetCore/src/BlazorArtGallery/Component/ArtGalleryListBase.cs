using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using BlazorArtGallery.Model;
using BlazorArtGallery.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http.Extensions;

namespace BlazorArtGallery.Component
{
  public class ArtGalleryListBase : ComponentBase
  {
    public IEnumerable<ArtDetail> ArtDetails { get; set; }

    [Inject]
    public IArtDetailService _artDetailService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    protected override async Task OnInitializedAsync()
    {
      ArtDetails = (await _artDetailService.GetArtDetails()).ToList();
    }

    protected void Mouse_Down(MouseEventArgs e, object id)
    {

      NavigationManager.NavigateTo($"/artgallerydetails/{id}", true);
    }
  }
}
