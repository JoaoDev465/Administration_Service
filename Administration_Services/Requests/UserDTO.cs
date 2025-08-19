using System.ComponentModel.DataAnnotations;

namespace Administration_Services.Requests;

public class UserDto
{
    [Required(ErrorMessage = "o nome não pode ser nulo")]
    public string Name { get; set; } = String.Empty;
    
    [EmailValidation]
    [EmailAddress]
    [Required(ErrorMessage = "o Email não pode ser nulo")]
    public string Email { get; set; } = String.Empty;
    
    [Required(ErrorMessage = "o campo Idade não pode ser nula")]
    public string? YearsOld { get; set; } = String.Empty;

    [Required(ErrorMessage = "o campo cpf é obrigatório")] 
    [MinLength(11,ErrorMessage = "o campo cpf precisa conter no mínimo 11 caracteres"),MaxLength(11)]
    public string Cpf { get; set; } = string.Empty;

    public int Id { get; set; } = Random.Shared.Next(1,100);
}

public class EmailValidation : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var email = value as string;
        if (string.IsNullOrEmpty(email))
        {
            return new ValidationResult(ErrorMessage = "a entrada não pode ser nula");
        }
        else if (!email.EndsWith("@gmail.com"))
        {
            return new ValidationResult(ErrorMessage = "o campo precisa conter @gmail.com");
        }
        return ValidationResult.Success;
    }
}