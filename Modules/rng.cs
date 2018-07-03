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
        public async Task rngAsync(int one,int two)
        {
            Random gen = new Random();
            int result = gen.Next(GetMin(one,two), GetMax(one,two));
            if (one == two)
            {
                await Context.Channel.SendMessageAsync("The two numbers are equal.");
            }
            else
            {
                await Context.Channel.SendMessageAsync(result.ToString());
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
