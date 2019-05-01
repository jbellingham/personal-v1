FROM microsoft/dotnet:sdk AS build-env
LABEL personal="true"

ARG CONFIGURATION="Release"
WORKDIR /solution/Personal.Db
COPY ./Personal.Db/. ./
RUN dotnet build -c ${CONFIGURATION} -r linux-x64 -f netcoreapp2.2 --no-restore --no-dependencies
RUN dotnet publish -c ${CONFIGURATION} -r linux-x64 -f netcoreapp2.2 -o /app --no-build

ENTRYPOINT ["dotnet", "Personal.Db.dll"]