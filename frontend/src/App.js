import React, { useState } from 'react';
import './App.css';

function App() {
  const [text, setText] = useState('');
  const [sentiment, setSentiment] = useState('');
  const [loading, setLoading] = useState(false);

  const checkSentiment = async () => {
    setLoading(true);
    try {
      const response = await fetch('https://localhost:32770/Sentiment/PredictSentiment', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ text }),
      });

      const data = await response.json();
      setSentiment(data.sentiment);
    } catch (error) {
      console.error('Error:', error);
      setSentiment('Error contacting server.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="container mt-5">
      <div className="card shadow">
        <div className="card-body">
          <h2 className="card-title text-center mb-4">Sentiment Analyzer</h2>
          <div className="mb-3">
            <textarea
              className="form-control"
              rows="4"
              placeholder="Enter a sentence..."
              value={text}
              onChange={(e) => setText(e.target.value)}
            ></textarea>
          </div>
          <div className="d-grid">
            <button
              className="btn btn-primary"
              disabled={loading || !text}
              onClick={checkSentiment}
            >
              {loading ? 'Analyzing...' : 'Check Sentiment'}
            </button>
          </div>
          {sentiment && (
            <div className="alert mt-4 text-center fw-bold
              alert-success" role="alert"
              style={{ backgroundColor: sentiment === 'Positive' ? '#d4edda' :
                                            sentiment === 'Negative' ? '#f8d7da' : '#e2e3e5',
                       color: sentiment === 'Positive' ? '#155724' :
                              sentiment === 'Negative' ? '#721c24' : '#383d41' }}>
              Sentiment: {sentiment}
            </div>
          )}
        </div>
      </div>
    </div>
  );
}

export default App;
