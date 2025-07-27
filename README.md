# Complete ML Solution

This repository contains a full-stack ML-powered sentiment analysis solution:

- **frontend/** — React + Bootstrap UI
- **MiddleTier/** — .NET 8 Web API (Dockerized)
- **MLSolution/** — Python FastAPI with sentiment model

## Getting Started

1. Start FastAPI ML backend:
cd MLSolution
uvicorn app.main:app --host 0.0.0.0 --port 8000

2. Start .NET API (in Docker or locally):

cd MiddleTier
docker build -t sentimentmiddletier .
docker run -p 32770:8080 sentimentmiddletier


3. Start React frontend:

cd frontend
npm install
npm start

## Architecture

[React] → [Dockerized .NET Web API] → [FastAPI ML backend]

