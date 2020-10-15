using System.Data.SqlClient;

namespace DataController
{
    class DataControl
    {
        const string WRITE_CMD = "INSERT INTO NABA.dbo.Person ([FirstName], [LastName]) VALUES (@firstName, @lastName)";
        const string DELETE_CMD = "DELETE FROM NABA.dbo.Person";
        SqlConnection connectionString = new SqlConnection(@"Data Source = DESKTOP-GQR2API;Initial Catalog = NABA;Trusted_Connection = true");

        public void ToDatabase(string fName, string lName)
        {
            using SqlCommand cmd = new SqlCommand(WRITE_CMD, connectionString);

            connectionString.Open();

            cmd.Parameters.Add("@firstName", System.Data.SqlDbType.NChar).Value = fName;

            cmd.Parameters.Add("@lastName", System.Data.SqlDbType.NChar).Value = lName;

            cmd.ExecuteNonQuery();
            connectionString.Close();
        }
        public void DeleteData()
        {
            connectionString.Open();
            SqlCommand cmd = new SqlCommand(DELETE_CMD, connectionString);
            cmd.ExecuteNonQuery();
            connectionString.Close();
        }
    }
}
