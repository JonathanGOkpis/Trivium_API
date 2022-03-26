using System.ComponentModel.DataAnnotations;

namespace Trivium_API.Model
{
    public class Cliente
    {
        [Key]
        public int ID { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
    }
}
