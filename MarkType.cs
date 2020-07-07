using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kółko_i_krzyżyk
{
    /// <summary>
    /// Rodzaj wartości w komórce obecnie to
    /// </summary>
    public enum MarkType
    {
        /// <summary>
        /// Komórka jeszcze nie została kliknięta
        /// </summary>
        Free,
        /// <summary>
        /// Komórka to 0
        /// </summary>
        Nought,
        /// <summary>
        /// Komórka to X
        /// </summary>
        Cross
    }
}