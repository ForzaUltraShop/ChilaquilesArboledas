using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodApp.BusinessLayer
{
    using FoodApp.DataModels;
    using FoodApp.Models;
    using FoodApp.Models.Shared;
    using Telegram.Bot;
    using System.Configuration;

    public class NotifyLogic
    {
        TelegramBotClient Bot = new TelegramBotClient(ConfigurationManager.AppSettings["TelegramBotId"].ToString());

        public void NotifyExecute(NotifyDTO notify)
        {
            switch (notify.Type)
            {
                case NotifyType.Telegram:
                    sendTelegramMessage(notify.Message, notify.Location);
                    break;
            }
        }

        private void sendTelegramMessage(string message, LocationDTO location)
        {
            Bot.SendTextMessageAsync
            (
                chatId: ConfigurationManager.AppSettings["TelegramChatId"].ToString(),
                text: message,
                replyMarkup: null
            );

            if(location != null)
            {
                Bot.SendLocationAsync
                (
                  chatId: ConfigurationManager.AppSettings["TelegramChatId"].ToString(),
                  latitude: float.Parse(location.Latitude),
                  longitude: float.Parse(location.Longitude)
                );
            }
        }
    }
}
