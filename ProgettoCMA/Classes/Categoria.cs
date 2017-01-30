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
        public static Categoria FindByName(String nome)
        {
            IQueryable<Categoria> categoria = Shared.cdc.CategoriaSet.Where(c => c.Nome == nome);
            if(categoria.Count() != 1) {
                throw new Exception("Trovata piu' di una categoria con lo stesso nome: " + nome);
            }
            return categoria.First();
        }
    }
}
