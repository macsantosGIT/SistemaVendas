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
    public class PedidoMaps :EntityTypeConfiguration<Pedido>
    {
        public PedidoMaps() {
            ToTable("TbPedido");
            HasKey(x => x.PedidoId);
            Property(x => x.PedidoId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.PedidoDatEmissao).IsRequired().HasColumnType("DATETIME");
            Property(x => x.PedidoDatAlteracao).IsRequired().HasColumnType("DATETIME");
            Property(x => x.PedidoFrete).HasColumnType("DECIMAL").HasPrecision(18, 2);
            Property(x => x.PedidoValorSubTotal).HasColumnType("DECIMAL").HasPrecision(18, 2);
            Property(x => x.PedidoDesconto).HasColumnType("DECIMAL").HasPrecision(18, 2);
            Property(x => x.PedidoValor).IsRequired().HasColumnType("DECIMAL").HasPrecision(18, 2);
            Property(x => x.PedidoCondPagto).IsRequired().HasMaxLength(20);
            Property(x => x.PedidoObservacao).HasColumnType("TEXT");
            Property(x => x.OrcamentoPedido).IsRequired();

            HasRequired(x => x.Cliente).WithMany(x => x.Pedidos).Map(m => m.MapKey("ClienteId"));
            HasRequired(x => x.Fornecedor).WithMany(x => x.Pedidos).Map(m => m.MapKey("FornecedorId"));
            HasRequired(x => x.Vendedor).WithMany(x => x.Pedidos).Map(m => m.MapKey("VendedorId"));
            //HasRequired(x => x.OrcamentoPedido) //(x => x.PedidoO).Map(m => m.MapKey("OrcamentoId"));
        }
    }
}
