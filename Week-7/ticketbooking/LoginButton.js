import React from 'react';

function LoginButton(props) {
  return (
    <button onClick={props.onClick} style={{ marginBottom: '20px' }}>
      Login
    </button>
  );
}

export default LoginButton;
