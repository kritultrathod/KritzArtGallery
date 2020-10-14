using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorArtGallery.Model;

namespace BlazorArtGallery.Services
{
  public interface IArtDetailService
  {
    Task<IEnumerable<ArtDetail>> GetArtDetails();
  }
}
