using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Data.CapturedData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace Novel.Tests
{
    [TestClass]
    public class IdMappingTest
    {
        [TestMethod]
        public void EncodeIdTest()
        {
            int id = 12345;
            int resultId = IdMappingHelper.EncodeId(id);

            Assert.IsTrue(resultId == 39710);
        }

        [TestMethod]
        public void DecodeIdTest()
        {
            int id = 82564;
            int resultId = IdMappingHelper.DecodeId(id);

            Assert.IsTrue(resultId == 67890);
        }

        [TestMethod]
        public void EncodeDecodeEqualTest()
        {
            int inputId = 12345;
            int outputId = IdMappingHelper.DecodeId(IdMappingHelper.EncodeId(inputId));

            Assert.IsTrue(inputId == outputId);
        }
    }
}
