using Division.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division.Models
{
    public class Cup : Container
    {
        private int factor = 0;
        private int value = 0;

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
        public int Value
        {
            get { return value; }
            set
            {
                var changed = (value != this.value);
                this.value = value;
                if (changed) OnPropertyChanged("Value");
                if (this.value < Beads.Count)
                    throw new SuggestionException("There are too many beads in this cup");
            }
        }
        public override void AddBead(Bead newbead)
        {
            base.AddBead(newbead);
            if (Beads.Count > value)
                throw new SuggestionException("There are too many beads in this cup");
        }
        public override void Reset()
        {
            Beads.Clear();
            base.Reset();
        }
    }
}
