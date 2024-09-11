using System;
using System.Collections.Generic;
using Test_WebAtrio.DTO;

namespace Test_WebAtrio.Models;

public partial class PersonneEmployée
{
    public int EmploiId { get; set; }

    public int PersonneId { get; set; }

    public DateTime DateDebut { get; set; }

    public DateTime? DateFin { get; set; }

    public virtual Emploi Emploi { get; set; } = null!;

    public virtual Personne Personne { get; set; } = null!;
}
