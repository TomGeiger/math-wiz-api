# MathWizApi

MathWizApi is an ASP.NET Core Web API for managing leaderboard entries for a math quiz application.

## Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [SQLite](https://www.sqlite.org/download.html)

### Installation

1. Clone the repository:
    ```sh
    git clone https://github.com/TomGeiger/math-wiz-api.git
    cd math-wiz-api
    ```

2. Restore the dependencies:
    ```sh
    dotnet restore
    ```

3. Apply the database migrations:
    ```sh
    dotnet ef database update
    ```

4. Run the application:
    ```sh
    dotnet run
    ```

### Usage

The API will be available at `http://localhost:5000`. You can use tools like [Postman](https://www.postman.com/) or [curl](https://curl.se/) to interact with the API.

### API Endpoints

- `GET /api/leaderboard` - Get all leaderboard entries
- `POST /api/leaderboard` - Add a new leaderboard entry
- `PUT /api/leaderboard/{id}` - Update a leaderboard entry
- `DELETE /api/leaderboard/{id}` - Delete a leaderboard entry

### Sample Data

Here is some sample JSON data for `LeaderboardEntry`:

```json
[
    {
        "Id": 1,
        "UserName": "Alice",
        "Score": 1500,
        "Date": "2023-10-01T14:30:00"
    },
    {
        "Id": 2,
        "UserName": "Bob",
        "Score": 1200,
        "Date": "2023-10-02T15:45:00"
    },
    {
        "Id": 3,
        "UserName": "Charlie",
        "Score": 1800,
        "Date": "2023-10-03T16:00:00"
    }
]