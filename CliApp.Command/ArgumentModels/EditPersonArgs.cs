using CommandDotNet;


namespace CliApp.Command.ArgumentModels
{
    public class EditPersonArgs: IArgumentModel
    {
        public PersonIdArgs Person { get; set; }
        public PersonNameArgs PersonName { get; set; }
    }
}
