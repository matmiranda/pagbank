using Moq;
using PagBank;
using RestSharp;
using System.Net;

namespace PagBankTest
{
    public class Tests
    {
        [Test]
        public async Task MockCriarPedido()
        {
            // Crie objeto 
            var body = new
            {
                customer = new
                {
                    tax_id = "62046100077",
                    email = "teste@teste.com.br",
                    name = "Jo�o Silva"
                },
                reference_id = "1234"
            };

            // Crie um mock do IRestClientWrapper
            var mockRestClient = new Mock<IRestClient>();

            // Configure o comportamento do mock para o m�todo ExecuteAsync
            var pagBankRequest = new PagBankRequest<object>
            {
                // Defina os valores necess�rios para o PagBankRequest
                Body = body,
                Method = PagBank.Method.Post,
                Endpoint = "orders"
            };

            // Defina o valor de retorno que voc� deseja para o m�todo ExecuteAsync
            var restResponse = new RestResponse
            {
                StatusCode = HttpStatusCode.Created,
                Content = "criado com sucesso"
            };

            // Configura o mock para retornar 'restResponse' quando o m�todo 'ExecuteAsync' for chamado
            mockRestClient
                .Setup(x => x.ExecuteAsync(It.IsAny<RestRequest>(), default))
                .ReturnsAsync(restResponse);

            var config = new PagBankConfig 
            {
              BaseUrl = BaseUrl.Sandbox,
              Token = "123",
              RestClient = mockRestClient.Object
            };

            // Create the PagBankClient using the mocked IRestClient
            var pagBankClient = new PagBankClient(config);

            // Chame o m�todo que utiliza o m�todo ExecuteAsync
            var response = await pagBankClient.ExecuteAsync(pagBankRequest);

            // Verifique o resultado
            Assert.That(restResponse, Is.EqualTo(response));
        }
    }
}