import React from 'react';

const ListofPlayers = () => {
    const players =[
        { name: "Jack", score: 50 },
        { name: "Michael", score: 70},
        { name: "John", score: 40},
        { name: "Ann", score: 61},
        { name: "Elisabeth", score: 61},
        { name: "Sachin", score: 95},
        { name: "Dhoni", score: 100},
        { name: "Virat", score: 84},
        { name: "Jadeja", score: 64},
        { name: "Raina", score: 75},
        { name: "Rohit", score: 80}

    ];
    const filteredPlayers = players.filter(player => player.score < 70);
    return (
    <div>
      <h2>All Players</h2>
      <ul>
        {players.map((player, index) => (
          <li key={index}>{player.name} - {player.score}</li>
        ))}
      </ul>

      <h3>Players with Score below 70</h3>
      <ul>
        {filteredPlayers.map((player, index) => (
          <li key={index}>{player.name} - {player.score}</li>
        ))}
      </ul>
    </div>
  );
};

export default ListofPlayers;