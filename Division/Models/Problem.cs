using Division.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division.Models
{
    public class Problem : INotifyPropertyChanged
    {
        private int divisor = 0;
        private int dividend = 0;
        private List<TubeTray> trays = new List<TubeTray>();
        private List<Cup> cups = new List<Cup>();
        private List<SpotRow> rows = new List<SpotRow>(9);
        
        public event PropertyChangedEventHandler PropertyChanged;

        public Problem()
        {
            for(int i=0;i<9;i++)
            {
                var row = new SpotRow() { Divisor = this.Divisor };
                row.PropertyChanged += row_PropertyChanged;
                rows.Add(row);
            }
        }

        public int Divisor
        {
            get { return divisor; }
            set
            {
                if (value > 9)
                    throw new RuleException("This tool does not currently support a divisor that is more than 9");
                var changed = (value != divisor);
                divisor = value;
                if (changed && PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Divisor"));
                rows.ForEach(r => r.Divisor = this.divisor);
            }
        }

        public int Dividend
        {
            get { return dividend; }
            set
            {
                if (value > 100000)
                    throw new RuleException("This tool does not currently support a divisor that is more than 100,000");
                var changed = (value != dividend);
                dividend = value;
                if (changed && PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Dividend"));

                if(changed)
                { 
                    for(int factor = 5; factor >= 0; factor--)
                    {
                        if (Math.Pow(10d, Convert.ToDouble(factor)) < dividend)
                        {
                            var tray = new TubeTray() { Factor = factor };
                            tray.PropertyChanged += tray_PropertyChanged;
                            tray.Fill();
                            trays.Add(tray);
                            var cup = new Cup() { Factor = factor };
                            cup.PropertyChanged += cup_PropertyChanged;
                        }
                    }
                }
            }
        }

        public List<TubeTray> Trays { get { return trays; } }
        public List<Cup> Cups { get { return cups; } }
        public List<SpotRow> Rows { get { return rows; } }

        private void row_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
        void tray_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
        void cup_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
    }
}
