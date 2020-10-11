using System;

namespace KritzArtGallery.Model
{
  public class ArtDetails
  {
    public Int32 ID { get; set; }
    public string Title { get; set; }
    public string ArtistName { get; set; }
    public string Description { get; set; }

    public Dimension ArtDimensions { get; set; }
    public Price ArtPrice { get; set; }

    public bool Private { get; set; }
    public bool Available { get; set; }
    public bool SendAFriend { get; set; }
    public string ImageSmall { get; set; }
    public string ImageLarge { get; set; }
  }
}