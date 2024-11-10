# เลือก base image ที่เหมาะสมสำหรับ ASP.NET Core runtime (.NET 5)
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

# ใช้ SDK image สำหรับ .NET 5 เพื่อ build แอปพลิเคชัน
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "Npz.csproj"
RUN dotnet publish "Npz.csproj" -c Release -o /app/publish

# คัดลอกผลลัพธ์ build มาที่ final image
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Npz.dll"]