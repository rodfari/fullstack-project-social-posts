using Core.Domain.Entities;

namespace Infrastructure.Persistence.mySQL;

public class GetUsers
{
    public static List<User> SeedUsers() => [
                new(){  Username = "Rodrigo", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, IsDeleted = false},
                new(){  Username = "Maria", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, IsDeleted = false},
                new(){  Username = "Jeniffer", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, IsDeleted = false},
                new(){  Username = "Hector", CreatedAt = DateTime.UtcNow, UpdatedAt = DateTime.UtcNow, IsDeleted = false},
            ];

}