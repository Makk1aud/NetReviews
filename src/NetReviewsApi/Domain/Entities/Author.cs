using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;
using Domain.Enums;

namespace Domain.Entities;

public class Author
{
    [Key]
    public Guid AuthorId { get; set; }
    
    [Required]
    [MaxLength(30)]
    public string FirstName { get; set; }
    
    [MaxLength(30)]
    public string LastName { get; set; }
    
    [Required]
    public DateOnly Birthday { get; set; }
    
    [Required]
    public AuthorTypes AuthorType { get; set; }
}