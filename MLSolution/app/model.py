import pandas as pd
from sklearn.feature_extraction.text import CountVectorizer
from sklearn.naive_bayes import MultinomialNB
import os

class SentimentModel:
    def __init__(self):
        self.vectorizer = CountVectorizer()
        self.model = MultinomialNB()
        self._train_model()

    def _train_model(self):
        # Determine the absolute path to the data file
        current_dir = os.path.dirname(os.path.abspath(__file__))
        data_path = os.path.join(current_dir, "..", "data", "sample_data.csv")

        # Load the data
        df = pd.read_csv(data_path)

        # Ensure proper formatting
        if "text" not in df.columns or "label" not in df.columns:
            raise ValueError("CSV must contain 'text' and 'label' columns.")

        X = self.vectorizer.fit_transform(df["text"])
        y = df["label"]
        self.model.fit(X, y)

    def predict(self, text: str) -> str:
        X = self.vectorizer.transform([text])
        prediction = self.model.predict(X)[0]
        return "Positive" if prediction == 1 else "Negative"
