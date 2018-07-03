using Discord;
using Discord.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master_Ferret.Modules
{
    public class rng: ModuleBase<SocketCommandContext>
    {
        private static readonly Random gen = new Random();
        private static readonly Random color = new Random();
        [Command("rng")]
        public async Task rngAsync(int one, int two)
        {
            int result = gen.Next(GetMin(one, two), GetMax(one, two));
            if (one == two)
            {
                await Context.Channel.SendMessageAsync("The two numbers are equal.");
            }
            else
            {
                var embed = new EmbedBuilder();
                embed.WithTitle(Context.User.Username + " rolled between " + one + " " + two);
                embed.WithDescription("The result is " + result.ToString());
                embed.WithColor(new Color(color.Next(0, 255), color.Next(0, 255), color.Next(0, 255)));
                await Context.Channel.SendMessageAsync("", false, embed);
            }
        }
        public static int GetMax(int first, int second)
        {
            return first > second ? first : second;
        }
        public static int GetMin(int first, int second)
        {
            return first < second ? first : second;
        }
    }
}
