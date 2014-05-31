using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division.Models
{
    public class Tube : Container
    {
        private int factor = 0;

        public int Factor
        {
            get { return factor; }
            set
            {
                var changed = (value != factor);
                factor = value;
                if (changed) OnPropertyChanged("Factor");
            }
        }

        public override void AddBead(Bead newbead)
        {
            base.AddBead(newbead);
        }

        public override void Reset()
        {
            while(Beads.Count < 10) Beads.Add(new Bead() { Factor = this.Factor });
            base.Reset();
        }
    }
}
