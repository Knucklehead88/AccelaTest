using CommandDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CliApp.Command.ArgumentModels
{
    public class EditAddressArgs: IArgumentModel
    {
        public AddressIdArgs Address { get; set; }

        public AddressArgs AddressDetails { get; set; }
    }
}
