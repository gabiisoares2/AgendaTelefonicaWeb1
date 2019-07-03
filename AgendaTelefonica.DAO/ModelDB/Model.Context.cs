namespace AgendaTelefonica.DAO.ModelDB
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class agendatelefonicaEntities : DbContext
    {
        public agendatelefonicaEntities()
            : base("name=agendatelefonicaEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_cliente> tbl_cliente { get; set; }
        public virtual DbSet<tbl_cliente_telefone> tbl_cliente_telefone { get; set; }
    }
}
