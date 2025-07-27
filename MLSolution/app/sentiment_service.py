from app.model import SentimentModel

class SentimentService:
    def __init__(self):
        self.model = SentimentModel()

    def analyze_sentiment(self, text: str) -> str:
        return self.model.predict(text)
