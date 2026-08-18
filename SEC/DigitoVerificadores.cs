using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEC
{
    public static class DigitoVerificadores
    {
        private const int MODULO = 997;

        
        private static int CalcularDV(string valor, int posJ)
        {
            int suma = 0;
            for (int i = 0; i < valor.Length; i++)
            {
                suma += valor[i] * (i + 1) * (posJ + 1);
            }
            return suma % MODULO;
        }

        
        public static int CalcularDVH(List<string> valoresColumnas)
        {
            int suma = 0;
            for (int j = 0; j < valoresColumnas.Count; j++)
            {
                suma += CalcularDV(valoresColumnas[j], j);
            }
            return suma % MODULO;
        }

        
        public static int CalcularDVV(List<string> valoresColumna)
        {
            int suma = 0;
            for (int i = 0; i < valoresColumna.Count; i++)
            {
                
                for (int c = 0; c < valoresColumna[i].Length; c++)
                {
                    suma += valoresColumna[i][c] * (c + 1) * (i + 1);
                }
            }
            return suma % MODULO;
        }

    }
}
