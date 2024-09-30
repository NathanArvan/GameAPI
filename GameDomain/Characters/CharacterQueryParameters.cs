namespace GameDomain.Characters
{
    public class CharacterQueryParameters
    {
        public int[] characterIds {  get; set; } = new int[0];
        public int[] battleIds { get; set; } = new int[0];

        public int[] userIds { get; set; } = new int[0];
    }
}
