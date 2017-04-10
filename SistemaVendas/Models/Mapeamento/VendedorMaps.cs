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
    public class VendedorMaps : EntityTypeConfiguration<Vendedor>
    {
        public VendedorMaps() {
            ToTable("TbVendedor");
            HasKey(x => x.VendedorId);
            Property(x => x.VendedorId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.VendedorNome).IsRequired().HasMaxLength(50);
            Property(x => x.VendedorDddTel).IsRequired();
            Property(x => x.VendedorTel).IsRequired();
            Property(x => x.VendedorDddCel).IsRequired();
            Property(x => x.VendedorCel).IsRequired();
            Property(x => x.VendedorEmail).IsRequired().HasMaxLength(100);

            //.HasColumnType(
        }
    }
}
