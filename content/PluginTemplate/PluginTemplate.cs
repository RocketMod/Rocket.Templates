using System;
using System.Globalization;
using System.Threading.Tasks;
#if Commands
using MyRocketPlugin.Commands;
#endif
#if Configuration
using MyRocketPlugin.Configuration;
#endif
using Rocket.API.DependencyInjection;
using Rocket.API.User;
using Rocket.Core.Logging;
using Rocket.Core.Plugins;

namespace MyRocketPlugin
{
#if GenerateConfiguration
    public class MyRocketPlugin : Plugin<MyPluginConfiguration>
#else
    public class MyRocketPlugin : Plugin
#endif
    {
#if GenerateCommands
        private readonly IUserManager _userManager;

        public MyRocketPlugin(IDependencyContainer container, IUserManager userManager) : base("PLUGIN-NAME", container)
        {
            _userManager = userManager;
        }
#else
        public MyRocketPlugin(IDependencyContainer container) : base("PLUGIN-NAME", container)
        {
        }
#endif

        protected override async Task OnActivate(bool isFromReload)
        {
            Logger.LogInformation("Hello World!");

#if GenerateCommands
            var commandsCollection = new CommandsCollection(_userManager);
            RegisterCommands(commandsCollection);
#endif

#if GenerateConfiguration
            var config = ConfigurationInstance;
            Logger.LogInformation("Last start time: " + (config.LastStartTime == null ? "None (first start)" : config.LastStartTime.Value.ToString(CultureInfo.CurrentCulture)));

            // do something with config

            config.LastStartTime = DateTime.UtcNow;
            await SaveConfigurationAsync();
#endif
        }

        protected override async Task OnDeactivate()
        {
            Logger.LogInformation("Good bye :(");
        }
    }
}
