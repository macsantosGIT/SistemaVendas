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
    public class CidadeMaps : EntityTypeConfiguration<Cidade>
    {
        public CidadeMaps()
        {
            ToTable("TbCidade");
            HasKey(x => x.CidadeId);
            Property(x => x.CidadeId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CidadeNome).IsRequired().HasMaxLength(50);

            HasRequired(x => x.Uf).WithMany(x => x.Cidades).Map(m => m.MapKey("UfId"));
        }
    }
}
