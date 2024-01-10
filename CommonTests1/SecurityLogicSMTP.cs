using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Tests
{
    [TestClass()]
    public class SecurityLogicSMTP
    {
        [TestMethod()]
        public void DecryptCryptos()
        {
            var estr = SecurityLogic.Instance().EncryptString("george_joseph99@hotmail.com");
            var str = SecurityLogic.Instance().Decrypt(estr);
        }
    }
}