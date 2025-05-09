using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class User
{
    [Key]
    public Guid UserId { get; set; }
    
    [Required]
    [StringLength(25)]
    public string Nickname { get; set; }
    
    [Required]
    [StringLength(30)]
    public string Email { get; set; }
    
    [Required]
    [StringLength(20)]
    public string Password { get; set; }
    
    [Required]
    public Guid UserRankId { get; set; }

    public virtual UserRank UserRank { get; set; } = new();
}