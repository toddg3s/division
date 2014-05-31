using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division.Models
{
    public class Container : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Container()
        {
            Beads = new List<Bead>();
        }

        public List<Bead> Beads { get; private set; }

        public virtual void AddBead(Bead newbead)
        {
            if (Beads.Contains(newbead))
                throw new ArgumentException("That bead is already in the container");
            Beads.Add(newbead);
            OnPropertyChanged("Beads");
        }
        public virtual void RemoveBead(Bead bead)
        {
            if (!Beads.Contains(bead))
                throw new ArgumentException("That bead is not in this container");
            Beads.Remove(bead);
            OnPropertyChanged("Beads");
        }
        public virtual void Reset()
        {
            OnPropertyChanged("Beads");
        }

        protected void OnPropertyChanged(string PropertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
        }

    }
}
