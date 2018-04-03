using System;
using System.Collections.Generic;
using System.Text;

namespace Opportunity.LrcParser
{
    internal interface IStringable
    {
        int GetStringLength();
        StringBuilder ToString(StringBuilder sb);
    }
}
