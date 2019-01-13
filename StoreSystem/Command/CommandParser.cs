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
            if (IsEqualCommandName(commandName, CommandSelectProducts.Name))
            {
                return new CommandSelectProducts();
            }
            else if (IsEqualCommandName(commandName, CommandExitSystem.Name))
            {
                return new CommandExitSystem();
            }
            throw new ArgumentException("");
        }

        // 大文字小文字区別なく文字列を比較する
        private bool IsEqualCommandName(string inputString, string commandName)
        {
            return string.Compare(inputString, commandName, ignoreCase: true) == 0;
        }

    }
}
