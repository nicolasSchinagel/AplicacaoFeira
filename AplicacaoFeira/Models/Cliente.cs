using System.ComponentModel.DataAnnotations;

namespace AplicacaoFeira.Models
{
    public class Cliente
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "O Email não é válido.")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 10 caracteres")]
        public string Senha { get; set; }

        [Display(Name = "Confirmação da senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Senha tem que ser confirmada")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 10 caracteres")]
        [Compare("Senha", ErrorMessage = "A confirmação da senha está errada")]
        public string ConfirmacaoSenha { get; set; }
    }
}
