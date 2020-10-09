using System;

namespace KritzArtGallery.Interface
{
  interface IArtDetails
  {
    Int32 ID { get; set; }
    string Name { get; set; }
    string Artist { get; set; }
    string DimInch { get; set; }
    string DimCm { get; set; }
    string Description { get; set; }
    decimal Price { get; set; }
    bool Private { get; set; }
    bool Available { get; set; }
    bool SendAFriend { get; set; }
    string ImageSmall { get; set; }
    string ImageLarge { get; set; }
  }
}
