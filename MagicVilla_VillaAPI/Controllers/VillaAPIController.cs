using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Model.Dto;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers;
[Route("api/VillaAPI")]
[ApiController]
public class VillaAPIController: ControllerBase
{
    [HttpGet]
    [ProducesResponseType(200)]
    
    public ActionResult<IEnumerable<VillaDTO>> GetVillas()
    {
        return Ok(VillaStore.villaList);
    }
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(404)]
    [ProducesResponseType(400)]
    public ActionResult<IEnumerable<VillaDTO>> GetVilla(int id)
    {
        if (id == 0)
        {
            return BadRequest();
        }
        
        var villa= VillaStore.villaList.FirstOrDefault(x => x.Id == id);
        
        if (villa == null)
        {
            return NotFound();
        }
        return Ok(villa);
    }
    
    
}