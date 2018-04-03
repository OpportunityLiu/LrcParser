using System;
using System.Collections.Generic;
using System.Text;

namespace Opportunity.LrcParser
{
    /// <summary>
    /// Represents lrc file.
    /// </summary>
    [System.Diagnostics.DebuggerDisplay(@"MetaDataCount = {MetaData.Count} LineCount = {Lines.Count}")]
    public class Lyrics
    {
        /// <summary>
        /// Parse lrc file.
        /// </summary>
        /// <param name="content">Content of lrc file.</param>
        /// <returns>Result of parsing.</returns>
        public static Lyrics Parse(string content)
        {
            return new Lyrics(new Parser(content));
        }

        /// <summary>
        /// Create new instance of <see cref="Lyrics"/>.
        /// </summary>
        public Lyrics()
        {
            this.Lines = new LineCollection();
            this.MetaData = new MetaDataDictionary();
        }

        internal Lyrics(Parser parser)
        {
            parser.Analyze();
            this.Lines = parser.Lines;
            this.MetaData = parser.MetaData;
        }

        /// <summary>
        /// Apply <see cref="MetaDataDictionary.Offset"/> to <see cref="Lines"/>, then set <see cref="MetaDataDictionary.Offset"/> to 0.
        /// </summary>
        /// <exception cref="InvalidOperationException"><see cref="MetaDataDictionary.Offset"/> out of range for some line.</exception>
        public void PreApplyOffset()
        {
            try
            {
                var offset = this.MetaData.Offset;
                this.Lines.ApplyOffset(offset);
                this.MetaData.Offset = default;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw new InvalidOperationException("Invalid offset.", ex);
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var sb = new StringBuilder(this.MetaData.Count * 10 + this.Lines.Count * 20);
            MetaData.ToString(sb);
            Lines.ToString(sb);
            return sb.ToString();
        }

        /// <summary>
        /// Content of lyrics.
        /// </summary>
        public LineCollection Lines { get; }

        /// <summary>
        /// Metadata of lyrics.
        /// </summary>
        public MetaDataDictionary MetaData { get; }
    }
}
