namespace AgendaApi.Agendamentos;

public class Agendamento
{
    public int Id { get; set; }
    public int ProfissionalId { get; set; }
    public required string NomeCliente { get; set; }
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
}