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
    public class OrcamentoDetalheMaps : EntityTypeConfiguration<OrcamentoDetalhe>
    {
        public OrcamentoDetalheMaps() {
            ToTable("TbOrcamentoDetalhe");
            HasKey(x => x.OrcamentoDetalheItem);
            Property(x => x.OrcamentoDetalheItem).IsRequired();
            Property(x => x.OrcamentoDetalheQtd).IsRequired();
            Property(x => x.OrcamentoDetalhePctDesc).HasColumnType("DECIMAL").HasPrecision(16, 4);
            Property(x => x.OrcamentoDetalhePrecoUnit).IsRequired().HasColumnType("DECIMAL").HasPrecision(18, 2);
            Property(x => x.OrcamentoDetalhePrecoTotal).IsRequired().HasColumnType("DECIMAL").HasPrecision(18, 2);

            HasRequired(x => x.Orcamento).WithMany(x => x.Odetalhes).Map(m => m.MapKey("OrcamentoId"));
            HasRequired(x => x.Produto).WithMany(x => x.Odetalhes).Map(m => m.MapKey("ProdutoId"));
        }
    }
}
