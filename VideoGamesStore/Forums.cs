//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VideoGamesStore
{
    using System;
    using System.Collections.Generic;
    
    public partial class Forums
    {
        public string ForumId { get; set; }
        public string CategoryId { get; set; }
        public string Descripcion { get; set; }
        public string Comments { get; set; }
    
        public virtual Category Category { get; set; }
    }
}