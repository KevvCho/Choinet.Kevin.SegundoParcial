using Xunit;
using Entidades;

namespace TestUnitario
{
    public class AcuaticoTests
    {
        [Fact]
        public void CalcularPoder_DebeRetornarLaSumaDeVelocidadYNivelDePoder()
        {
            Acuatico acuatico = new Acuatico("Acuatico", EPoderes.Telepatia, 10);
            acuatico.Velocidad = 3;

            int resultado = acuatico.CalcularPoder();

            Assert.Equal(13, resultado);
        }

        [Fact]
        public void ObtenerDescripcion_DebeRetornarDescripcionCorrecta()
        {
            Acuatico acuatico = new Acuatico("Acuatico", EPoderes.Telepatia, 10);
            acuatico.Velocidad = 3;
            acuatico.BooleanoHeroe = true;

            string descripcion = acuatico.ToString();

            Assert.Equal("¡Soy Acuatico, un héroe acuático con una velocidad de natación de 3 y con habilidad de comunicación marina!", descripcion);
        }

        [Fact]
        public void Equals_DebeRetornarTrueSiLosObjetosSonIguales()
        {
            Acuatico acuatico1 = new Acuatico("Acuatico", EPoderes.Telepatia, 10);
            acuatico1.Velocidad = 3;
            acuatico1.BooleanoHeroe = true;

            Acuatico acuatico2 = new Acuatico("Acuatico", EPoderes.Telepatia, 10);
            acuatico2.Velocidad = 3;
            acuatico2.BooleanoHeroe = true;

            bool resultado = acuatico1.Equals(acuatico2);

            Assert.True(resultado);
        }

        [Fact]
        public void Equals_DebeRetornarFalseSiLosObjetosNoSonIguales()
        {
            Acuatico acuatico1 = new Acuatico("Acuatico1", EPoderes.Telepatia, 10);
            acuatico1.Velocidad = 3;
            acuatico1.BooleanoHeroe = true;

            Acuatico acuatico2 = new Acuatico("Acuatico2", EPoderes.Telepatia, 10);
            acuatico2.Velocidad = 3;
            acuatico2.BooleanoHeroe = true;

            bool resultado = acuatico1.Equals(acuatico2);

            Assert.False(resultado);
        }
    }
}