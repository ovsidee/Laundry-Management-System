namespace Test2.DAL.DTO.Responses;

public class PurchaseDTO
{
    public DateTime date { get; set; }
    public int? rating { get; set; }
    public decimal price { get; set; }
    
    public WashingMachineDTO washingMachine { get; set; }
    public ProgramDTO program { get; set; }
}