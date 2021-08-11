using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_TCO.Models;

namespace Web_TCO
{
    public static class DataBase
    {
        public async static Task Input (Bid bid)
        {
            using (SqlConnection connection = new SqlConnection(@"Data Source=YRAFRO\SQLEXPRESS;Initial Catalog=zayavkiSQL;Integrated Security=True"))
            {
                await connection.OpenAsync();

                SqlCommand sqlCommand = new SqlCommand($@"insert into za_reborn (Дата, Аудитория, Установили, Время_установки, Забрали, Время_окончания, Оборудование, Фамилия_преподавателя)
values ('{bid.Date.ToString("yyyy/MM/dd").Replace("/", "")}', '{bid.Aud}', '{bid.Put.ToString()}', '{bid.Date_Put}', '{bid.Take.ToString()}', '{bid.Date_Take}', '{bid.Obor}', '{bid.Prepod}')", connection);

                int reader = await sqlCommand.ExecuteNonQueryAsync();
            }
        }

        public async static Task<List<Bid>> Out(string date)
        {
            if (String.IsNullOrEmpty(date))
                date = DateTime.Now.ToString("yyyy/MM/dd").Replace("/", "");

            var bids = new List<Bid>();
            using (SqlConnection connection = new SqlConnection(@"Data Source=YRAFRO\SQLEXPRESS;Initial Catalog=zayavkiSQL;Integrated Security=True"))
            {
                await connection.OpenAsync();

                SqlCommand sqlCommand = new SqlCommand($@"select za_reborn.Дата, za_reborn.Аудитория, za_reborn.Время_установки, za_reborn.Время_окончания, za_reborn.Установили, za_reborn.Забрали, za_reborn.Оборудование, za_reborn.Фамилия_преподавателя
from za_reborn
where Дата = '{date}'
ORDER BY Дата DESC, Время_Установки ASC", connection);

                SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

                if (reader.HasRows)
                {
                    while (await reader.ReadAsync())
                    {
                        bids.Add(new Bid() { 
                            Date = (DateTime)reader.GetValue(0), 
                            Aud = (String)reader.GetValue(1),
                            Date_Put = (String)reader.GetValue(2),
                            Date_Take = (String)reader.GetValue(3),
                            Put = (bool)reader.GetValue(4),
                            Take = (bool)reader.GetValue(5),
                            Obor = (String)reader.GetValue(6),
                            Prepod = (String)reader.GetValue(7)
                        });
                    }
                }

                
            }

            return bids;
        }
    }
}
