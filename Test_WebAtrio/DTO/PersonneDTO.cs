using Test_WebAtrio.Models;

namespace Test_WebAtrio.DTO
{
    public class PersonneDTO
    {

        public string Nom { get; set; } = null!;

        public string Prenom { get; set; } = null!;

        public DateTime DateDeNaissance { get; set; }

        public PersonneDTO() { }

        public PersonneDTO(Personne personne)
        {
            Nom = personne.Nom;
            Prenom = personne.Prenom;
            DateDeNaissance = personne.DateDeNaissance;
        }
    }
}
