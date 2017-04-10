namespace SistemaVendas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Orcamento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TbOrcamento", "OrcamentoFrete", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TbOrcamento", "OrcamentoValorSubTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.TbOrcamento", "OrcamentoObservacao", c => c.String(unicode: false, storeType: "text"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.TbOrcamento", "OrcamentoObservacao");
            DropColumn("dbo.TbOrcamento", "OrcamentoValorSubTotal");
            DropColumn("dbo.TbOrcamento", "OrcamentoFrete");
        }
    }
}
