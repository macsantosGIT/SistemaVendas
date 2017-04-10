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
    public class FornecedorMaps: EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorMaps()
        {
            ToTable("TbFornecedor");
            HasKey(x => x.FornecedorId);
            Property(x => x.FornecedorId).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.FornecedorTipoPessoa).IsRequired().HasColumnType("INT");
            Property(x => x.FornecedorNome).IsRequired().HasMaxLength(100);
            Property(x => x.FornecedorNomeFantasia).IsRequired().HasMaxLength(100);
            Property(x => x.FornecedorCnpjCpf).IsRequired().HasMaxLength(20);
            Property(x => x.FornecedorIeRg).IsRequired().HasMaxLength(20);
            Property(x => x.FornecedorDddTel).HasColumnType("INT");
            Property(x => x.FornecedorTel).HasColumnType("INT");
            Property(x => x.FornecedorDddCel).HasColumnType("INT");
            Property(x => x.FornecedorCel).HasColumnType("INT");
            Property(x => x.FornecedorEmail).IsRequired().HasMaxLength(100);
            Property(x => x.FornecedorCep).HasColumnType("INT");
            Property(x => x.FornecedorEndereco).IsRequired().IsRequired().HasMaxLength(100);
            Property(x => x.FornecedorEnderecoComp).IsRequired().HasMaxLength(100);
            Property(x => x.FornecedorBairro).IsRequired().HasMaxLength(100);
            Property(x => x.FornecedorObservacao).HasColumnType("TEXT");//.HasMaxLength(2000);
            Property(x => x.FornecedorSite).HasMaxLength(100);
            Property(x => x.FornecedorContatoNome1).HasMaxLength(100);
            Property(x => x.FornecedorContatoCargo1).HasMaxLength(100);
            Property(x => x.FornecedorContatoEmail1).HasMaxLength(100);
            Property(x => x.FornecedorContatoDddTel1).HasColumnType("INT");
            Property(x => x.FornecedorContatoTel1).HasColumnType("INT");
            Property(x => x.FornecedorContatoDddCel1).HasColumnType("INT");
            Property(x => x.FornecedorContatoCel1).HasColumnType("INT");
            Property(x => x.FornecedorContatoNome2).HasMaxLength(100);
            Property(x => x.FornecedorContatoCargo2).HasMaxLength(100);
            Property(x => x.FornecedorContatoEmail2).HasMaxLength(100);
            Property(x => x.FornecedorContatoDddTel2).HasColumnType("INT");
            Property(x => x.FornecedorContatoTel2).HasColumnType("INT");
            Property(x => x.FornecedorContatoDddCel2).HasColumnType("INT");
            Property(x => x.FornecedorContatoCel2).HasColumnType("INT");

            HasRequired(x => x.Cidade).WithMany(x => x.Fornecedores).Map(m => m.MapKey("CidadeId"));
        }
    }
}
