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
    public class AreaTransportadoraMaps : EntityTypeConfiguration<AreaTransportadora>
    {
        public AreaTransportadoraMaps()
        {
            ToTable("TbAreaTransportadora");
            HasKey(x => x.AreaTransportadoraId);

            HasRequired(x => x.Transportadora).WithMany(x => x.AreaTransportadoras).Map(m => m.MapKey("TransportadoraId"));
            HasRequired(x => x.Uf).WithMany(x => x.AreaTransportadoras).Map(m => m.MapKey("UfId"));
        }
    }
}
