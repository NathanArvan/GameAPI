using System.ComponentModel.DataAnnotations.Schema;

namespace GameDomain
{
    public class ItemAbility
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ItemAbilityId { get; set; }
        public int ItemId { get; set; }
        public int AbilityId { get; set; }
    }
}
