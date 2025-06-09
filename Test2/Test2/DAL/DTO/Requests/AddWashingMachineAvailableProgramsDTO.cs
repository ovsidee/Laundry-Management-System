using System.Threading.Channels;

namespace Test2.DAL.DTO.Requests;

public class AddWashingMachineAvailableProgramsDTO
{
    public AddWashingMachineDTO washingMachine { get; set; }
    public List<AddAvailableProgramPriceDTO> availablePrograms { get; set; }
}