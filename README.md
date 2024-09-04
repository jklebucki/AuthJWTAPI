# AuthJWTAPI
![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-blue) ![Version](https://img.shields.io/badge/version-1.0.0-green)

**AuthJWTAPI** to narzędzie deweloperskie stworzone w .NET Core 8 do testowania aplikacji klienckich wymagających autoryzacji przy użyciu JSON Web Tokens (JWT).

## Funkcjonalności

- Rejestracja użytkownika
- Logowanie i generowanie tokenu JWT
- Wylogowanie użytkownika
- Zmiana hasła
- Resetowanie hasła

## Instalacja i uruchomienie

1. **Sklonuj repozytorium:**

    ```bash
    git clone https://github.com/yourusername/AuthJWTAPI.git
    cd AuthJWTAPI
    ```

2. **Przywróć zależności i uruchom aplikację:**

    ```bash
    dotnet restore
    dotnet run
    ```

3. **Dostęp do Swagger UI:**

    Po uruchomieniu aplikacji, dokumentacja Swagger UI będzie dostępna pod adresem `https://localhost:5001/swagger`.

## Przykładowe zapytania

- **Logowanie użytkownika:**

    ```bash
    curl -X POST https://localhost:5001/api/auth/signin -H "Content-Type: application/json" -d "{\"username\":\"testuser\", \"password\":\"password123\"}"
    ```

- **Zmiana hasła:**

    ```bash
    curl -X POST https://localhost:5001/api/auth/changepassword -H "Authorization: Bearer {token}" -H "Content-Type: application/json" -d "{\"newPassword\":\"newpassword123\"}"
    ```

## Informacje dodatkowe

AuthJWTAPI to projekt open-source stworzony w celach edukacyjnych i testowych. Używaj go, aby szybko testować i rozwijać aplikacje klienckie wymagające autoryzacji.
