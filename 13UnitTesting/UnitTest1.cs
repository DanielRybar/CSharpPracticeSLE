using _13TestovaniSW;
using _13TestovaniSW.Exceptions;

// nutn� p�idat referenci na testovan� projekt (prav� tl. na projekt - Add - Project Reference)
// spu�t�n� - Test/Run All Tests

namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        private QuadraticEquation _eq;

        [TestInitialize] // zavol� se p�ed ka�d�m testem
        public void Initialize()
        {
            _eq = new QuadraticEquation(1, 2, 3);
        }

        [TestCleanup] // zavol� se po ka�d�m testu
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
        [ExpectedException(typeof(QuadraticCoefficientException))] // o�ek�van� v�jimka
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
        [ExpectedException(typeof(QuadraticCoefficientException))] // o�ek�van� v�jimka
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
* AreEqual() - Dva objekty se shoduj�
* AreNotEqual() - Pou��v�me pokud chceme ov��it, �e se 2 objekty NEshoduj�.
* AreSame() - Zkontroluje, zda 2 reference ukazuj� na stejn� objekt (porovn�v� pomoc� oper�toru ==).
* Equals() - Pou��v�me v p��pad�, kdy� chceme ov��it 2 objekty pomoc� metody Equals() a zjistit, zda jsou stejn�. Nepou��v�me pro ov��en� hodnoty m�sto AreEqual().
* Fail() - Zp�sob� selh�n� test�. Obvykle ji vkl�d�me za n�jakou podm�nku a dopl�ujeme o voliteln� parametry chybov� hl�ka a parametry.
* Inconclusive() - Funguje podobn� jako Fail(). Vyvol� v�jimku signalizuj�c� nepr�kaznost testu.
* IsFalse() - Ov���, zda je dan� v�raz NEpravdiv�.
* IsInstanceOfType() - Ov���, zda je objekt instanc� dan�ho typu.
* IsNull() - Ov���, zda je hodnota null.
* IsTrue() - Ov���, zda je dan� v�raz pravdiv�.
* ReplaceNullChars() - Nahrad� nulov� znaky \0 za \\0. Vyu�ijeme zejm�na u diagnostick�ch v�pis� �et�zc� s t�mito znaky.
* ThrowsException() - Spust� p�edan� deleg�t a ov���, �e vyvol�v� v�jimku p�edanou jako generick� argument. Metoda m� tak� asynchronn� verzi ThrowsExceptionAsync().
*/