# AuthJWTAPI

![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-blue) ![Version](https://img.shields.io/badge/version-1.0.0-green)

**AuthJWTAPI** is a developer tool built in .NET Core 8 for testing client applications that require authorization using JSON Web Tokens (JWT).

## Features

- User registration
- User login and JWT generation
- User logout
- Password change
- Password reset

## Installation and Running

1. **Clone the repository:**

    ```bash
    git clone https://github.com/yourusername/AuthJWTAPI.git
    cd AuthJWTAPI
    ```

2. **Restore dependencies and run the application:**

    ```bash
    dotnet restore
    dotnet run
    ```

3. **Access Swagger UI:**

    After starting the application, Swagger UI documentation will be available at `https://localhost:5001/swagger`.

## Example Requests

- **User login:**

    ```bash
    curl -X POST https://localhost:5001/api/auth/signin -H "Content-Type: application/json" -d "{\"username\":\"testuser\", \"password\":\"password123\"}"
    ```

- **Change password:**

    ```bash
    curl -X POST https://localhost:5001/api/auth/changepassword -H "Authorization: Bearer {token}" -H "Content-Type: application/json" -d "{\"newPassword\":\"newpassword123\"}"
    ```

## Additional Information

AuthJWTAPI is an open-source project created for educational and testing purposes. Use it to quickly test and develop client applications that require authorization.
