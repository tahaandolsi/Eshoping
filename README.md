# Eshoping

Eshoping is a full-stack e-commerce application built using a **microservices architecture**.

The application provides an online shopping experience with product management, shopping basket, authentication, discounts, and order processing.

## Architecture

The backend is divided into several independent services:

- **Catalog Service** – Product catalog and product management
- **Basket Service** – Shopping basket management
- **Discount Service** – Discount and coupon management
- **Ordering Service** – Order processing and management
- **Identity Service** – Authentication and authorization
- **API Gateway** – Centralized API routing using Ocelot
- **Angular Client** – Frontend application

The services communicate through REST APIs and gRPC where appropriate.

## Technologies

### Backend

- C#
- ASP.NET Core
- .NET
- Entity Framework Core
- REST API
- gRPC
- Ocelot API Gateway
- IdentityServer
- Docker
- Docker Compose

### Frontend

- Angular
- TypeScript
- HTML5
- SCSS
- Bootstrap

## Features

- User authentication and authorization
- Product catalog and product management
- Product search
- Shopping basket
- Discount and coupon management
- Order processing and management
- API Gateway routing
- Microservices architecture
- Docker containerization

## How the Application Works

The application follows a microservices architecture.

When a user interacts with the Angular frontend, requests are sent through the API Gateway. The Gateway routes each request to the appropriate microservice.

For example:

1. The user browses products through the Angular client.
2. The request is routed through the Ocelot API Gateway.
3. The Catalog Service retrieves product information.
4. When the user adds a product to the basket, the Basket Service manages the shopping cart.
5. The Discount Service handles discount calculations.
6. During checkout, the Ordering Service processes the order.
7. The Identity Service handles authentication and authorization.

This separation allows each business domain to be developed and maintained independently.

## Project Structure

```text
Eshoping/
│
├── ApiGateways/
│   └── Ocelot.ApiGateway/
│
├── Infrastructure/
│   ├── Common.Logging/
│   ├── EShopping.Identity/
│   └── EventBus.Messages/
│
├── Services/
│   ├── Basket/
│   ├── Catalog/
│   ├── Discount/
│   └── Ordering/
│
├── client/
│   └── Angular application
│
├── docker-compose.yml
├── docker-compose.override.yml
└── Eshoping.sln
```

## Getting Started

### Prerequisites

- .NET SDK
- Node.js and npm
- Docker Desktop
- Git

### Clone the repository

```bash
git clone https://github.com/tahaandolsi/Eshoping.git
cd Eshoping
```

### Run with Docker

```bash
docker compose up --build
```

### Run the Angular application

```bash
cd client
npm install
ng serve
```

The Angular application will be available at:

```text
http://localhost:4200
```


## License

This project is provided for educational purposes.
