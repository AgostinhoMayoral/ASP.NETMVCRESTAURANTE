namespace EntidadesDAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CadastroModelo : DbContext
    {
        public CadastroModelo()
            : base("name=CadastroModelo")
        {
        }

        public virtual DbSet<Prato> Prato { get; set; }
        public virtual DbSet<Restaurante> Restaurante { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Prato>()
                .Property(e => e.PratoPreco)
                .HasPrecision(16, 2);

            modelBuilder.Entity<Restaurante>()
                .Property(e => e.RestauranteNome)
                .IsUnicode(false);

            modelBuilder.Entity<Restaurante>()
                .HasMany(e => e.Prato)
                .WithOptional(e => e.Restaurante)
                .WillCascadeOnDelete();
        }
    }
}
