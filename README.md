
# CliApp

This a demo cli console application used to execute CRUD commands in a terminal.The application is composed of 3 projects.
|    Name        |Technology                 |Purpose                                               |
|----------------|---------------------------|------------------------------------------------------|
|CliApp.Command  |`.NET Core 3.1`            | Console Application                                  |
|CliApp.Tests    |`.NET Core 3.1`            | Unit Test project                                    |
|CliApp.Core     |`.NET Core 3.1`            | DAL project using EF Core                            |

# Bootstrap the application

- After cloning the repository set **CliApp.Command** as startup project .To restore packages run the command **dotnet restore** for each project.
> Make sure that you have .NET Core 3.1 installed otherwise install it from [Here](https://dotnet.microsoft.com/download/dotnet-core/3.1)
- In the **CliApp.Core** project run the command **dotnet ef update databse** in order to apply the Migrations  
- In the **CliApp.Tests** directory to test the project run the command **dotnet test** or simple run the tests in the Visual Studio Test Explorer.
- Build the **CLiApp.Core**, then go to the bin folder all the way to the generated dll's EX: `CliApp.Command\bin\Debug\netcoreapp3.1` and see if a **persons.dll** has been generated. To test the CLI run the command(in the folder containing all the dll's) **dotnet persons.dll --help** to get the list of all commands.

## Functionality
get all commands
```sh
$ dotnet persons.dll --help
```
get all persons
```sh
$ dotnet persons.dll list
```
add person
```sh
$ dotnet persons.dll add -f 'firstname' -l 'lastname'
```
delete person
```sh
$ dotnet persons.dll delete -i 'PersonId'
```
count persons
```sh
$ dotnet persons.dll count
```
edit person
```sh
$ dotnet persons.dll edit -i 'personId' -f 'firstname' -l 'lastname'
```
add address
```sh
$ dotnet persons.dll add -i 'personId '--street 'street' --city 'city' --state 'state' --postalcode 'postalcode'
```
delete address
```sh
$ dotnet persons.dll delete_addr -i 'addressId'
```
modify address
```sh
$ dotnet persons.dll edit_addr -i 'addressId ' --street 'street' --city 'city' --state 'state' --postalcode 'postalcode'
``` 
list addresses
```sh
$ dotnet persons.dll list_addr
```



## 3rd Party Frameworks Used

- **XUnit** for Unit testing
- **Entity Framework Core InMemoryDb** to use as a mock database
-  **Entity Framework Core Code First** as a data provider
- **CommandDotNet** for creating cli commands [CommandDotNet](https://github.com/bilal-fazlani/commanddotnet)
