using Microsoft.VisualStudio.TestTools.UnitTesting;
using TesteIMC;

namespace TestarIMC
{
    [TestClass]
    public class ClassificarIMCTests
    {
        [TestMethod]
        public void ClassificarIMC()
        {
            double imc = 28;

            var classificacaoIMC = Operacoes.ClassificarIMC(imc);

            Assert.AreEqual("Sobrepeso", classificacaoIMC);
        }
    }

}
