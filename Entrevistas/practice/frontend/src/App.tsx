import { useState } from 'react';
import './App.css';

function App() {
  const [message, setMessage] = useState('');
  const [cacheKey, setCacheKey] = useState('');
  const [cachedData, setCachedData] = useState(null);
  const [loading, setLoading] = useState(false);

  const postMessage = async () => {
    setLoading(true);
    try {
      await fetch('/api/messages', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(message),
      });
      alert('Message sent to queue!');
    } catch (error) {
      console.error('Error sending message:', error);
      alert('Failed to send message.');
    }
    setLoading(false);
  };

  const getFromCache = async () => {
    setLoading(true);
    setCachedData(null);
    try {
      const response = await fetch(`/api/messages/${cacheKey}`);
      if (response.ok) {
        const data = await response.json();
        setCachedData(data);
      } else {
        alert('Cache key not found.');
      }
    } catch (error) {
      console.error('Error fetching from cache:', error);
      alert('Failed to fetch from cache.');
    }
    setLoading(false);
  };

  return (
    <div className="App">
      <h1>.NET 8 API with Queue and Cache</h1>

      <section>
        <h2>Send Message to Queue</h2>
        <input
          type="text"
          value={message}
          onChange={(e) => setMessage(e.target.value)}
          placeholder="Enter message to send"
        />
        <button onClick={postMessage} disabled={loading}>
          {loading ? 'Sending...' : 'Send to Queue'}
        </button>
      </section>

      <section>
        <h2>Get from Cache</h2>
        <input
          type="text"
          value={cacheKey}
          onChange={(e) => setCacheKey(e.target.value)}
          placeholder="Enter cache key"
        />
        <button onClick={getFromCache} disabled={loading}>
          {loading ? 'Fetching...' : 'Get from Cache'}
        </button>
        {cachedData && (
          <div>
            <h3>Result:</h3>
            <pre>{JSON.stringify(cachedData, null, 2)}</pre>
          </div>
        )}
      </section>
    </div>
  );
}

export default App;
