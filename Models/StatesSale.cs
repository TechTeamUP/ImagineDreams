namespace ImagineDreams.Models
{
    public class StatesSale
    {
        public int? Id { get; set; }
        public string Name { get; set; } = default!;

        public ICollection<SalesEntity> Sale { get; set; } = default!;
    }
}