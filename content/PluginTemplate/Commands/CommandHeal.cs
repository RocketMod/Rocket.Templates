using System.Drawing;
using System.Threading.Tasks;
using Rocket.API.Commands;
using Rocket.API.Entities;
using Rocket.API.Player;
using Rocket.API.User;
using Rocket.Core.User;

namespace MyRocketPlugin.Commands
{
    public class CommandHeal : ICommand
    {
        public bool SupportsUser(IUser user)
        {
            return user is IPlayerUser;
        }

        public async Task ExecuteAsync(ICommandContext context)
        {
            var player = ((IPlayerUser)context.User).Player;

            if (player.Entity is ILivingEntity playerEntity)
            {
                playerEntity.Health = playerEntity.MaxHealth;
                await context.User.SendMessageAsync("You have been healed.", Color.Green);
                return;
            }

            await context.User.SendMessageAsync("You can not heal yourself.", Color.DarkRed);
        }

        public string Name { get; } = "Heal";
        public string[] Aliases { get; } = {"h"};
        public string Summary { get; } = "Heal yourself";
        public string Description { get; }
        public string Syntax { get; }
        public IChildCommand[] ChildCommands { get; }
    }
}