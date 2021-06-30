using Microsoft.EntityFrameworkCore;
using Database.Models;

namespace Database.Data
{
    public class EvaluacionContext: DbContext
    {
        public EvaluacionContext(DbContextOptions<EvaluacionContext> options) : base(options)
        {

        }

        public DbSet<Candidato> Candidatos { get; set; }
        public DbSet<Evaluacion> Evaluaciones { get; set; }
    }
}
