using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.BLL.Models
{
    public class ApiProduto //Classe que representa o JSON recebido da API
    {
        public string Descricao = "";
        public string CodigoBarras = "";
        public List<string> Imagens = new();
    }
}
