FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# disable microsoft telematry
ENV DOTNET_CLI_TELEMETRY_OPTOUT='true'

WORKDIR /app

# Copy csproj and restore as distinct layers
COPY ./PostgresTraining.sln ./
COPY ./PostgresTraining/PostgresTraining.csproj ./PostgresTraining/
COPY ./PostgresTraining.Tests/PostgresTraining.Tests.csproj ./PostgresTraining.Tests/

RUN dotnet restore ./PostgresTraining/PostgresTraining.csproj
RUN dotnet restore ./PostgresTraining.Tests/PostgresTraining.Tests.csproj

# Copy everything else and build
COPY . .

RUN dotnet build -c debug -o out PostgresTraining.Tests/PostgresTraining.Tests.csproj

CMD dotnet test
