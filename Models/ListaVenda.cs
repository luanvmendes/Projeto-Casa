namespace CasaShow.Models
{
    public class ListaVenda
    {
        public int Id { get; set; }
        public Venda Vendas { get; set; }
        public Evento Evento { get; set; }
        public int Quantidade { get; set; }
    }
}