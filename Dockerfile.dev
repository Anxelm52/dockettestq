FROM microsoft/aspnetcore-build

ENV DOTNET_USE_POLLING_FILE_WATCHER=true

ENV ASPNETCORE_URLS=http://+:80

EXPOSE 80/tcp

VOLUME /app

WORKDIR /app

ENTRYPOINT dotnet restore \
 && dotnet watch run --environment=Development