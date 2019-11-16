using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    public class Fighter : IFighter
    {
        public int Lives { get; set; }
        public int AttackValue { get; set; }
        public int DefenseValue { get; set; }

        public Fighter(int lives, int attack, int defense)
        {
            this.Lives = lives;
            this.AttackValue = attack;
            this.DefenseValue = defense;
        }

        public void Defend(Attack attack)
        {
            int hit = Math.Max(0, attack.Value - DefenseValue);
            this.Lives -= hit;
            attack.Messages.Add(String.Format("Attacked: {0}, Defended: {1}, got hit: {2}", attack.Value, DefenseValue, hit));
        }

        public Attack Attack()
        {
            var attack = new Attack("Normal attack: " + this.AttackValue, this.AttackValue);
            return attack;
        }
    }
}
