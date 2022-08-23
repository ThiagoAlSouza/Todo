﻿using System.Linq.Expressions;
using Todo.Domain.Entities;

namespace Todo.Domain.Queries;

public static class TodoQueries
{
    #region Methods

    public static Expression<Func<TodoItem, bool>> GetAll(string user)
    {
        return x => x.User == user;
    }

    public static Expression<Func<TodoItem, bool>> GetAllDone(string user)
    {
        return x => x.User == user && x.Done;
    }

    public static Expression<Func<TodoItem, bool>> GetAllUnDone(string user)
    {
        return x => x.User == user && !x.Done;
    }

    #endregion
}