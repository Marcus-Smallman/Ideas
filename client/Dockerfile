FROM mcr.microsoft.com/dotnet/core/runtime:2.2-stretch-slim-arm32v7

# Set working directory
WORKDIR /app

# Copy output to image
COPY /dist ./dist/
COPY /out ./

# Set entrypoint command
ENTRYPOINT ["dotnet", "client.dll"]