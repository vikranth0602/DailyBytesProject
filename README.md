# DailyBytes

A full-stack article management platform built using **ASP.NET Core 8 Web API**, **Angular 17**, **Entity Framework Core**, and **SQLite**.

DailyBytes allows users to register, authenticate using JWT, browse articles, filter by category, bookmark articles, submit ratings, and participate in discussions through comments.

---

# Live Demo

**Application**

https://dailybytes.netlify.app

---

# Features

## Authentication

* User Registration
* User Login
* JWT Authentication
* Protected API Endpoints
* Angular Route Guards
* HTTP Authorization Interceptor
* BCrypt Password Hashing

## Articles

* Browse Articles
* Read Full Articles
* Category Filtering
* Estimated Reading Time

## Bookmarks

* Add Bookmark
* Remove Bookmark
* View Personal Bookmarks

## Ratings

* Submit Ratings
* Update Existing Ratings
* Average Rating Calculation

## Comments

* Add Comments
* Delete Comments
* View Article Discussions

## User Experience

* Global Notification System
* Loading Indicators
* Responsive Design

---

# Technology Stack

## Backend

* ASP.NET Core 8 Web API
* Entity Framework Core
* SQLite
* Repository Pattern
* DTO Pattern
* Generic API Response Wrapper
* Exception Handling Middleware
* Data Annotation Validation
* BCrypt Password Hashing
* JWT Authentication

## Frontend

* Angular 17
* Standalone Components
* Reactive Forms
* RxJS
* Functional Route Guards
* HTTP Interceptors
* Angular Router

## Deployment

* Docker
* Multi-stage Docker Build
* Render
* Netlify
* GitHub Automatic Deployments

---

# Project Architecture

### Backend

Controllers

↓

Repositories

↓

Entity Framework Core

↓

SQLite

### Frontend

Angular Components

↓

Services

↓

REST API

↓

ASP.NET Core Web API

---

# Deployment

## Frontend

Hosted on **Netlify**

* Angular Production Build
* Single Page Application (SPA) Routing
* HTTPS Enabled
* Production Environment Configuration

## Backend

Hosted on **Render**

* ASP.NET Core 8 Web API
* Docker Container
* Multi-stage Docker Build
* Automatic Deployments from GitHub
* Automatic Database Migration
* Automatic Seed Data

## Database

SQLite

On application startup:

* Applies Entity Framework Core Migrations
* Creates the database if required
* Seeds Categories
* Seeds Articles

---

# DevOps & Deployment

This project demonstrates:

* Git Version Control
* GitHub Repository Management
* Docker Containerization
* Multi-stage Docker Builds
* Cloud Deployment
* GitHub-based Automatic Deployment
* Environment-specific Configuration
* Entity Framework Core Migrations
* Database Seeding
* Frontend & Backend Integration
* CORS Configuration

---

# Project Structure

### Backend

* Controllers
* DTOs
* Mappers
* Middleware
* Models
* Repositories

### Frontend

* Components
* Services
* Models
* Guards
* Interceptors

---

# Technologies

* C#
* ASP.NET Core 8
* Entity Framework Core
* SQLite
* Angular 17
* TypeScript
* HTML5
* CSS3
* RxJS
* Docker
* JWT
* BCrypt
* Git
* GitHub
* Netlify
* Render

---

# Future Improvements

* Refresh Token Authentication
* Role-Based Authorization
* Service Layer
* Unit Testing
* Pagination
* Article Search
* User Profile
* AutoMapper
* Structured Logging
* Performance Optimizations

---

# Learning Outcomes

This project provided practical experience with:

* Full-Stack Web Development
* REST API Design
* Authentication & Authorization
* Entity Framework Core
* Angular Application Architecture
* Repository Pattern
* DTO Mapping
* Exception Handling
* Docker Deployment
* Cloud Hosting
* Production Environment Configuration
