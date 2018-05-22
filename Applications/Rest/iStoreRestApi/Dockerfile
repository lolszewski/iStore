FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 18592
EXPOSE 44311

FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
WORKDIR /src
COPY Applications/Rest/iStoreRestApi/iStoreRestApi.csproj Applications/Rest/iStoreRestApi/
RUN dotnet restore Applications/Rest/iStoreRestApi/iStoreRestApi.csproj
COPY . .
WORKDIR /src/Applications/Rest/iStoreRestApi
RUN dotnet build iStoreRestApi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish iStoreRestApi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "iStoreRestApi.dll"]
