using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master_Ferret.Modules
{
    public class echo : ModuleBase<SocketCommandContext>
    {
        [Command("echo")]
        public async Task echoAsync([Remainder]string message)
        {
            string[] SplitArray = message.Split(new char[] { ' ' },StringSplitOptions.RemoveEmptyEntries);
            List<string> split = SplitArray.ToList();
            if (split[0] == "tts")
            {
                split.RemoveAt(0);
                await Context.Channel.SendMessageAsync(string.Concat(split), true);
            }
            else
            {
                await Context.Channel.SendMessageAsync(message);
            }
            }
    }
}
