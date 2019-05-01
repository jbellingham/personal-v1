FROM personal/dotnet:latest AS domain
LABEL personal="true"
ARG CONFIGURATION="Release"
WORKDIR /solution/Personal.Domain
COPY ./Personal.Domain/. ./
#RUN perl -i -p0e 's~<Target Name="Gulp".*?</Target>~~ms' ./Personal.Domain.csproj
RUN dotnet build -c ${CONFIGURATION} -f netcoreapp2.2 --no-restore