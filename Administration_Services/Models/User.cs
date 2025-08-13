namespace Administration_Services.Models;

public class User
{
    public string Name { get; set; } = string.Empty;
    public short YearsOld { get; set; } 
    public string Cpf{ get; set; } = String.Empty;
    public string Email { get; set; } = string.Empty;
    public  string Code { get; set; } = String.Empty;
}