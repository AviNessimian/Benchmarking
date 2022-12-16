FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /src
COPY . .
RUN dotnet restore

RUN dotnet build "Benchmarking/Benchmarking.csproj" -c Release -o /src/bin
RUN dotnet publish "Benchmarking/Benchmarking.csproj" -c Release -o /src/bin/publish

WORKDIR /src/bin/publish
ENTRYPOINT ["dotnet", "Benchmarking.dll"]