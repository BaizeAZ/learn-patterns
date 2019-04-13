using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public class AbstractFactoryExample2
    {
        public void RunExample2()
        {
            ContinentFactory africaFactory = new AfricaFactory();
            ContinentFactory americaFactory = new AmericaFactory();
            AnimaWorld animaWorld = new AnimaWorld(africaFactory);
            animaWorld.RunAnimaWorld();
            animaWorld.ChangeFactory(americaFactory);
            animaWorld.RunAnimaWorld();
        }
        
    }

    abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnbivore CreateCarnbivore();
    }

    abstract class Herbivore
    {

    }
    abstract class Carnbivore
    {
        public abstract void Eat(Herbivore h);
    }
    class Wildebeest : Herbivore
    {

    }
    class Lion : Carnbivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine(this.GetType().Name + " eat " + h.GetType().Name);
        }
    }
    class Bison : Herbivore
    {

    }
    class Wolf : Carnbivore
    {
        public override void Eat(Herbivore h)
        {
            Console.WriteLine(this.GetType().Name + " eat " + h.GetType().Name);
        }
    }

    class AfricaFactory : ContinentFactory
    {
        public override Carnbivore CreateCarnbivore()
        {
            return new Lion();                 
        }

        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }
    }
    class AmericaFactory : ContinentFactory
    {
        public override Carnbivore CreateCarnbivore()
        {
            return new Wolf();
        }

        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
    }

    class AnimaWorld
    {
        private Herbivore _herbivore;
        private Carnbivore _carnbivore;

        public AnimaWorld(ContinentFactory _factory)
        {
            _herbivore = _factory.CreateHerbivore();
            _carnbivore = _factory.CreateCarnbivore();
        }

        public void ChangeFactory(ContinentFactory _factory)
        {
            _herbivore = _factory.CreateHerbivore();
            _carnbivore = _factory.CreateCarnbivore();
        }

        public void RunAnimaWorld()
        {
            _carnbivore.Eat(_herbivore);
        }
    }
}
