using Flunt.Validations;
using Store.Domain.Repositories.Interfaces;

namespace Store.Domain.Entities;

public class Customer : Entity
{
    public Customer(string name, string email)
    {
        AddNotifications(
            new Contract()
                .Requires()
                .HasMinLengthIfNotNullOrEmpty(name, 3, "Name", "Nome inválido")
                .IsEmail(email, "Email", "Email inválido")
        );

        Name = name;
        Email = email;
    }
    public string Name { get; private set; }
    public string Email { get; private set; }
}