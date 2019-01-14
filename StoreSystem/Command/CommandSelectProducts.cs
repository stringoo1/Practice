using System;
using System.Collections.Generic;
using System.Linq;
using StoreSystem.Entity;
using StoreSystem.Database;
using System.Text;


namespace StoreSystem.Command
{
    // 在庫が存在する製品情報を表示する
    public class CommandSelectProducts : CommandBase
    {
        // コマンド名
        public static readonly string Name = "SelectProducts";

        // 引数解析処理
        public override void ParseArguments(string[] args)
        {
            // 何もしない
            Console.WriteLine(string.Join(", ", args));
        }

        // コマンド処理
        public override void Execute(StoreSystemState state)
        {
            // 全商品を取得する
            List<Product> products;
            using (var accessor = new ProductAccessor())
            {
                products = accessor.SelectProducts();
            }
            
            // 在庫が存在する情報を取得する
            List<Stock> stocksInStock;
            using (var accessor = new StockAccessor())
            {
                stocksInStock = accessor.SelectStocks().Where(elm => elm.Quantity >= 1).ToList();
            }

            var results = from P in products
                         join S in stocksInStock
                         on P.ID equals S.ProductId
                         orderby P.ID ascending
                         select new
                         {
                             ID = P.ID,
                             Name = P.Name,
                             Volume = P.Volume,
                             Price = P.Price,
                             Quantity = S.Quantity,
                         };

            // ヘッダを表示する
            List<string> colNames = new List<string> {
                "製品名称", "製品内容量(ml)", "販売価格(円)", "在庫数" };
            Console.WriteLine(string.Join("|", colNames));

            List<int> colByteLength = 
                colNames.Select(
                    elm => Encoding.GetEncoding("Shift_JIS").GetByteCount(elm)
                ).ToList();

            List<int> colLength = colNames.Select(elm => elm.Length).ToList();

            // 内容を表示する
            results.ToList().ForEach(elm => Console.WriteLine($"{elm.Name}|{elm.Volume}|{elm.Price}|{elm.Quantity}"));




        }
    }
}
