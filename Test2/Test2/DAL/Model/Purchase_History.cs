using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Test2.DAL.Model;

[Table("Purchase_History")]
[PrimaryKey(nameof(AvailableProgramId), nameof(CustomerId))]
public class Purchase_History
{
    [ForeignKey(nameof(Available_Program))]
    public int AvailableProgramId { get; set; }
    
    [ForeignKey(nameof(Customer))]
    public int CustomerId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime PurchaseDate { get; set; }

    public int? Rating { get; set; }

    public Customer Customer { get; set; }
    public Available_Program Available_Program { get; set; }
}