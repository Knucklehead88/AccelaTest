using System;
using System.Collections.Generic;
using System.Text;
using CommandDotNet;

namespace CliApp.Command.ArgumentModels
{
    public class AddressArgs: IArgumentModel
    {
        [Option(LongName = "street")]
        public string Street { get; set; }

        [Option(LongName = "city")]
        public string City { get; set; }

        [Option(LongName = "state")]
        public string State { get; set; }

        [Option(LongName = "postalcode")]
        public string PostalCode { get; set; }
    }
}
