FROM personal/dotnet:latest AS build-env
LABEL personal="true"
WORKDIR /app

ARG CONFIGURATION="Release"
WORKDIR /solution
COPY --from=personal/domain:latest /solution/Personal.Domain/bin/. ./Personal.Domain/bin/
COPY --from=personal/domain:latest /solution/Personal.Domain/obj/. ./Personal.Domain/obj/

WORKDIR /app
RUN curl -sL https://deb.nodesource.com/setup_10.x |  bash -
RUN apt-get install -y nodejs

# Copy csproj and restore as distinct layers
COPY Personal.Api/*.csproj ./Personal.Api/
WORKDIR /app/Personal.Api
RUN dotnet restore


# Copy everything else and build
WORKDIR /app
COPY --from=personal/dotnet:latest /solution/Personal.Api/. ./Personal.Api

WORKDIR /app/Personal.Api
RUN dotnet publish -c Release -o out


FROM node:8 as build-deps
WORKDIR /app
COPY Personal.Api/ClientApp/package.json Personal.Api/ClientApp/yarn.lock ./Personal.Api/ClientApp/
COPY Personal.Api/ClientApp/public/. ./Personal.Api/ClientApp/public/
WORKDIR /app/Personal.Api/ClientApp
RUN yarn

FROM nginx
COPY Nginx.conf /etc/nginx/conf.d/default.conf

WORKDIR /app
COPY Personal.Api/ClientApp/build /usr/share/nginx/html
#EXPOSE 5001
CMD ["nginx", "-g", "daemon off;"]


# Build runtime image
FROM microsoft/dotnet:aspnetcore-runtime
WORKDIR /app
COPY --from=build-env /app/Personal.Api/out .

#ENV ASPNETCORE_URLS http://+:5001
#EXPOSE 5001
ENTRYPOINT ["dotnet", "Personal.Api.dll"]
