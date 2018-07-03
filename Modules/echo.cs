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
                await Context.Channel.SendMessageAsync(message);
        }
    }
}
