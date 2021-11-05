using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroJourney.Data
{
    public class HeroJourneyDbContext : IdentityDbContext
    {
        public HeroJourneyDbContext(DbContextOptions<HeroJourneyDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hero> Heroes { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Class> Classes { get; set; }

        public DbSet<EnemyClass> EnemyClasses { get; set; }

        public DbSet<EnemyType> EnemyTypes { get; set; }

        public DbSet<EnemyRecords> EnemyRecords { get; set; }

        public DbSet<SubHeroClass> SubHeroClasses { get; set; }

        public DbSet<Level> Levels { get; set; }

        public DbSet<Story> Stories { get; set; }

        public DbSet<ArenaStat> ArenaStats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Hero>(hero =>
            {
                hero.HasKey(x => x.Id);

                hero.HasOne(x => x.Class)
                    .WithMany(x => x.Heroes)
                    .HasForeignKey(x => x.ClassId);

                hero.HasOne<IdentityUser>()
                     .WithOne()
                     .HasForeignKey<Hero>(x => x.UserId);

                hero.HasMany(x => x.EnemyRecords)
                    .WithOne(x => x.Hero)
                    .OnDelete(DeleteBehavior.Restrict);

                hero.HasOne(x => x.SubHeroClass)
                   .WithMany(x => x.Heroes)
                   .HasForeignKey(x => x.SubHeroClassId);

                hero.HasOne(x => x.Story)
                    .WithMany(x => x.Heroes)
                    .HasForeignKey(x => x.StoryId);

                hero.HasMany(x => x.ArenaStats)
                  .WithOne(x => x.Hero)
                  .OnDelete(DeleteBehavior.Restrict);


            });

            builder.Entity<Class>(cl =>
            {
                cl.HasKey(x => x.Id);

                cl.HasMany(x => x.Heroes)
                    .WithOne(x => x.Class)
                    .OnDelete(DeleteBehavior.Restrict);

                cl.HasMany(x => x.SubHeroClasses)
                    .WithOne(x => x.Class)
                    .OnDelete(DeleteBehavior.Restrict);

                cl.HasMany(x => x.Items)
                 .WithOne(x => x.Class)
                 .OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<SubHeroClass>(shc =>
            {
                shc.HasKey(x => x.Id);

                shc.HasOne(x => x.Class)
                    .WithMany(x => x.SubHeroClasses)
                    .HasForeignKey(x => x.ClassId)
                    .OnDelete(DeleteBehavior.Restrict);

                shc.HasMany(x => x.Heroes)
                    .WithOne(x => x.SubHeroClass)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<Item>(item =>
            {
                item.HasKey(x => x.Id);

                item.HasOne(x => x.Class)
                    .WithMany(x => x.Items)
                    .HasForeignKey(x => x.ClassId);


            });

            builder.Entity<EnemyClass>(enclass =>
            {
                enclass.HasKey(x => x.Id);

            });

            builder.Entity<Story>(story =>
            {
                story.HasKey(x => x.Id);

                story.HasMany(x => x.Heroes)
                     .WithOne(x => x.Story)
                     .OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<EnemyType>(entype =>
            {
                entype.HasKey(x => x.Id);

            });

            builder.Entity<EnemyRecords>(enrec =>
            {
                enrec.HasKey(x => x.Id);

                enrec.HasOne(x => x.Hero)
                    .WithMany(x => x.EnemyRecords)
                    .HasForeignKey(x => x.HeroId);

                enrec.HasMany(x => x.ArenaStats)
                    .WithOne(x => x.Enemy)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            builder.Entity<Level>(level =>
            {
                level.HasKey(x => x.Id);

            });

            builder.Entity<ArenaStat>(arenaStat =>
            {
                arenaStat.HasKey(x => x.Id);

                arenaStat.HasOne(x => x.Hero)
                        .WithMany(x => x.ArenaStats)
                         .HasForeignKey(x => x.HeroId);

                arenaStat.HasOne(x => x.Enemy)
                .WithMany(x => x.ArenaStats)
                 .HasForeignKey(x => x.EnemyId);

            });

            base.OnModelCreating(builder);
        }
    }
}
