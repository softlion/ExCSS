using System;
using System.Linq;
using ExCSS.Model;
using ExCSS.Model.Extensions;
using System.Text;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class MediaRule : ConditionalRule, ISupportsMedia
    {
        private readonly MediaTypeList _media;

        public MediaRule() 
        {
            _media = new MediaTypeList();
            RuleType = RuleType.Media;
        }

        public override string Condition
        {
            get { return _media.MediaType; }
            set { _media.MediaType = value; }
        }

        public MediaTypeList Media
        {
            get { return _media; }
        }

        
        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat=false, int indentation = 0)
        {
            sb.NewLineIndent(friendlyFormat, indentation).Append("@media ").Append(_media.MediaType).Append("{");
            return RuleSetsToString(sb, friendlyFormat, indentation).NewLineIndent("}", friendlyFormat, indentation);
        }
    }
}
