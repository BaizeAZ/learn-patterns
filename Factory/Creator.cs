using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 工厂方法
/// </summary>
namespace Factory
{
    public abstract class Creator
    {
        public abstract Fruit CreateFruitFactory();
    }

    public class AppleFactory : Creator
    {
        public override Fruit CreateFruitFactory()
        {
            return new Apple();
        }
    }

    public class BananaFactory : Creator
    {
        public override Fruit CreateFruitFactory()
        {
            return new Banana();
        }
    }

    public class WatermelonFactory : Creator
    {
        public override Fruit CreateFruitFactory()
        {
            return new Watermelon();
        }
    }
}
