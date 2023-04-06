using _13TestovaniSW;
using _13TestovaniSW.Exceptions;

// nutné pøidat referenci na testovaný projekt (pravé tl. na projekt - Add - Project Reference)
// spuštìní - Test/Run All Tests

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        private QuadraticEquation _eq;

        [TestInitialize] // zavolá se pøed každým testem
        public void Initialize()
        {
            _eq = new QuadraticEquation(1, 2, 3);
        }

        [TestCleanup] // zavolá se po každém testu
        public void Cleanup()
        {
        }

        [TestMethod] // reprezentuje jeden test
        public void TestDiscriminant()
        {
            Assert.AreEqual(-8, _eq.GetDiscriminant());
            _eq.SetParameters(-5, 6, 7);
            Assert.AreEqual(176, _eq.GetDiscriminant());
            _eq.SetParameters(-12, -6, 7);
            Assert.AreEqual(372, _eq.GetDiscriminant());
            _eq.SetParameters(-8, -8, -3);
            Assert.AreEqual(-32, _eq.GetDiscriminant());
            _eq.SetParameters(5, 8, -88);
            Assert.AreEqual(1824, _eq.GetDiscriminant());
        }

        [TestMethod]
        [ExpectedException(typeof(QuadraticCoefficientException))] // oèekávaná výjimka
        public void TestRootCount()
        {
            Assert.AreEqual(0, _eq.RootCount);
            _eq.SetParameters(-5, 6, 7);
            Assert.AreEqual(2, _eq.RootCount);
            _eq.SetParameters(-7, -79, 16);
            Assert.AreEqual(2, _eq.RootCount);

            _eq.SetParameters(0, 5, 5);
            double[] roots = _eq.Roots();
        }

        [TestMethod]
        [ExpectedException(typeof(QuadraticCoefficientException))] // oèekávaná výjimka
        public void TestValue()
        {
            Assert.AreEqual(38, _eq.Value(5));
            _eq.SetParameters(-5, 6, 7);
            Assert.AreEqual(-433, _eq.Value(10));
            _eq.SetParameters(-7, -79, 16);
            Assert.AreEqual(-77884, _eq.Value(100));

            _eq.SetParameters(0, 0, 0);
            double val = _eq.Value(8);
        }
    }
}

/*
Metody Assert
* AreEqual() - Dva objekty se shodují
* AreNotEqual() - Používáme pokud chceme ovìøit, že se 2 objekty NEshodují.
* AreSame() - Zkontroluje, zda 2 reference ukazují na stejný objekt (porovnává pomocí operátoru ==).
* Equals() - Používáme v pøípadì, když chceme ovìøit 2 objekty pomocí metody Equals() a zjistit, zda jsou stejné. Nepoužíváme pro ovìøení hodnoty místo AreEqual().
* Fail() - Zpùsobí selhání testù. Obvykle ji vkládáme za nìjakou podmínku a doplòujeme o volitelné parametry chybová hláška a parametry.
* Inconclusive() - Funguje podobnì jako Fail(). Vyvolá výjimku signalizující neprùkaznost testu.
* IsFalse() - Ovìøí, zda je daný výraz NEpravdivý.
* IsInstanceOfType() - Ovìøí, zda je objekt instancí daného typu.
* IsNull() - Ovìøí, zda je hodnota null.
* IsTrue() - Ovìøí, zda je daný výraz pravdivý.
* ReplaceNullChars() - Nahradí nulové znaky \0 za \\0. Využijeme zejména u diagnostických výpisù øetìzcù s tìmito znaky.
* ThrowsException() - Spustí pøedaný delegát a ovìøí, že vyvolává výjimku pøedanou jako generický argument. Metoda má také asynchronní verzi ThrowsExceptionAsync().
*/