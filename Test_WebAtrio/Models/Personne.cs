namespace Test_WebAtrio.Models;

public partial class Personne
{
    public int PersonneId { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public DateTime DateDeNaissance { get; set; }

    public virtual ICollection<PersonneEmployée> PersonneEmployées { get; set; } = new List<PersonneEmployée>();
}
