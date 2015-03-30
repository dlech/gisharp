using System;
using System.IO;

namespace GISharp.CodeGen
{
    /// <summary>
    /// Wrapper around TextWriter that keeps track of indent level
    /// </summary>
    public class CodeWriter : IDisposable
    {
        const string indent = "\t";

        readonly TextWriter tw;
        bool needToIndent = true;
        int indentLevel = 0;

        public CodeWriter (Stream stream) : this (new StreamWriter (stream))
        {
        }

        public CodeWriter (TextWriter tw)
        {
            this.tw = tw;
        }

        public void Write (string value)
        {
            if (needToIndent) {
                WriteIndent ();
            }
            tw.Write (value);
        }

        public void Write (string format, params object[] arg)
        {
            if (needToIndent) {
                WriteIndent ();
            }
            tw.Write (format, arg);
        }

        public void WriteLine ()
        {
            tw.WriteLine ();
            needToIndent = true;
        }

        public void WriteLine (string value)
        {
            if (needToIndent) {
                WriteIndent ();
            }
            tw.WriteLine (value);
            needToIndent = true;
        }

        public void WriteLine (string format, params object[] arg)
        {
            if (needToIndent) {
                WriteIndent ();
            }
            tw.WriteLine (format, arg);
            needToIndent = true;
        }

        void WriteIndent ()
        {
            for (int i = 0; i < indentLevel; i++) {
                tw.Write (indent);
            }
            needToIndent = false;
        }

        public void IncIndent ()
        {
            indentLevel += 1;
        }

        public void DecIndent ()
        {
            if (indentLevel == 0) {
                throw new InvalidOperationException ("Indent cannot be less than zero.");
            }
            indentLevel -= 1;
        }

        public void Dispose () {
            tw.Dispose ();
        }
    }
}
