FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /app

RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs

# copy csproj and restore as distinct layers
COPY Personal.Web/*.csproj ./Personal.Web/
COPY Personal.Domain/*.csproj ./Personal.Domain/
WORKDIR /app/Personal.Web
RUN dotnet restore

# copy and publish app and libraries
WORKDIR /app/
COPY Personal.Domain/. ./Personal.Domain/
COPY Personal.Web/. ./Personal.Web/
WORKDIR /app/Personal.Web/
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build /app/Personal.Web/out ./Personal.Web/

FROM node:8 as build-deps
WORKDIR /app
COPY Personal.Web/ClientApp/package.json Personal.Web/ClientApp/yarn.lock ./Personal.Web/ClientApp/
COPY Personal.Web/ClientApp/public/. ./Personal.Web/ClientApp/public/
WORKDIR /app/Personal.Web/ClientApp
RUN yarn
#COPY . ./
RUN yarn build
RUN npm serve -s build

ENTRYPOINT ["dotnet", "Personal.Web.dll"]