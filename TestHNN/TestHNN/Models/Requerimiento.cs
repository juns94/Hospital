//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestHNN.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Requerimiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Nullable<System.DateTime> Fecha { get; set; }
        public int Solicitante { get; set; }
        public string Dificultad { get; set; }
        public string Importancia { get; set; }
        public string Urgencia { get; set; }
        public string Jerarquia { get; set; }
        public string Prioridad { get; set; }
        public string Modulo { get; set; }
        public string Plantilla { get; set; }
        public string Descripcion { get; set; }
        public Nullable<System.DateTime> FechaEnviado { get; set; }
        public Nullable<System.DateTime> FechaRecibido { get; set; }
        public Nullable<int> Estado { get; set; }
        public Nullable<int> Sistema { get; set; }
    
        public virtual Estado Estado1 { get; set; }
        public virtual Sistema Sistema1 { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
