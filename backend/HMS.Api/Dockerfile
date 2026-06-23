FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["HMS.Api/HMS.Api.csproj", "HMS.Api/"]
COPY ["HMS.Shared/HMS.Shared.csproj", "HMS.Shared/"]
COPY ["HMS.Modules.Tenants/HMS.Modules.Tenants.Api/HMS.Modules.Tenants.Api.csproj", "HMS.Modules.Tenants/HMS.Modules.Tenants.Api/"]
COPY ["HMS.Modules.Tenants/HMS.Modules.Tenants.Application/HMS.Modules.Tenants.Application.csproj", "HMS.Modules.Tenants/HMS.Modules.Tenants.Application/"]
COPY ["HMS.Modules.Tenants/HMS.Modules.Tenants.Domain/HMS.Modules.Tenants.Domain.csproj", "HMS.Modules.Tenants/HMS.Modules.Tenants.Domain/"]
COPY ["HMS.Modules.Tenants/HMS.Modules.Tenants.Infrastructure/HMS.Modules.Tenants.Infrastructure.csproj", "HMS.Modules.Tenants/HMS.Modules.Tenants.Infrastructure/"]
# Add other modules
COPY ["HMS.Modules.Patients/HMS.Modules.Patients.Api/HMS.Modules.Patients.Api.csproj", "HMS.Modules.Patients/HMS.Modules.Patients.Api/"]
COPY ["HMS.Modules.Patients/HMS.Modules.Patients.Application/HMS.Modules.Patients.Application.csproj", "HMS.Modules.Patients/HMS.Modules.Patients.Application/"]
COPY ["HMS.Modules.Patients/HMS.Modules.Patients.Domain/HMS.Modules.Patients.Domain.csproj", "HMS.Modules.Patients/HMS.Modules.Patients.Domain/"]
COPY ["HMS.Modules.Patients/HMS.Modules.Patients.Infrastructure/HMS.Modules.Patients.Infrastructure.csproj", "HMS.Modules.Patients/HMS.Modules.Patients.Infrastructure/"]
COPY ["HMS.Modules.Appointments/HMS.Modules.Appointments.Api/HMS.Modules.Appointments.Api.csproj", "HMS.Modules.Appointments/HMS.Modules.Appointments.Api/"]
COPY ["HMS.Modules.Appointments/HMS.Modules.Appointments.Application/HMS.Modules.Appointments.Application.csproj", "HMS.Modules.Appointments/HMS.Modules.Appointments.Application/"]
COPY ["HMS.Modules.Appointments/HMS.Modules.Appointments.Domain/HMS.Modules.Appointments.Domain.csproj", "HMS.Modules.Appointments/HMS.Modules.Appointments.Domain/"]
COPY ["HMS.Modules.Appointments/HMS.Modules.Appointments.Infrastructure/HMS.Modules.Appointments.Infrastructure.csproj", "HMS.Modules.Appointments/HMS.Modules.Appointments.Infrastructure/"]

RUN dotnet restore "HMS.Api/HMS.Api.csproj"
COPY . .
WORKDIR "/src/HMS.Api"
RUN dotnet build "HMS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HMS.Api.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HMS.Api.dll"]
