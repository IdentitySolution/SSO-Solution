# SSO-Solution - A (nearly) production ready Single-Sign-On Solution

SSO-Solution is a (nearly) production ready cross platform, open source, single-sign-on solution built with .net core 3.0, IdentityServer4, and PostGreSql.

## Supported OS for Development

| OS      | Supported          |
| ------- | ------------------ |
| Windows | :heavy_check_mark: |
| Linux   | :x: coming soon    |
| MacOs   | :x: coming soon    |

## Tools & Services

The following default tools and services are used, but they can be changed depending on your individual needs.

| Service        | Tool                         |
| -------------- | ---------------------------- |
| Identity       | Microsot.AspNetCore.Identity |
| OIDC/OAuth 2.0 | IdentityServer4              |
| Database       | PostGreSql                   |
| Logging        | Serilog                      |
| Email          | TBD                          |

## Getting Started

### Windows

It's easy to get started developing your own solution.

#### Install

1. Download and install [.net core 3.0](https://dotnet.microsoft.com/download/dotnet-core/3.0)
2. Install openssl. Here's a [guide](https://tecadmin.net/install-openssl-on-windows/)
3. Install [PostGreSql](https://www.postgresql.org/download/windows/)
4. Open up a cmd or terminal and navigate to where you want to create a new solution
5. Install the template by running `dotnet new -install sso-sln`

#### Create New Solution

Create a new solution using the installed template by running `dotnet new sso-sln`

- add `-d samplewebsite.com` to specify the domain name (defaults to `website.com`)
- **Do Not** use the `--output` arg for dotnet new, the post-install scripts will not be run and you will have to run them manually. Instead create a folder with the solution's name and run the command from there.
- (Optional) add `--allow-scripts yes` to run the post install scripts without being prompted

#### Initialize Database

1. Navigate to the folder containing the `.csproj` file for the Identity Server
2. Update the connecstion string in `appsettings.Development.json`
3. Run `dotnet run --seed`

**Notes**

- To clean the database run `dotnet run --clean`
- To clean and reseed the database run `dotnet run --clean --seed`
- To **only** migrate the database and not run the project add the `--dont-run` arg

#### Running the Identity Server

To run the identity server navigate to the project and run `dotnet run`

#### Running the Samples

There are dotnet samples and a node samples which are preconfigured to run with your newly created identity server. Go to their respective folders and run them according to their tooling.

### Linux

Coming soon...

### MacOs

Coming soon...

## Notes

### Post Install Actions

The template includes the following 2 scripts that are run after installation:

1. CallAddHosts (Requires admin privileges ) - Updates your hosts file to add the applications url (`website.com` by default) to point to `127.0.0.1`.
2. CallCreateSSLCertificate (Requires admin privileges ) - Creates and installs a self-signed SSL Certificate to your machine and the newly created solution.

By default you are prompted to run the scripts, or you can add `--allow-scripts yes` to `dotnet new sso-sln`.

## Deploying to Production

[Work in progress](https://github.com/IdentitySolution/SSO-Solution/projects/3)
