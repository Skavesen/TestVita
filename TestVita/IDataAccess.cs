using System.Collections.Generic;

namespace TestVita
{
    public interface IDataAccess
    {
        List<Income> GetIncomes();

        List<Order> GetOrders();

        List<Payment> GetPayments();

        void BindIncomeAndOrder(int incomeId, int orderId, decimal bindingAmount, string orderVersion, string incomeVersion);
    }
}
