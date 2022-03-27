using System.ComponentModel.DataAnnotations.Schema;

namespace Trivium_API.Model
{
    public class Produto
    {
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public double Preco { get; set; }
        
        [NotMapped]
        public int TotalCompras {get;set;}
        [NotMapped]
        public double TotalArrecadado {get;set;}
        


    }
}
