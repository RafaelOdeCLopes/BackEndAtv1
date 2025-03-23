using BackEndAtv1.Models;
using Microsoft.EntityFrameworkCore;


namespace BackEndAtv1.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            Context context = app.ApplicationServices.GetRequiredService<Context>();
            context.Database.Migrate();
            if (!context.Participantes.Any())
            {
                context.Participantes.AddRange(
                    new Participante { Nome = "Rafael Lopes", EventoID = 1 },
                    new Participante { Nome = "Lenilson Júnior", EventoID = 2 },
                    new Participante { Nome = "Celso Ramos", EventoID = 3 });

                context.Eventos.AddRange(
                    new Evento { Nome = "JOIN 2025", Horas = 10 },
                    new Evento { Nome = "Hackathon 2025", Horas = 3 },
                    new Evento { Nome = "Experience Day 2025", Horas = 5 });

                context.SaveChanges();
            }
        }
    }
}