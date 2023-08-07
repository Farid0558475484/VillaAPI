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
    
    [HttpGet("{id:int}", Name = "GetVilla")]
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

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public ActionResult<VillaDTO> CreateVilla([FromBody] VillaDTO villaDto)
    {
        // if(!ModelState.IsValid )
        // {
        //     return BadRequest(ModelState);
        // }
        if(VillaStore.villaList.FirstOrDefault(u=>u.Name.ToLower()==villaDto.Name.ToLower())!=null)
        {
            ModelState.AddModelError("", $"Villa {villaDto.Name} already exists");
            return BadRequest(ModelState);
        }
   
        if (villaDto == null)
        {
            return BadRequest(villaDto);
        }

        if (villaDto.Id > 0)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
        
        villaDto.Id = VillaStore.villaList.Max(x => x.Id) + 1;
        
        VillaStore.villaList.Add(villaDto);
        return CreatedAtRoute("GetVilla", new {id=villaDto.Id},villaDto);
    }
    
    
    [HttpDelete("{id:int}", Name = "DeleteVilla")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    public ActionResult<VillaDTO> DeleteVilla(int id)
    {
        if (id == null)
        {
            return BadRequest();
        }

      
        
        var villa = VillaStore.villaList.FirstOrDefault(x => x.Id == id);
        
        if (villa == null)
        {
            return NotFound();
        }
        
        VillaStore.villaList.Remove(villa);
        return NoContent();
    }



    [HttpPut("{id:int}", Name = "UpdateVilla")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    

    public ActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDto)
    {
        if (villaDto == null || id != villaDto.Id)
        {
            return BadRequest();
        }
        
        var villa = VillaStore.villaList.FirstOrDefault(x => x.Id == id);
        villa.Name = villaDto.Name;
        villa.Occupancy = villaDto.Occupancy;
        villa.Sqft = villaDto.Sqft;
        return NoContent();
    }
    

}