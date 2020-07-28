using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandDotNet;


namespace CliApp.Command.ArgumentModels
{
    public class PersonNameArgs: IArgumentModel
    {
        [Option(ShortName = "f")]
        public string FirstName { get; set; }

        [Option(ShortName = "l")]
        public string LastName { get; set; }

    }
}
