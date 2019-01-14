using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreSystem.Entity;

namespace StoreSystem.Database
{
    public class StockAccessor : AccessorBase
    {
        public List<Stock> SelectStocks()
        {
            string sqlQuery = @"select * from Stock";

            return this.ExecuteReader(
                sqlQuery,
                null,
                reader =>
                {
                    int id = (int)reader.GetFieldValue<int>(reader.GetOrdinal("ProductId"));
                    int quantity = (int)reader.GetFieldValue<int>(reader.GetOrdinal("Quantity"));

                    return new Stock(id, quantity);
                }
                );
        }

    }
}
