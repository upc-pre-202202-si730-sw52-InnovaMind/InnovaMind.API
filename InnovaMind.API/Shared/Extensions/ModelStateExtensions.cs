﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
namespace InnovaMind.API.Shared.Extensions;
public static class ModelStateExtensions
{
    public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
    {
        return dictionary.SelectMany(m => m.Value.Errors)
            .Select(m => m.ErrorMessage)
            .ToList();
    }
}