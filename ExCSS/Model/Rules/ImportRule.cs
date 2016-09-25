using ExCSS.Model;
using ExCSS.Model.Extensions;
using System.Text;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public class ImportRule : RuleSet, ISupportsMedia
    {
        private string _href;
        private readonly MediaTypeList _media;

        public ImportRule() 
        {
            _media = new MediaTypeList();
            RuleType = RuleType.Import;
        }
      
        public string Href
        {
            get { return _href; }
            set { _href = value; }
        }

        public MediaTypeList Media
        {
            get { return _media; }
        }

        

        public override StringBuilder ToString(StringBuilder sb, bool friendlyFormat=false, int indentation = 0)
        {
            sb.NewLineIndent(friendlyFormat, indentation).Append("@import url(").Append(_href);
            if (_media.Count > 0)
                sb.Append(") ").Append(_media).Append(';');
            else
                sb.Append(");");
            return sb;
        }
    }
}
