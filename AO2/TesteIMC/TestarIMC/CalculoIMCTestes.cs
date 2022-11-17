using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteIMC;

namespace TestarIMC
{
    [TestClass]
    public class CalculoIMCTests
    {
        [TestMethod]
        public void CalcularIMC()
        {
            double peso = 118;
            double altura = 1.79;

            var resultadoIMC = Operacoes.CalcularIMC(peso, altura);

            Assert.AreEqual(36.83, resultadoIMC);
        }
    }

}
