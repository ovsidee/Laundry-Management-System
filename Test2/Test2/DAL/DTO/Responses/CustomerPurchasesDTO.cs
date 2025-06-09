namespace Test2.DAL.DTO.Responses;

public class CustomerPurchasesDTO
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string? phoneNumber { get; set; }
    
    public List<PurchaseDTO> purchases { get; set; }
}