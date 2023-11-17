using Xunit;
using Entidades;

namespace TestUnitario
{
    public class TerrestreTests
    {
        [Fact]
        public void CalcularPoder_DebeRetornarLaSumaDeVelocidadYNivelDePoder()
        {
            Terrestre terrestre = new Terrestre("Terrestre", EPoderes.Fuego, 10);
            terrestre.Velocidad = 7;

            int resultado = terrestre.CalcularPoder();

            Assert.Equal(17, resultado);
        }

        [Fact]
        public void ObtenerDescripcion_DebeRetornarDescripcionCorrecta()
        {
            Terrestre terrestre = new Terrestre("Terrestre", EPoderes.Fuego, 10);
            terrestre.Velocidad = 7;
            terrestre.BooleanoHeroe = true;

            string descripcion = terrestre.ToString();

            Assert.Equal("¡Soy Terrestre, un héroe terrestre con super fuerza y con un nivel de velocidad de 7!", descripcion);
        }

        [Fact]
        public void Equals_DebeRetornarTrueSiLosObjetosSonIguales()
        {
            Terrestre terrestre1 = new Terrestre("Terrestre", EPoderes.Fuego, 10);
            terrestre1.Velocidad = 7;
            terrestre1.BooleanoHeroe = true;

            Terrestre terrestre2 = new Terrestre("Terrestre", EPoderes.Fuego, 10);
            terrestre2.Velocidad = 7;
            terrestre2.BooleanoHeroe = true;

            bool resultado = terrestre1.Equals(terrestre2);

            Assert.True(resultado);
        }

        [Fact]
        public void Equals_DebeRetornarFalseSiLosObjetosNoSonIguales()
        {
            Terrestre terrestre1 = new Terrestre("Terrestre1", EPoderes.Fuego, 10);
            terrestre1.Velocidad = 7;
            terrestre1.BooleanoHeroe = true;

            Terrestre terrestre2 = new Terrestre("Terrestre2", EPoderes.Fuego, 10);
            terrestre2.Velocidad = 7;
            terrestre2.BooleanoHeroe = true;

            bool resultado = terrestre1.Equals(terrestre2);

            Assert.False(resultado);
        }
    }
}