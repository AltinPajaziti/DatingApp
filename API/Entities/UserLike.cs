namespace API.Entities
{
    public class UserLike
    {
        public AppUsser SourceUser { get; set; } = null!;
        public int SourceUserId { get; set; }
        public AppUsser TargetUser { get; set; } = null!;
        public int TargetUserId { get; set; }
    }
}
