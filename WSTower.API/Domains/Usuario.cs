using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WSTower.API.Domains
{
    public partial class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O Nome do usuário é obrigatório")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "O Nome deve conter entre 3 e 30 caracteres.")]
        public string Nome { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "O E-mail do usuário é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O Apelido do usuário é obrigatória")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "O Apelido deve conter entre 3 e 30 caracteres.")]
        public string Apelido { get; set; }
        [Required(ErrorMessage = "A Foto do usuario é obrigatória")]
        public byte[] Foto { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A Senha do usuário é obrigatória")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "A senha deve conter entre 3 e 30 caracteres.")]
        public string Senha { get; set; }
    }
}
