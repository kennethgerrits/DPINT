using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPINT_Wk2_Decorator.Model
{
    abstract class BaseFighterDecorator : IFighter
    {
        private IFighter _fighterImplementation;

        protected BaseFighterDecorator(IFighter iFighter)
        {
            _fighterImplementation = iFighter;
        }

        public virtual int Lives
        {
            get => _fighterImplementation.Lives;
            set => _fighterImplementation.Lives = value;
        }

        public virtual int AttackValue
        {
            get => _fighterImplementation.AttackValue;
            set => _fighterImplementation.AttackValue = value;
        }

        public virtual int DefenseValue
        {
            get => _fighterImplementation.DefenseValue;
            set => _fighterImplementation.DefenseValue = value;
        }

        public virtual void Defend(Attack attack)
        {
            _fighterImplementation.Defend(attack);
        }

        public virtual Attack Attack()
        {
            return _fighterImplementation.Attack();
        }
    }
}
