using System.ComponentModel.DataAnnotations;

namespace Commsflow.DTOs;

public class GenerateRequest
{
    [Required]
    public int TemplateId { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public string Invoice { get; set; } = string.Empty;
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}