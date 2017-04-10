using SistemaVendas.Models;
using System.Data.Entity;
using System.Reflection;

namespace SistemaVendas.DAL
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class SistemaVendasContexto : DbContext
    {

        public SistemaVendasContexto() : base("ConexaoBanco") { }

        public static SistemaVendasContexto Instancia = new SistemaVendasContexto();

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Uf> Uf { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Transportadora> Transportadora { get; set; }
        public DbSet<AreaTransportadora> AreaTransportadora { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; }
        public DbSet<Orcamento> Orcamento { get; set; }
        public DbSet<OrcamentoDetalhe> OrcamentoDetalhe { get; set; }
        //public DbSet<Pedido> Pedido { get; set; }
        //public DbSet<PedidoDetalhe> PedidoDetalhe { get; set; }       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(type => !string.IsNullOrEmpty(type.Namespace)).
            //Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
            //foreach(var type in typesToRegister)
            //{
            //    var configInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configInstance);
            //}
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
