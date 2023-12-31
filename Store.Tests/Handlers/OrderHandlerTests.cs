using Store.Domain.Commands;
using Store.Domain.Handlers;
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
        var command = new CreateOrderCommand();
        command.Customer = "11111111111";
        command.ZipCode = "71020030";
        command.PromoCode = "11223344";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        
        var handler = new OrderHandler(_customerRepository, _deliveryRepository, _discountRepository, _productRepository, _orderRepository);
        handler.Handle(command);

        Assert.AreEqual(handler.Valid, false);
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void Dado_um_cep_invalido_o_pedido_nao_deve_ser_gerado()
    {
        var command = new CreateOrderCommand();
        command.Customer = "12345678911";
        command.ZipCode = "";
        command.PromoCode = "12345678";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        
        var handler = new OrderHandler(_customerRepository, _deliveryRepository, _discountRepository, _productRepository, _orderRepository);
        handler.Handle(command);

        Assert.AreEqual(handler.Valid, false);
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void Dado_um_promocode_inexistente_o_pedido_deve_ser_gerado_normalmente()
    {
        var command = new CreateOrderCommand();
        command.Customer = "12345678911";
        command.ZipCode = "71020030";
        command.PromoCode = "11223344";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        
        var handler = new OrderHandler(_customerRepository, _deliveryRepository, _discountRepository, _productRepository, _orderRepository);
        handler.Handle(command);

        Assert.AreEqual(handler.Valid, true);
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void Dado_um_pedido_sem_items_o_mesmo_nao_deve_ser_gerado()
    {
        var command = new CreateOrderCommand();
        command.Customer = "12345678911";
        command.ZipCode = "71020030";
        command.PromoCode = "12345678";
        
        var handler = new OrderHandler(_customerRepository, _deliveryRepository, _discountRepository, _productRepository, _orderRepository);
        handler.Handle(command);

        Assert.AreEqual(handler.Valid, false);
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void Dado_um_comand_invalido_o_pedido_nao_deve_ser_gerado()
    {
        var command = new CreateOrderCommand();
        command.Customer = "";
        command.ZipCode = "71020030";
        command.PromoCode = "12345678";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));

        var handler = new OrderHandler(_customerRepository, _deliveryRepository, _discountRepository, _productRepository, _orderRepository);
        handler.Handle(command);

        Assert.AreEqual(handler.Valid, false);
    }

    [TestMethod]
    [TestCategory("Handlers")]
    public void Dado_um_comando_valido_o_pedido_deve_ser_gerado()
    {
        var command = new CreateOrderCommand();
        command.Customer = "12345678911";
        command.ZipCode = "71020030";
        command.PromoCode = "12345678";
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        command.Items.Add(new CreateOrderItemCommand(Guid.NewGuid(), 1));
        
        var handler = new OrderHandler(_customerRepository, _deliveryRepository, _discountRepository, _productRepository, _orderRepository);
        handler.Handle(command);

        Assert.AreEqual(handler.Valid, true);
    }
}