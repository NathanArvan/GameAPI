using GameDomain;
using GameDomain.Abilities;
using GameDomain.Battles;
using GameDomain.Characters;
using GameDomain.Items;
using GameDomain.Maps;
using GameDomain.RuleSets;
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

        public DbSet<RuleSet> RuleSets { get; set; }
        public DbSet<ItemAbility> ItemAbilities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().ToTable("Character");
            modelBuilder.Entity<Item>()
                .HasMany(e => e.Abilities)
                .WithMany(e => e.Items)
                .UsingEntity<ItemAbility>();

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

            modelBuilder.Entity<Battle>()
                .HasMany(b => b.Characters)
                .WithOne(c => c.Battle)
                .HasForeignKey(c => c.BattleId)
                .IsRequired(false);

            modelBuilder.Entity<RuleSet>()
                .HasMany(r => r.Items)
                .WithOne(i => i.RuleSet)
                .HasForeignKey(i => i.RuleSetId)
                .IsRequired(false);

            modelBuilder.Entity<RuleSet>()
                .HasMany(r => r.Battles)
                .WithOne(b => b.RuleSet)
                .HasForeignKey(b => b.RuleSetId)
                .IsRequired(false);

            modelBuilder.Entity<RuleSet>()
                .HasMany(r => r.Abilities)
                .WithOne(a => a.RuleSet)
                .HasForeignKey(a => a.RuleSetId)
                .IsRequired(false);

            modelBuilder.Entity<RuleSet>()
                .HasData(new RuleSet { RuleSetId = 1, Name = "Test" });

            modelBuilder.Entity<Item>()
                .HasData(new Item { ItemId = 1, RuleSetId = 1, Name = "Bow" });

            modelBuilder.Entity<Ability>()
                .HasData(new Ability { AbilityId = 1, RuleSetId = 1, Name = "Shoot Arrow" });

            modelBuilder.Entity<ItemAbility>()
                .HasData(new ItemAbility { ItemAbilityId =1 ,ItemId = 1, AbilityId = 1 });
        }
    }
}
