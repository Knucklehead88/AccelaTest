using CommandDotNet;


namespace CliApp.Command.ArgumentModels
{
    public class PersonIdArgs: IArgumentModel
    {
        [Option(ShortName = "i")]
        public int PersonId { get; set; }
    }
}
