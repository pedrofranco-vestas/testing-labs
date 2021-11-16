#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["HelloWorld.Api/HelloWorld.Api.csproj", "HelloWorld.Api/"]
RUN dotnet restore "HelloWorld.Api/HelloWorld.Api.csproj"
COPY . .
WORKDIR "/src/HelloWorld.Api"
RUN dotnet build "HelloWorld.Api.csproj" -c Release -o /app/build

FROM build AS publish
ARG PACKAGE_SOURCE_USER
ARG PACKAGE_SOURCE_TOKEN
RUN echo ${PACKAGE_SOURCE_USER}
RUN echo ${PACKAGE_SOURCE_TOKEN} 
RUN dotnet publish "HelloWorld.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloWorld.Api.dll"]