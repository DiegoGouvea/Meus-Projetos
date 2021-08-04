using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JogoDaMemoria
{
    public partial class FrmPrincipal : Form
    {

        int cliques = 1;
        jogo j; 
        string caminho = "C:\\Users\\diego\\Desktop\\JogoDaMemoria\\img\\"; //necessário modificar o caminho para execução em outras maquinas
        arquivo arquivo1 = new arquivo("C:\\Users\\diego\\Desktop\\JogoDaMemoria\\jogada.txt");//necessário modificar o caminho para execução em outras maquinas
        string dados = "";
        string[] verificaDupla = new string[] {"",""}; 
        Button[] btns;
        int primeiraCarta;
        //transformar os dados em dados globais

        public void BloqueiaBotoes()//desabilita todos os botoes
        {
            for(int i = 0; i < btns.Length; i++)
            {
                btns[i].Enabled = false;
                
            }
        }
        public void AtivaBotoes()//ativa todos botoes
        {
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].Enabled = true;
            }
        }


        //verifica se é a primeira ou a segunda jogada e toma a ação necessária para cada uma delas
        public void VerificaPares(int index )
        {
            switch (cliques)
            {
                case 1:
                    primeiraCarta = index;
                    btns[index].BackgroundImage = Image.FromFile(caminho + dados[index] + ".jpg");// percorre os index tanto do botão quanto da imagem simultaneamente 
                    verificaDupla[0] = dados[index].ToString();//atribui o nome da imagem ao index zero do verificador de pares
                    btns[index].Enabled = false;//desabilita o click para nao ser possivel clicar 2 vezes na mesma carta
                    cliques = 2;
                    break;
                case 2:
                    btns[primeiraCarta].Enabled = true;//reabilita a primeiro botao apos o segundo click
                    btns[index].BackgroundImage = Image.FromFile(caminho + dados[index] + ".jpg");
                    btns[index].Refresh();
                    System.Threading.Thread.Sleep(700);
                    verificaDupla[1]= dados[index].ToString();//atribui o nome da imagem ao index um do verificador de pares
                    j.incrementaJogadas();
                    lb_Jogadas.Text="Número de Jogadas: "+j.getJogadas();

                    if (verificaDupla[0] != verificaDupla[1])
                    {
                        btns[index].BackgroundImage = Image.FromFile(caminho + "f.jpg");
                        cliques = 1;
                        btns[primeiraCarta].BackgroundImage=Image.FromFile(caminho + "f.jpg");
                    }
                    else
                    {
                        j.incrementaAcertos();
                        btns[index].Enabled = false;
                        btns[primeiraCarta].Enabled = false;
                        cliques = 1;
                        if (j.VerificaSeGameOver()) 
                        {
                            MessageBox.Show("Parabens voce terminou em : " + j.getJogadas() +" jogadas");
                            MessageBox.Show("Para Jogar mais uma rodada clique no play");
                            btnPlay.Enabled = true;
                            j.SetJogadas(0);
                            lb_Jogadas.Text = "Número de Joagadas: " +j.getJogadas();
                            j.SetAcertos(0);
                        }
                    }
                    break;

            }
        }
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
             btnPlay.Enabled = false;
           
            AtivaBotoes();
            switch (j.getRodada())
            {
                case 1: dados = arquivo1.lendoDadosArquivo(); break;
                case 2:dados = dados.Substring(18); break;
                case 3: dados = dados.Substring(18);j.SetRodada(0);break;//reinicia o embaralhamento para o inicio da string do arquivo

            }
            j.incrementaRodada();

           // varre os botoes e exibe as cartas pós embaralhamento
            for(int i = 0; i < btns.Length; i++)
            {
               btns[i].BackgroundImage = Image.FromFile(caminho + dados[i] + ".jpg");
               btns[i].Refresh();
            }
            //delay de 2 segundos
            System.Threading.Thread.Sleep(2000);
            // vira todas as cartas exibindo o verso
            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].BackgroundImage = Image.FromFile(caminho + "f.jpg");
                btns[i].Refresh();
            }

        }
        
        private void btn_1_Click(object sender, EventArgs e)
        {
            VerificaPares(0);
            
        }

        private void btn_2_Click(object sender, EventArgs e)
        {
            VerificaPares(1);

        }

        private void btn_3_Click(object sender, EventArgs e)
        {
            VerificaPares(2);
        }

        private void btn_4_Click(object sender, EventArgs e)
        {
            VerificaPares(3);
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            VerificaPares(4);
        }

        private void btn_6_Click(object sender, EventArgs e)
        {
            VerificaPares(5);
        }

        private void btn_7_Click(object sender, EventArgs e)
        {
            VerificaPares(6);
        }

        private void btn_8_Click(object sender, EventArgs e)
        {
            VerificaPares(7);
        }

        private void btn_9_Click(object sender, EventArgs e)
        {
            VerificaPares(8);
        }

        private void btn_10_Click(object sender, EventArgs e)
        {
            VerificaPares(9);
        }

        private void btn_11_Click(object sender, EventArgs e)
        {
            VerificaPares(10);
        }

        private void btn_12_Click(object sender, EventArgs e)
        {
            VerificaPares(11);
        }

        private void btn_13_Click(object sender, EventArgs e)
        {
            VerificaPares(12);
        }

        private void btn_14_Click(object sender, EventArgs e)
        {
            VerificaPares(13);
        }

        private void btn_15_Click(object sender, EventArgs e)
        {
            VerificaPares(14);
        }

        private void btn_16_Click(object sender, EventArgs e)
        {
            VerificaPares(15);

        }

        private void btn_17_Click(object sender, EventArgs e)
        {
            VerificaPares(16);

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            j = new jogo();// instanciando classe jogo
           
            btns = new Button[] { btn_1, btn_2, btn_3, btn_4, btn_5, btn_6, btn_7, btn_8, btn_9, btn_10, btn_11, btn_12, btn_13, btn_14, btn_15, btn_16, btn_17, btn_18 };//array de botoes
            BloqueiaBotoes();
        }

        private void btn_18_Click(object sender, EventArgs e)
        {
            
            VerificaPares(17);
        }
    }
}
