using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division.Models
{
    public class Bead : INotifyPropertyChanged
    {
        private int factor = 0;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Factor
        {
            get { return factor; }
            set
            {
                var changed = (value != factor);
                factor = value;
                if (changed && PropertyChanged!=null) PropertyChanged(this, new PropertyChangedEventArgs("Factor"));
            }
        }
    }
}
