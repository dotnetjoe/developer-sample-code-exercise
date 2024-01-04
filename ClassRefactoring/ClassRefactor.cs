using System;

namespace DeveloperSample.ClassRefactoring
{
    public enum SwallowLoad
    {
        None, 
        Coconut
    }

    public enum SwallowType
    {
        African,
        European
    }

    public abstract class Swallow
    {
        public abstract double GetBaseAirspeedVelocity();

        public SwallowLoad Load { get; private set; }

        public void ApplyLoad(SwallowLoad load)
        {
            Load = load;
        }

        public double GetAirspeedVelocity()
        {
            double baseSpeed = GetBaseAirspeedVelocity();

            if (Load == SwallowLoad.Coconut)
            {
                return baseSpeed - 4; // Decrease speed by 4 if laden with a coconut
            }

            return baseSpeed;
        }
    }

    public class AfricanSwallow : Swallow
    {
        public override double GetBaseAirspeedVelocity()
        {
            return 22;
        }
    }

    public class EuropeanSwallow : Swallow
    {
        public override double GetBaseAirspeedVelocity()
        {
            return 20;
        }
    }

    public class SwallowFactory
    {
        public Swallow GetSwallow(SwallowType swallowType)
        {
            switch (swallowType)
            {
                case SwallowType.African:
                    return new AfricanSwallow();
                case SwallowType.European:
                    return new EuropeanSwallow();
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}