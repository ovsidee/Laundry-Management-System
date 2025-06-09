using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.DAL.Model;

[Table("Washing_Machine")]
public class Washing_Machine
{
    [Key]
    public int WashingMachineId { get; set; }
   
    [Column(TypeName = "decimal(10,2)")]
    public decimal MaxWeight { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string SerialNumber { get; set; }
}