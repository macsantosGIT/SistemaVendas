namespace SistemaVendas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Uf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TbAreaTransportadora",
                c => new
                    {
                        AreaTransportadoraId = c.Int(nullable: false, identity: true),
                        TransportadoraId = c.Int(nullable: false),
                        UfId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AreaTransportadoraId)
                .ForeignKey("dbo.TbTransportadora", t => t.TransportadoraId, cascadeDelete: true)
                .ForeignKey("dbo.TbUf", t => t.UfId, cascadeDelete: true)
                .Index(t => t.TransportadoraId)
                .Index(t => t.UfId);
            
            CreateTable(
                "dbo.TbTransportadora",
                c => new
                    {
                        TransportadoraId = c.Int(nullable: false, identity: true),
                        TransportadoraTipoPessoa = c.Int(nullable: false),
                        TransportadoraNome = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        TransportadoraNomeFantasia = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        TransportadoraCnpjCpf = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        TransportadoraIeRg = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        TransportadoraDddTel = c.Int(nullable: false),
                        TransportadoraTel = c.Int(nullable: false),
                        TransportadoraDddCel = c.Int(nullable: false),
                        TransportadoraCel = c.Int(nullable: false),
                        TransportadoraEmail = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        TransportadoraCep = c.Int(nullable: false),
                        TransportadoraEndereco = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        TransportadoraEnderecoComp = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        TransportadoraBairro = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        TransportadoraObservacao = c.String(unicode: false, storeType: "text"),
                        TransportadoraSite = c.String(maxLength: 100, storeType: "nvarchar"),
                        TransportadoraContatoNome1 = c.String(maxLength: 100, storeType: "nvarchar"),
                        TransportadoraContatoCargo1 = c.String(maxLength: 100, storeType: "nvarchar"),
                        TransportadoraContatoEmail1 = c.String(maxLength: 100, storeType: "nvarchar"),
                        TransportadoraContatoDddTel1 = c.Int(nullable: false),
                        TransportadoraContatoTel1 = c.Int(nullable: false),
                        TransportadoraContatoDddCel1 = c.Int(nullable: false),
                        TransportadoraContatoCel1 = c.Int(nullable: false),
                        TransportadoraContatoNome2 = c.String(maxLength: 100, storeType: "nvarchar"),
                        TransportadoraContatoCargo2 = c.String(maxLength: 100, storeType: "nvarchar"),
                        TransportadoraContatoEmail2 = c.String(maxLength: 100, storeType: "nvarchar"),
                        TransportadoraContatoDddTel2 = c.Int(nullable: false),
                        TransportadoraContatoTel2 = c.Int(nullable: false),
                        TransportadoraContatoDddCel2 = c.Int(nullable: false),
                        TransportadoraContatoCel2 = c.Int(nullable: false),
                        CidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TransportadoraId)
                .ForeignKey("dbo.TbCidade", t => t.CidadeId, cascadeDelete: true)
                .Index(t => t.CidadeId);
            
            CreateTable(
                "dbo.TbCidade",
                c => new
                    {
                        CidadeId = c.Int(nullable: false, identity: true),
                        CidadeNome = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        UfId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CidadeId)
                .ForeignKey("dbo.TbUf", t => t.UfId, cascadeDelete: true)
                .Index(t => t.UfId);
            
            CreateTable(
                "dbo.TbCliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        ClienteTipoPessoa = c.Int(nullable: false),
                        ClienteNome = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        ClienteNomeFantasia = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        ClienteCnpjCpf = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        ClienteIeRg = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        ClienteDddTel = c.Int(nullable: false),
                        ClienteTel = c.Int(nullable: false),
                        ClienteDddCel = c.Int(nullable: false),
                        ClienteCel = c.Int(nullable: false),
                        ClienteEmail = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        ClienteCep = c.Int(nullable: false),
                        ClienteEndereco = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        ClienteEnderecoComp = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        ClienteBairro = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        ClienteObservacao = c.String(unicode: false, storeType: "text"),
                        ClienteSite = c.String(maxLength: 100, storeType: "nvarchar"),
                        ClienteContatoNome1 = c.String(maxLength: 100, storeType: "nvarchar"),
                        ClienteContatoCargo1 = c.String(maxLength: 100, storeType: "nvarchar"),
                        ClienteContatoEmail1 = c.String(maxLength: 100, storeType: "nvarchar"),
                        ClienteContatoDddTel1 = c.Int(nullable: false),
                        ClienteContatoTel1 = c.Int(nullable: false),
                        ClienteContatoDddCel1 = c.Int(nullable: false),
                        ClienteContatoCel1 = c.Int(nullable: false),
                        ClienteContatoNome2 = c.String(maxLength: 100, storeType: "nvarchar"),
                        ClienteContatoCargo2 = c.String(maxLength: 100, storeType: "nvarchar"),
                        ClienteContatoEmail2 = c.String(maxLength: 100, storeType: "nvarchar"),
                        ClienteContatoDddTel2 = c.Int(nullable: false),
                        ClienteContatoTel2 = c.Int(nullable: false),
                        ClienteContatoDddCel2 = c.Int(nullable: false),
                        ClienteContatoCel2 = c.Int(nullable: false),
                        CidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ClienteId)
                .ForeignKey("dbo.TbCidade", t => t.CidadeId, cascadeDelete: true)
                .Index(t => t.CidadeId);
            
            CreateTable(
                "dbo.TbOrcamento",
                c => new
                    {
                        OrcamentoId = c.Int(nullable: false, identity: true),
                        OrcamentoDatEmissao = c.DateTime(nullable: false, precision: 0),
                        OrcamentoDatAlteracao = c.DateTime(nullable: false, precision: 0),
                        OrcamentoDesconto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrcamentoFrete = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrcamentoValorSubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrcamentoValor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrcamentoCondPagto = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        OrcamentoObservacao = c.String(unicode: false, storeType: "text"),
                        OrcamentoStatus = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        VendedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrcamentoId)
                .ForeignKey("dbo.TbCliente", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.TbVendedor", t => t.VendedorId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.VendedorId);
            
            CreateTable(
                "dbo.TbOrcamentoDetalhe",
                c => new
                    {
                        OrcamentoDetalheItem = c.Int(nullable: false, identity: true),
                        OrcamentoDetalheQtd = c.Int(nullable: false),
                        OrcamentoDetalhePctDesc = c.Decimal(nullable: false, precision: 16, scale: 4),
                        OrcamentoDetalhePrecoUnit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrcamentoDetalhePrecoTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrcamentoId = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrcamentoDetalheItem)
                .ForeignKey("dbo.TbOrcamento", t => t.OrcamentoId, cascadeDelete: true)
                .ForeignKey("dbo.TbProduto", t => t.ProdutoId, cascadeDelete: true)
                .Index(t => t.OrcamentoId)
                .Index(t => t.ProdutoId);
            
            CreateTable(
                "dbo.TbProduto",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        ProdutoNome = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        ProdutoObservacao = c.String(nullable: false, unicode: false, storeType: "text"),
                        ProdutoUnidade = c.String(nullable: false, maxLength: 5, storeType: "nvarchar"),
                        ProdutoImagem = c.Binary(storeType: "mediumblob"),
                        ProdutoIpi = c.Decimal(precision: 18, scale: 2),
                        ProdutoSubsTributaria = c.Decimal(precision: 18, scale: 2),
                        ProdutoPrecoCompra = c.Decimal(precision: 18, scale: 2),
                        ProdutoPctVenda = c.Decimal(precision: 18, scale: 2),
                        ProdutoPrecoSugerido = c.Decimal(precision: 18, scale: 2),
                        ProdutoMoeda = c.String(maxLength: 10, storeType: "nvarchar"),
                        ProdutoEstoque = c.Boolean(nullable: false),
                        ProdutoQtdEstoque = c.Int(),
                        ProdutoQtdMinEstoque = c.Int(),
                        ProdutoCodOrigem = c.String(maxLength: 20, storeType: "nvarchar"),
                        CategoriaId = c.Int(nullable: false),
                        FornecedorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.TbCategoria", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.TbFornecedor", t => t.FornecedorId, cascadeDelete: true)
                .Index(t => t.CategoriaId)
                .Index(t => t.FornecedorId);
            
            CreateTable(
                "dbo.TbCategoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        CategoriaNome = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.TbFornecedor",
                c => new
                    {
                        FornecedorId = c.Int(nullable: false, identity: true),
                        FornecedorTipoPessoa = c.Int(nullable: false),
                        FornecedorNome = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        FornecedorNomeFantasia = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        FornecedorCnpjCpf = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        FornecedorIeRg = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        FornecedorDddTel = c.Int(nullable: false),
                        FornecedorTel = c.Int(nullable: false),
                        FornecedorDddCel = c.Int(nullable: false),
                        FornecedorCel = c.Int(nullable: false),
                        FornecedorEmail = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        FornecedorCep = c.Int(nullable: false),
                        FornecedorEndereco = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        FornecedorEnderecoComp = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        FornecedorBairro = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        FornecedorObservacao = c.String(unicode: false, storeType: "text"),
                        FornecedorSite = c.String(maxLength: 100, storeType: "nvarchar"),
                        FornecedorContatoNome1 = c.String(maxLength: 100, storeType: "nvarchar"),
                        FornecedorContatoCargo1 = c.String(maxLength: 100, storeType: "nvarchar"),
                        FornecedorContatoEmail1 = c.String(maxLength: 100, storeType: "nvarchar"),
                        FornecedorContatoDddTel1 = c.Int(nullable: false),
                        FornecedorContatoTel1 = c.Int(nullable: false),
                        FornecedorContatoDddCel1 = c.Int(nullable: false),
                        FornecedorContatoCel1 = c.Int(nullable: false),
                        FornecedorContatoNome2 = c.String(maxLength: 100, storeType: "nvarchar"),
                        FornecedorContatoCargo2 = c.String(maxLength: 100, storeType: "nvarchar"),
                        FornecedorContatoEmail2 = c.String(maxLength: 100, storeType: "nvarchar"),
                        FornecedorContatoDddTel2 = c.Int(nullable: false),
                        FornecedorContatoTel2 = c.Int(nullable: false),
                        FornecedorContatoDddCel2 = c.Int(nullable: false),
                        FornecedorContatoCel2 = c.Int(nullable: false),
                        CidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FornecedorId)
                .ForeignKey("dbo.TbCidade", t => t.CidadeId, cascadeDelete: true)
                .Index(t => t.CidadeId);
            
            CreateTable(
                "dbo.TbVendedor",
                c => new
                    {
                        VendedorId = c.Int(nullable: false, identity: true),
                        VendedorNome = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        VendedorDddTel = c.Int(nullable: false),
                        VendedorTel = c.Int(nullable: false),
                        VendedorDddCel = c.Int(nullable: false),
                        VendedorCel = c.Int(nullable: false),
                        VendedorEmail = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.VendedorId);
            
            CreateTable(
                "dbo.TbEmpresa",
                c => new
                    {
                        EmpresaId = c.Int(nullable: false, identity: true),
                        EmpresaNome = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        EmpresaNomeFantasia = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        EmpresaCnpj = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        EmpresaIe = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        EmpresaDddTel = c.Int(nullable: false),
                        EmpresaTel = c.Int(nullable: false),
                        EmpresaDddCel = c.Int(nullable: false),
                        EmpresaCel = c.Int(nullable: false),
                        EmpresaEmail = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        EmpresaCep = c.Int(nullable: false),
                        EmpresaEndereco = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        EmpresaEnderecoComp = c.String(maxLength: 50, storeType: "nvarchar"),
                        EmpresaBairro = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        EmpresaObservacao = c.String(unicode: false, storeType: "text"),
                        EmpresaSite = c.String(maxLength: 100, storeType: "nvarchar"),
                        CidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmpresaId)
                .ForeignKey("dbo.TbCidade", t => t.CidadeId, cascadeDelete: true)
                .Index(t => t.CidadeId);
            
            CreateTable(
                "dbo.TbUf",
                c => new
                    {
                        UfId = c.Int(nullable: false, identity: true),
                        UfNome = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        UfSigla = c.String(nullable: false, maxLength: 2, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.UfId);
            
            CreateTable(
                "dbo.TbUsuario",
                c => new
                    {
                        Codigo = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        Login = c.String(nullable: false, maxLength: 20, storeType: "nvarchar"),
                        Senha = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Codigo);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TbAreaTransportadora", "UfId", "dbo.TbUf");
            DropForeignKey("dbo.TbAreaTransportadora", "TransportadoraId", "dbo.TbTransportadora");
            DropForeignKey("dbo.TbTransportadora", "CidadeId", "dbo.TbCidade");
            DropForeignKey("dbo.TbCidade", "UfId", "dbo.TbUf");
            DropForeignKey("dbo.TbEmpresa", "CidadeId", "dbo.TbCidade");
            DropForeignKey("dbo.TbOrcamento", "VendedorId", "dbo.TbVendedor");
            DropForeignKey("dbo.TbOrcamentoDetalhe", "ProdutoId", "dbo.TbProduto");
            DropForeignKey("dbo.TbProduto", "FornecedorId", "dbo.TbFornecedor");
            DropForeignKey("dbo.TbFornecedor", "CidadeId", "dbo.TbCidade");
            DropForeignKey("dbo.TbProduto", "CategoriaId", "dbo.TbCategoria");
            DropForeignKey("dbo.TbOrcamentoDetalhe", "OrcamentoId", "dbo.TbOrcamento");
            DropForeignKey("dbo.TbOrcamento", "ClienteId", "dbo.TbCliente");
            DropForeignKey("dbo.TbCliente", "CidadeId", "dbo.TbCidade");
            DropIndex("dbo.TbEmpresa", new[] { "CidadeId" });
            DropIndex("dbo.TbFornecedor", new[] { "CidadeId" });
            DropIndex("dbo.TbProduto", new[] { "FornecedorId" });
            DropIndex("dbo.TbProduto", new[] { "CategoriaId" });
            DropIndex("dbo.TbOrcamentoDetalhe", new[] { "ProdutoId" });
            DropIndex("dbo.TbOrcamentoDetalhe", new[] { "OrcamentoId" });
            DropIndex("dbo.TbOrcamento", new[] { "VendedorId" });
            DropIndex("dbo.TbOrcamento", new[] { "ClienteId" });
            DropIndex("dbo.TbCliente", new[] { "CidadeId" });
            DropIndex("dbo.TbCidade", new[] { "UfId" });
            DropIndex("dbo.TbTransportadora", new[] { "CidadeId" });
            DropIndex("dbo.TbAreaTransportadora", new[] { "UfId" });
            DropIndex("dbo.TbAreaTransportadora", new[] { "TransportadoraId" });
            DropTable("dbo.TbUsuario");
            DropTable("dbo.TbUf");
            DropTable("dbo.TbEmpresa");
            DropTable("dbo.TbVendedor");
            DropTable("dbo.TbFornecedor");
            DropTable("dbo.TbCategoria");
            DropTable("dbo.TbProduto");
            DropTable("dbo.TbOrcamentoDetalhe");
            DropTable("dbo.TbOrcamento");
            DropTable("dbo.TbCliente");
            DropTable("dbo.TbCidade");
            DropTable("dbo.TbTransportadora");
            DropTable("dbo.TbAreaTransportadora");
        }
    }
}
