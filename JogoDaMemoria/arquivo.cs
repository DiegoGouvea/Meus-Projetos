using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JogoDaMemoria
{
    class arquivo
    {
        // atributos
        private StreamReader arqL;  // arquivo de leitura
        private string CaminhoArquivo;

        public arquivo(string c)
        { CaminhoArquivo = c; }

        // MÉTODOS FUNCIONAIS
        public string lendoDadosArquivo()
        {
            // abrindo arquivo para leitura
            arqL = File.OpenText(CaminhoArquivo);
            string dados = "";
            // enquanto não for final do arquivo texto
            while (arqL.EndOfStream != true)
            {
                // lendo linha a linha do arquivo
                string linha = arqL.ReadLine() + System.Environment.NewLine;
                dados += linha;
            }
            arqL.Close();
            return dados;
        }
    }
}
