using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Shared.Database;
using System.Linq;
using System.Linq.Expressions;

public class AutoMapperExtensionsTests(DatabaseContext context, IMapper mapper)
{
    [Fact]
    public async Task TEST()
    {
        //ICollection<Payment> requests = await context.Vsd_PaymentSet.GetItemsAsync(mapper, r => r.Id > 0 && r.Id < 3, null);
        //ICollection<Payment> users = await context.Vsd_PaymentSet.GetItemsAsync<Payment, Vsd_Payment>(mapper, u => u.Date < DateTime.Now);//, q => q.OrderBy(u => u.Name));
        ICollection<Country> users = await context.Vsd_CountrySet.GetItemsAsync<Country, Vsd_Country>(mapper, u => u.Name != "Canada");//, q => q.OrderBy(u => u.Name));
        //int count = await context.Request.Query<RequestDTO, Request, int, int>(mapper, q => q.Count(r => r.Id > 1));
        Assert.NotNull(users);
    }
}
