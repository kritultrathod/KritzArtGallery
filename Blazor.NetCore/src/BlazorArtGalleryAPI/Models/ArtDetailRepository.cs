using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using BlazorArtGallery.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorArtGalleryAPI.Models
{
  public class ArtDetailRepository : IArtDetailRepository
  {
    private readonly AppDbContext _AppDbContext;

    public ArtDetailRepository(AppDbContext appDbContext)
    {
      _AppDbContext = appDbContext;
    }

    public async Task<IEnumerable<ArtDetail>> GetArtDetails()
    {
      return await _AppDbContext.ArtDetail.ToListAsync();
    }

    public async Task<IEnumerable<ArtDetail>> Search(string title, string artistName)
    {
      IQueryable<ArtDetail> query = _AppDbContext.ArtDetail;

      if (!string.IsNullOrEmpty(title))
      {
        query = query.Where(x => x.Title.Contains(title));
      }

      if (!string.IsNullOrEmpty(artistName))
      {
        query = query.Where(x => x.ArtistName.Contains(artistName));
      }
      
      return await query.ToListAsync();
    }

    public async Task<ArtDetail> GetArtDetail(int artDetailId)
    {
      return await _AppDbContext.ArtDetail.FirstOrDefaultAsync(e => e.ID == artDetailId);
    }

    public async Task<ArtDetail> GetArtDetailByTitle(string title)
    {
      return await _AppDbContext.ArtDetail.FirstOrDefaultAsync(e => e.Title == title);
    }

    public async Task<ArtDetail> AddArtDetail(ArtDetail artDetail)
    {
      var result = await _AppDbContext.ArtDetail.AddAsync(artDetail);
      await _AppDbContext.SaveChangesAsync();
      return result.Entity;
    }

    public async Task<ArtDetail> UpdateArtDetail(ArtDetail artDetail)
    {
      var result = await _AppDbContext.ArtDetail.FirstOrDefaultAsync(e => e.ID == artDetail.ID);

      if (result == null)
      {
        return null;
      }

      result.Title = artDetail.Title;
      result.ArtistName = artDetail.ArtistName;
      result.Description = artDetail.Description;
      result.Private = artDetail.Private;
      result.Available = artDetail.Available;
      result.SendAFriend = artDetail.SendAFriend;
      result.SmallImageUrl = artDetail.SmallImageUrl;
      result.LargeImageUrl = artDetail.LargeImageUrl;

      await _AppDbContext.SaveChangesAsync();

      return result;
    }

    //TODO: remove async void here, handle error
    public async Task<ArtDetail> DeleteArtDetail(int artDetailId)
    {
      var result = await _AppDbContext.ArtDetail.FirstOrDefaultAsync(e => e.ID == artDetailId);
      if (result == null)
        return null;

      _AppDbContext.ArtDetail.Remove(result);

      await _AppDbContext.SaveChangesAsync();
      return result;
    }
  }
}
