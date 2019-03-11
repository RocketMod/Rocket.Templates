﻿using System.Threading.Tasks;
using Rocket.API.Commands;
using Rocket.API.Entities;
using Rocket.API.Player;
using Rocket.API.User;
using Rocket.Core.Commands;
using Rocket.Core.User;

namespace MyRocketPlugin.Commands
{
    public class CommandsCollection
    {
        private readonly IUserManager userManager;

        public CommandsCollection(IUserManager userManager)
        {
            this.userManager = userManager;
        }

        [Command(Summary = "Kills a player.")] //By default, name is the same as the method name, and it will support all command callers
        public async Task Kill(IUser sender, IPlayer target)
        {
            if (target.IsOnline && target.Entity is ILivingEntity entity)
                await entity.KillAsync(sender);
            else // the game likely does not support killing players (e.g. Eco)
                await sender.SendMessageAsync("Target could not be killed :(");
        }

        [Command(Name = "Broadcast", Summary = "Broadcasts a message.")]
        [CommandAlias("bc")]
        [CommandUser(typeof(IConsole))] // only console can call it
        public async Task Broadcast(IUser sender, string[] args)
        {
            var broadcastMessage = $"{sender.UserName}: {string.Join(" ", args)}";
            await userManager.BroadcastAsync(sender, broadcastMessage);
        }
    }
}