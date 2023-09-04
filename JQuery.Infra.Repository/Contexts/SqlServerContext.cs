using Microsoft.EntityFrameworkCore;
using JQuery.Domain.Entities;
using JQuery.Infra.Repository.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JQuery.Infra.Repository.Contexts
{
    /// <summary>
    /// Classe de conexão com o banco de dados atraves do EF
    /// </summary>
    public class SqlServerContext : DbContext
    {
        //construtor para inicializar a classe por meio de injeção de dependência
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false; // Desabilitar o lazy loading

        }

        //declarar uma propriedade DbSet para cada entidade
        public DbSet<Friend> Friend { get; set; }
        public DbSet<State> State { get; set; }

        //adicionar cada classe de mapeamento feita no projeto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FriendMap());
            modelBuilder.ApplyConfiguration(new StateMap());
        }
    }
}
