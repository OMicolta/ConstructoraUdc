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
    
    public partial class PMT_Country
    {
        public PMT_Country()
        {
            this.PMT_City = new HashSet<PMT_City>();
        }
    
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<PMT_City> PMT_City { get; set; }
    }
}
