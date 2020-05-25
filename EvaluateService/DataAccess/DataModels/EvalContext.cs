using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace E_ValuateDataAccess.DataModels
{
    public partial class EvalContext : DbContext
    {
        public EvalContext()
        {
        }

        public EvalContext(DbContextOptions<EvalContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<FriendData> FriendData { get; set; }
        public virtual DbSet<FriendsDetails> FriendsDetails { get; set; }
        public virtual DbSet<PictureData> PictureData { get; set; }
        public virtual DbSet<PostsData> PostsData { get; set; }
        public virtual DbSet<PostsDetails> PostsDetails { get; set; }
        public virtual DbSet<Users> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId)
                    .HasColumnName("AddressID")
                    .ValueGeneratedNever();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FriendData>(entity =>
            {
                entity.HasKey(e => e.FriendId);

                entity.Property(e => e.FriendId).HasColumnName("FriendID");

                entity.HasOne(d => d.FriendInfoNavigation)
                    .WithMany(p => p.FriendData)
                    .HasForeignKey(d => d.FriendInfo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FriendData_Users");
            });

            modelBuilder.Entity<FriendsDetails>(entity =>
            {
                entity.HasKey(e => e.DetailsId);

                entity.Property(e => e.DetailsId).HasColumnName("DetailsID");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.FriendId).HasColumnName("FriendID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Friend)
                    .WithMany(p => p.FriendsDetails)
                    .HasForeignKey(d => d.FriendId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FriendsDetails_FriendData");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.FriendsDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FriendsDetails_Users");
            });

            modelBuilder.Entity<PictureData>(entity =>
            {
                entity.HasKey(e => e.PictureId);

                entity.Property(e => e.PictureId).HasColumnName("PictureID");

                entity.Property(e => e.ImgDate)
                    .HasColumnName("imgDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.ImgName)
                    .HasColumnName("imgName")
                    .IsUnicode(false);

                entity.Property(e => e.ImgSource)
                    .IsRequired()
                    .HasColumnName("imgSource");
            });

            modelBuilder.Entity<PostsData>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.Media).IsRequired();

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PostsDetails>(entity =>
            {
                entity.HasKey(e => e.DetailsId);

                entity.Property(e => e.DetailsId).HasColumnName("DetailsID");

                entity.Property(e => e.PostDate).HasColumnType("datetime");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostsDetails)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostsDetails_PostsData");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PostsDetails)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostsDetails_Users");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Dob)
                    .HasColumnName("DOB")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Platform)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.HasOne(d => d.AddressNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Address)
                    .HasConstraintName("FK_Users_Address");

                entity.HasOne(d => d.ProfilePictureNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ProfilePicture)
                    .HasConstraintName("FK_Users_PictureData");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
