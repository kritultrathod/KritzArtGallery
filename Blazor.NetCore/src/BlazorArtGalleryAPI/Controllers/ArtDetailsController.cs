using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BlazorArtGalleryAPI.Controllers
{
  public class ArtDetailsController : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}
