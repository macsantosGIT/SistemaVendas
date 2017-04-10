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
    public class PedidoDetalheMaps :EntityTypeConfiguration<PedidoDetalhe>
    {
        public PedidoDetalheMaps(){
            ToTable("TbPedidoDetalhe");
            HasKey(x => x.PedidoDetalheItem);
            Property(x => x.PedidoDetalheItem).IsRequired();
            Property(x => x.PedidoDetalheQtd).IsRequired();
            Property(x => x.PedidoDetalhePctDesc).HasColumnType("DECIMAL").HasPrecision(16, 4);
            Property(x => x.PedidoDetalhePrecoUnit).IsRequired().HasColumnType("DECIMAL").HasPrecision(18, 2);
            Property(x => x.PedidoDetalhePrecoTotal).IsRequired().HasColumnType("DECIMAL").HasPrecision(18, 2);

            HasRequired(x => x.Pedido).WithMany(x => x.Pdetalhes).Map(m => m.MapKey("PedidoId"));
            HasRequired(x => x.Produto).WithMany(x => x.Pdetalhes).Map(m => m.MapKey("ProdutoId"));
        }
    }
}
