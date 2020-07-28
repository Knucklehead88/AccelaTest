using System;
using CommandDotNet.Rendering;
using System.Collections.Generic;
using CommandDotNet;

namespace CliApp.Tests
{
    public class App
    {
        public void List(IConsole console, List<string> args) =>
            console.WriteLine(string.Join(Environment.NewLine, args));
    }
}
