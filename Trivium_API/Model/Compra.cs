using System.ComponentModel.DataAnnotations.Schema;
namespace Trivium_API.Model
{
    public class Compra
    {
        public int ID { get; set; }
        [ForeignKey("Cliente")]
        public int IDClient { get; set; }
        public Cliente? Cliente {get;set;}

    }
}
