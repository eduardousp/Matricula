namespace matricula.infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mapping : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Aluno", "Nome", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Aluno", "Identificacao", c => c.String(maxLength: 20));
            AlterColumn("dbo.Aluno", "Telefone", c => c.String(maxLength: 15));
            CreateIndex("dbo.Aluno", "Nome", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Aluno", new[] { "Nome" });
            AlterColumn("dbo.Aluno", "Telefone", c => c.String());
            AlterColumn("dbo.Aluno", "Identificacao", c => c.String());
            AlterColumn("dbo.Aluno", "Nome", c => c.String());
        }
    }
}
