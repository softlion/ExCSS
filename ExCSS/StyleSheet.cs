using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExCSS.Model.Extensions;

#if SALTARELLE
using StringBuilder = System.Text.Saltarelle.StringBuilder;
#endif

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public static class StyleSheetExtensions
    {
        public static StyleSheet RemoveRule(this StyleSheet styleSheet, int index)
        {
            if (styleSheet == null)
                throw new ArgumentNullException(nameof(styleSheet));

            if (index >= 0 && index < styleSheet.Rules.Count)
                styleSheet.Rules.RemoveAt(index);

            return styleSheet;
        }

        /// <summary>
        /// Parse <paramref name="css"/> and append new rules to <paramref name="styleSheet"/>
        /// </summary>
        /// <param name="styleSheet">The stylesheet to modify</param>
        /// <param name="css">css directives</param>
        /// <param name="parser">An existing parser object to reuse, or null to let this method create one</param>
        /// <returns>The number of Rules appended to this stylesheet</returns>
        public static int Append(this StyleSheet styleSheet, string css, Parser parser = null)
        {
            if(parser==null)
                parser = new Parser();

            var index = styleSheet.Rules.Count;
            parser.Parse(css, styleSheet);
            return styleSheet.Rules.Count - index;
        }

        /// <summary>
        /// Remove rules from <paramref name="styleSheet"/>.Rules so it contains at most <paramref name="rulesCount"/>
        /// </summary>
        /// <param name="styleSheet"></param>
        /// <param name="rulesCount">The max number of rules this <paramref name="styleSheet"/> will contain after the operation</param>
        public static void PopToCount(this StyleSheet styleSheet, int rulesCount)
        {
            var n = styleSheet.Rules.Count - rulesCount;
            if(n > 0)
                styleSheet.Rules.RemoveRange(rulesCount, n);
        }

        public static void PopCount(this StyleSheet styleSheet, int n)
        {
            var count = styleSheet.Rules.Count;
            n = Math.Min(n, count);
            if(n>0)
                styleSheet.Rules.RemoveRange(count-n, n);
        }

        //Totally inefficient. + creates a dependency loop. Removed.
        //public static StyleSheet InsertRule(this StyleSheet styleSheet, string rule, int index)
        //{
        //    if (index < 0 || index > styleSheet.Rules.Count)
        //        return styleSheet;

        //    var value = Parser.ParseRule(rule);
        //    styleSheet.Rules.Insert(index, value);

        //    return styleSheet;
        //}
    }

    public sealed class StyleSheet
    {
        public StyleSheet()
        {
            Errors = new List<StylesheetParseError>();
        }

        public List<RuleSet> Rules { get; } = new List<RuleSet>();

        public IList<StyleRule> StyleRules
        {
            get
            {
                return Rules.Where(r => r is StyleRule).Cast<StyleRule>().ToList();
            }
        } 

        public IList<CharacterSetRule> CharsetDirectives => GetDirectives<CharacterSetRule>(RuleType.Charset);

        public IList<ImportRule> ImportDirectives => GetDirectives<ImportRule>(RuleType.Import);

        public IList<FontFaceRule> FontFaceDirectives => GetDirectives<FontFaceRule>(RuleType.FontFace);

        public IList<KeyframesRule> KeyframeDirectives => GetDirectives<KeyframesRule>(RuleType.Keyframes);

        public IList<MediaRule> MediaDirectives => GetDirectives<MediaRule>(RuleType.Media);

        public IList<PageRule> PageDirectives => GetDirectives<PageRule>(RuleType.Page);

        public IList<SupportsRule> SupportsDirectives => GetDirectives<SupportsRule>(RuleType.Supports);

        public IList<NamespaceRule> NamespaceDirectives => GetDirectives<NamespaceRule>(RuleType.Namespace);

        private IList<T> GetDirectives<T>(RuleType ruleType)
        {
            return Rules.Where(r => r.RuleType == ruleType).Cast<T>().ToList();
        }

        public List<StylesheetParseError> Errors { get; private set; }

        public override string ToString()
        {
            //var sb = ReseekableStringBuilder.AcquirePooledStringBuilder();
            var sb = new StringBuilder();
            ToString(sb, false);
            //return ReseekableStringBuilder.GetValueAndRelease(sb);
            return sb.ToString();
        }

        public StringBuilder ToString(StringBuilder sb, bool friendlyFormat, int indentation = 0)
        {
            foreach (var rule in Rules)
                rule.ToString(sb, friendlyFormat, indentation);
            return sb;
        }

    }
}
