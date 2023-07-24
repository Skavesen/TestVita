using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestVita
{
    public class SqlDataAccess : IDataAccess
    {
        private readonly string connectionString;

        public SqlDataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Income> GetIncomes()
        {
            var incomes = new List<Income>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("sp_GetIncomes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var income = new Income
                            {
                                Id = (int)reader["Id"],
                                Date = (DateTime)reader["Date"],
                                Amount = (decimal)reader["Amount"],
                                Balance = (decimal)reader["Balance"],
                                Version = BitConverter.ToString((byte[])reader["Version"])
                            };

                            incomes.Add(income);
                        }
                    }

                    connection.Close();
                }
            }

            return incomes;
        }

        public List<Order> GetOrders()
        {
            var orders = new List<Order>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("sp_GetOrders", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();
                    
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var order = new Order
                            {
                                Id = (int)reader["Id"],
                                Date = (DateTime)reader["Date"],
                                Amount = (decimal)reader["Amount"],
                                PaymentAmount = (decimal)reader["PaymentAmount"],
                                Version = BitConverter.ToString((byte[])reader["Version"])
                            };

                            orders.Add(order);
                        }
                    }

                    connection.Close();
                }
            }

            return orders;
        }

        public List<Payment> GetPayments()
        {
            var payments = new List<Payment>();

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("sp_GetPayments", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var payment = new Payment
                            {
                                Id = (int)reader["Id"],
                                OrderId = (int)reader["OrderId"],
                                IncomeId = (int)reader["IncomeId"],
                                PaymentAmount = (decimal)reader["PaymentAmount"],
                                Version = BitConverter.ToString((byte[])reader["Version"])
                            };

                            payments.Add(payment);
                        }
                    }

                    connection.Close();
                }
            }

            return payments;
        }

        public void BindIncomeAndOrder(int incomeId, int orderId, decimal bindingAmount, string orderVersion, string incomeVersion)
        { 
            byte[] orderBytes = StringToBytes(orderVersion);
            byte[] incomeBytes = StringToBytes(incomeVersion);
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("sp_InsertPayment", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@IncomeId", incomeId);
                    command.Parameters.AddWithValue("@OrderId", orderId);
                    command.Parameters.AddWithValue("@PaymentAmount", bindingAmount);
                    command.Parameters.AddWithValue("@OrderVersion", orderBytes);
                    command.Parameters.AddWithValue("@IncomeVersion", incomeBytes);

                    connection.Open();

                    try
                    {
                        int result = command.ExecuteNonQuery();

                        if (result == -1)
                        {
                            // Версии не совпадают, повторить попытку с новыми версиями или показать сообщение об ошибке пользователю
                        }
                        else
                        {
                            // Операция успешно выполнена
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ошибка" + ex.ToString());
                    }

                    connection.Close();
                }
            }
        }
        private byte[] StringToBytes(string hexString)
        {
            string[] hexValues = hexString.Split('-');
            byte[] bytes = new byte[hexValues.Length];
            for (int i = 0; i < hexValues.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexValues[i], 16);
            }
            return bytes;
        }
    }
}
