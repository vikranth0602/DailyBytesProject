# DailyBytes

DailyBytes is a full-stack article management and learning platform built with **ASP.NET Core Web API**, **Entity Framework Core**, **SQL Server**, and **Angular**.

The application allows users to discover articles, bookmark content, rate articles, participate in discussions through comments, and manage authentication securely through JWT-based authorization.

---

## Features

### Authentication & Authorization

* User Registration
* User Login
* JWT Authentication
* Protected Routes
* Guest Route Guards
* Role-based API Security

### Article Management

* Browse Articles
* Filter Articles by Category
* Article Details Page
* Reading Time Calculation
* Responsive Article Layout

### Bookmarks

* Add Bookmark
* Remove Bookmark
* View Personal Bookmark Collection

### Ratings

* Rate Articles (1–5 Stars)
* Average Rating Calculation
* User Rating Tracking

### Comments

* Add Comments
* Delete Own Comments
* Discussion Section Per Article

### User Experience

* Skeleton Loaders
* Toast Notifications
* Responsive Design
* Loading States
* Empty States
* Form Validation
* Password Visibility Toggle

---

## Tech Stack

### Frontend

* Angular
* TypeScript
* RxJS
* Standalone Components
* Route Guards
* Reactive Forms

### Backend

* ASP.NET Core Web API
* Entity Framework Core
* LINQ
* Dependency Injection
* Custom Middleware

### Database

* SQL Server

### Authentication

* JWT Bearer Tokens

---

## Architecture

### Backend Layers

* Controllers
* Services
* Repositories
* DTOs
* Middleware
* Entity Models

### Frontend Structure

* Components
* Services
* Models
* Route Guards
* Shared Utilities

---

## Key Implementations

### Global Exception Handling

Implemented custom middleware for centralized exception handling and consistent API responses.

### Repository Pattern

Used repository abstraction to separate data access logic from business logic.

### Dependency Injection

Applied ASP.NET Core built-in Dependency Injection to manage services and repositories.

### API Response Standardization

Created a generic API response model for consistent success and error responses.

### Authentication Flow

JWT token generation and validation with route protection on both frontend and backend.

---

## Database Entities

* Users
* Articles
* Categories
* Bookmarks
* Comments
* Ratings

---

## Project Highlights

* Full-stack application built from scratch
* Clean layered architecture
* Secure JWT Authentication
* Custom Exception Middleware
* Entity Framework Core Integration
* Responsive Angular UI
* Real-world CRUD Operations
* Route Guards and Access Control
* Reusable Services and Components

---

## Future Enhancements

* Refresh Token Authentication
* Role-Based Authorization
* Search Functionality
* Pagination
* Article Creation Dashboard
* Rich Text Editor
* Unit Testing
* Integration Testing
* Docker Deployment
* CI/CD Pipeline

---

## Learning Outcomes

This project strengthened practical experience in:

* ASP.NET Core Web API Development
* Angular Application Development
* Entity Framework Core
* JWT Authentication
* Middleware Development
* RESTful API Design
* SQL Database Design
* Dependency Injection
* Repository Pattern
* Frontend State Management
* Responsive UI Development

---

## Author

Built and maintained by: 
Vikranth
