namespace GameStore.Dtos
{
    public record class Game(int Id, string Name, string Genre, decimal Price)
    {
        public int GetId()
        {
            return this.Id;
        }

        public string GetName()
        {
            return this.Name;
        }
    };
}