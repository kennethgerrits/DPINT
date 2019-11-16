using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    class ShieldFighterDecorator : BaseFighterDecorator
    {
        private int ShieldDefends;
        public ShieldFighterDecorator(IFighter iFighter, int shieldDefends) : base(iFighter)
        {
            ShieldDefends = shieldDefends;
        }

        public override void Defend(Attack attack)
        {
            if (ShieldDefends > 0)
            {
                attack.Messages.Add("Shield protected, attack value = 0");
                attack.Value = 0;
                ShieldDefends--;
            }
            base.Defend(attack);
        }
    }
}
