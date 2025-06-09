using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.DAL.Model;

[Table("Customer")]
public class Customer
{
    [Key]
    public int CustomerId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string LastName { get; set; }

    public string? PhoneNumber { get; set; }
}