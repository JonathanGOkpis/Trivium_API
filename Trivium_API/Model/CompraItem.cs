using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Trivium_API.Model
{
    public class CompraItem
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Compra")]
        public int IDCompra { get; set; }
        public Compra? Compra{get;set;}
        [ForeignKey("Produto")]
        public int IDProduto { get; set; }
        public Produto? Produto {get;set;}
        public int Quantidade { get; set; }
       
        [NotMapped]
        public double valorTotalCompra {get;set;}

    }
}
