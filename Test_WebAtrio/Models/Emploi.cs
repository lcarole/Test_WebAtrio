using System;
using System.Collections.Generic;

namespace Test_WebAtrio.Models;

public partial class Emploi
{
    public int EmploiId { get; set; }

    public string Entreprise { get; set; } = null!;

    public string Poste { get; set; } = null!;

    public virtual ICollection<PersonneEmployée> PersonneEmployées { get; set; } = new List<PersonneEmployée>();
}
