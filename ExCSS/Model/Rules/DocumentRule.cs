using System;
using System.Collections.Generic;
using System.Text;
using ExCSS.Model;
using ExCSS.Model.Extensions;
#if SALTARELLE
using StringBuilder = System.Text.Saltarelle.StringBuilder;
#endif

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    public sealed class DocumentRule : AggregateRule
    {
        readonly List<DocumentFunctionStringPair> _conditions;

        internal DocumentRule()
        { 
            RuleType = RuleType.Document;
            _conditions = new List<DocumentFunctionStringPair>();
        }

        public string ConditionText
        {
            get
            {
                var builder = new StringBuilder();
                var concat = false;

                foreach (var condition in _conditions)
                {
                    if (concat)
                    {
                        builder.Append(',');
                    }

                    switch (condition.Item1)
                    {
                        case DocumentFunction.Url:
                            builder.Append("url");
                            break;

                        case DocumentFunction.UrlPrefix:
                            builder.Append("url-prefix");
                            break;

                        case DocumentFunction.Domain:
                            builder.Append("domain");
                            break;

                        case DocumentFunction.RegExp:
                            builder.Append("regexp");
                            break;
                    }

                    builder.Append(Specification.ParenOpen);
                    builder.Append(Specification.DoubleQuote);
                    builder.Append(condition.Item2);
                    builder.Append(Specification.DoubleQuote);
                    builder.Append(Specification.ParenClose);
                    concat = true;
                }

                return builder.ToString();
            }
        }

        internal List<DocumentFunctionStringPair> Conditions
        {
            get { return _conditions; }
        }

        public override string ToString()
        {
            return ToString(false);
        }

        public override string ToString(bool friendlyFormat, int indentation = 0)
        {
            return "@document " + ConditionText + " {" + 
                RuleSets + 
                "}".NewLineIndent(friendlyFormat, indentation);
        }
    }
}
