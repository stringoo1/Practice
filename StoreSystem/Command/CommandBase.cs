using StoreSystem;

namespace StoreSystem.Command
{
    // 各種コマンドの基底クラス
    public abstract class CommandBase
    {
        public abstract void ParseArguments(string[] args);
        public abstract void Execute(StoreSystemState state);
    }
}
