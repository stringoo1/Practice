using System;
using System.Collections.Generic;
using System.Linq;
using StoreSystem.Entity;
using StoreSystem.Database;


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
            List<Product> products;
            using (var accessor = new ProductAccessor())
            {
                products = accessor.SelectProducts();
            }

            products.ForEach(elm => Console.WriteLine($"{elm.ID}, {elm.Name}, {elm.Price}, "));
        }
    }
}
