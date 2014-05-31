using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Division.Models
{
    public class Hand : Container
    {
        public override void Reset()
        {
            Beads.Clear();
            base.Reset();
        }
    }
}
