using System.Data;
using System.Text;
using MySqlConnector;

async void ExecCommand(MySqlConnection connection, string sqlCommand, bool jumpLine = true)
{
    string data = null;
    StringBuilder sb = new StringBuilder();

    var command = new MySqlCommand(sqlCommand, connection);
    using var reader = command.ExecuteReader();
    while (await reader.ReadAsync())
    {
        for (int i = 0; i < reader.FieldCount; i++)
        {
            if (reader.IsDBNull(i))
                continue;

            var typeOfData = reader.GetFieldType(i);

            if (typeOfData.IsEquivalentTo(typeof(int)))
                data = reader.GetInt32(i).ToString();

            if (typeOfData.IsEquivalentTo(typeof(string)))
                data = reader.GetString(i);

            if (typeOfData.IsEquivalentTo(typeof(decimal)))
                data = reader.GetDecimal(i).ToString();

            if (typeOfData.IsEquivalentTo(typeof(DateTime)))
                data = reader.GetDateTime(i).ToString();

            if (typeOfData.IsEquivalentTo(typeof(sbyte)))
                data = reader.GetSByte(i).ToString();

            //Console.WriteLine(data);

            if (jumpLine)
            {
                sb.Append($"{data}");
                if (i < reader.FieldCount - 1) sb.Append(" ; ");
            }
        }
        if (jumpLine)
        {
            sb.Append("\r\n");
            //Console.WriteLine("Next...");
            //Console.WriteLine();
        }
    }

    if (jumpLine)
    {
        var dir = Directory.GetCurrentDirectory().Split("bin")[0];
        var path = $"{dir}\\texto.csv";
        using (var sw = File.CreateText(path))
        {
            sw.Write(sb.ToString());
        }
    }

}



//MYSQL
//dotnet add package MySqlConnector
var connString = "Server=localhost;Port=3306;User ID=admin;Password=123;Database=app_db;";
try
{
    using MySqlConnection connection = new MySqlConnection(connString);
    connection.Open();
    Console.WriteLine("Conexão bem-sucedida!");

    ExecCommand(connection, "SHOW TABLES;", false);
    ExecCommand(connection, "SELECT * FROM babies_AUD;");


    connection.Close();
}
catch (MySqlException ex)
{
    Console.WriteLine($"Erro ao conectar ao MySQL: {ex.Message}");
}

//using Microsoft.Data.SqlClient; //=> SQL SERVER
//dotnet add package Microsoft.Data.SqlClient
//var builder = new SqlConnectionStringBuilder
//{
//    DataSource = "localhost:3306",
//    UserID = "admin",
//    Password = "123",
//    InitialCatalog = "app_db"
//};
//var connString = builder.ConnectionString;

//await using var conn = new SqlConnection(connString);
//await conn.OpenAsync();