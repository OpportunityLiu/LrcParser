namespace Opportunity.LrcParser
{
    internal class ParserBase<TLine>
        where TLine : Line
    {
        public readonly MetaDataDictionary MetaData = new MetaDataDictionary();
        public readonly LineCollection<TLine> Lines = new LineCollection<TLine>();
    }
}
