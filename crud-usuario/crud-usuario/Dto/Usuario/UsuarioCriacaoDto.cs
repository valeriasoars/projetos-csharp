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


        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
       

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        public string senha { get; set; }

        [Required(ErrorMessage = "O campo Confirma Senha é obrigatório.")]
        [Compare("senha", ErrorMessage = "As senhas não coincidem.")]
        public string confirmaSenha{ get; set; }
    }
}
