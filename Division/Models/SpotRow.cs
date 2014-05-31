using Division.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division.Models
{
    public class SpotRow : INotifyPropertyChanged
    {
        private int divisor = 0;
        private List<Spot> spots = new List<Spot>(9);

        public event PropertyChangedEventHandler PropertyChanged;

        public SpotRow()
        {
            for(int i=0;i<9;i++)
            {
                var s = new Spot();
                s.PropertyChanged += Spot_PropertyChanged;
                spots.Add(s);
            }
        }

        public List<Spot> Spots
        {
            get { return spots; }
        }

        public int Divisor
        {
            get { return divisor; }
            set
            {
                var changed = (divisor != value);
                divisor = value;
                if (changed && PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Divisor"));
            }
        }

        public bool IsFull
        {
            get
            {
                var value = Spots.Where(s => s.Beads.Count > 0).Count();
                return (value >= divisor);
            }
        }

        public void Reset()
        {
            Spots.ForEach(s => s.Reset());
        }
        private void Spot_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Spot spot = (Spot)sender;
            if (!spots.Contains(spot))
                throw new ArgumentException("The changed spot is not part of this row.");
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Spots"));

            if (spots.IndexOf(spot) >= divisor)
                throw new SuggestionException("The divisor is only " + divisor.ToString() + ". This bead doesn't belong there.");
        }

    }
}
