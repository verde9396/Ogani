using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WouldYouGetItDone.Data
{
    public class MyDbContext :DbContext
    {
        public DbSet<Type> Types { get; set; }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewGoods> GetReviewGoods { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<GoodsTag> GoodsTags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubImg>(e => {
                e.HasOne(h => h.Goods)
                .WithMany(hh => hh.SubImgs)
                .HasForeignKey(h => h.GoodsId);
            });
            modelBuilder.Entity<Goods>(e =>
            {
                e.ToTable("Goods");
                e.HasKey(hh => hh.GoodsId);
                e.Property(hh => hh.GoodsId)
                    //.HasDefaultValue("0");
                    .HasDefaultValueSql("newid()");
                e.Property(hh => hh.GoodsName)
                .IsRequired().HasMaxLength(100);
                e.Property(hh => hh.Details).HasMaxLength(200);
                e.HasIndex(hh => hh.GoodsName).IsUnique();

                e.HasOne(hh => hh.Type)
                .WithMany(lo => lo.Goods)
                .HasForeignKey(hh => hh.TypeId)
                .OnDelete(DeleteBehavior.SetNull);
            });
            modelBuilder.Entity<Tag>(e => {
                e.ToTable("Tag");
                e.HasKey(hh => hh.TagKey);
                e.Property(hh => hh.TagKey).HasMaxLength(50);
            });
            modelBuilder.Entity<GoodsTag>(e => {
                e.ToTable("GoodsTag");
                e.HasKey(hh => new { hh.TagKey, hh.GoodsId });
                e.HasOne(hh => hh.Goods)
                 .WithMany(hht => hht.GoodsTags)
                 .HasForeignKey(t => t.GoodsId);
            e.HasOne(hh => hh.Tag)
               .WithMany(hht => hht.GoodsTags)
               .HasForeignKey(t => t.TagKey);
        });

                modelBuilder.Entity<Type>(e =>
            {
                e.ToTable("Type");
                e.Property(e => e.TypeId).IsRequired().HasMaxLength(100);
                e.HasKey(e => e.TypeId);
            });
            }
            
        public MyDbContext(DbContextOptions<MyDbContext> opt) : base(opt)
        {

        }

       

    }
}
