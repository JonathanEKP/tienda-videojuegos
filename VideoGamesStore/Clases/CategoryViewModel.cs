using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGamesStore.Clases
{
    class CategoryViewModel
    {
        public int CategoryId { get; set; }

        public string Description { get; set; }


        public List<Categorie> ListaC()
        {
            ProyectopooEntities model = new ProyectopooEntities();
            List<Categorie> lista = new List<Categorie>();
            try
            {
                lista = model.Categorie.ToList();
                return lista;
            }catch(Exception ex)
            {
                return lista;
            }
        }

    }
}
