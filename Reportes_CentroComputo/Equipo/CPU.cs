using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reportes_CentroComputo
{
    class CPU
    {
        public int      IDCPU           { get; set; }
        public string   UniqueID        { get; set; }
        public string   NumSerie        { get; set; }
        public string   NumInventario   { get; set; }
        public string   Marca           { get; set; }
        public string   Modelo          { get; set; }
        public string   Procesador      { get; set; }
        public string   TipoRAM         { get; set; }
        public int      TotalRAM        { get; set; }
        public string   TipoDiscoDuro   { get; set; }
        public int      TotalDiscoDuro  { get; set; }

        public CPU(int I, string U, string S, string N, string B, string M, string P, string T, int R, string H, int D)
        {
            IDCPU = I;
            UniqueID = U;
            NumSerie = S;
            NumInventario = N;
            Marca = B;
            Modelo = M;
            Procesador = P;
            TipoRAM = T;
            TotalRAM = R;
            TipoDiscoDuro = H;
            TotalDiscoDuro = D;
            if(NumInventario.Length>20)
            {
                NumInventario = NumInventario.Substring(0, 20);
            }
            if(Marca.Length>10)
            {
                Marca = Marca.Substring(0, 10);
            }
            if (Modelo.Length > 10)
            {
                Modelo = Modelo.Substring(0, 10);
            }
            if (Procesador.Length > 15)
            {
                Procesador = Procesador.Substring(0, 15);
            }
            if (TipoRAM.Length > 10)
            {
                TipoRAM = TipoRAM.Substring(0, 10);
            }
            if (TipoDiscoDuro.Length > 10)
            {
                TipoDiscoDuro = TipoDiscoDuro.Substring(0, 10);
            }
        }
    }
}
