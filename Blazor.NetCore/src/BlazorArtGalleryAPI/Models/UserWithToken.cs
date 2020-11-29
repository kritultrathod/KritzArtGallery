using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace BlazorArtGalleryAPI.Models
{
  public class UserWithToken : User
  {

    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }

    public UserWithToken(User user)
    {
      this.UserId = user.UserId;
      this.EmailAddress = user.EmailAddress;
      this.FirstName = user.FirstName;
      this.MiddleName = user.MiddleName;
      this.LastName = user.LastName;
      this.PubId = user.PubId;
      this.HireDate = user.HireDate;

      this.Role = user.Role;
    }
  }

  public partial class User
  {
    public User()
    {
      RefreshTokens = new HashSet<RefreshToken>();
    }

    public int UserId { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public string Source { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string LastName { get; set; }
    public short RoleId { get; set; }
    public int PubId { get; set; }
    public DateTime? HireDate { get; set; }

    //public virtual Publisher Pub { get; set; }
    public virtual Role Role { get; set; }
    public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
  }

  public partial class RefreshToken
  {
    public int TokenId { get; set; }
    public int UserId { get; set; }
    public string Token { get; set; }
    public DateTime ExpiryDate { get; set; }

    public virtual User User { get; set; }
  }

  public partial class Role
  {
    public Role()
    {
      Users = new HashSet<User>();
    }

    public short RoleId { get; set; }
    public string RoleDesc { get; set; }

    public virtual ICollection<User> Users { get; set; }
  }
}
