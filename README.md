# SneakerCollection

SneakerCollection is a .NET application for managing your sneaker collection. This application allows users to add, update, list, and delete sneakers from their collection.

## Getting Started

### Prerequisites

Make sure you have the following tools installed:

- [.NET SDK](https://dotnet.microsoft.com/download)

### Running the Application

To run the application, use the following command:

```bash
dotnet watch run --project src/SneakerCollection.Api
```

This will start the application, and you can access the Swagger documentation at [http://localhost:5210/swagger/index.html](http://localhost:5210/swagger/index.html).

## API Endpoints

The API provides the following endpoints:

### Authentication
- `POST /auth/register`: Register a new user.
- `POST /auth/login`: Login an existing user.

### Sneakers
- `GET /sneakers`: List all sneakers.
- `POST /sneakers`: Add a new sneaker to the collection.
- `PUT /sneakers/{sneakerId}`: Update an existing sneaker.
- `DELETE /sneakers/{sneakerId}`: Delete a sneaker from the collection.

For detailed information about each endpoint, refer to the Swagger documentation.

## Contributing

If you'd like to contribute to SneakerCollection, please follow the [Contribution Guidelines](CONTRIBUTING.md).

## License

This project is licensed under the MIT License
