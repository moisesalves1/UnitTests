using Store.Domain.Entities;
using Store.Domain.Enums;

namespace Store.Tests.Domain
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        [TestCategory("Domain")]
        public void Dado_um_novo_pedido_valido_ele_deve_gerar_um_numero_com_8_caracteres()
        {
            var cliente = new Customer("Moises", "moisesalves1@gmail.com");

            // My try

            /* var taxaEntrega = 9.90M;
            var desconto = new Discount(4.90M, DateTime.Now.AddDays(3));

            var novoPedido = new Order(cliente, taxaEntrega, desconto);
            var numeroPedido = novoPedido.Number.Length;

            Assert.AreEqual(8, numeroPedido);
            */

            // Balta's

            var order = new Order(cliente, 0, null);
            Assert.AreEqual(8, order.Number.Length);
        }
    }
}