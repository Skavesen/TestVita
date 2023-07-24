using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestVita
{
    public partial class Form1 : Form
    {
        private readonly IDataAccess dataAccess;

        private List<Income> incomes;

        private List<Order> orders;

        private List<Payment> payments;


        public Form1(IDataAccess dataAccess)
        {
            InitializeComponent();
            this.dataAccess = dataAccess;

            incomes = dataAccess.GetIncomes();
            orders = dataAccess.GetOrders();
            payments = dataAccess.GetPayments();

            incomeDataGridView.DataSource = incomes;
            orderDataGridView.DataSource = orders;
            paymentDataGridView.DataSource = payments;
        }
        private void bindButton_Click(object sender, EventArgs e)
        {
            var income = incomeDataGridView.CurrentRow.DataBoundItem as Income;
            var order = orderDataGridView.CurrentRow.DataBoundItem as Order;

            if (income != null && order != null)
            {
                var bindingAmountText = bindingAmountTextBox.Text;

                if (decimal.TryParse(bindingAmountText, out decimal bindingAmount))
                {
                    if (bindingAmount > 0 && bindingAmount <= income.Balance && bindingAmount <= order.Amount - order.PaymentAmount)
                    {
                        dataAccess.BindIncomeAndOrder(income.Id, order.Id, bindingAmount, order.Version, income.Version);

                        income.Balance -= bindingAmount;
                        order.PaymentAmount += bindingAmount;

                        incomeDataGridView.Refresh();
                        orderDataGridView.Refresh();
                        paymentDataGridView.Refresh();

                        MessageBox.Show("Приход и заказ были успешно привязаны к сумме " + bindingAmount);
                    }
                    else
                    {
                        MessageBox.Show("Сумма привязки должна быть положительной и не превышать остаток дохода или сумму заказа за вычетом суммы платежа");
                    }
                }
                else
                {
                    MessageBox.Show("Сумма привязки должна быть допустимым десятичным числом");
                }
            }
            else
            {
                MessageBox.Show("Вы должны выбрать доход и заказ, чтобы привязать их");
            }
        }
    }
}