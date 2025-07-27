from fastapi import FastAPI
from pydantic import BaseModel
from app.sentiment_service import SentimentService

app = FastAPI()
service = SentimentService()

class TextInput(BaseModel):
    text: str

@app.post("/analyze")
def analyze_sentiment(input: TextInput):
    result = service.analyze_sentiment(input.text)
    return {"sentiment": result}
