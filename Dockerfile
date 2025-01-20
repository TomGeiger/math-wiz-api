# Use the official .NET image as a build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Install the dotnet-ef tool
RUN dotnet tool install --global dotnet-ef

# Ensure the dotnet tools are available in the PATH
ENV PATH="$PATH:/root/.dotnet/tools"

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Run the migrations in the build stage
RUN dotnet ef database update

# Use the official ASP.NET image as a runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app/out .
COPY --from=build /app/*.db /app/ 
# Ensure the destination is a directory

# Expose port 80
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "MathWizApi.dll"]