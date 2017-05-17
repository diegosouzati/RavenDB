using Raven.Imports.Newtonsoft.Json;

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

        [JsonIgnore]
        public Cliente  Indicador { get; set; }
        public string IndicadorId { get; set; }
    }
}
