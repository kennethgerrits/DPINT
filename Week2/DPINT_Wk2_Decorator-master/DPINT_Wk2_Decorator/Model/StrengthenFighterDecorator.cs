using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    class StrengthenFighterDecorator : BaseFighterDecorator
    {
        private const int PERCENTAGE_BUFF = 10;

        public StrengthenFighterDecorator(IFighter iFighter) : base(iFighter)
        {
            double defendDouble = base.DefenseValue * ((100.00 + PERCENTAGE_BUFF) / 100.00);
            base.DefenseValue = (int)Math.Round(defendDouble, MidpointRounding.AwayFromZero);
        }

        public override Attack Attack()
        {
            var attack = base.Attack();
            double attackDouble = base.AttackValue * ((100.00 + PERCENTAGE_BUFF) / 100.00);
            attack.Value = (int)Math.Round(attackDouble, MidpointRounding.AwayFromZero); 
            return attack;
        }
    }
}
