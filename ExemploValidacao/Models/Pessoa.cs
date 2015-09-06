using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ExemploValidacao.Models
{
    public class Pessoa
    {
        [Required(ErrorMessage = "O Nome deve ser preenchido*")]
        public String Nome { get; set; }

        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$",
            ErrorMessage = "O email deve ser digitado no formato correto")]
        //[DataType(DataType.EmailAddress,ErrorMessage = "Insira um email valido")]
        [Required(ErrorMessage = "O campo email deve ser preenchido")]
        public string Email { get; set; }

        [MaxLength(50, ErrorMessage = "O curriculo deve ter no máximo 50 caracteres")]
        [MinLength(5, ErrorMessage = "O curriculo deve ter no minimo 5 caracteres.")]
        [Required(ErrorMessage = "O campo curriculo deve ser preenchido")]
        public string Curriculo { get; set; }

        [DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Currency, ErrorMessage = "Insira um valor")]
        [Range(10, 9999, ErrorMessage = "O salario deve ser entre 10 e 900")]
        public Decimal Salario { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime)]
        [DisplayName("Data de Nascimento")]
        public DateTime? DataNascimento { get; set; }

        //[RegularExpression(@"{a-zA-Z}",ErrorMessage = "Login deve possuir somente letras")]
        [Required(ErrorMessage = "O login deve ser preenchido")]
        [Remote("LoginUnico", "Pessoa", ErrorMessage = "Esse nome de usuario já existe")]
        public String Login { get; set; }

        [Required(ErrorMessage = "A senha deve ser informada")]
        public string Senha { get; set; }

        [DisplayName("Confirmar Senha")]
        [System.ComponentModel.DataAnnotations.Compare("Senha", ErrorMessage = "As senha não são iguais")]
        public String ConfirmarSenha { get; set; }
    }
}