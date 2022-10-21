using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public static class RegionAdapters
{
    public static RegionDto ToRegionDto(this Region region)
    {
        return new RegionDto
        { 
            Id = region.RegionId, 
            Description = region.RegionDescription
        };
    }
}