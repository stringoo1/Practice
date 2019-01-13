using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreSystem.Command
{
    public class CommandExitSystem : CommandBase
    {
        public static readonly string Name = "ExitSystem";

        public override void Execute(StoreSystemState state)
        {
            // 状態を終了ステータスにする
            state.ExitSystem();
        }

        public override void ParseArguments(string[] args)
        {
            // 無視する
        }
    }
}
