# 🚗 AutoToll: Automotive Payment Orchestration API (PoC)

![.NET Core](https://img.shields.io/badge/.NET%2010-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-316192?style=for-the-badge&logo=postgresql&logoColor=white)
![MongoDB](https://img.shields.io/badge/MongoDB-4EA94B?style=for-the-badge&logo=mongodb&logoColor=white)
![Docker](https://img.shields.io/badge/Docker-2CA5E0?style=for-the-badge&logo=docker&logoColor=white)

## 📌 Overview
This project is a Proof of Concept (PoC) designed to validate the end-to-end orchestration of automated automotive payment scenarios. It demonstrates deterministic orchestration, rule-based evaluation, and secure integration with third-party payment APIs within a highly scalable backend environment. 

## 🎯 Key Capabilities & Architecture

* **Deterministic Rule-Based Evaluation:** Implements a scalable rules engine (using Strategy/Chain of Responsibility patterns) to calculate dynamic pricing based on vehicle type, time of day, and road conditions.
* **Third-Party API Integration:** Robust external API consumption with built-in resilience (retries, timeouts) to simulate payment processing through external gateways.
* **Polyglot Persistence (SQL + NoSQL):** * **PostgreSQL:** Handles relational data (Users, Vehicles, Core Transactions) ensuring ACID compliance.
  * **MongoDB:** Stores unstructured audit logs, raw third-party API payloads, and non-binding AI-generated scenario history.
* **High Performance & Asynchronous Flows:** Utilizes C# asynchronous programming (`async/await`) and optimized memory allocation to ensure non-blocking, high-throughput transaction processing.

## ⚙️ System Workflow (The Orchestration)
1. **Ingestion:** API receives an automotive event payload (e.g., license plate, timestamp, sensor ID).
2. **Evaluation:** The Rules Engine deterministically calculates the fee.
3. **Integration:** An asynchronous call is dispatched to a Mock Payment API to authorize the transaction.
4. **Persistence:** The transaction state is saved in PostgreSQL, while the raw request/response communication is logged in MongoDB.

## 🧪 Testing & Quality Assurance
Built with a Test-Driven Development (TDD) mindset. 
* **Unit Tests (xUnit):** Extensive coverage of the Rule-Based Evaluation engine to guarantee 100% deterministic outputs.
* **Integration Tests:** Validating the interaction between the orchestration layer, PostgreSQL, and MongoDB.

## 🚀 How to Run Locally
Provide a seamless execution experience. Use Docker Compose so the recruiter only needs one command.
```bash
docker-compose up -d