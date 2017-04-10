namespace SistemaVendas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orcamento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TbOrcamento", "FornecedorId", c => c.Int(nullable: false));
            CreateIndex("dbo.TbOrcamento", "FornecedorId");
            AddForeignKey("dbo.TbOrcamento", "FornecedorId", "dbo.TbFornecedor", "FornecedorId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TbOrcamento", "FornecedorId", "dbo.TbFornecedor");
            DropIndex("dbo.TbOrcamento", new[] { "FornecedorId" });
            DropColumn("dbo.TbOrcamento", "FornecedorId");
        }
    }
}
