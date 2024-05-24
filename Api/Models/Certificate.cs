namespace Api.Models
{
    public class Certificate
    {
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public DateTime ValidityStart { get; set; }
        public DateTime ValidityEnd { get; set; }

        public Certificate(int ownerId, DateTime validityStart, DateTime validityEnd)
        {
            Id = Guid.NewGuid().GetHashCode();
            OwnerId = ownerId;
            ValidityStart = validityStart;
            ValidityEnd = validityEnd;
        }
    }
}
