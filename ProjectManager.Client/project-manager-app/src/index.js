import React from 'react';
import ReactDOM from 'react-dom';
import 'normalize.css';
import './index.css';
import "antd/dist/antd.css";
import { store } from './app/store';
import { Provider } from 'react-redux';
import { BrowserRouter as Router } from 'react-router-dom';
import Header from './features/header';
import RouterConfig from './navigation/RouterConfig';
import { Divider } from 'antd';

ReactDOM.render(
  <React.StrictMode>
    <Provider store={store}>
      <Router>
        <div>
          <Header />
          <Divider style={{margin: "0"}} />
        </div>
        <RouterConfig />
      </Router>
    </Provider>
  </React.StrictMode>,
  document.getElementById('root')
);
