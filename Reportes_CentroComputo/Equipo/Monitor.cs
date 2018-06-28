using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportes_CentroComputo.Equipo
{
    class Monitor
    {
        public int      IDMonitor       { get; set; }
        public string   NumSerie        { get; set; }
        public string   NumInventario   { get; set; }

        public Monitor(int M, string S, string I)
        {
            IDMonitor = M;
            NumSerie = S;
            NumInventario = I;

            if(NumSerie.Length>20)
            {
                NumSerie = NumSerie.Substring(0, 20);
            }
            if(NumInventario.Length>20)
            {
                NumInventario = NumInventario.Substring(0, 20);
            }
        }
    }
}
