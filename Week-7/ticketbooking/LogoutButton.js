import React from 'react';

function LogoutButton(props) {
  return (
    <button onClick={props.onClick} style={{ marginBottom: '20px' }}>
      Logout
    </button>
  );
}

export default LogoutButton;

