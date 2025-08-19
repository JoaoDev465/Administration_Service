// See https://aka.ms/new-console-template for more information

using System.ComponentModel.DataAnnotations;
using Administration_Services.Data;
using Administration_Services.Requests;

namespace Administration_Services;

public static class Startup
{
    public static void Main()
    {
        var data = new AdminData();
        var userInput = new UserDto();
        var validationresult = new List<ValidationResult>();
        var validationContext = new ValidationContext(userInput, serviceProvider: null, items: null);
        while (true)
        {
            Console.WriteLine("escolha uma opçao");
            Console.WriteLine("------------------");
            Console.WriteLine("1 - adicionar");
            Console.WriteLine("2 - sair");
            Console.WriteLine("3 - remover usuário");
            Console.WriteLine("4 - consultar usuários");
        
            var option = Console.ReadLine()?.Trim();

            switch (option)
            {
                case "1":
                    Console.WriteLine("digite os dados do cliente");
                    Console.WriteLine("Email:");
                    userInput.Email = Console.ReadLine();
                    Console.WriteLine("cpf:");
                    userInput.Cpf = Console.ReadLine();
                    Console.WriteLine("nome:");
                    userInput.Name = Console.ReadLine();
                    Console.WriteLine("Idade");
                    userInput.YearsOld = Console.ReadLine();
                    if (!Validator.TryValidateObject(userInput, validationContext, validationresult, true))
                    {
                        foreach (var error in validationresult)
                        {
                            Console.WriteLine($"Erro: {error.ErrorMessage}");
                        }
                    }
                    else
                    {
                        data.Add(userInput);
                    }
                    break;
                case "3":
                    Console.WriteLine("digite o Id do usuário");
                    userInput.Id = int.Parse(Console.ReadLine());
                    data.Remove(userInput);
                    break;
                case "4":
                    data.Get_All();
                    break;
                case "2":
                    Environment.Exit(2);
                    break;
               
                default:
                    Console.WriteLine("opção invãlida");
                    break;
            }
        }
    }
}