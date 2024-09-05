using GameDomain;
using GameDomain.Abilities;
using GameDomain.Battle;
using GameDomain.Characters;
using GameDomain.Items;
using GameDomain.Maps;
using GameDomain.Tokens;
using Microsoft.EntityFrameworkCore;

namespace GameInfrestructure
{
    public class GameContext: DbContext
    {
        public GameContext() { }
        public GameContext(DbContextOptions<GameContext> options) : base(options) { }
        public DbSet<Ability> Abilities { get; set; }
        public DbSet<Campaign> Campaigns { get; set; }
        public DbSet<Character> Characters { get; set; } 
        public DbSet<Class> Classes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<TokenImage> TokenImages { get; set; }
        public DbSet<Battle> Batttles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().ToTable("Character");
            modelBuilder.Entity<Item>()
                .HasMany(e => e.Abilities)
                .WithMany(e => e.Items)
                .UsingEntity(
                    "ItemAbilities",
                    l => l.HasOne(typeof(Ability)).WithMany().HasForeignKey("AbilityIds").HasPrincipalKey(nameof(Ability.AbilityId)),
                    r => r.HasOne(typeof(Item)).WithMany().HasForeignKey("ItemIds").HasPrincipalKey(nameof(Item.ItemId)),
                    j => j.HasKey("AbilityIds", "ItemIds")
                );

            modelBuilder.Entity<Character>()
                .HasMany(e => e.Items)
                .WithMany(e => e.Characters)
                .UsingEntity(
                    "CharacterItems",
                    l => l.HasOne(typeof(Item)).WithMany().HasForeignKey("ItemIds").HasPrincipalKey(nameof(Item.ItemId)),
                    r => r.HasOne(typeof(Character)).WithMany().HasForeignKey("CharacterIds").HasPrincipalKey(nameof(Character.CharacterId)),
                    j => j.HasKey("CharacterIds", "ItemIds")
                );

            modelBuilder.Entity<Character>()
                .HasOne<Token>(e => e.Token)
                .WithMany(e => e.Characters)
                .IsRequired(false);
        }
    }
}
