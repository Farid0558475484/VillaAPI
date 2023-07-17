using MagicVilla_VillaAPI.Model.Dto;

namespace MagicVilla_VillaAPI.Data;

public static class VillaStore
{
    public static List<VillaDTO> villaList = new List<VillaDTO>
    {
        new VillaDTO { Id = 1, Name = "Pool View" },
        new VillaDTO { Id = 2, Name = "Garden View" },
        new VillaDTO { Id = 3, Name = "Sea View" },
        new VillaDTO { Id = 4, Name = "Beach Front" }
    };
}