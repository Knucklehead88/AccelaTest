
using CommandDotNet;


namespace CliApp.Command.ArgumentModels
{
    public class AddressIdArgs: IArgumentModel
    {
        [Option(ShortName = "i")]
        public int AddressId { get; set; }
    }
}
