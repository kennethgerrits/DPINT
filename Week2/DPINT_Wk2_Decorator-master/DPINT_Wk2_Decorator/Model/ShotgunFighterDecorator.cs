using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    class ShotgunFighterDecorator : BaseFighterDecorator
    {
        private int _shotgunRoundsFired = 0;
        public ShotgunFighterDecorator(IFighter iFighter) : base(iFighter)
        {
        }

        public override Attack Attack()
        {
            var attack = base.Attack();

            if (_shotgunRoundsFired < 2)
            {
                attack.Messages.Add("Shotgun: 20");
                attack.Value += 20;
                _shotgunRoundsFired++;
            }
            else
            {
                attack.Messages.Add("Shotgun reloading, no extra damage.");
                _shotgunRoundsFired = 0;
            }
            return attack;
        }
    }
}
