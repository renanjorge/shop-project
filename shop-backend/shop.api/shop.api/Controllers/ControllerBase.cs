using Microsoft.AspNetCore.Mvc;

namespace shop.api.Controllers;

public abstract class ControllerBase : Controller 
{ 
    protected CreatedAtActionResult Created<T>(T value, string? actionName = null)
    {
        return CreatedAtAction(actionName, value);
    }
}