using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVendas.Models.Mapeamento
{
    public class ProdutoMaps : EntityTypeConfiguration<Produto>
    {
        public ProdutoMaps() {
            ToTable("TbProduto");
            HasKey(x => x.ProdutoId);
            Property(x => x.ProdutoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ProdutoNome).IsRequired().HasMaxLength(100);
            Property(x => x.ProdutoObservacao).IsRequired().HasColumnType("TEXT");//.HasMaxLength(2000);
            Property(x => x.ProdutoUnidade).IsRequired().HasMaxLength(5);
            Property(x => x.ProdutoImagem).IsOptional().HasColumnType("MEDIUMBLOB");
            Property(x => x.ProdutoIpi).IsOptional().HasColumnType("DECIMAL").HasPrecision(18,2);
            Property(x => x.ProdutoSubsTributaria).IsOptional().HasColumnType("DECIMAL").HasPrecision(18, 2);
            Property(x => x.ProdutoPrecoCompra).IsOptional().HasColumnType("DECIMAL").HasPrecision(18, 2);
            Property(x => x.ProdutoPctVenda).IsOptional().HasColumnType("DECIMAL").HasPrecision(18, 2);
            Property(x => x.ProdutoPrecoSugerido).IsOptional().HasColumnType("DECIMAL").HasPrecision(18, 2);
            Property(x => x.ProdutoMoeda).IsOptional().HasMaxLength(10);
            Property(x => x.ProdutoEstoque).IsRequired().HasColumnType("BOOL");
            Property(x => x.ProdutoQtdEstoque).IsOptional();
            Property(x => x.ProdutoQtdMinEstoque).IsOptional();
            Property(x => x.ProdutoCodOrigem).IsOptional().HasMaxLength(20);

            HasRequired(x => x.Categoria).WithMany(x => x.Produtos).Map(m => m.MapKey("CategoriaId"));
            HasRequired(x => x.Fornecedor).WithMany(x => x.Produtos).Map(m => m.MapKey("FornecedorId"));

            //Property(x => x.ProdutoNome).IsRequired().HasColumnType("VARCHAR").HasMaxLength(100); //.HasMaxLength(100);
            //.HasColumnType("VARCHAR")

            //HasKey(x => x.Id);
            //Property(x => x.ReceivedTime).HasColumnType("datetime").IsRequired(); ;
            //Property(x => x.SentTime).HasColumnType("datetime").IsRequired();
            //Property(x => x.Status).HasColumnType("varchar").HasMaxLength(75).IsRequired();

        }
    }
}
