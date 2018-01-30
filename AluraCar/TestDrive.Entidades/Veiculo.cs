using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TestDrive.Entidades
{
    public class Veiculo
    {
        public string Nome { get; set; }
        public decimal Preco { get; set; }


        public Veiculo()
        {

        }

        public Veiculo(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }
    }
}
