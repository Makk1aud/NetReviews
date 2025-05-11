using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

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
    public string Password { get; set; }
    
    [Required]
    public byte[] Salt { get; set; }
    
    [Required]
    public Guid UserRankId { get; set; }

    public virtual UserRank UserRank { get; set; }
}