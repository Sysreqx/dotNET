namespace Adaptive_Code_via_CSharp
{
    internal class TradeRecord
    {
        internal string destinationCurrencyCode;

        public string SourceCurrency { get; internal set; }
        public float Lots { get; internal set; }
        public decimal Price { get; internal set; }
        public object DestinationCurrency { get; internal set; }
    }
}