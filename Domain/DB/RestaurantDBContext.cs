using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestaurantTimBaig.Domain.Model;
using RestaurantTimBaig.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantTimBaig.Domain.DB
{
    public class RestaurantDBContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="options"></param>
        public RestaurantDBContext(DbContextOptions<RestaurantDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Пользователи
        /// </summary>
        public override DbSet<User> Users { get; set; }

        /// <summary>
        /// Сотрудники
        /// </summary>
        public DbSet<Restaurant> Employee { get; private set; }

        /// <inheritdoc/>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(x =>
            {
                x.HasOne(y => y.Restaurant)
                .WithOne()
                .HasForeignKey<User>("RestaurantId")
                .IsRequired(true);
                x.HasIndex("RestaurantId").IsUnique(true);
            });

            #region Employee

            modelBuilder.Entity<Restaurant>(b =>
            {
                b.ToTable("Restaurants");
                EntityId(b);
                b.Property(x => x.RestName)
                    .HasColumnName("Name")
                    .IsRequired();
                b.Property(x => x.RestAddress)
                    .HasColumnName("Address")
                    .IsRequired();
                b.Property(x => x.RestPhone)
                    .HasColumnName("Phone")
                    .IsRequired();
            });


            /*modelBuilder.Entity<BlogPost>(b =>
            {
                b.ToTable("BlogPosts");
                EntityId(b);
                b.Property(x => x.Created)
                    .HasColumnName("Created")
                    .IsRequired();
                b.Property(x => x.Title)
                    .HasColumnName("Title")
                    .IsRequired();
                b.Property(x => x.Data)
                    .HasColumnName("Data")
                    .IsRequired();
                b.HasOne(x => x.Owner)
                    .WithMany()
                    .IsRequired();
            });*/

            #endregion

        }

        /// <summary>
        /// Описание идентификатора сущности модели
        /// </summary>
        /// <typeparam name="TEntity">Тип сущности</typeparam>
        /// <param name="builder">Построитель модели данных</param>
        private static void EntityId<TEntity>(EntityTypeBuilder<TEntity> builder)
            where TEntity : Entity
        {
            builder.Property(x => x.Id)
                .HasColumnName("Id")
                .IsRequired();
            builder.HasKey(x => x.Id)
                .HasAnnotation("Npgsql:Serial", true);
        }

    }
}
