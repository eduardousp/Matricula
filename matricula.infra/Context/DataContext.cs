using matricula.infra.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace matricula.infra.Context
{
    public class DataContext : DbContext, IUnitOfWork
    {
        public DataContext() : base("Data Source=EDU-ACER;Initial Catalog=matriculadb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False") { }
        public DbSet<Aluno> Alunos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public void Save()
        {
            base.SaveChanges();
        }
    }


}
