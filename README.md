# Parking Management System

A Parking Management Application with DevOps implementation using Docker Compose and GitHub Actions.

## Overview

This project contains a frontend and a .NET backend. Docker Compose is used to manage application containers, while GitHub Actions is configured to automate workflow tasks.

## Technologies Used

- Frontend: HTML, CSS, JavaScript
- Backend: ASP.NET Core / .NET
- Database: SQLite
- Containerization: Docker
- Container Management: Docker Compose
- CI/CD: GitHub Actions
- Version Control: Git and GitHub

## Project Structure

```text
parking-management-system/
├── .github/
│   └── workflows/
│       └── main.yml
├── backend/
│   └── Dockerfile
├── frontend/
│   └── Dockerfile
├── docker-compose.yml
└── README.md
```

## DevOps Implementation

### Docker

Docker is used to containerize the application components.

### Docker Compose

Docker Compose simplifies building, starting, and managing the application services.

Start the application:

```bash
docker compose up --build
```

Run in the background:

```bash
docker compose up --build -d
```

Check running containers:

```bash
docker compose ps
```

Stop the application:

```bash
docker compose down
```

### GitHub Actions

The GitHub Actions workflow is located at `.github/workflows/main.yml`. It automates the tasks configured in the workflow file.

## Getting Started

1. Install Git and Docker Desktop.
2. Clone the repository:

   ```bash
   git clone https://github.com/hsinexa-ui/parking-management-system.git
   ```

3. Open the project folder:

   ```bash
   cd parking-management-system
   ```

4. Start the application:

   ```bash
   docker compose up --build
   ```

5. Check `docker-compose.yml` for the frontend URL and port.

## Author

Habib Ullah

DevOps | Docker | Docker Compose | GitHub Actions
