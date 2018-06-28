using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportes_CentroComputo
{
    class InfoEquipo
    {
        public int IDEquipo { get; set; }
        public int IDCPU { get; set; }
        public int IDMonitor { get; set; }
        public int IDTeclado { get; set; }
        public int IDRaton { get; set; }

        public InfoEquipo(int E, int C, int M, int T, int R)
        {
            IDEquipo = E;
            IDCPU = C;
            IDMonitor = M;
            IDTeclado = T;
            IDRaton = R;
        }
    }
}
