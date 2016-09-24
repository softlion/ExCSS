﻿using System;
using System.Text;

// ReSharper disable once CheckNamespace
namespace ExCSS
{
    internal sealed class NthLastChildSelector : NthChildSelector
    {
        public override void ToString(StringBuilder sb, bool friendlyFormat, int indentation = 0)
        {
            FormatSelector(sb, PseudoSelectorPrefix.PseudoFunctionNthlastchild);
        }
    }
}