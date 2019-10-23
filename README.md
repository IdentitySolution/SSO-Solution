# SSO-Solution - A (nearly) production ready Single-Sign-On Solution

SSO-Solution is a (nearly) production ready cross platform, open source, single-sign-on solution built with .net core 3.0, IdentityServer4, and PostGreSql.

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

It's easy to get started developing your own solution.

1. Download and install [.net core 3.0](https://dotnet.microsoft.com/download/dotnet-core/3.0)
2. Open up a cmd or terminal and navigate to where you want to create a new solution
3. Install the template by running `dotnet new -install sso-sln`
4. Create a new solution using the installed template by running `dotnet new sso-sln`
   - add `-d samplewebsite.com` to specify the domain name (defaults to `website.com`)
   - **Do Not** use the `--output` arg for dotnet new, the post-install scripts will not be run and you will have to run them manually. Instead create a folder with the solution's name and run the command from there.

## Notes

- your hosts file is modified by adding the projects' urls. This isn't entirely necessary, but if you're developing multiple clients simultaneously, it is recommended to avoid conflicts in your browser's cookies.

## Deploying to Production

[Work in progress](https://github.com/IdentitySolution/SSO-Solution/projects/3)
