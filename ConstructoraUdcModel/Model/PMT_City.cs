//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConstructoraUdcModel.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class PMT_City
    {
        public PMT_City()
        {
            this.SEC_User = new HashSet<SEC_User>();
        }
    
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int country_id { get; set; }
    
        public virtual ICollection<SEC_User> SEC_User { get; set; }
        public virtual PMT_Country PMT_Country { get; set; }
    }
}