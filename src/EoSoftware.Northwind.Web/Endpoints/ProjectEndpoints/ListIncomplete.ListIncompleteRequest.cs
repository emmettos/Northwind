using Microsoft.AspNetCore.Mvc;

namespace EoSoftware.Northwind.Web.Endpoints.ProjectEndpoints;

public class ListIncompleteRequest
{
  [FromRoute]
  public int ProjectId { get; set; }
  [FromQuery]
  public string SearchString { get; set; }
}
