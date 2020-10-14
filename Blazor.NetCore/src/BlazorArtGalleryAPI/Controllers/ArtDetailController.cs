using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorArtGallery.Model;
using BlazorArtGalleryAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorArtGalleryAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ArtDetailController : ControllerBase
  {
    private readonly IArtDetailRepository _ArtDetailRepository;

    public ArtDetailController(IArtDetailRepository artDetailRepository)
    {
      _ArtDetailRepository = artDetailRepository;
    }

    [HttpGet]
    public async Task<ActionResult> GetArtDetails()
    {
      return Ok(await _ArtDetailRepository.GetArtDetails());
    }

    //public IActionResult Index()
    //{
    //  return View();
    //}
  }
}
