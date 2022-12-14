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

    public static Region ToRegion(this NewRegionDto newRegionDto)
    {
        return new Region
        { 
            RegionDescription = newRegionDto.Description
        };
    }

    public static Region ToRegion(this RegionDto regionDto)
    {
        return new Region
        {
            RegionId = regionDto.Id!.Value,
            RegionDescription = regionDto.Description
        };
    }
}
