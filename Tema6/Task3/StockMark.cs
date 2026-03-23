class StockMark
{
    public event StockHandler StockPriceChanged;

    public void ChangePrice(string info)
    {
        StockPriceChanged?.Invoke(info);
    }
}