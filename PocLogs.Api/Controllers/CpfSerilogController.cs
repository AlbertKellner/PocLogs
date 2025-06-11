using Microsoft.AspNetCore.Mvc;
using PocLogs.Api.Models;
using PocLogs.Api.Validators;

namespace PocLogs.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CpfSerilogController : ControllerBase
{
    private readonly CpfValidatorWithSerilog _validator;

    public CpfSerilogController(CpfValidatorWithSerilog validator)
    {
        _validator = validator;
    }

    [HttpPost]
    public ActionResult<bool> Post([FromBody] CpfRequest request)
    {
        bool valid = false;
        for (int i = 0; i < 1000; i++)
        {
            valid = _validator.IsValid(request.Cpf);
        }

        return Ok(valid);
    }
}
