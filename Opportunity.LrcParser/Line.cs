using System;
using System.Collections.Generic;
using System.Text;

namespace Opportunity.LrcParser
{
    /// <summary>
    /// Represents single line of lyrics.
    /// </summary>
    [System.Diagnostics.DebuggerDisplay(@"{ToString(),nq}")]
    public class Line : IComparable<Line>, IComparable
    {
        /// <summary>
        /// Create new instance of <see cref="Line"/>.
        /// </summary>
        public Line() { }

        /// <summary>
        /// Create new instance of <see cref="Line"/>.
        /// </summary>
        /// <param name="timestamp">Timestamp of this line.</param>
        /// <param name="content">Lyrics of this line.</param>
        public Line(DateTime timestamp, string content)
        {
            Timestamp = timestamp;
            Content = content;
        }

        private static DateTime ONE_HOUR = new DateTime(1, 1, 1, 1, 0, 0);
        private static DateTime ONE_YEAR = new DateTime(2, 1, 1, 0, 0, 0);

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal DateTime InternalTimestamp;
        /// <summary>
        /// Timestamp of this line of lyrics.
        /// </summary>
        public DateTime Timestamp
        {
            get => this.InternalTimestamp;
            set
            {
                if (value.Kind != DateTimeKind.Unspecified)
                    throw new ArgumentException("Kind of value should be DateTimeKind.Unspecified");
                if (value >= ONE_YEAR) //Auto correct.
                    value = new DateTime(1, 1, 1, value.Hour, value.Minute, value.Second, value.Millisecond);
                this.InternalTimestamp = value;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal string InternalContent = "";
        /// <summary>
        /// Lyrics of this line.
        /// </summary>
        public string Content { get => this.InternalContent; set => this.InternalContent = (value ?? "").Trim(); }

        internal StringBuilder ToString(StringBuilder sb)
        {
            return sb.Append('[')
                .Append(this.InternalTimestamp.ToLrcString())
                .Append(']')
                .AppendLine(this.InternalContent);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var sb = new StringBuilder(this.InternalContent.Length + 10);
            ToString(sb);
            return sb.ToString();
        }

        /// <inheritdoc/>
        public int CompareTo(Line other)
        {
            if (other is null)
                return 1;
            var ct = this.InternalTimestamp.CompareTo(other.InternalTimestamp);
            if (ct != 0)
                return ct;
            return this.InternalContent.CompareTo(other.InternalContent);
        }
        int IComparable.CompareTo(object obj) => CompareTo((Line)obj);
    }
}
