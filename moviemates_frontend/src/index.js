import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import * as serviceWorker from './serviceWorker';
import Alert from './Components/Alert/Alert';
import { HubConnectionBuilder } from '@microsoft/signalr';

var connection = new HubConnectionBuilder().withUrl("https://localhost:5001/hub").build();

connection.on("sendToUser", (textheading, textcontext) => {
  console.log("Connected!");
  console.log(textheading + textcontext);

  ReactDOM.unmountComponentAtNode(document.getElementById('alert'));
  ReactDOM.render(<Alert title={textheading} context={textcontext} />, document.getElementById('alert'));
});
    
connection.start().catch(function (err) {
console.error(err.toString());
});



ReactDOM.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>,
  document.getElementById('root')
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
