@echo off
echo Instalando pacotes NuGet no projeto...

dotnet add package BCrypt.Net-Next --version 4.0.3
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.0
dotnet add package Microsoft.EntityFrameworkCore --version 9.0.7
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 9.0.7
dotnet add package Microsoft.IdentityModel.Tokens --version 8.12.1
dotnet add package Swashbuckle.AspNetCore --version 9.0.3
dotnet add package System.IdentityModel.Tokens.Jwt --version 8.12.1
dotnet add package System.ServiceModel.Primitives --version 8.1.2

echo Pacotes instalados com sucesso!
pause