using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSystem.Command
{
    // コマンドを変換する処理
    public class CommandParser
    {
        // 入力されたコマンド・引数を分解する
        public CommandBase Parse(string inputCommand)
        {
            var splitted = inputCommand.Split(' ');
            var commandName = splitted[0];
            var command = this.CreateInstance(commandName);
            if (splitted.Length >= 2)
            {
                var args = splitted.Skip(1).ToArray();
                command.ParseArguments(args);
            }

            return command;
        }

        // コマンドのインスタンスを作成する
        private CommandBase CreateInstance(string commandName)
        {
            if (string.Compare(commandName, CommandSelectProducts.Name, ignoreCase:true) == 0)
            {
                return new CommandSelectProducts();
            }
            else
            {
                // tmp
                return new CommandSelectProducts();
            }
            throw new ArgumentException("");
        }

    }
}
