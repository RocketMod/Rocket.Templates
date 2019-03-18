# Rocket.Templates
This repository contains the plugin templates for the [RocketMod](https://github.com/RocketMod/Rocket) .NET Game Server Plugin Framework.

## Getting Started
To get started, first install the templates:
`dotnet new -i "Rocket.Templates::*"`

After installing the template, you can now create a new plugin using the following command:
`dotnet new rocket-plugin`

The full command is like this:

`dotnet new rocket-plugin [--name <ProjectName>] [--FullPluginName <FullPluginName>] [--GenerateConfiguration <true/false>] [--GenerateCommands <true/false>] [--PluginType <Universal/Unturned/Eco>]`

For example, if you want to create an Unturned plugin, you can use the following command:

`dotnet new rocket-plugin --FullPluginName "My Unturned Plugin" --PluginType Unturned`