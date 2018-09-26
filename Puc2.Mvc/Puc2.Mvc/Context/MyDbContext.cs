using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.Extensions.Options;
using System.Data.Entity.ModelConfiguration.Conventions;
using Puc2.Mvc.Entidades;

namespace Puc2.Mvc.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base("PucLogistica_AWS")  // local-->pucLocalhost  //AWS-->PucLogistica_AWS  // Azure -->"PucLogistica_AZURE"
        {
        }

        public DbSet<Coleta> Coletas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public System.Data.Entity.DbSet<Puc2.Mvc.Entidades.PedidoColeta> PedidoColetas { get; set; }
    }


}