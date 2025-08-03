import React, { useState } from 'react';
import CurrencyConvertor from './CurrencyConvertor';

function App() {
  const [count, setCount] = useState(0);

  const increment = () => {
    setCount(count + 1);
    sayHello();
  };

  const decrement = () => {
    setCount(count - 1);
  };

  const sayHello = () => {
    alert('Hello! Static message here.');
  };

  const sayWelcome = (message) => {
    alert(message);
  };

  const handleSyntheticClick = () => {
    alert('I was clicked');
  };

  return (
    <div style={{ padding: '20px' }}>
      <h1>React Event Examples</h1>

      <h2>Counter: {count}</h2>
      <button onClick={increment}>Increment</button>
      <button onClick={decrement}>Decrement</button>

      <hr />

      <button onClick={() => sayWelcome('Welcome to the React App!')}>
        Say Welcome
      </button>

      <hr />

      <button onClick={handleSyntheticClick}>
        Click Me (Synthetic Event)
      </button>

      <hr />

      <CurrencyConvertor />
    </div>
  );
}

export default App;
