using Division.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division.Models
{
    public class TubeTray : INotifyPropertyChanged
    {
        private int factor = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Tube> Tubes { get; private set; }

        public int Factor
        {
            get { return factor; }
            set
            {
                var changed = (factor != value);
                factor = value;
                if (changed && PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Factor"));
            }
        }

        public TubeTray()
        {
            Tubes = new List<Tube>();
        }

        public void AddTube(Tube tube)
        {
            if (Tubes.Contains(tube))
                throw new ArgumentException("This tray already contains that tube");
            if (tube.Factor != this.Factor)
                throw new RuleException("That tube doesn't belong in this tray");
            Tubes.Add(tube);
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Tubes"));
        }

        public void Fill()
        {
            while (Tubes.Count < 10)
                Tubes.Add(new Tube() { Factor = this.Factor });
            Tubes.ForEach(t => t.Reset());
        }
    }
}
