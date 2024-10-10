using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estagio_riberão_preto
{
    public class SequenciaFibonacci
    {
        public List<int> Calcular(int n)
        {
            var result = new List<int>();

            var anterior = 0;
            var atual = 1;
            var sequencia = 0;

            result.Add(anterior);
            result.Add(atual);

            while (sequencia < n)
            {
                sequencia = anterior + atual;
                result.Add(sequencia);

                anterior = atual;
                atual = sequencia;
            }

            return result;
        }
    }
}
