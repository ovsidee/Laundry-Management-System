# Laundry Management System

The **Laundry Management System** is a lightweight RESTful API built with ASP.NET Core and Entity Framework Core.  
It is designed to manage **customers**, **their purchase history**, and **washing machine inventory** in a structured, consistent, and easily extendable way.  

---

## Table of Contents
- [Overview](#overview)
- [Tech Stack](#tech-stack)
- [API Endpoints](#api-endpoints)
- [Example Output](#example-output)

---

## Overview

This API acts as the backend for a simple laundry business scenario.  
It supports:
- Managing customer records and their interactions with the service.
- Registering and configuring washing machines with multiple programs.
- Tracking purchases, including dates, prices, and customer ratings.
- Providing structured JSON responses for easy integration with front-end applications or third-party services.

---

## Tech Stack

- **ASP.NET Core** – for building robust and high-performance REST APIs.  
- **C#** – the main programming language used throughout the project.  
- **Entity Framework Core** – for data persistence and interaction with the database using an ORM approach.

---

## API Endpoints

### Customers

| Method | Endpoint                        | Description                               |
|--------|----------------------------------|-------------------------------------------|
| GET    | `/api/customers/{id}/purchases` | Retrieve all purchase records for a specific customer, including machine and program details. |

### Washing Machines

| Method | Endpoint                  | Description                              |
|--------|---------------------------|------------------------------------------|
| POST   | `/api/washing-machines`   | Register a new washing machine along with its available washing programs. |

---

## Example Output

### `GET /api/customers/{id}/purchases` – Retrieve customer purchase history

```json
{
  "firstName": "John",
  "lastName": "Doe",
  "phoneNumber": null,
  "purchases": [
    {
      "date": "2025-06-03T09:00:00",
      "rating": 4,
      "price": 33.4,
      "washingMachine": {
        "serial": "WM2012/S431/12",
        "maxWeight": 32.23
      },
      "program": {
        "name": "Quick Wash",
        "duration": 69
      }
    },
    {
      "date": "2025-06-04T09:00:00",
      "rating": null,
      "price": 48.7,
      "washingMachine": {
        "serial": "WM2014/S491/28",
        "maxWeight": 52.23
      },
      "program": {
        "name": "Cotton Cycle",
        "duration": 143
      }
    }
  ]
}
```

### `POST /api/washing-machines` – Create a new washing machine

```json
{
  "washingMachine": {
    "maxWeight": 9.52,
    "serialNumber": "WM2025/S1431/13"
  },
  "availablePrograms": [
    {
      "programName": "Quick Wash",
      "price": 12.99
    },
    {
      "programName": "Cotton Cycle",
      "price": 17.29
    },
    {
      "programName": "Synthetic",
      "price": 23.99
    }
  ]
}
```
