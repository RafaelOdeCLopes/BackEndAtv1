namespace BackEndAtv1.Models
{
    public class Evento
    {
        public int EventoID { get; set; }
        public string Nome { get; set; }
        public int Horas { get; set; }
        public ICollection<Participante> Participantes { get; set; }
    }
}
