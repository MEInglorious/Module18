
namespace Module18
{
    /// <summary>
    /// Отправитель команды
    /// </summary>
    class Sender
    {
        Command _command;

        public void SetCommand(Command command)
        {
            _command = command;
        }

        // Выполнить
        public void Run(string url, string path)
        {
            _command.Run(url, path);
        }
    }
}
