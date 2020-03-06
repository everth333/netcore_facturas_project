using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace NetCore.Infraestructure.Persistence.Config
{
    public static class InvalidModelStateResponseFactory
    {
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            var errors = context.ModelState
                                .SelectMany(m => m.Value.Errors)
                                .Select(m => m.ErrorMessage)
                                .ToList();

            var response = new WebAPI.Controllers.Resources.ErrorResource(messages: errors);
            return new BadRequestObjectResult(response);
        }

    }
}
