﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TestDrive.Entidades
{
    public class Automovel
    {


        public string Nome { get; set; }
        public decimal Preco { get; set; }



        public string PrecoFormatado
        {
            get {return $"R$ {Preco}";}
        }



        public Automovel(string nome, decimal preco)
        {
            Nome = nome;
            Preco = preco;
        }

        


        public Automovel()
        {

        }

    }
}
