namespace BackEndAtv1.Models
{
    public class Participante
    {
        public int ParticipanteID { get; set; }
        public string Nome { get; set; }
        public int EventoID { get; set; }
        public Evento Evento { get; set; }
    }
}
