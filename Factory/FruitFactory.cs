using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factory
{
    enum FruitType : byte
    {
        Banana = 0,
        Apple,
        Watermelon,
    }
    class FruitFactory
    {
        public Fruit SimpleCreator(FruitType type)
        {
            switch (type)
            {
                case FruitType.Banana:
                    return new Banana();                    
                case FruitType.Apple:
                    return new Apple();                    
                case FruitType.Watermelon:
                    return new Watermelon();
                default:
                    break;
            }
            return null;
        }
    }
}
