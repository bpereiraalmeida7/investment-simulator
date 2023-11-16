FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 AS build
WORKDIR /app

COPY *.sln .
COPY InvestimentSimulator.WebAPI/*.csproj ./webapi/
COPY webapi/*.config ./webapi/
RUN nuget restore

COPY InvestimentSimulator.WebAPI/. ./webapi/
WORKDIR /app/webapi
RUN msbuild /p:Configuration=Release -r:False


FROM mcr.microsoft.com/dotnet/framework/aspnet:4.8 AS runtime
WORKDIR /inetpub/wwwroot
COPY --from=build /app/webapi/. ./