//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArrobaGym
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cliente
    {
        public Cliente()
        {
            this.Seguimientoes = new HashSet<Seguimiento>();
        }
    
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Factores_de_riesgos { get; set; }
        public string Objetivos { get; set; }
        public byte[] Imagen { get; set; }
        public System.DateTime Fecha_Inscripcion { get; set; }
        public string Status { get; set; }
        public Nullable<decimal> Saldo { get; set; }
        public Nullable<System.DateTime> Ultimo_Pago { get; set; }
        public Nullable<int> IdPrograma { get; set; }
    
        public virtual Programa Programa { get; set; }
        public virtual ICollection<Seguimiento> Seguimientoes { get; set; }
    }
}
