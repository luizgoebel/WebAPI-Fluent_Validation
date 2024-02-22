using FluentValidation;
using FluentValidation.Results;

namespace WebAPI_Fluent_Validation.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Idade { get; set; }

}
