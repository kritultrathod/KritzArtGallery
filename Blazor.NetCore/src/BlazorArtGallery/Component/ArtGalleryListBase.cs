using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public int OnInitializedCount { get; set; }
    public int OnParametersSetCount { get; set; }
    public int OnAfterRenderCount { get; set; }

    public IEnumerable<ArtDetail> ArtDetails { get; set; }

    [Inject]
    public IArtDetailService _artDetailService { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    #region  ComponentlifeCycle
    protected override async Task OnInitializedAsync()
    {
      OnInitializedCount++;
      ArtDetails = (await _artDetailService.GetArtDetails()).ToList();

      Debug.WriteLine($@"KTR:OnInitializedCount: {OnInitializedCount}");
    }

    protected override Task OnParametersSetAsync()
    {
      OnParametersSetCount++;

      Debug.WriteLine($@"KTR:OnParametersSetCount: {OnParametersSetCount}");

      return base.OnParametersSetAsync();
    }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
      OnAfterRenderCount++;

      Debug.WriteLine($@"KTR:OnAfterRenderCount: {OnAfterRenderCount}");

      return base.OnAfterRenderAsync(firstRender);
    }

    #endregion

    protected void Mouse_Down(MouseEventArgs e, object id)
    {

      NavigationManager.NavigateTo($"/artgallerydetails/{id}", true);
    }
  }
}
