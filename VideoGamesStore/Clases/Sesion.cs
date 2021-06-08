using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGamesStore.Clases
{
    
    public class Sesion
    {
       
        private  int log_id;

        private  string nombre, apellido, email;
        public int Login {
            get { return log_id; }
            set { log_id = value; }
        } 
    }
}
