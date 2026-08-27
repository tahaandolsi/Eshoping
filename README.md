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
