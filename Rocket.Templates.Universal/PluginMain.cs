using System.Collections.Generic;
using Rocket.API.DependencyInjection;
using Rocket.API.Logging;
using Rocket.Core.Plugins;

namespace $safeprojectname$
{
    public class $safeprojectname$Main : PluginBase
    {
        private readonly ILogger _logger;

        public PluginMain(IDependencyContainer container, ILogger logger) : base(container)
        {
            _logger = logger;
        }

        public override void Load()
        {
            _logger.Info("Hello world!");
        }

        public override void Unload()
        {

        }

        public override IEnumerable<string> Capabilities => new List<string>();

        public override string Name => "$safeprojectname$";
    }
}
