using System.ComponentModel.DataAnnotations;

namespace crud_usuario.Dto.Usuario
{
    public class UsuarioCriacaoDto
    {

        [Required(ErrorMessage = "O campo Usuário é obrigatório.")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Sobrenome é obrigatório.")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        public string Email { get; set; }


        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;


        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "O campo Confirma Senha é obrigatório.")]
        [Compare("Senha", ErrorMessage = "As senhas não coincidem.")]
        public string ConfirmaSenha{ get; set; }
    }
}
