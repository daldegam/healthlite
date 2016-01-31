//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HealthApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pessoa
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pessoa()
        {
            this.Remedios = new HashSet<Remedio>();
        }
    
        public int PessoaId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public System.DateTime Nascimento { get; set; }
        public string Telefone { get; set; }
        public short Peso { get; set; }
        public short Altura { get; set; }
        public bool Sexo { get; set; }
        public string ApiToken { get; set; }
        public byte[] Imagem { get; set; }
        public string Alergia { get; set; }
        public string Intolerancia { get; set; }
        public string Doencas { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Remedio> Remedios { get; set; }
    }
}
