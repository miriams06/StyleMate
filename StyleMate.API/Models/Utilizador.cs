using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

<<<<<<< HEAD
namespace StyleMateAPI.Models
=======
namespace StyleMate1._1.Models
>>>>>>> 856aa784dc6d940e6820f47978450581557e3a84
{
    public class Utilizador
    {
        [Key]
        public int IdUtilizador { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        public string ExternalId { get; set; }
        public string Nome { get; set; }
        public string FotoPerfil { get; set; }
        public string Preferencias { get; set; }
        public DateTime DataRegisto { get; set; } = DateTime.UtcNow;
        public DateTime? UltimoAcesso { get; set; }

        public ICollection<Roupa> Roupas { get; set; }
        public ICollection<Conjunto> Conjuntos { get; set; }
        public ICollection<Evento> Eventos { get; set; }
        public ICollection<Mala> Malas { get; set; }
    }
}
