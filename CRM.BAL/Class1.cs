using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.DAL;
using EZMasterSetup;

namespace CRM.BAL
{
    public class Class1
    {
        public Class1(string CmpyCode) {
            GlobalVariable.CmpyCode = CmpyCode;
        }
    }
}
