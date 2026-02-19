```markdown
# SEP6_IMDB

**SEP6_IMDB** is a full-stack IMDb-like web application that lets users browse movies, view detailed movie information, and interact through features such as authentication, favourites, and comments.

The solution is split into:

- **Backend:** ASP.NET Core Web API  
- **Frontend:** Blazor WebAssembly  

The two parts communicate over HTTP Client.



# 🏗 Architecture Overview

## 🔧 Backend (ASP.NET Core Web API)

The backend exposes REST endpoints via controllers, uses **Entity Framework Core** through a `DataContext`, and implements a DAO/service-style abstraction through interfaces and scoped implementations.

### Key Characteristics (from `Backend/Program.cs`)

- Registers **Controllers** and **Swagger (OpenAPI)** for API discovery/testing.
- Adds `DataContext` as the EF Core database context.
- Registers scoped dependencies:
  - Movies: `IMoviesInterface` → `MoviesImplementation`
  - Users: `IUserInterface` → `UserImplementation`
  - Favourites: `IFavouriteInterface` → `FavouriteImplementation`
  - Comments: `ICommentInterface` → `CommentImplementation`
- Enables permissive **CORS** (allow any origin/header/method) so the Blazor WebAssembly client can call the API.
- Uses:
  - HTTPS redirection
  - Authorization middleware
  - Controller mapping

### Typical Request Flow

```

Frontend → HTTP call → Controller → DAO Interface → EF Core DataContext → Database → Response → Frontend

```

---

## 🎨 Frontend (FrontendBlazorWebAssembly)

The frontend is a **Blazor WebAssembly** app targeting **.NET 7 (`net7.0`)**, containing:

- Pages (Razor components)
- Shared layout components
- Authentication state management
- Service classes for API communication

---

# 📁 Frontend Structure

## 📂 Directory: `FrontendBlazorWebAssembly`

### 🖥 Pages/

UI pages (Razor components) representing screens and flows:

- `Movies.razor` / `MoviesBase.cs` – Movie listing experience
- `Details.razor` / `DetailsBase.cs` – Movie details view
- `FavouritePage.razor`, `FavouriteDetails.razor` (+ base classes) – User favourites management
- `Login.razor` / `LoginBase.cs` – Authentication UI
- `RegistrationPage.razor` / `RegistrationPageBase.cs` – User registration
- `Index.razor`, `Counter.razor`, `FetchData.razor` – App entry/demo pages

---

### 🔌 Services/

Client-side services responsible for backend communication:

- `MovieService.cs` → implements `IMovieService.cs`
- `LoginService.cs` → implements `ILoginService.cs`
- `RegisterUserService.cs` → implements `IRegisterUserService.cs`
- `FavouriteService.cs` → implements `IFavouriteService.cs`
- `CommentService.cs` → implements `ICommentService.cs`

---

### 🔐 Authentication/

Authentication infrastructure for Blazor:

- `IAuthManager.cs`
- `AuthManagerImpl.cs` – Handles authentication logic/state
- `SimpleAuthenticationStateProvider.cs` – Integrates with Blazor authorization system

---

### 🧩 Model/

Data models used by UI and services:

- `MovieDetails.cs`
- `MovieIMG.cs`

---

### 🧱 Shared/

Shared UI components and layout:

- `MainLayout.razor` (+ CSS)
- `Navbar.razor`
- `NavMenu.razor` (+ CSS)

---

### 🌐 wwwroot/

Static web assets:

- `index.html`
- Icons and images
- CSS (Bootstrap, bootstrap-icons, app styles)
- `staticwebapp.config.json` (for SPA route fallback/static hosting)
- `nginx.conf`
- `Dockerfile` (for containerized/static deployment)

---

### 📌 Root Files

- `Program.cs` – Configures DI and HTTP client setup
- `App.razor`
- `_Imports.razor`

---

# ⭐ Core Features

## 🎬 Movies Browsing

- `Pages/Movies.razor` – Displays a collection of movies
- `Pages/Details.razor` – Shows extended movie information  
  (likely using `Model/MovieDetails.cs` and `Model/MovieIMG.cs`)

---

## 👤 Authentication & User Management

- Login: `Pages/Login.razor`
- Registration: `Pages/RegistrationPage.razor`
- Authentication state managed via:
  - `SimpleAuthenticationStateProvider.cs`
  - `IAuthManager.cs`
  - `AuthManagerImpl.cs`

---

## ❤️ Favourites

- `Pages/FavouritePage.razor`
- `Pages/FavouriteDetails.razor`
- Backend communication via `Services/FavouriteService.cs`

---

## 💬 Comments

- Managed through `Services/CommentService.cs`
- Communicates with backend comment endpoints

---

# 🛠 Development Tooling

## 📘 Swagger (Backend)

When running in development mode:

- Swagger UI is enabled
- Allows API inspection and manual endpoint testing

---

## 🔄 CORS

Backend CORS configuration allows cross-origin requests from the frontend, which is required when:

- Developing locally
- Hosting frontend and backend separately

---

# 🚀 Deployment Notes (High Level)

- Frontend includes:
  - `Dockerfile`
  - `nginx.conf`  
  → Can be built as static assets and served via **Nginx**
- `wwwroot/staticwebapp.config.json`  
  → Indicates compatibility with static hosting platforms requiring SPA route fallback configuration

---

# 📂 Directory Snapshot (Frontend)

```

FrontendBlazorWebAssembly/
│
├── Pages/            # App screens
├── Shared/           # Layout/navigation components
├── Services/         # Typed API client services
├── Authentication/   # Auth state and logic
├── Model/            # DTOs / View models
└── wwwroot/          # Static assets and styling

```

---

# 📌 Summary

**SEP6_IMDB** combines:

- An **ASP.NET Core Web API** backend  
  - EF Core  
  - Swagger  
  - CORS  
  - Scoped DAO abstractions  

with:

- A **Blazor WebAssembly** frontend  
  - Pages  
  - Typed service layer  
  - Authentication state management  

Together, they deliver an IMDb-style experience featuring:

- Movie browsing  
- Movie details  
- Login & registration  
- Favourites management  
- Comments system  
```
