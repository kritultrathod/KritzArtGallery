using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorArtGallery.Model;

namespace BlazorArtGalleryAPI.Models
{
  public interface IArtDetailRepository
  {
    Task<IEnumerable<ArtDetail>> GetArtDetails();
    Task<ArtDetail> GetArtDetail(int artDetailId);
    Task<ArtDetail> GetArtDetailByTitle(string title);
    Task<ArtDetail> AddArtDetail(ArtDetail artDetail);
    Task<ArtDetail> UpdateArtDetail(ArtDetail artDetail);
    Task<ArtDetail> DeleteArtDetail(int artDetailId);
  }
}
