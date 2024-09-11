using Test_WebAtrio.Models;

namespace Test_WebAtrio.DTO
{
    public class EmploiDTO
    {
        public string Entreprise { get; set; } = null!;
        public string Poste { get; set; } = null!;

        public EmploiDTO() { }
        public EmploiDTO(Emploi emploi)
        {
            Entreprise = emploi.Entreprise;
            Poste = emploi.Poste;
        }
    }
}
