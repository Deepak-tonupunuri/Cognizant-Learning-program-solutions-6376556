import React, { useState } from 'react';

const CurrencyConvertor = () => {
  const [amount, setAmount] = useState('');
  const [currency, setCurrency] = useState('EUR');
  const [converted, setConverted] = useState(null);

  const conversionRates = {
    EUR: 0.011,
    USD: 0.012,
    GBP: 0.0095,
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const rupees = parseFloat(amount);

    if (isNaN(rupees)) {
      alert('Please enter a valid numeric amount');
      return;
    }

    const rate = conversionRates[currency];
    const result = (rupees * rate).toFixed(2);
    setConverted(`${result} ${currency}`);
  };

  return (
    <div>
      <h2>Currency Converter</h2>
      <form onSubmit={handleSubmit}>
        <div>
          <label>Amount (INR): </label>
          <input
            type="text"
            value={amount}
            onChange={(e) => setAmount(e.target.value)}
            placeholder="Enter INR amount"
          />
        </div>
        <br />
        <div>
          <label>Convert to: </label>
          <select
            value={currency}
            onChange={(e) => setCurrency(e.target.value)}
          >
            <option value="EUR">Euro (EUR)</option>
            <option value="USD">US Dollar (USD)</option>
            <option value="GBP">British Pound (GBP)</option>
          </select>
        </div>
        <br />
        <button type="submit">Convert</button>
      </form>

      {converted && (
        <h3>Converted Value: {converted}</h3>
      )}
    </div>
  );
};

export default CurrencyConvertor;
