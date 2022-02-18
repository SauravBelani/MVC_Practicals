using NUnit.Framework;
using Practical_08.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical_08.Test
{
    [TestFixture]
    public class HelloWorld
    {
        [Test]
        public void Return()
        {
            var sut = new TestCase();
            Assert.That(sut.print(),Is.EqualTo("Hello World!"));
        }
    }
}
