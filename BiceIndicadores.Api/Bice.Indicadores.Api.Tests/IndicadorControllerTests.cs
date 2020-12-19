using Bice.BusinessActions;
using Bice.BusinessObjects;
using Bice.Context;
using Bice.DataAccess.DataService;
using Bice.DataAccess.Infrastructure;
using Bice.Indicadores.Api.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Bice.Indicadores.Api.Tests
{
    [TestClass]
    public class IndicadorControllerTests
    {
        [TestMethod]
        public async Task Get_ShouldReturnResponseIndicadorWithAllObj()
        {
            //Arrange:
            ExternalApiContext api = new ExternalApiContext();
            IIndicadorRepository _contextDA = new IndicadorRepository(api);
            IndicadorActions _contextActions = new IndicadorActions(_contextDA);
            IndicadorController pController = new IndicadorController(_contextActions);

            FiltroIndicador param = new FiltroIndicador { TipoIndicador = "" };

            //Act:
            Response<Indicador_Entity> response = await pController.Get(param);

            //CollectionAssert:
            var responseErrorCode = response.CodigoError;
            var responseSystemMsg = response.MensajeSistema;
            var responseHumanMsg = response.MensajeHumano;
            var responseList = response.Contenido;

            Assert.AreEqual("E00", responseErrorCode);
            Assert.AreEqual("Record(s) found", responseSystemMsg);
            Assert.AreEqual("Consulta exitosa!", responseHumanMsg);
            Assert.AreEqual(10, responseList.Count);
        }
    }
}