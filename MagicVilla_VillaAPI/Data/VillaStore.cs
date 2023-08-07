using MagicVilla_VillaAPI.Model.Dto;

namespace MagicVilla_VillaAPI.Data;

public static class VillaStore
{
    public static List<VillaDTO> villaList = new List<VillaDTO>
    {
        new VillaDTO { Id = 1, Name = "Pool View", Occupancy = 2, Sqft = 1000 },
        new VillaDTO { Id = 2, Name = "Garden View", Occupancy = 4, Sqft = 2000 },
        new VillaDTO { Id = 3, Name = "Sea View", Occupancy = 6, Sqft = 3000},
        new VillaDTO { Id = 4, Name = "Beach Front", Occupancy = 8, Sqft = 4000}
    };
}