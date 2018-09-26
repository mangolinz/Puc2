using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//using Microsoft.Extensions.Options;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Puc2.AcessoADados
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("PucLogistica_AWS") // local-->pucLocalhost  //AWS-->PucLogistica_AWS  // Azure -->"PucLogistica_AZURE"
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Puc2.BaseDeDados.Coleta> Coletas { get; set; }

        public DbSet<Puc2.BaseDeDados.PedidoColeta> PedidoColetas { get; set; }

        //public DbSet<> PedidoColetas { get; set; }
    }


}