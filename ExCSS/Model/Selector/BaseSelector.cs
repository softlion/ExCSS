﻿
// ReSharper disable once CheckNamespace
using Shaman.Runtime;
using System.Text;
using System;

namespace ExCSS
{
    public abstract class BaseSelector
    {
        public sealed override string ToString()
        {
            var sb = ReseekableStringBuilder.AcquirePooledStringBuilder();
            ToString(sb, false);
            return ReseekableStringBuilder.GetValueAndRelease(sb);
        }

        public abstract void ToString(StringBuilder sb, bool friendlyFormat = false, int indentation = 0);

        
    }
}

