namespace Meuevento.Models
{
    public class logica
    {
        // IMPLEMENTAÇÃO: Novas propriedades para Nome e Local do Evento
        public string NomeEvento { get; set; }
        public string LocalEvento { get; set; }

        // Mapeado de: QntAdultos (representa o número total de participantes do evento)
        public int QntAdultos { get; set; }

        // Mantido caso queira separar por tipo, ou pode deixar como 0 se não for usar
        public int QntCriancas { get; set; }

        // Mapeado de: dtpck_checkin e dtpck_checkout
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        // Nova propriedade para o Custo por Participante (substituindo a dependência da classe 'Quarto')
        public double CustoPorParticipante { get; set; }

        // Retorna a duração do evento em dias (Herdado da sua lógica original)
        public int Estadia
        {
            get => DataCheckOut.Subtract(DataCheckIn).Days;
        }

        // ADAPTAÇÃO: Calcula o valor total com base nos participantes e no custo por pessoa
        // Se o seu evento durar múltiplos dias e o custo for por dia, você pode multiplicar por 'Estadia' no final.
        public double ValorTotal
        {
            get
            {
                // Multiplica o total de participantes (Adultos + Crianças) pelo custo individual
                double totalParticipantes = QntAdultos + QntCriancas;
                double total = totalParticipantes * CustoPorParticipante;

                return total;
            }
        }
    }
}