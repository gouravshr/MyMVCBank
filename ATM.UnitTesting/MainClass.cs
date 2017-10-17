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
   
}

namespace ATM.SampleClasses
{

    public class SubClass
    {

        public SubClass()
        {
            ATM.UnitTesting.MainClass mc = new ATM.UnitTesting.MainClass();
            mc.LoadText = false;
        }
    }

}
