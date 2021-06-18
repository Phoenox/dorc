# <img src="https://raw.githubusercontent.com/Phoenox/dorc/main/resources/logo.png" height="50"> D'Orc


# How To Add New Modules And CI Tests

At the time of writing, the `dotnet` command does not support passing patterns like `dotnet test modules/*`. So we need to create a "parent test solution" and add new test projects to that solution.

For creating a new module `foo` with corresponding tests:
  1. create new dir in modules: `modules/foo`
  2. create new project inside `modules/foo`: `dotnet new project -lang F#`
  3. create test dir: `modules/foo/test`
  4. create test project inside `modules/foo/test`: `dotnet new nunit -lang "F#"`
  5. add reference to the corresponding module project: `dotnet add reference ../foo.csproj`

For adding the tests to the module test solution (necessary for CI to execute them):
  6. cd to `modules` and add reference from the solution to the new test module: `dotnet sln add reference foo/test/tests.csproj`
