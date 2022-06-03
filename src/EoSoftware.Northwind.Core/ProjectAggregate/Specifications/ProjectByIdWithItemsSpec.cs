﻿using Ardalis.Specification;
using EoSoftware.Northwind.Core.ProjectAggregate;

namespace EoSoftware.Northwind.Core.ProjectAggregate.Specifications;

public class ProjectByIdWithItemsSpec : Specification<Project>, ISingleResultSpecification
{
  public ProjectByIdWithItemsSpec(int projectId)
  {
    Query
        .Where(project => project.Id == projectId)
        .Include(project => project.Items);
  }
}