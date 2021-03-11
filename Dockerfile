ARG ALPINE_VERSION=3.12
FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine${ALPINE_VERSION}

WORKDIR /build
COPY . .

RUN apk add --no-cache tree && dotnet build && dotnet publish -o /app

# RUN tree /app
RUN /app/LibGit2SharpBug /build