# MyStore API

MyStore API is an ASP.NET Core application that interacts with a SQL Server database. This project is designed to demonstrate how to set up a simple API with a database using Docker Compose.

## Prerequisites

Before you begin, ensure you have the following installed on your machine:

- [Docker](https://www.docker.com/get-started) (including Docker Compose)

## Getting Started

Follow these steps to run the application using Docker Compose.

1. **Clone the Repository**

   ```bash
   git clone https://github.com/Zapwap123/MyStore.git
   cd MyStore
   ```

2. **Build and Run the Application**

   Use Docker Compose to build and run the services:

   ```bash
   docker-compose up --build
   ```

   This command will start the SQL Server database and the ASP.NET Core API. The application will be accessible at `http://localhost:5000`.

3. **Access the API**

   You can test the API endpoints using a tool like [Postman](https://www.postman.com/) or by using `curl` commands.

4. **Stopping the Services**

   To stop the services, press `Ctrl + C` in the terminal where Docker Compose is running. You can also run:

   ```bash
   docker-compose down
   ```

   This command will stop and remove the containers.

## Configuration

The connection to the SQL Server database is configured in the `appsettings.json` file, and the password for the `sa` user is defined in the `docker-compose.yml` file.

```json
"ConnectionStrings": {
    "DefaultConnection": "Server=db;Database=CustomerDB;User Id=sa;Password=YourPassword123;"
}
```

## API Endpoints for Testing in Postman

You can test the `CustomerController` endpoints using the following paths:

1. **Get All Customers (Paginated)**

   - **Endpoint**: `GET /api/customer`
   - **Query Parameters**:
     - `page` (optional, default: 1): Page number for pagination.
     - `pageSize` (optional, default: 10): Number of customers per page.

   **Example**: `http://localhost:5000/api/customer?page=1&pageSize=10`

2. **Get Customer by Customer Number**

   - **Endpoint**: `GET /api/customer/{customerNumber}`
   - **Example**: `http://localhost:5000/api/customer/12345`

3. **Create a New Customer**

   - **Endpoint**: `POST /api/customer`
   - **Body (JSON)**:
     ```json
     {
     	"customerNumber": "12345",
     	"name": "John Doe",
     	"email": "johndoe@example.com",
     	"phone": "123-456-7890"
     }
     ```
   - **Example**: `http://localhost:5000/api/customer`

4. **Update Customer by Customer Number**

   - **Endpoint**: `PUT /api/customer/{customerNumber}`
   - **Body (JSON)**:
     ```json
     {
     	"customerNumber": "12345",
     	"name": "Jane Doe",
     	"email": "janedoe@example.com",
     	"phone": "098-765-4321"
     }
     ```
   - **Example**: `http://localhost:5000/api/customer/12345`

5. **Delete Customer by Customer Number**

   - **Endpoint**: `DELETE /api/customer/{customerNumber}`
   - **Example**: `http://localhost:5000/api/customer/12345`

Use these paths to interact with the API in Postman. Make sure to set the `Content-Type` to `application/json` for POST and PUT requests.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Contributing

Contributions are welcome! Please feel free to submit a pull request or open an issue if you encounter any problems.

## Contact

For any inquiries or feedback, feel free to reach out:

- **Email**: sethanmawen97@gmail.com
- **LinkedIn**: [linkedin.com/in/seth-anmawen-30813721a](https://www.linkedin.com/in/seth-anmawen-30813721a)
