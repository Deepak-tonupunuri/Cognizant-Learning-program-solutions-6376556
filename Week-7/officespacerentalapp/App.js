import React from 'react';
import './App.css';

function App() {
  // Step 1: Declare a string variable
  const element = "Office Space";

  // Step 2: Declare an image JSX element
  const sr = "https://img.freepik.com/free-photo/empty-room-with-chairs-desks_23-2149008873.jpg?semt=ais_hybrid&w=740";
  const jsxatt = <img src={sr} width="25%" height="25%" alt="Office Space" />;

  // Step 3: Declare an object for one office item
  const ItemName = {
    Name: "DBS",
    Rent: 50000,
    Address: "Chennai"
  };

  // Step 4: Conditionally apply color based on Rent
  const rentColor = ItemName.Rent < 60000 ? 'textRed' : 'textGreen';

  return (
    <div className="App">
      <h1>{element}, at Affordable Range</h1>
      {jsxatt}
      <h1>Name: {ItemName.Name}</h1>
      <h3 className={rentColor}>Rent: Rs. {ItemName.Rent}</h3>
      <h3>Address: {ItemName.Address}</h3>
    </div>
  );
}

export default App;
