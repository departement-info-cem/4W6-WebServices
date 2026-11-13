using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using serveur16.Models;

namespace serveur16.Data;

public static class DatabaseSeeder
{
    private const string FirstUserId = "11111111-1111-1111-1111-111111111111";

    public static async Task SeedAsync(IServiceProvider services)
    {
        await using var scope = services.CreateAsyncScope();

        var context = scope.ServiceProvider
            .GetRequiredService<serveur16Context>();

        var userManager = scope.ServiceProvider
            .GetRequiredService<UserManager<User>>();

        await context.Database.MigrateAsync();

        var firstUser = await CreateUserIfMissingAsync(
            userManager,
            FirstUserId,
            "bob",
            "b@b.b",
            "allo");

        await AddReviewIfMissingAsync(
            context,
            1,
            "Cyberpunk 2077",
            "C'parce que lé bonhommes font des T poses pis y rentrer dans le plancher des fois xd",
            firstUser.Id);

        await AddReviewIfMissingAsync(
            context,
            2,
            "Mario Kart World",
            "Je préfère de loin Garfield Kart !",
            firstUser.Id);

        await context.SaveChangesAsync();
    }

    private static async Task<User> CreateUserIfMissingAsync(
        UserManager<User> userManager,
        string userId,
        string userName,
        string email,
        string password)
    {
        var user = await userManager.FindByIdAsync(userId);

        if (user is not null)
        {
            return user;
        }

        user = new User
        {
            Id = userId,
            UserName = userName,
            Email = email,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            var errors = string.Join(
                ", ",
                result.Errors.Select(error => error.Description));

            throw new InvalidOperationException(
                $"Impossible de créer l'utilisateur '{userName}' : {errors}");
        }

        return user;
    }

    private static async Task AddReviewIfMissingAsync(
        serveur16Context context,
        int id,
        string game,
        string text,
        string authorId)
    {
        var reviewExists = await context.Review
            .AnyAsync(review => review.Id == id);

        if (reviewExists)
        {
            return;
        }

        context.Review.Add(new Review
        {
            Id = id,
            Game = game,
            Text = text,
            AuthorId = authorId
        });
    }
}