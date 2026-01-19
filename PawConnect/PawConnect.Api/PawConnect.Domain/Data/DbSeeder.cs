using PawConnect.Domain.Data;
using PawConnect.Domain.Entities;

public static class DbSeeder
{
    public static void Seed(PawConnectDbContext context)
    {
        // 1️⃣ Seed User
        if (!context.Users.Any())
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                FullName = "Test User",
                Email = "test@pawconnect.com"
            };

            context.Users.Add(user);
            context.SaveChanges();
        }

        var existingUser = context.Users.First();

        // 2️⃣ Seed Pets
        if (!context.Pets.Any())
        {
            context.Pets.AddRange(
                new Pet
                {
                    Name = "Rocky",
                    Age = 2,
                    Type = "Dog",
                    ImageUrl = "https://placehold.co/300",
                    OwnerId = existingUser.Id
                },
                new Pet
                {
                    Name = "Milo",
                    Age = 1,
                    Type = "Cat",
                    ImageUrl = "https://placehold.co/300",
                    OwnerId = existingUser.Id
                }
            );

            context.SaveChanges();
        }
    }
}
