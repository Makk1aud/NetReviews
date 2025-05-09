using System.ComponentModel.DataAnnotations;

namespace Entities;

public class UserRank
{
    [Key]
    public Guid UserRankId { get; set; }
    
    [Required]
    [StringLength(30)]
    public string Title { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Description { get; set; }
    
    public virtual ICollection<User> Users { get; set; } = new List<User>();
}