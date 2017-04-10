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
    public class OrcamentoMaps: EntityTypeConfiguration<Orcamento>
    {
        public OrcamentoMaps() {
            ToTable("TbOrcamento");
            HasKey(x => x.OrcamentoId);
            Property(x => x.OrcamentoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.OrcamentoDatEmissao).IsRequired().HasColumnType("DATETIME");
            Property(x=>x.OrcamentoDatAlteracao).IsRequired().HasColumnType("DATETIME");
            Property(x => x.OrcamentoDesconto).HasColumnType("DECIMAL").HasPrecision(18,2);
            Property(x => x.OrcamentoFrete).HasColumnType("DECIMAL").HasPrecision(18, 2);
            Property(x => x.OrcamentoValorSubTotal).HasColumnType("DECIMAL").HasPrecision(18, 2);
            Property(x => x.OrcamentoValor).IsRequired().HasColumnType("DECIMAL").HasPrecision(18, 2);
            Property(x => x.OrcamentoCondPagto).IsRequired().HasMaxLength(20);
            Property(x => x.OrcamentoObservacao).HasColumnType("TEXT");
            Property(x => x.OrcamentoStatus).IsRequired();
            Property(x => x.OrcamentoDataEntrega).HasColumnType("DATETIME");

            HasRequired(x => x.Cliente).WithMany(x => x.Orcamentos).Map(m => m.MapKey("ClienteId"));
            HasRequired(x => x.Vendedor).WithMany(x => x.Orcamentos).Map(m => m.MapKey("VendedorId"));
            HasRequired(x => x.Fornecedor).WithMany(x => x.Orcamentos).Map(m => m.MapKey("FornecedorId"));
        }
    }
}
