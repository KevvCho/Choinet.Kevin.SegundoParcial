using Xunit;
using Entidades;

namespace TestUnitario
{
    public class AereoTests
    {
        [Fact]
        public void CalcularPoder_DebeRetornarLaSumaDeVelocidadYNivelDePoder()
        {
            Aereo aereo = new Aereo("Aereo", EPoderes.Invisibilidad, 10);
            aereo.Velocidad = 5;

            int resultado = aereo.CalcularPoder();

            Assert.Equal(15, resultado);
        }

        [Fact]
        public void ObtenerDescripcion_DebeRetornarDescripcionCorrecta()
        {
            Aereo aereo = new Aereo("Aereo", EPoderes.Invisibilidad, 10);
            aereo.Velocidad = 5;
            aereo.BooleanoHeroe = true;

            string descripcion = aereo.ToString();

            Assert.Equal("¡Soy Aereo, un héroe aéreo con alas y una velocidad de vuelo de 5!", descripcion);
        }

        [Fact]
        public void Equals_DebeRetornarTrueSiLosObjetosSonIguales()
        {
            Aereo aereo1 = new Aereo("Aereo", EPoderes.Invisibilidad, 10);
            aereo1.Velocidad = 5;
            aereo1.BooleanoHeroe = true;

            Aereo aereo2 = new Aereo("Aereo", EPoderes.Invisibilidad, 10);
            aereo2.Velocidad = 5;
            aereo2.BooleanoHeroe = true;

            bool resultado = aereo1.Equals(aereo2);

            Assert.True(resultado);
        }

        [Fact]
        public void Equals_DebeRetornarFalseSiLosObjetosNoSonIguales()
        {
            Aereo aereo1 = new Aereo("Aereo1", EPoderes.Invisibilidad, 10);
            aereo1.Velocidad = 5;
            aereo1.BooleanoHeroe = true;

            Aereo aereo2 = new Aereo("Aereo2", EPoderes.Invisibilidad, 10);
            aereo2.Velocidad = 5;
            aereo2.BooleanoHeroe = true;

            bool resultado = aereo1.Equals(aereo2);

            Assert.False(resultado);
        }
    }
}