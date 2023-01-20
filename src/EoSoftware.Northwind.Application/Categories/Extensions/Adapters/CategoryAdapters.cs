using EoSoftware.Northwind.Domain;

namespace EoSoftware.Northwind.Application;

public static class CategoryAdapters
{
    public static CategoryDto ToCategoryDto(this Category category)
    {
        return new CategoryDto
        { 
            Id = category.CategoryId, 
            Name = category.CategoryName,
            Description = category.Description,
        };
    }

    public static Category ToCategory(this NewCategoryDto newCategoryDto)
    {
        return new Category
        { 
            CategoryName = newCategoryDto.Name,
            Description = newCategoryDto.Description,
        };
    }

    public static Category ToCategory(this CategoryDto categoryDto)
    {
        return new Category
        { 
            CategoryId = categoryDto.Id!.Value,
            CategoryName = categoryDto.Name,
            Description = categoryDto.Description,
        };
    }
}
