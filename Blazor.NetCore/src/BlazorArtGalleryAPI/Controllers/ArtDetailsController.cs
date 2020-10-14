using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorArtGallery.Model;
using BlazorArtGalleryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorArtGalleryAPI.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ArtDetailsController : ControllerBase
  {
    private readonly IArtDetailRepository _ArtDetailRepository;

    public ArtDetailsController(IArtDetailRepository artDetailRepository)
    {
      _ArtDetailRepository = artDetailRepository;
    }

    [HttpGet]
    public async Task<ActionResult> GetArtDetails()
    {
      try
      {
        return Ok(await _ArtDetailRepository.GetArtDetails());
      }
      catch (Exception e)
      {
        LogException(e);
        return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving Art Details from database");
      }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ArtDetail>> GetArtDetail(int id)
    {
      try
      {
        var result = await _ArtDetailRepository.GetArtDetail(id);

        if (result == null)
        {
          return NotFound();
        }

        return result;
      }
      catch (Exception e)
      {
        LogException(e);
        return StatusCode(StatusCodes.Status500InternalServerError, $@"Error retrieving Art Detail for id {id} from database");
      }
    }

    public async Task<ActionResult<ArtDetail>> AddArtDetail(ArtDetail artDetail)
    {
      try
      {
        if (artDetail == null)
        {
          return BadRequest();
        }

        var createdArtDetail = await _ArtDetailRepository.AddArtDetail(artDetail);
        return CreatedAtAction(nameof(GetArtDetail), new { id = createdArtDetail .ID}, createdArtDetail);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    private static void LogException(Exception e)
    {
      if (e != null)
      {
        Console.WriteLine(e.Message);
        Console.WriteLine(e.StackTrace);
        if (e.InnerException != null) { }
        {
          Console.WriteLine();
          LogException(e.InnerException);
        }
      }
    }
  }
}
