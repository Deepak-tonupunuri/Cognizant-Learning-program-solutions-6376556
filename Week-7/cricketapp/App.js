import React from "react";
import ListofPlayers from "./ListofPlayers";
import IndianPlayers from "./IndianPlayers";

function App() {
  const showList = true; // Set this to false to show IndianPlayers

  return (
    <div className="App">
      <h1>Cricket App</h1>
      {showList ? <ListofPlayers /> : <IndianPlayers />}
    </div>
  );
}

export default App;
