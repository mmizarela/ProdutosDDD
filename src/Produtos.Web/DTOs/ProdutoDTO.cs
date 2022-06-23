using System.ComponentModel.DataAnnotations;

namespace Produtos.Web.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email{ get; set; }
    }
}