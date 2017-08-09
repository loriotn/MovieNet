namespace MovieNetDbProject
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelMovieNet : DbContext
    {
        public ModelMovieNet()
            : base("name=ModelMovieNet")
        {
        }

        public virtual DbSet<Commentaire> commentaire { get; set; }
        public virtual DbSet<Film> film { get; set; }
        public virtual DbSet<Genre> genre { get; set; }
        public virtual DbSet<Note> note { get; set; }
        public virtual DbSet<Utilisateur> utilisateur { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commentaire>()
                .Property(e => e.commentaire)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.titre_film)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .Property(e => e.resume_film)
                .IsUnicode(false);

            modelBuilder.Entity<Film>()
                .HasMany(e => e.commentaire)
                .WithRequired(e => e.film)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Film>()
                .HasMany(e => e.note)
                .WithRequired(e => e.film)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Genre>()
                .Property(e => e.label_genre)
                .IsUnicode(false);

            modelBuilder.Entity<Genre>()
                .HasMany(e => e.film)
                .WithRequired(e => e.genre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.nom_utilisateur)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.prenom_utilisateur)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .Property(e => e.mdp_utilisateur)
                .IsUnicode(false);

            modelBuilder.Entity<Utilisateur>()
                .HasMany(e => e.commentaire)
                .WithRequired(e => e.utilisateur)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Utilisateur>()
                .HasMany(e => e.note)
                .WithRequired(e => e.utilisateur)
                .WillCascadeOnDelete(false);
        }
    }
}
