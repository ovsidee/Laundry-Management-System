using Microsoft.AspNetCore.Mvc;
using Test2.DAL.DTO.Requests;
using Test2.Services;

namespace Test2.Controllers;

[ApiController]
[Route("washing-machines")]
public class WashingMachinesController : ControllerBase
{
    public IDbService DbService { get; set; }

    public WashingMachinesController(IDbService dbService)
    {
        DbService = dbService;
    }

    [HttpPost]
    public async Task<IActionResult> AddWashingMachineAsync([FromBody] AddWashingMachineAvailableProgramsDTO addWashingMachineAvailableProgramsDto, CancellationToken cancellationToken)
    {
        var result = await DbService.AddWashingMachineWithProgramsAsync(addWashingMachineAvailableProgramsDto, cancellationToken);
        
        return result switch
        {
            "WashingMachineLeastThan8" => BadRequest("Washing machine max weight must be at least 8 kg"),
            "PriceMoreThan25" => BadRequest("Program price must be less than or equal to 25"),
            "MachineExistsSerialNumber" => Conflict("Machine with this serial number already exists"),
            "ProgramNotExists" => NotFound("Program does not exist"),
            "success" => Created("", "Washing machine and programs were added successfully"),
            _ => BadRequest()
        };
    }
}