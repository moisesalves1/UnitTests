using Store.Domain.Repositories.Interfaces;
using Store.Tests.Repositories;

namespace Store.Tests.Handlers;

[TestClass]
public class OrderHandlerTests
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IDeliveryFeeRepository _deliveryRepository;
    private readonly IDiscountRepository _discountRepository;
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;

    public OrderHandlerTests()
    {
        _customerRepository = new FakeCustomerRepository();
        _deliveryRepository = new FakeDeliveryRepository();
        _discountRepository = new FakeDiscountRepository();
        _productRepository = new FakeProductRepository();
        _orderRepository = new FakeOrderRepository();
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void Dado_um_cliente_inexistente_o_pedido_nao_deve_ser_gerado()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void Dado_um_cep_invalido_o_pedido_deve_ser_gerado_normalmente()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void Dado_um_promocode_inexistente_o_pedido_deve_ser_gerado_normalmente()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void Dado_um_pedido_sem_items_o_mesmo_nao_deve_ser_gerado()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void Dado_um_comando_invalido_o_pedido_nao_deve_ser_gerado()
    {
        Assert.Fail();
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void Dado_um_comando_valido_o_pedido_deve_ser_gerado()
    {
        Assert.Fail();
    }
}