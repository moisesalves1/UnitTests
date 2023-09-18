using Store.Domain.Entities;
using Store.Domain.Repositories.Interfaces;

namespace Store.Tests.Repositories;

public class FakeDeliveryRepository : IDeliveryFeeRepository
{
    public decimal Get(string zipCode)
    {
        return 10;
    }
}