import React from "react";

const IndianPlayers = () => {
  const allPlayers = [
    "Virat Kohli", "Rohit Sharma", "KL Rahul", "Shubman Gill",
    "Ravindra Jadeja", "Hardik Pandya", "Rishabh Pant",
    "Jasprit Bumrah", "Mohammed Shami", "Axar Patel", "Chahal"
  ];

  const oddTeam = [];
  const evenTeam = [];

  allPlayers.forEach((player, index) => {
    if ((index + 1) % 2 === 0) {
      evenTeam.push(player);
    } else {
      oddTeam.push(player);
    }
  });

  const T20players = ["Suryakumar Yadav", "Ishan Kishan"];
  const RanjiTrophyPlayers = ["Mayank Agarwal", "Karun Nair"];

  const mergedPlayers = [...T20players, ...RanjiTrophyPlayers];

  return (
    <div>
      <h2>Odd Team Players</h2>
      <ul>
        {oddTeam.map((player, index) => <li key={index}>{player}</li>)}
      </ul>

      <h2>Even Team Players</h2>
      <ul>
        {evenTeam.map((player, index) => <li key={index}>{player}</li>)}
      </ul>

      <h2>Merged T20 + Ranji Trophy Players</h2>
      <ul>
        {mergedPlayers.map((player, index) => <li key={index}>{player}</li>)}
      </ul>
    </div>
  );
};

export default IndianPlayers;
