using Microsoft.AspNetCore.Mvc;
using unit_converter.Models;
using unit_converter.Services;

namespace unit_converter.Controllers;

[ApiController]
[Route("api/conversion")]
public class ConversionController : ControllerBase
{

    private readonly ConversionService conversionService;

    public ConversionController(ConversionService conversionService)
    {
        this.conversionService = conversionService;
    }

    [HttpPost]
    public ConversionResponse Convert(ConversionRequest request)
    {
        return conversionService.Convert(request.Value,request.FromUnit,request.ToUnit);
    }

}
