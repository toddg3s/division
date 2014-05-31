using Division.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division.Models
{
    public class Spot : Container
    {
        public override void AddBead(Bead newbead)
        {
            if (Beads.Count > 0)
                throw new RuleException("This spot already has a bead");
            base.AddBead(newbead);
        }

        public override void Reset()
        {
            Beads.Clear();
            base.Reset();
        }
    }
}
