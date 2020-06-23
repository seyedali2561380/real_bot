using System;
using System.IO;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.InputFiles;
using System.Collections.Generic;
using System.Linq;

namespace real_bot
{
    class Program
    {
        static TelegramBotClient bot;
        static void Main(string[] args)
        {

            bot = new TelegramBotClient("1198338994:AAF-_meJGNM-ELRGrU-FRvbfpTkG2XcVA-M");
            var me = bot.GetMeAsync().Result;
            bot.OnMessage += bot_message;
            bot.StartReceiving();
            System.Threading.Thread.Sleep(int.MaxValue);
            Console.ReadKey();
        }
        public static async void bot_message(object sender, MessageEventArgs e)
        {
            if (e.Message != null)
            {
                var chatid = e.Message.Chat;
                if (e.Message.Text.ToLower() == "/start")
                {

                    Console.WriteLine("bot started by " + e.Message.Chat.Username);

                    StringBuilder sb = new StringBuilder();
                    sb.Append(" سلام ");
                    sb.AppendLine(e.Message.Chat.FirstName);
                    sb.AppendLine("اسم من سید علیه.  خوشحالم که از ربات من استفاده میکنی");
                    await bot.SendTextMessageAsync(chatId: e.Message.Chat, text: sb.ToString());


                }
                if (e.Message.Text.ToLower() == "/photo")
                {

                    string photoPath = "C:\\Users\\USER\\Desktop\\mobiles\\pictures\\note9.jpeg";
                    String url;
                    FileStream fs = System.IO.File.OpenRead(photoPath);

                    InputOnlineFile inp = new InputOnlineFile(fs, "ali");
                    await bot.SendPhotoAsync(e.Message.Chat, inp, "this is galaxy note 9");
                    url = inp.Url;

                }
                if (e.Message.Text.ToLower() == "/gif")
                {
                    string gifPath = "C:\\Users\\USER\\Desktop\\mobiles\\pictures\\Gifybot.gif";
                    FileStream fs = System.IO.File.OpenRead(gifPath);
                    InputOnlineFile inp = new InputOnlineFile(fs, "this is hot gif");
                    await bot.SendVideoAsync(chatid, inp);
                }
                if (e.Message.Text.ToLower() == "/poll")
                {
                    string question = "do you have sex so far??";
                    List<string> options = new List<string> { "yes i have ", "no and i fuck everyone has sex " };
                    bool anonymos = false;
                    await bot.SendPollAsync(chatid, question, options, isAnonymous: anonymos);
                }


                Console.WriteLine("message from " + e.Message.Chat.Username);
                Console.WriteLine("the message is: " + e.Message.Text);
                await bot.SendTextMessageAsync(
                chatId: e.Message.Chat,
  text: "your username " + "@" + e.Message.Chat.Username + "You said:\n" + e.Message.Text


);

            }
        }
    }
}
