using YoutubeExplode.Converter;
using YouTubeDownloader;
using YoutubeExplode;

namespace Module18
{
    /// <summary>
    /// Реализация команды по скачиванию видео
    /// </summary>
    class Download : Command
    {
        Receiver receiver;

        public Download(Receiver receiver)
        {
            this.receiver = receiver;
        }

        // Выполнить
        public override async void Run(string url, string path)
        {
            Console.WriteLine("Начинаю скачивать.");
            receiver.Operation();

            var youtube = new YoutubeClient();

            try
            {
                var video = await youtube.Videos.GetAsync(url);
                await youtube.Videos.DownloadAsync(url, $"{path}/{video.Title}.avi", builder => builder.SetPreset(ConversionPreset.UltraFast));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Проблема: \n{0}.", ex.Message);
            }
            finally
            {
                Console.WriteLine("СКАЧИВАНИЕ ЗАВЕРШЕНО.");
            }
        }
    }
}
