using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSTower.API.ViewModel
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "O Nome deve conter entre 3 e 30 caracteres.")]
        public string Nome { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(30, MinimumLength = 3, ErrorMessage = "O Apelido deve conter entre 3 e 30 caracteres.")]
        public string Apelido { get; set; }
        public byte[] Foto { get; set; }
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "A senha deve conter entre 3 e 30 caracteres.")]
        public string Senha { get; set; }
    }
}
