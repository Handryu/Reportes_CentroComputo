using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportes_CentroComputo.Equipo
{
    class Teclado
    {
        public int      IDTeclado   { get; set; }
        public string   Descripcion { get; set; }

        public Teclado(int I, string D)
        {
            IDTeclado = I;
            Descripcion = D;

            if(Descripcion.Length>50)
            {
                Descripcion = Descripcion.Substring(0, 50);
            }
        }
    }
}
