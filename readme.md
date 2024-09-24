# Project Title

This project is quick practice about creating a client-server model using C#.
It uses sockets to communicate using the method TCP.

## Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.

## Guide of Use

1. Run the Server project.
2. Run the Client project in a different terminal.
3. Input a message in Client side.

## How to Run

1. **Clone the repository:**
  ```sh
  git clone https://github.com/andrepalacio/Client_Server_Practice.git
  cd your-repo
  ```

2. **Build the project:**
If it is neccesary, enter follow commands in terminal
  ```sh
  dotnet build --project Client
  ```
  ```sh
  dotnet build --project Server
  ```

3. **Run the project:**
It will be needed two different terminal instances to run the program
To run Client use
  ```sh
  dotnet run --project Client
  ```
It is also possible to use following command if you are in the Client folder route
  ```sh
  dotnet run
  ```
To run Server use 
  ```sh
  dotnet run --project Server
  ```
It is also possible to use following command if you are in the Server folder route
  ```sh
  dotnet run
  ```
<!-- ## Running Tests

To run the tests, use the following command:
```sh
dotnet test
``` -->