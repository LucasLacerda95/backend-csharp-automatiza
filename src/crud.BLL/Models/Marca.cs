using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crud.BLL.Models
{
    public class Marca : Entity
    {
        public Guid MarcaID { get; set; }

        public string Descricao { get; set; }
        public string Status { get; set; }


        // Relacionamento Entity
        public Produto ProdutoId { get; set; }
    }
}
