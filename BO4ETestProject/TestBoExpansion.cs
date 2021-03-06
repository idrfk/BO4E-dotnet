﻿using System;
using System.Collections.Generic;
using BO4E.BO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestBO4E
{
    [TestClass]
    public class TestBoExpansion
    {
        [TestMethod]
        public void TestBoExpansionMaLo()
        {
            HashSet<string> result = new HashSet<string>(BusinessObject.GetExpandablePropertyNames(typeof(Marktlokation)).Keys);
            Assert.IsTrue(result.Contains("zugehoerigeMesslokationen"));

            HashSet<string> result2 = new HashSet<string>(BusinessObject.GetExpandableFieldNames("Marktlokation").Keys);
            Assert.IsTrue(result.SetEquals(result2));
            Assert.ThrowsException<ArgumentException>(() => BusinessObject.GetExpandableFieldNames("kein gültiges bo"));
        }

        [TestMethod]
        public void TestBoExpansionMeLo()
        {
            HashSet<string> result = new HashSet<string>(BusinessObject.GetExpandablePropertyNames(typeof(Messlokation)).Keys);
            Assert.IsTrue(result.Contains("messadresse"));
            Assert.IsTrue(result.Contains("messlokationszaehler"));
            Assert.IsTrue(result.Contains("messlokationszaehler.zaehlwerke"));
        }

        [TestMethod]
        public void TestTypesEnergiemenge()
        {
            Dictionary<string, Type> result = BusinessObject.GetExpandablePropertyNames(typeof(Energiemenge));
            Assert.IsTrue(result.ContainsKey("energieverbrauch"));
            Type verbrauchsType = result["energieverbrauch"];
            Assert.IsTrue(verbrauchsType.IsGenericType);
            Assert.IsTrue(verbrauchsType.GetGenericTypeDefinition() == typeof(List<>));
        }
    }
}
