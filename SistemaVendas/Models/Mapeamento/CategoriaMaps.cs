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
    public class CategoriaMaps : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMaps()
        {
            ToTable("TbCategoria");
            HasKey(x => x.CategoriaId);
            Property(x => x.CategoriaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x=>x.CategoriaNome).IsRequired().HasMaxLength(50);

        }
    }
}
