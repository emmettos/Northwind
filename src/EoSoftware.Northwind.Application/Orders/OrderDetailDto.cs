using System.ComponentModel.DataAnnotations;

namespace EoSoftware.Northwind.Application;

public class OrderDetailDto
{   
    [Required]
    public short OrderId { get; set; }
    [Required]
    public short ProductId { get; set; }
    [Required]
    public float UnitPrice { get; set; }
    [Required]
    public short Quantity { get; set; }
    public float Discount { get; set; }
}

// public class OrderDto : NewOrderDto
// {
//     [Required]
//     [Range(1, 999999999)]
//     public short? Id { get; set; }
// }
