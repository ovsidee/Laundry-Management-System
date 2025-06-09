using Test2.DAL.DTO.Requests;
using Test2.DAL.DTO.Responses;

namespace Test2.Services;

public interface IDbService
{
    public Task<CustomerPurchasesDTO?> GetCustomerWithPurchasesAsync(int customerId, CancellationToken cancellationToken);
    public Task<string> AddWashingMachineWithProgramsAsync(AddWashingMachineAvailableProgramsDTO washingDTO, CancellationToken cancellationToken);
}