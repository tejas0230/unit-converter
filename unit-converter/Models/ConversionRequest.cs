namespace unit_converter.Models;
using System.ComponentModel.DataAnnotations;

public class ConversionRequest
{
    [Required]
    public double Value { get; set; }

    [Required]
    public string FromUnit { get; set; } = string.Empty;

    [Required]
    public string ToUnit { get; set; } = string.Empty;
}
