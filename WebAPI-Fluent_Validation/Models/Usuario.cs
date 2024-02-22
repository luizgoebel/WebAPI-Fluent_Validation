using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace WebAPI_Fluent_Validation.Models;

public class Usuario
{
    public Usuario(string nome, string email, int idade)
    {
        Id = new Random()
            .Next(0, 101);
        Nome = nome;
        Email = email;
        Idade = idade;
    }
    [JsonIgnore]
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public int Idade { get; set; }

}
