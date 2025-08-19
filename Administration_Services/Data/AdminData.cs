using System.Text.Json;
using Administration_Services.Interfaces;
using Administration_Services.Requests;

namespace Administration_Services.Data;

public class AdminData:IData
{
    public Dictionary<int, UserDto> Management { get; set; } = new();

    public UserDto Add(UserDto dto)
    {
        Management.Add(dto.Id,dto);
        Console.WriteLine($"usuário {dto.Name} adicionado com sucesso ");
        return dto;
    }
    
    public UserDto? Remove(UserDto userDto)
    {
        if (userDto.Id == null)
        {
            Console.WriteLine("nenhuma Id encontrada");
            return null;
        }

        if (Management.Remove(userDto.Id))
        {
            Management.Remove(userDto.Id);
            Console.WriteLine($"o usuário {userDto.Name} removido com sucesso");
            return userDto;
        }
        else
        {
            Console.WriteLine("nenhum usuário encontrado");
            return null;
        }
    }

    public IEnumerable<UserDto> Get_All()
    {

        if (Management.Count == 0)
        {
            Console.WriteLine("nenhum registro");
            return null;
        }

        if (Management.Values !=  null)
        {
            foreach (var users in Management.Values)
            {
                Console.WriteLine($"Id:{users.Id}-{users.Name}-{users.Email}-{users.Cpf}");
            }
        }

        return Management.Values;
    }
}