using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    class PoisonFighterDecorator : BaseFighterDecorator
    {
        public PoisonFighterDecorator(IFighter iFighter) : base(iFighter)
        {
        }
    }
}
