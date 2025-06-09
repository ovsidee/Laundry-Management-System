using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test2.DAL.Model;

[Table("Available_Program")]
public class Available_Program
{
    [Key]
    public int AvailableProgramId { get; set; }
    
    [ForeignKey(nameof(Washing_Machine))]
    public int WashingMachineId { get; set; }
    
    [ForeignKey(nameof(Program))] 
    public int ProgramId { get; set; }
    
    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
    
    public Washing_Machine Washing_Machine { get; set; }
    public Program Program { get; set; }
}