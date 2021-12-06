# Core Infrastructure Group Regression Test Repository

This repository holds of the CIG's main projects regression testing automated test cases, including:

## Web Applications
* FMS Web Portal
* Customer Portal
* InTouch Alerts Portal

The results of the automated tests will be stored in TestRail in the CIG Dashboard

### Getting Started

#### Prerequisites

- Make sure to have [.NET Core SDK 3.1](https://dotnet.microsoft.com/download/dotnet-core) installed.
- Make sure you have the browsers in which you want to run the tests.

#### Installing

1. Clone the cig-automated-tests repository by issuing the command:
```sh
    $ git clone https://github.com/IntouchHealth/cig-automated-tests.git
```
2. Navigate to the `./cig-automated-tests/config` folder and make a copy of the `ConnectionStrings.json.example`, `Secrets.json.example`, and `SmtpSettings.json.example` files.
3. Rename the files to `ConnectionStrings.json`, `Secrets.json`, and `SmtpSettings.json` by removing the `.example` file extension.
4. Modify these config files to include valid connection string. Make sure to have a user with enough privileges to `SELECT` permissions on the `FMS2` database.
5. Navigate to the `./cig-automated-tests/src/Common` folder and make a copy of the `TokenSecrets.json.example` file.
6. Rename the file to `TokenSecrets.json` by removing the `.example` file extension.
7. Modify the Environment files (Development, Integration and/or Staging) to set:
    - Headless Mode functionality, the variable *HeadlessMode* is set to `true` by default. You can change the variable to `false` to see the webDriver working. IE does not have support for a headless mode.
    - Choose the Browser in which the tests will be run, setting the *DriverType* variable, the available browsers are: Chrome, Edge, and Firefox. IE and Safari browsers can also be used for the Customer Portal software. (Safari only supported on macOS).

#### Usage

1. Launch a Web Application from Visual Studio, making sure to select the desired Solution:
2. You can run the tests from the Test Explorer sale.
3. Alternatively, you can open your favorite Terminal, navigate to one of the solution folders, for example `./cig-automated-tests/src/FMS Web Portal`, and run these commands:
```sh
        dotnet test --configuration Integration --verbosity:d
```

Or for a specific test you can use:
```sh
        dotnet test --configuration Integration --verbosity:d --filter DisplayName="History"
```
- You can check the [dotnet test](https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-test).
4. Another option is to run all browsers with a script like the following:
```sh
        SET DriverType=Firefox
        dotnet test --configuration Integration --verbosity:d
        SET DriverType=Chrome
        dotnet test --configuration Integration --verbosity:d
        SET DriverType=Edge
        dotnet test --configuration Integration --verbosity:d
```
    - This script is build to be run in Jenkins.
