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
    public class EmpresaMaps : EntityTypeConfiguration<Empresa>
    {
        public EmpresaMaps()
        {
            ToTable("TbEmpresa");
            HasKey(x => x.EmpresaId);
            Property(x => x.EmpresaId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.EmpresaNome).IsRequired().HasMaxLength(100);
            Property(x => x.EmpresaNomeFantasia).IsRequired().HasMaxLength(100);
            Property(x => x.EmpresaCnpj).IsRequired().HasMaxLength(20);
            Property(x => x.EmpresaIe).IsRequired().HasMaxLength(20);
            Property(x => x.EmpresaDddTel).HasColumnType("INT");
            Property(x => x.EmpresaTel).HasColumnType("INT");
            Property(x => x.EmpresaDddCel).HasColumnType("INT");
            Property(x => x.EmpresaCel).HasColumnType("INT");
            Property(x => x.EmpresaEmail).IsRequired().HasMaxLength(100);
            Property(x => x.EmpresaCep).IsRequired().HasColumnType("INT");
            Property(x => x.EmpresaEndereco).IsRequired().HasMaxLength(100);
            Property(x => x.EmpresaEnderecoComp).HasMaxLength(50);
            Property(x => x.EmpresaBairro).IsRequired().HasMaxLength(50);
            Property(x => x.EmpresaObservacao).HasColumnType("TEXT");//.HasMaxLength(2000);
            Property(x => x.EmpresaSite).HasMaxLength(100);
            
            HasRequired(x=>x.Cidade).WithMany(x=>x.Empresas).Map(m=>m.MapKey("CidadeId"));
        }
    }
}
