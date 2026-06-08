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

        /// Calcula el DV de un string teniendo en cuenta
        /// la posición de cada caracter (posI) y la posición
        /// del atributo dentro de la entidad (posJ).
        private static int CalcularDV(string valor, int posJ)
        {
            int suma = 0;
            for (int i = 0; i < valor.Length; i++)
            {
                suma += valor[i] * (i + 1) * (posJ + 1);
            }
            return suma % MODULO;
        }

        /// Calcula el DVH de una fila a partir de una lista ordenada
        /// de valores de sus columnas (como strings).
        /// Es genérico: funciona para cualquier entidad.
        public static int CalcularDVH(List<string> valoresColumnas)
        {
            int suma = 0;
            for (int j = 0; j < valoresColumnas.Count; j++)
            {
                suma += CalcularDV(valoresColumnas[j], j);
            }
            return suma % MODULO;
        }

        /// Calcula el DVV de una columna completa a partir de todos
        /// sus valores en la tabla (lista de strings).
        /// Es genérico: funciona para cualquier columna de cualquier entidad.
        public static int CalcularDVV(List<string> valoresColumna)
        {
            int suma = 0;
            for (int i = 0; i < valoresColumna.Count; i++)
            {
                // posJ = 0 porque es una sola columna,
                // posI = posición de la fila en la tabla
                for (int c = 0; c < valoresColumna[i].Length; c++)
                {
                    suma += valoresColumna[i][c] * (c + 1) * (i + 1);
                }
            }
            return suma % MODULO;
        }

    }
}
