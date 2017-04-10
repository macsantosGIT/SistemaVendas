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
    public class UsuarioMaps : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMaps()
        {
            ToTable("TbUsuario");
            HasKey(x => x.Codigo);
            Property(x => x.Codigo).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Nome).IsRequired().HasMaxLength(50);
            Property(x => x.Senha).IsRequired().HasMaxLength(50);
            Property(x => x.Login).IsRequired().HasMaxLength(20);
        }
    }
}
