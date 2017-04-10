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
    public class UfMaps : EntityTypeConfiguration<Uf>
    {
        public UfMaps()
        {
            ToTable("TbUf");
            HasKey(x => x.UfId);
            Property(x => x.UfId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.UfNome).IsRequired().HasMaxLength(50);
            Property(x => x.UfSigla).IsRequired().HasMaxLength(2);
        }

    }
}
