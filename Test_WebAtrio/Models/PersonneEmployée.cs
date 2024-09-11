using System;
using System.Collections.Generic;

namespace Test_WebAtrio.Models;

public partial class PersonneEmployée
{
    public int PersonneEmployee { get; set; }

    public int? EmploiId { get; set; }

    public int? PersonneId { get; set; }

    public DateTime DateDebut { get; set; }

    public DateTime? DateFin { get; set; }

    public virtual Emploi? Emploi { get; set; }

    public virtual Personne? Personne { get; set; }
}
