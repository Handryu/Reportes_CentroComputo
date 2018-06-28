using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportes_CentroComputo.Equipo
{
    class Raton
    {
        public int IDRaton { get; set; }
        public string Descripcion { get; set; }

        public Raton(int I, string D)
        {
            IDRaton = I;
            Descripcion = D;

            if (Descripcion.Length > 50)
            {
                Descripcion = Descripcion.Substring(0, 50);
            }
        }
    }
}
