using FluentValidation;
using GymManagmentApplication.Application.Common;
using GymManagmentApplication.Application.Trainer.Interfaces;
using GymManagmentApplication.Application.Trainer.Requests;
using Microsoft.AspNetCore.Mvc;

namespace GymManagmentApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TrainerController(ITrainerService service, IValidator<CreateTrainerRequest> validator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<ApiResponse<object>>> Create([FromBody] CreateTrainerRequest request)
    {
        var validation = await validator.ValidateAsync(request);
        if (!validation.IsValid)
        {
            var errors = validation.Errors.Select(e => e.ErrorMessage).ToList();
            return BadRequest(ApiResponse<object>.Fail("Validation failed.", errors));
        }

        var result = await service.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = result.Id },
            ApiResponse<object>.Ok(result, "Trainer created successfully."));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ApiResponse<object>>> GetById(ulong id)
    {
        var result = await service.GetByIdAsync(id);
        if (result is null)
            return NotFound(ApiResponse<object>.Fail($"Trainer with id {id} not found."));

        return Ok(ApiResponse<object>.Ok(result));
    }
}
