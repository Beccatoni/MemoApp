using System.ComponentModel.DataAnnotations;

namespace MemoApp.DTOs;

public class UpdateMemoDto
{
    [Required]
    [StringLength(100)]
    public string? Title { get; set; }
        
    [Required]
    public string? Content { get; set; }
    
}