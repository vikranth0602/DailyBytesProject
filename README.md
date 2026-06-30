# 📚 DailyBytes

A full-stack article management platform built with **ASP.NET Core Web API**, **Angular**, **Entity Framework Core**, and **SQLite**.

DailyBytes allows users to browse articles, authenticate securely, bookmark articles, submit ratings, and participate through comments. The project demonstrates modern full-stack development practices, REST API design, responsive UI development, and cloud deployment.

🌐 **Live Application**

https://dailybytes.netlify.app

---

# Project Overview

DailyBytes was built as a portfolio project to strengthen practical experience in modern web application development.

The application follows a layered backend architecture using repositories, DTOs, entity mapping, middleware, and REST APIs while the frontend is developed using Angular standalone components with responsive UI principles and reusable services.

The project also demonstrates cloud deployment using Docker, Render, and Netlify.

---

# Features

## Authentication

- User Registration
- User Login
- Password Hashing using BCrypt
- JWT Authentication
- Route Guards
- HTTP Interceptor for Authorization Header
- Persistent Login using Local Storage

---

## Articles

- Browse all articles
- Read complete article
- Category based filtering
- Estimated reading time
- Responsive article layout

---

## Bookmarks

- Add bookmark
- Remove bookmark
- Dedicated bookmarks page
- Bookmark state synchronization

---

## Ratings

- 5-Star rating system
- Average article rating
- Update existing rating
- Prevent duplicate ratings

---

## Comments

- Add comments
- Delete comments
- Comment validation
- Latest comments displayed first

---

## User Experience

- Responsive Design
- Notification System
- Global Design System
- Reusable Button Components
- Loading States
- Consistent Error Handling

---

# Technology Stack

## Backend

- ASP.NET Core 8 Web API
- Entity Framework Core
- SQLite
- Repository Pattern
- DTO Pattern
- Extension Mapper Classes
- BCrypt Password Hashing
- JWT Authentication
- Global Exception Middleware

---

## Frontend

- Angular 17
- TypeScript
- Standalone Components
- RxJS
- Reactive Forms
- Angular Router
- Route Guards
- HTTP Interceptors

---

## UI / UX

- Responsive Design
- CSS Variables
- Global Design System
- Consistent Typography
- Color Theory (70-20-10)
- Notification System

---

## DevOps

- Docker
- Multi-stage Docker Build
- Render Deployment
- Netlify Deployment
- GitHub Version Control

---

# Project Architecture

```
Angular Frontend

        │

        ▼

ASP.NET Core Web API

        │

        ▼

Repository Layer

        │

        ▼

Entity Framework Core

        │

        ▼

SQLite Database
```

---

# Project Structure

```
DailyBytes

│
├── DailyBytesServices
│     ├── Controllers
│     ├── DTOs
│     ├── Mappers
│     ├── Middleware
│     └── Helpers
│
├── DailyBytesDAL
│     ├── Models
│     ├── Repositories
│     └── DbContext
│
└── DailyBytes-UI
      ├── Components
      ├── Services
      ├── Models
      ├── Guards
      ├── Interceptors
      └── Shared
```

---

# REST API Highlights

The backend exposes RESTful endpoints for:

- Authentication
- Articles
- Categories
- Bookmarks
- Ratings
- Comments

Each endpoint returns a standardized API response structure.

---

# Deployment

## Frontend

- Hosted on Netlify
- Production Angular Build
- HTTPS Enabled

## Backend

- Hosted on Render
- Docker Container
- Multi-stage Docker Build
- Automatic Database Migration
- Automatic Seed Data

---

# Database

SQLite is used as the primary database.

Entity Framework Core handles:

- Database Migrations
- Entity Relationships
- Data Access
- Automatic Database Creation
- Initial Seed Data

---

# Security

Current implementation includes:

- BCrypt Password Hashing
- JWT Authentication
- Protected Routes
- Authorization Header Interceptor
- Request Validation
- Global Exception Handling

---

# Skills Demonstrated

- Full Stack Development
- REST API Design
- Angular SPA Development
- Entity Framework Core
- Repository Pattern
- DTO Mapping
- Authentication
- Responsive UI Development
- Cloud Deployment
- Docker
- Git & GitHub
- Exception Handling
- State Management
- Component-Based Architecture

---

# Future Improvements

The project will continue evolving with planned enhancements including:

- Complete JWT Authorization
- Service Layer Refactoring
- Role-Based Authorization
- Refresh Tokens
- Search & Pagination
- User Profile Management
- Unit Testing
- Integration Testing
- Logging
- Performance Optimizations

---

# Learning Outcomes

This project provided practical experience in designing and building a complete full-stack web application using ASP.NET Core and Angular.

It strengthened understanding of REST API development, Entity Framework Core, authentication, responsive frontend development, repository-based architecture, Docker containerization, cloud deployment, and frontend-backend integration.
