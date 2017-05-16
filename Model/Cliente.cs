using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Cliente : ElementoBase
    {

        //Outra forma de fazer é assim
        public Cliente()
        {
            Endereco = new Endereco();
        }
        public string CPF { get; set; }
        public int Idade { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }
    }
}
