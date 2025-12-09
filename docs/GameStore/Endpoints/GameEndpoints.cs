using GameStore.Dtos;

namespace GameStore.Endpoints;

public static class GameEndpoints
{
    const string GameEndpointName = "GetGame";

    private static readonly List<Game> games = [
        new (1, "Devil May Cry 3 Special Edition", "Beat'em up", 1_000),
    new (2, "Assassin's Creed Shadows", "Stealth", 1_499),
    new (3, "Final Fantasy XIV", "RPG", 549)
    ];
    public static RouteGroupBuilder MapGameEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("games").WithParameterValidation();
        // GET
        group.MapGet("/", () => games).WithName(GameEndpointName);

        group.MapGet("/get/{id}", (int Id) => games.Find(game => game.Id == Id));

        // POST
        group.MapPost("/add", (Game newGame) =>
        {
            games.Add(new(games.Count + 1, newGame.Name, newGame.Genre, newGame.Price));
            return Results.CreatedAtRoute(GameEndpointName);
        });

        // PUT
        group.MapPut("/update/{id}", (int Id, Game newGame) =>
        {
            var index = games.FindIndex(game => game.Id == Id);
            games[index] = new(Id, newGame.Name, newGame.Genre, newGame.Price);

            return Results.NoContent();
        });

        // DELETE
        group.MapDelete("/delete/{id}", (int Id) =>
        {
            var game = games.Find(game => game.Id == Id);
            games.Remove(game);
            return Results.NoContent();
        });

        return group;
    }
}


