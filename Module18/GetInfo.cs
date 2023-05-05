using YoutubeExplode;

namespace Module18
{
    /// <summary>
    /// Реализация команды по получению информации о видео
    /// </summary>
    class GetInfo : Command
    {
        Receiver receiver;

        public GetInfo(Receiver receiver)
        {
            this.receiver = receiver;
        }

        // Выполнить
        public override async void Run(string url, string path)
        {
            Console.WriteLine("Информация о видео запрошена.");
            receiver.Operation();

            var youtube = new YoutubeClient();

            try
            {
                var video = await youtube.Videos.GetAsync(url);

                Console.WriteLine("Видео называется: \n{0}.", video.Title);
                Console.WriteLine();
                Console.WriteLine("Описание видео: \n{0}.", video.Description);
                Console.WriteLine();
                Console.WriteLine("Автор видео: \n{0}.", video.Author);
                Console.WriteLine();
                Console.WriteLine("Продолжительность видео: \n{0}.", video.Duration);
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Проблема: \n{0}.", ex.Message);
            }
            finally
            {
                Console.WriteLine("ИНФОРМАЦИЯ О ВИДЕО ВЫВЕДЕНА В КОНСОЛЬ.");
            }
        }
    }
}
