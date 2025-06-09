using Microsoft.EntityFrameworkCore;
using Test2.DAL.DTO.Requests;
using Test2.DAL.DTO.Responses;
using Test2.DAL.Model;
using Test2.DAL.Model.Db;

namespace Test2.Services;

public class DbService : IDbService
{
    public DatabaseContext _context { get; set; }

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<CustomerPurchasesDTO?> GetCustomerWithPurchasesAsync(int customerId, CancellationToken cancellationToken)
    {
        var customersWithPurchases = await _context
            .Customers
            .Where(c => c.CustomerId == customerId)
            .Select(c => new CustomerPurchasesDTO()
            {
                firstName = c.FirstName,
                lastName = c.LastName,
                phoneNumber = c.PhoneNumber,
                purchases = _context
                    .PurchaseHistories
                    .Where(ph => ph.CustomerId == customerId)
                    .Select(ph => new PurchaseDTO()
                    {
                        date = ph.PurchaseDate,
                        rating = ph.Rating,
                        price = ph.Available_Program.Price,
                        washingMachine = new WashingMachineDTO()
                        {
                            serial = ph.Available_Program.Washing_Machine.SerialNumber,
                            maxWeight = ph.Available_Program.Washing_Machine.MaxWeight
                        },
                        program = new ProgramDTO()
                        {
                            name = ph.Available_Program.Program.Name,
                            duration = ph.Available_Program.Program.DurationMinutes
                        }
                    }).ToList()
            }).FirstOrDefaultAsync(cancellationToken);
        
        return customersWithPurchases;
    }

    public async Task<string> AddWashingMachineWithProgramsAsync(AddWashingMachineAvailableProgramsDTO washingDTO, CancellationToken cancellationToken)
        {
            if (washingDTO.washingMachine.maxWeight < 8)
                return "WashingMachineLeastThan8";
            
            if (washingDTO.availablePrograms
                .Any(av => av.price > 25))
                return "PriceMoreThan25";
            
            var isMachineExistsWithSerialNumber = await _context
                .WashingMachines
                .AnyAsync(wm => wm.SerialNumber == washingDTO.washingMachine.serialNumber, cancellationToken);
           
            if (isMachineExistsWithSerialNumber)
                return "MachineExistsSerialNumber";

            foreach (var program in washingDTO.availablePrograms)
            {
                var isExistsInDataBase = await _context
                   .Programs
                   .AnyAsync(pr => pr.Name == program.programName, cancellationToken);
               
               if (!isExistsInDataBase)
                   return "ProgramNotExists";
            }

            var newWashingMachineToBeAdded = new Washing_Machine()
            {
                SerialNumber = washingDTO.washingMachine.serialNumber,
                MaxWeight = washingDTO.washingMachine.maxWeight
            };
            
            await _context.WashingMachines.AddAsync(newWashingMachineToBeAdded, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            
            var idOfNewWashingMachine = newWashingMachineToBeAdded.WashingMachineId;
            
            foreach (var program in washingDTO.availablePrograms)
            {
                var programInDataBase = await _context
                    .Programs
                    .Where(p => p.Name == program.programName)
                    .Select(p => p.ProgramId)
                    .FirstOrDefaultAsync(cancellationToken);
                
                await _context
                    .AvailablePrograms
                    .AddAsync(new Available_Program()
                    {
                        WashingMachineId = idOfNewWashingMachine,
                        ProgramId = programInDataBase,
                        Price = program.price
                    }, cancellationToken);
                
                await _context.SaveChangesAsync(cancellationToken);
            }
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return "success";
        }
}