using API_da_rifa.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API_da_rifa.Infrastructure
{
    public class ConnectionContext : DbContext
    {
        //Setta a tabela
        public DbSet<Participante> Participante { get; set; }

        //Passa os parametros para conexção com o banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseMySql(
            "server=localhost;" +
            "Port=3306; Database = rifadb;" +
            "User=root;" +
            "Password=Tetoterritory2930!",
            new MySqlServerVersion(new Version(8, 0, 36)));

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.Entity<Participante>(entity =>
        {
            entity.ToTable("Participante");

            entity.HasKey(p => p.ID_participante);

            entity.Property(p => p.DataNascimento)
                  .HasColumnName("Data_nasc");

            entity.Property(p => p.NumeroTelefone)
                  .HasColumnName("Numero_tel");

            entity.Property(p => p.NumeroComprado)
                  .HasColumnName("Numero_comprado");
        });
    }

}
