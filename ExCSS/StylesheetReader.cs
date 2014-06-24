using System.Collections.Generic;
using System.IO;
using System.Text;
using ExCSS.Model;
#if SALTARELLE
using StringBuilder = System.Text.Saltarelle.StringBuilder;
#endif

namespace ExCSS
{
    internal class StylesheetReader
    {
        private int _insertion;
        private readonly Stack<int> _collengths;
#if SALTARELLE
        private readonly string _buffer;
#else
        private readonly StringBuilder _buffer;
        private TextReader _reader;
#endif
        private bool _lineWithReturn;

        StylesheetReader()
        {
#if !SALTARELLE
            _buffer = new StringBuilder();
#endif
            _collengths = new Stack<int>();
            Column = 1;
            Line = 1;
        }

        internal StylesheetReader(string styleText) : this()
        {
#if SALTARELLE
            _buffer = styleText;
#else
            _reader = new StringReader(styleText);
#endif
            ReadCurrent();
        }
#if !SALTARELLE
        internal StylesheetReader(Stream styleStream) : this()
        {
            _reader = new StreamReader(styleStream, true);
            ReadCurrent();
        }
#endif

        internal bool IsBeginning
        {
            get { return _insertion < 2; }
        }

        internal int Line;

        internal int Column;

        internal bool IsEnded;

        internal bool IsEnding
        {
            get { return Current == Specification.EndOfFile; }
        }

        internal char Current;

        internal char Next
        {
            get
            {
                Advance();

                return Current;
            }
        }

        internal char Previous
        {
            get
            {
                Back();

                return Current;
            }
        }

        internal void Advance()
        {
            if (!IsEnding)
            {
                AdvanceUnsafe();
            }
            else if (!IsEnded)
            {
                IsEnded = true;
            }
        }

        internal void Advance(int positions)
        {
            while (positions-- > 0 && !IsEnding)
            {
                AdvanceUnsafe();
            }
        }

        internal void Back()
        {
            IsEnded = false;

            if (!IsBeginning)
            {
                BackUnsafe();
            }
        }

        internal void Back(int positions)
        {
            IsEnded = false;

            while (positions-- > 0 && !IsBeginning)
            {
                BackUnsafe();
            }
        }

        private void ReadCurrent()
        {
            if (_insertion < _buffer.Length)
            {
                Current = _buffer[_insertion];
                _insertion++;
                return;
            }

#if SALTARELLE
            Current = Specification.EndOfFile;
#else
            var nextPosition = _reader.Read();
            Current = nextPosition == -1 ? Specification.EndOfFile : (char)nextPosition;

            if (Current == Specification.CarriageReturn)
            {
                Current = Specification.LineFeed;
                _lineWithReturn = true;
            }
            else if (_lineWithReturn)
            {
                _lineWithReturn = false;

                if (Current == Specification.LineFeed)
                {
                    ReadCurrent();
                    return;
                }
            }

            _buffer.Append(Current);
            _insertion++;
#endif
        }

        private void AdvanceUnsafe()
        {
            if (Current.IsLineBreak())
            {
                _collengths.Push(Column);
                Column = 1;
                Line++;
            }
            else
            {
                Column++;
            }

            ReadCurrent();
        }

        private void BackUnsafe()
        {
            _insertion--;

            if (_insertion == 0)
            {
                Column = 0;
                Current = Specification.Null;
                return;
            }

            Current = _buffer[_insertion - 1];

            if (Current.IsLineBreak())
            {
                Column = _collengths.Count != 0 ? _collengths.Pop() : 1;
                Line--;
            }
            else
            {
                Column--;
            }
        }
    }
}