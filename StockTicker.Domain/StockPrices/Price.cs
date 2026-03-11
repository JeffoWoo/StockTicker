namespace StockTicker.Domain.StockPrices
{
    public record Price(decimal Value)
    {
        public static Price operator+(Price first, Price second)
        {
            return new Price(first.Value + second.Value);
        }

        public static Price operator -(Price first, Price second)
        {
            return new Price(first.Value - second.Value);
        }

        public static Price Zero() => new Price(0m);

        public bool IsZero() => this == Zero();
    }    
}
