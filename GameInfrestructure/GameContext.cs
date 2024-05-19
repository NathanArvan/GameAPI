using GameDomain;
using GameDomain.Abilities;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().ToTable("Character");
        }
    }
}
