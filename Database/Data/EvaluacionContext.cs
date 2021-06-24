using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
