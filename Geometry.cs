using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace redac
{
    public class Geometry
    {
        public string Figure { get; set; }
        public string Linelength { get; set; }
        public string Width { get; set; }
        private Geometry() { }

        public Geometry(string figures, string linelength, string widths)
        {
            Figure = figures;
            Linelength = linelength;
            Width = widths;
        }
    }
}