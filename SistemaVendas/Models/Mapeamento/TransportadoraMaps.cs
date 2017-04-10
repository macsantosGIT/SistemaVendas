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
    public class TransportadoraMaps : EntityTypeConfiguration<Transportadora>
    {
        public TransportadoraMaps()
        {
            ToTable("TbTransportadora");
            HasKey(x => x.TransportadoraId);
            Property(x => x.TransportadoraId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.TransportadoraTipoPessoa).IsRequired().HasColumnType("INT");
            Property(x => x.TransportadoraNome).IsRequired().HasMaxLength(100);
            Property(x => x.TransportadoraNomeFantasia).IsRequired().HasMaxLength(100);
            Property(x => x.TransportadoraCnpjCpf).IsRequired().HasMaxLength(20);
            Property(x => x.TransportadoraIeRg).IsRequired().HasMaxLength(20);
            Property(x => x.TransportadoraDddTel).HasColumnType("INT");
            Property(x => x.TransportadoraTel).HasColumnType("INT");
            Property(x => x.TransportadoraDddCel).HasColumnType("INT");
            Property(x => x.TransportadoraCel).HasColumnType("INT");
            Property(x => x.TransportadoraEmail).IsRequired().HasMaxLength(100);
            Property(x => x.TransportadoraCep).HasColumnType("INT");
            Property(x => x.TransportadoraEndereco).IsRequired().IsRequired().HasMaxLength(100);
            Property(x => x.TransportadoraEnderecoComp).IsRequired().HasMaxLength(100);
            Property(x => x.TransportadoraBairro).IsRequired().HasMaxLength(100);
            Property(x => x.TransportadoraObservacao).HasColumnType("TEXT");//HasMaxLength(2000);
            Property(x => x.TransportadoraSite).HasMaxLength(100);
            Property(x => x.TransportadoraContatoNome1).HasMaxLength(100);
            Property(x => x.TransportadoraContatoCargo1).HasMaxLength(100);
            Property(x => x.TransportadoraContatoEmail1).HasMaxLength(100);
            Property(x => x.TransportadoraContatoDddTel1).HasColumnType("INT");
            Property(x => x.TransportadoraContatoTel1).HasColumnType("INT");
            Property(x => x.TransportadoraContatoDddCel1).HasColumnType("INT");
            Property(x => x.TransportadoraContatoCel1).HasColumnType("INT");
            Property(x => x.TransportadoraContatoNome2).HasMaxLength(100);
            Property(x => x.TransportadoraContatoCargo2).HasMaxLength(100);
            Property(x => x.TransportadoraContatoEmail2).HasMaxLength(100);
            Property(x => x.TransportadoraContatoDddTel2).HasColumnType("INT");
            Property(x => x.TransportadoraContatoTel2).HasColumnType("INT");
            Property(x => x.TransportadoraContatoDddCel2).HasColumnType("INT");
            Property(x => x.TransportadoraContatoCel2).HasColumnType("INT");

            HasRequired(x => x.Cidade).WithMany(x=>x.Transportadoras).Map(m=>m.MapKey("CidadeId"));
        }
    }
}
