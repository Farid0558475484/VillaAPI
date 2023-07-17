using MagicVilla_VillaAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace MagicVilla_VillaAPI.Controllers;
[Route("api/VillaAPI")]
[ApiController]
public class VillaAPIController: ControllerBase
{
    [HttpGet]
    public IEnumerable<Villa> GetVillas()
    {
        return new List<Villa>
        {
            new Villa { Id = 1, Name = "Pool View" },
            new Villa { Id = 2, Name = "Garden View" },
            new Villa { Id = 3, Name = "Sea View" },
            new Villa { Id = 4, Name = "Beach Front" }
        };

    }
}