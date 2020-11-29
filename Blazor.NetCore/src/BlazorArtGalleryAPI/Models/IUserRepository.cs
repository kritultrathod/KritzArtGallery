using BlazorArtGalleryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorArtGalleryAPI.Models
{
  public interface IUserRepository
  {
    public Task<User> GetUserAsync(int id);
    public Task SaveUserAsync(User user);
  }
}
