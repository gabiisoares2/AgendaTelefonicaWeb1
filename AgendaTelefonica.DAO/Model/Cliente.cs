using System;

namespace AgendaTelefonica.DAO.Model
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public ExceptionFull exceptionFull = new ExceptionFull();
    }
}
