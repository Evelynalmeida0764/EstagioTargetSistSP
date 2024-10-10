using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace estagio_são_paulo
{
    public class PorcentualPorEstadoDistribuidora
    {
        double faturamentoSp = 67836.43;
        double faturamentoRj = 36678.66;
        double faturamentoMg = 29229.88;
        double faturamentoEs = 27165.48;
        double faturamentoOutros = 19849.53;

        public void CalcularPorcentual() {

            double valorTotalMensal = faturamentoSp + faturamentoRj + faturamentoMg + faturamentoEs + faturamentoOutros;

            double porcentualSp = (faturamentoSp / valorTotalMensal) * 100;
            double porcentualRj = (faturamentoRj / valorTotalMensal) * 100;
            double porcentualMg = (faturamentoMg / valorTotalMensal) * 100;
            double porcentualEs = (faturamentoEs / valorTotalMensal) * 100;
            double porcentualOutros = (faturamentoOutros / valorTotalMensal) * 100;

            Console.WriteLine("O valor tootal mensal é de R$" + valorTotalMensal);
            Console.WriteLine("O porcentual de contribuição referente ao estado de São Paulo foi de " + porcentualSp.ToString("F2") + "%");
            Console.WriteLine("O porcentual de contribuição referente ao estado de Rio de Janeiro foi de " + porcentualRj.ToString("F2") + "%");
            Console.WriteLine("O porcentual de contribuição referente ao estado de Minas Gerais foi de " + porcentualMg.ToString("F2") + "%");
            Console.WriteLine("O porcentual de contribuição referente ao estado de Espirito Santo foi de " + porcentualEs.ToString("F2") + "%");
            Console.WriteLine("O porcentual de contribuição referente a outros estados foi de " + porcentualOutros.ToString("F2") + "%");
            Console.ReadLine();
            return;
        }

    }
}
