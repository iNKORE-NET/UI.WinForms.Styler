using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace iNKORE.UI.WinForms.Styler.Dwm
{
    [Serializable]
    class DwmCompositionException : Exception
    {
        public DwmCompositionException(string m)
            : base(m) {
        }

        public DwmCompositionException(string m, Exception innerException)
            : base(m, innerException) {
        }

        public DwmCompositionException(SerializationInfo info, StreamingContext context)
            : base(info, context) {
        }
    }
}
