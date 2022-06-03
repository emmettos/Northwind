﻿using Ardalis.Result;
using EoSoftware.Northwind.Core.ProjectAggregate;

namespace EoSoftware.Northwind.Core.Interfaces;

public interface IToDoItemSearchService
{
  Task<Result<ToDoItem>> GetNextIncompleteItemAsync(int projectId);
  Task<Result<List<ToDoItem>>> GetAllIncompleteItemsAsync(int projectId, string searchString);
}
