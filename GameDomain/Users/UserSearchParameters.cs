namespace GameDomain.Users
{
    public class UserSearchParameters
    {
        public string[] emails { get; set; } = new string[0];
        public int[] userIds { get; set; } = new int[0];
    }
}
