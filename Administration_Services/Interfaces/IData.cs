using Administration_Services.Models;
using Administration_Services.Requests;

namespace Administration_Services.Interfaces;

public interface IData
{
   public Dictionary<int,UserDto> Management { get; set; }

   public UserDto Add(UserDto userDto);

   public UserDto Remove(UserDto userDto);

   public IEnumerable<UserDto> Get_All();

}