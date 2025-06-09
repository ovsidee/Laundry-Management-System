using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.DAL.Model;

[Table("Program")]
public class Program
{
    [Key]
    public int ProgramId { get; set; }
    
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    
    public int DurationMinutes { get; set; }
    public int TemperatureCelsius { get; set; }
}