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
      //TODO: add model validation before proceeding 
      try
      {
        if (artDetail == null)
        {
          return BadRequest();
        }

        // TODO: make it idempotent (Created or retrieved)
        var result = await _ArtDetailRepository.GetArtDetailByTitle(artDetail.Title);
        if (result != null)
        {
          ModelState.AddModelError("Title", $@"Artifact with title {artDetail.Title} is already present");
          return BadRequest(ModelState);
        }

        var createdArtDetail = await _ArtDetailRepository.AddArtDetail(artDetail);
        return CreatedAtAction(nameof(GetArtDetail), new { id = createdArtDetail.ID }, createdArtDetail);
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return StatusCode(StatusCodes.Status500InternalServerError, $@"Error creating Art Detail with Title {artDetail.Title}.");
      }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<ArtDetail>> UpdateArtDetail(int id, ArtDetail artDetail)
    {
      try
      {
        if (id != artDetail.ID)
        {
          return BadRequest("Art Detail ID mismatch");
        }

        var result = await _ArtDetailRepository.GetArtDetail(id);

        if (result == null)
        {
          return NotFound();
        }

        return await _ArtDetailRepository.UpdateArtDetail(artDetail);

      }
      catch (Exception e)
      {
        LogException(e);
        return StatusCode(StatusCodes.Status500InternalServerError, $@"Error updating Art Detail for id {id} into database");
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
