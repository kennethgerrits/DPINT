using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    class MinionFighterDecorator : BaseFighterDecorator
    {
        public MinionFighterDecorator(IFighter iFighter) : base(iFighter)
        {
        }

        public override Attack Attack()
        {
            var attack = new Attack("Normal attack: " + this.AttackValue, this.AttackValue);

            attack.Messages.Add("Minion helping the attack: " + MinionAttackValue);
            attack.Value += MinionAttackValue;

        }

    }
}
