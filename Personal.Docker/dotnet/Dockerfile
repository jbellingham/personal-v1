FROM mcr.microsoft.com/dotnet/core/sdk:2.2.203-stretch AS dotnet-build-env
LABEL personal="true"
WORKDIR /solution

COPY ./Personal.sln ./
COPY ./Personal.Db/Personal.Db.csproj ./Personal.Db/
COPY ./Personal.Domain/Personal.Domain.csproj ./Personal.Domain/
COPY ./Personal.Web/Personal.Web.csproj ./Personal.Web/

RUN dotnet restore