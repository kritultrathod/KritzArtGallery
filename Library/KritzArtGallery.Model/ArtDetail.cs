using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorArtGallery.Model
{
  public class ArtDetail
  {
    public Int32 ID { get; set; }
    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    public string Title { get; set; }
    [Required]
    [MinLength(2)]
    [MaxLength(50)]
    public string ArtistName { get; set; }
    public string Description { get; set; }

    //public Dimension ArtDimensions { get; set; }
    //public Price ArtPrice { get; set; }Dimension

    public bool Private { get; set; }
    public bool Available { get; set; }
    public bool SendAFriend { get; set; }

    [Required]
    public string SmallImageUrl { get; set; }
    [Required]
    public string LargeImageUrl { get; set; }
  }
}