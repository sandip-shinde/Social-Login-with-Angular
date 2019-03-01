import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter } from 'react-router-dom';
import './index.css';
import './assets/Styles/bootstrap.min.css';
import registerServiceWorker from './registerServiceWorker';

import App from './App';
import ErrorBoundary from './global/error-boundary';

ReactDOM.render(
    <ErrorBoundary>
        <BrowserRouter>
            <App />
        </BrowserRouter>
    </ErrorBoundary>
, document.getElementById('root'));

registerServiceWorker();
