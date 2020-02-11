namespace ProjetoTeste.Models
{
    public class ListaVenda
    {
        public int Id { get; set; }
        public Venda Venda { get; set; }
        public Evento Evento { get; set; }
        public int Quantidade { get; set; }
    }
}