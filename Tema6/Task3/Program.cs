class Program
{
    static void Main()
    {
        StockMark market = new();

        Investor investor = new();
        NewsAgency news = new();

        market.StockPriceChanged += investor.Analyze;
        market.StockPriceChanged += news.Publish;

        market.ChangePrice("Цена выросла");
    }
}