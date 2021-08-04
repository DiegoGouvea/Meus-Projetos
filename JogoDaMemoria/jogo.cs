using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoDaMemoria
{
    class jogo
    {
        private int rodada;
        private int acertos;
        private int jogadas;

        public jogo()
        {
            rodada = 1;
            jogadas = 0;
            acertos = 0;
        }

        public int getJogadas()
        {
            return jogadas;
        }
        public int getAcertos()
        {
            return acertos;
        }
        public int getRodada()
        {
            return rodada;
        }
        public void SetRodada(int i)
        {
            rodada = i;
        }
        public void SetJogadas( int i)
        {
            jogadas= i;
        }
        public void SetAcertos(int i)
        {
            acertos = i;
        }
        public void incrementaJogadas()
        {
            jogadas++;
        }


        public void incrementaRodada()
        {
            rodada++;
        }

        public void incrementaAcertos()
        {
            acertos++;
        }
        public bool VerificaSeGameOver()
        {
            return (getAcertos() == 9); 
        }


    }
}
