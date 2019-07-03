using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaTelefonica.DAO.Model
{
    public class ExceptionFull
    {
        public int IdLogErro { get; set; }
        public string Ambiente { get; set; }
        public string ProjectName { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public bool StatusAtual { get; set; }
        public string Message { get; set; }
        public DateTime DataHora { get; set; }
        public int Login { get; set; }
    }
}
