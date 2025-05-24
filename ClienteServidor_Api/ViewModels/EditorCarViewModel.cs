
using System.ComponentModel.DataAnnotations;

namespace ClienteServidor_Api.ViewModels
{
    /// <summary>
    /// permite que apenas as informações desejada seja obtida ou mostrada atraves de uma requisição
    /// 
    /// mapeia os atributos e envia mensagens de erro caso a requisição nao cumpra os requisitos
    /// </summary>
    public class EditorCarViewModel
    {
        [Required(ErrorMessage ="O modelo é obrigatorio")]
        [StringLength(35, MinimumLength = 3, ErrorMessage = "Este campo deve conter entre 3 e 30 caracteres")]
        public string Model { get; set; }

        [Required(ErrorMessage = "A quilometragem é obrigatoria")]
        public long Mileage { get; set; }

        [Required(ErrorMessage = "O valor é obrigatorio")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "O ano é obrigatorio")]
        [Range(1931, 2025)]
        public int Year { get; set; }

        [StringLength(225, ErrorMessage = "Este campo deve conter no maximo 225 caracteres")]
        public string Description { get; set; }
    }
}
