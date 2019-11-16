using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    class DoubleHandedFighterDecorator : BaseFighterDecorator
    {
        public DoubleHandedFighterDecorator(IFighter iFighter) : base(iFighter)
        {
        }

        public override Attack Attack()
        {
            var attack = new Attack("Normal attack: " + this.AttackValue, this.AttackValue);
            attack.Value += AttackValue;
            attack.Messages.Add("Doubled the original attack value: " + AttackValue);
            return attack;
        }

  
    }
}
