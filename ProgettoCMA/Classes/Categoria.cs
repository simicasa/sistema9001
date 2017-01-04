using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgettoCMA
{
    public partial class Categoria
    {
        public Categoria(int ID, String nome, Categoria macro)
        {
            this.ID = ID;
            this.Macro = macro;
            this.Nome = nome;
        }
    }
}
