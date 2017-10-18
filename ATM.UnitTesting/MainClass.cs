using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.UnitTesting
{
    internal class MainClass
    {
        protected string GetText { get; set; }
        internal bool LoadText { get; set; }
    }
   
   public interface IProduct
    {
        void GetDetails();
    }

    public class ProductA : IProduct
    {
        public void GetDetails()
        {
            Console.WriteLine("Product A");
        }
    }
    public class ProductB : IProduct
    {
        public void GetDetails()
        {
            Console.WriteLine("Product B");
        }
    }

    public abstract class Factory {

        public abstract IProduct GetProduct();

    }

    public class ProductCreateA : Factory
    {
        public override IProduct GetProduct()
        {
            return new ProductA();
        }
    }

    public class ProductCreateB : Factory
    {
        public override IProduct GetProduct()
        {
            return new ProductB();
        }
    }
}
