﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure
{
    public class NegosudContext : DbContext
    {
        public NegosudContext(DbContextOptions<NegosudContext> options)
        : base(options)
        {

        }

        public DbSet<Famille> Famille { get; set; }

        public DbSet<Article> Article { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Définir la relation entre Article et Famille
            modelBuilder.Entity<Article>()
                .HasOne(a => a.Famille)         // Un Article a une Famille
                .WithMany()                     // Une Famille peut avoir plusieurs Articles (si la relation est 1 à N)
                .HasForeignKey(a => a.FamilleId);  // La clé étrangère dans Article qui pointe vers Famille

            modelBuilder.Entity<Article>()
                .HasMany(x => x.Stocks)
                .WithOne()
                .HasForeignKey(x => x.ArticleId);
        }
        
        public DbSet<Adresse> Adresse { get; set; }
        public DbSet<Utilisateur> Utilisateur { get; set; }
        public DbSet<Fournisseur> Fournisseur { get; set; }
        public DbSet<PrixArticle> PrixArticle { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Commande> Commande { get; set; }
        public DbSet<ArticleCommande> ArticleCommande { get; set; }
    }
}
