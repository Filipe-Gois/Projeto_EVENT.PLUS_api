using Microsoft.EntityFrameworkCore;
using webapi.event_.tarde.Domains;

namespace webapi.event_.tarde.Contexts
{
    public class EventContext : DbContext
    {
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<TipoEvento> TipoEvento { get; set; }
        public DbSet<Evento> Evento { get; set; }
        public DbSet<ComentarioEvento> ComentarioEvento { get; set; }
        public DbSet<Instituicao> Instituicao { get; set; }
        public DbSet<PresencaEvento> PresencaEvento { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = NOTE14-S14; Database = event+_codeFirst_tarde; User Id = sa; Pwd = Senai@134; TrustServerCertificate = true");
            base.OnConfiguring(optionsBuilder);



            //String de conexão pc de casa
            //optionsBuilder.UseSqlServer("Server = FILIPEGOISSQLEXPRESS; Database = event+_codeFirst_tarde; User Id = sa; Pwd = xtringer28700; TrustServerCertificate = true");
            //base.OnConfiguring(optionsBuilder);



        }
    }
}
