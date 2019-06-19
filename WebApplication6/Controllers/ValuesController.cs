using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace WebApplication6.Controllers
{
	[Route("api/[controller]")]
	public class ValuesController : Controller
	{
		// GET api/values
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			var name = "";
			if (id == 1)
				CreateItemTable();

			if (id == 2)
				InsertItem();

			if (id == 3)
				name = GetItem();

			if (id == 4)
				name = "test";

			return "value " + id + ", name " + name;
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}

		private MySqlConnection GetConnection()
		{
			var connectionString = "Server=172.17.0.15;Port=3306;Database=sampledb;Uid=userFF2;Pwd=e7g0ERWRI0w8kntQ;charset=utf8;";

			return new MySqlConnection(connectionString);
		}

		public void CreateItemTable()
		{
			using (var conn = GetConnection())
			{
				conn.Open();
				var cmd = new MySqlCommand("CREATE TABLE test (`Name` varchar(100))", conn);
				cmd.ExecuteNonQuery();

			}
		}

		public void InsertItem()
		{
			using (var conn = GetConnection())
			{
				conn.Open();
				var cmd = new MySqlCommand("INSERT INTO test (`Name`) VALUES ('Test Name')", conn);
				cmd.ExecuteNonQuery();

			}
		}

		public string GetItem()
		{
			using (var conn = GetConnection())
			{
				conn.Open();
				var cmd = new MySqlCommand("SELECT * FROM test", conn);
				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						var name = reader.GetString("Name");

					}
				}
			}

			return "";
		}
	}
}
