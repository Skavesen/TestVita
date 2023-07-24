using System;
using System.Windows.Forms;

namespace TestVita
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string connectionString = "Server=localhost;Database=test;User Id=sa;Password=Admin12345;";
            IDataAccess dataAccess = new SqlDataAccess(connectionString);
            Application.Run(new Form1(dataAccess));
        }
    }
}
