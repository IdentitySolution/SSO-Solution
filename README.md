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

1. Download and install [.net core 3.0](https://dotnet.microsoft.com/download/dotnet-core/3.0)
2. Install openssl. Here's a [guide](https://tecadmin.net/install-openssl-on-windows/)
3. Open up a cmd or terminal and navigate to where you want to create a new solution
4. Install the template by running `dotnet new -install sso-sln`
5. Create a new solution using the installed template by running `dotnet new sso-sln`
   - add `-d samplewebsite.com` to specify the domain name (defaults to `website.com`)
   - **Do Not** use the `--output` arg for dotnet new, the post-install scripts will not be run and you will have to run them manually. Instead create a folder with the solution's name and run the command from there.

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
