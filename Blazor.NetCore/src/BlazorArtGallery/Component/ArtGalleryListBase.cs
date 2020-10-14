using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using BlazorArtGallery.Model;
using Microsoft.AspNetCore.Components;

namespace BlazorArtGallery.Component
{
  public class ArtGalleryListBase : ComponentBase
  {
    public IEnumerable<ArtDetail> ArtDetails { get; set; }

    protected override async Task OnInitializedAsync()
    {
      await Task.Run(LoadEmployees);
      //return base.OnInitializedAsync();
    }

    #region Service Call
    private void LoadEmployees()
    {
      Thread.Sleep(3000);
      List<ArtDetail> artDetails = new List<ArtDetail>();

      artDetails.Add(new ArtDetail()
      {
        ID = 1,
        Title = "Love Is the Devil",
        ArtistName = "Misti Vanni",
        Description = "vel accumsan tellus nisi eu orci mauris lacinia sapien quis libero",
        //        ArtDimensions = new Dimension()
        //        {
        //          Height = 4,
        //          Width = 4,
        //          MeasureUnits = MeasureUnit.Centimeter
        //        },
        //        ArtPrice = new Price()
        //        {
        //          Amount = 5000d,
        //          Currency = Currency.IndianRupee
        //        },

        Private = true,
        Available = true,
        SendAFriend = true,
        SmallImageUrl = @"images/small-images/Rock_On_Stencil_by_spookyjthm777.jpg",
        LargeImageUrl = @"images/big-images/Rock_On_Stencil_by_spookyjthm777.jpg"
      });
      artDetails.Add(new ArtDetail()
      {
        ID = 2,
        Title = "Way We Laughed, The (Così Ridevano)",
        ArtistName = "Kassi Grist",
        Description = "ipsum ac tellus semper interdum mauris ullamcorper purus sit amet nulla quisque",
        //        ArtDimensions = new Dimension()
        //        {
        //          Height = 4,
        //          Width = 4,
        //          MeasureUnits = MeasureUnit.Centimeter
        //        },
        //        ArtPrice = new Price()
        //        {
        //          Amount = 5000d,
        //          Currency = Currency.IndianRupee
        //        },

        Private = true,
        Available = true,
        SendAFriend = true,
        SmallImageUrl = @"images/small-images/Rock_On_Stencil_by_spookyjthm777.jpg",
        LargeImageUrl = @"images/big-images/Rock_On_Stencil_by_spookyjthm777.jpg"
      });
      artDetails.Add(new ArtDetail()
      {
        ID = 3,
        Title = "Undertaker and His Pals",
        ArtistName = "Mallissa Barhams",
        Description = "fermentum donec ut mauris eget massa tempor convallis nulla neque libero convallis eget eleifend luctus ultricies eu nibh",
        //        ArtDimensions = new Dimension()
        //        {
        //          Height = 4,
        //          Width = 4,
        //          MeasureUnits = MeasureUnit.Centimeter
        //        },
        //        ArtPrice = new Price()
        //        {
        //          Amount = 5000d,
        //          Currency = Currency.IndianRupee
        //        },

        Private = true,
        Available = true,
        SendAFriend = true,
        SmallImageUrl = @"images/small-images/Rock_On_Stencil_by_spookyjthm777.jpg",
        LargeImageUrl = @"images/big-images/Rock_On_Stencil_by_spookyjthm777.jpg"
      });
      artDetails.Add(new ArtDetail()
      {
        ID = 4,
        Title = "Being Elmo: A Puppeteer's Journey",
        ArtistName = "Cathe Pallaske",
        Description = "posuere cubilia curae donec pharetra magna vestibulum aliquet ultrices erat tortor sollicitudin",
        //        ArtDimensions = new Dimension()
        //        {
        //          Height = 4,
        //          Width = 4,
        //          MeasureUnits = MeasureUnit.Centimeter
        //        },
        //        ArtPrice = new Price()
        //        {
        //          Amount = 5000d,
        //          Currency = Currency.IndianRupee
        //        },

        Private = true,
        Available = true,
        SendAFriend = true,
        SmallImageUrl = @"images/small-images/Rock_On_Stencil_by_spookyjthm777.jpg",
        LargeImageUrl = @"images/big-images/Rock_On_Stencil_by_spookyjthm777.jpg"
      });
      artDetails.Add(new ArtDetail()
      {
        ID = 5,
        Title = "Love Is the Devil",
        ArtistName = "Misti Vanni",
        Description = "vel accumsan tellus nisi eu orci mauris lacinia sapien quis libero",
        //        ArtDimensions = new Dimension()
        //        {
        //          Height = 4,
        //          Width = 4,
        //          MeasureUnits = MeasureUnit.Centimeter
        //        },
        //        ArtPrice = new Price()
        //        {
        //          Amount = 5000d,
        //          Currency = Currency.IndianRupee
        //        },

        Private = true,
        Available = true,
        SendAFriend = true,
        SmallImageUrl = @"images/small-images/Rock_On_Stencil_by_spookyjthm777.jpg",
        LargeImageUrl = @"images/big-images/Rock_On_Stencil_by_spookyjthm777.jpg"
      });
      artDetails.Add(new ArtDetail()
      {
        ID = 6,
        Title = "Way We Laughed, The (Così Ridevano)",
        ArtistName = "Kassi Grist",
        Description = "ipsum ac tellus semper interdum mauris ullamcorper purus sit amet nulla quisque",
        //        ArtDimensions = new Dimension()
        //        {
        //          Height = 4,
        //          Width = 4,
        //          MeasureUnits = MeasureUnit.Centimeter
        //        },
        //        ArtPrice = new Price()
        //        {
        //          Amount = 5000d,
        //          Currency = Currency.IndianRupee
        //        },

        Private = true,
        Available = true,
        SendAFriend = true,
        SmallImageUrl = @"images/small-images/Rock_On_Stencil_by_spookyjthm777.jpg",
        LargeImageUrl = @"images/big-images/Rock_On_Stencil_by_spookyjthm777.jpg"
      });
      artDetails.Add(new ArtDetail()
      {
        ID = 7,
        Title = "Undertaker and His Pals",
        ArtistName = "Mallissa Barhams",
        Description = "fermentum donec ut mauris eget massa tempor convallis nulla neque libero convallis eget eleifend luctus ultricies eu nibh",
        //        ArtDimensions = new Dimension()
        //        {
        //          Height = 4,
        //          Width = 4,
        //          MeasureUnits = MeasureUnit.Centimeter
        //        },
        //        ArtPrice = new Price()
        //        {
        //          Amount = 5000d,
        //          Currency = Currency.IndianRupee
        //        },

        Private = true,
        Available = true,
        SendAFriend = true,
        SmallImageUrl = @"images/small-images/Rock_On_Stencil_by_spookyjthm777.jpg",
        LargeImageUrl = @"images/big-images/Rock_On_Stencil_by_spookyjthm777.jpg"
      });
      artDetails.Add(new ArtDetail()
      {
        ID = 8,
        Title = "Being Elmo: A Puppeteer's Journey",
        ArtistName = "Cathe Pallaske",
        Description = "posuere cubilia curae donec pharetra magna vestibulum aliquet ultrices erat tortor sollicitudin",
        //        ArtDimensions = new Dimension()
        //        {
        //          Height = 4,
        //          Width = 4,
        //          MeasureUnits = MeasureUnit.Centimeter
        //        },
        //        ArtPrice = new Price()
        //        {
        //          Amount = 5000d,
        //          Currency = Currency.IndianRupee
        //        },

        Private = true,
        Available = true,
        SendAFriend = true,
        SmallImageUrl = @"images/small-images/Rock_On_Stencil_by_spookyjthm777.jpg",
        LargeImageUrl = @"images/big-images/Rock_On_Stencil_by_spookyjthm777.jpg"
      });

      ArtDetails = artDetails;
    }
    #endregion
  }
}
