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
    public class ClienteMaps : EntityTypeConfiguration<Cliente>
    {
        public ClienteMaps()
        {
            ToTable("TbCliente");
            HasKey(x => x.ClienteId);
            Property(x => x.ClienteId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ClienteTipoPessoa).IsRequired().HasColumnType("INT");
            Property(x => x.ClienteNome).IsRequired().HasMaxLength(100);
            Property(x => x.ClienteNomeFantasia).IsRequired().HasMaxLength(100);
            Property(x => x.ClienteCnpjCpf).IsRequired().HasMaxLength(20);
            Property(x => x.ClienteIeRg).IsRequired().HasMaxLength(20);
            Property(x => x.ClienteDddTel).HasColumnType("INT");
            Property(x => x.ClienteTel).HasColumnType("INT");
            Property(x => x.ClienteDddCel).HasColumnType("INT");
            Property(x => x.ClienteCel).HasColumnType("INT");
            Property(x => x.ClienteEmail).IsRequired().HasMaxLength(100);
            Property(x => x.ClienteCep).HasColumnType("INT");
            Property(x => x.ClienteEndereco).IsRequired().IsRequired().HasMaxLength(100);
            Property(x => x.ClienteEnderecoComp).IsRequired().HasMaxLength(100);
            Property(x => x.ClienteBairro).IsRequired().HasMaxLength(100);
            Property(x => x.ClienteObservacao).HasColumnType("TEXT");//.HasMaxLength(2000);
            Property(x => x.ClienteSite).HasMaxLength(100);
            Property(x => x.ClienteContatoNome1).HasMaxLength(100);
            Property(x => x.ClienteContatoCargo1).HasMaxLength(100);
            Property(x => x.ClienteContatoEmail1).HasMaxLength(100);
            Property(x => x.ClienteContatoDddTel1).HasColumnType("INT");
            Property(x => x.ClienteContatoTel1).HasColumnType("INT");
            Property(x => x.ClienteContatoDddCel1).HasColumnType("INT");
            Property(x => x.ClienteContatoCel1).HasColumnType("INT");
            Property(x => x.ClienteContatoNome2).HasMaxLength(100);
            Property(x => x.ClienteContatoCargo2).HasMaxLength(100);
            Property(x => x.ClienteContatoEmail2).HasMaxLength(100);
            Property(x => x.ClienteContatoDddTel2).HasColumnType("INT");
            Property(x => x.ClienteContatoTel2).HasColumnType("INT");
            Property(x => x.ClienteContatoDddCel2).HasColumnType("INT");
            Property(x => x.ClienteContatoCel2).HasColumnType("INT");

            HasRequired(x => x.Cidade).WithMany(x => x.Clientes).Map(m => m.MapKey("CidadeId"));
        }
    }
}
