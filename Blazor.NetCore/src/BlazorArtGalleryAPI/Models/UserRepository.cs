using BlazorArtGalleryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlazorArtGalleryAPI.Models
{
  public class UserRepository : IUserRepository
  {
    IEnumerable<User> users = new List<User>();

    public UserRepository()
    {
      users = new List<User>()
      {
        new User()
        {
          UserId = 1,
          EmailAddress = "kritul1@blazorartgallery.com",
          FirstName = "Kritul1",
          MiddleName = "T",
          LastName = "Rathod",
          PubId = 1,
          HireDate = new DateTime(2020,01,01)
        },
        new User()
        {
          UserId = 2,
          EmailAddress = "kritul2@blazorartgallery.com",
          FirstName = "Kritul2",
          MiddleName = "T",
          LastName = "Rathod",
          PubId = 1,
          HireDate = new DateTime(2020,01,01)
        }
      };
    }

    public async Task<User> GetUserAsync(int id)
    {
      return await Task.FromResult(users.Where(u => u.UserId == id).FirstOrDefault());
    }

    public async Task SaveUserAsync(User user)
    {
      await Task.Run(() =>
      {
        SaveUser(user);
      });
    }

    public void SaveUser(User user)
    {
      var dbUser = users.Where(u => u.UserId == user.UserId).FirstOrDefault();
      if (dbUser != null)
      {
        dbUser.RefreshTokens = user.RefreshTokens;
      }
    }
  }
}
