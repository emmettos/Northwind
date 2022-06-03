using System.ComponentModel.DataAnnotations;

namespace EoSoftware.Northwind.Web.Endpoints.ProjectEndpoints;

public class CreateProjectRequest
{
  public const string Route = "/Projects";

  [Required]
  public string? Name { get; set; }
}
