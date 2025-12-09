using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos
{
    public record class Game(
        int Id,
        [Required][StringLength(50)] string Name,
        [Required][StringLength(50)] string Genre,
        [Required][Range(1, 1999)] decimal Price);
}