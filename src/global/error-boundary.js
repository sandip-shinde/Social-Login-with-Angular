import React from 'react';

class ErrorBoundary extends React.Component {
  constructor(props) {
    super(props);
    this.state = { hasError: false, error : null };
  }

  componentDidCatch(error, info) {
    this.setState({ hasError: true, error : error });
    //console.log('MY APP REPORTED ERROR -' + error);
    //logErrorToMyService(error, info);
  }

  render() {
    if (this.state.hasError) {
      return <h1>Something went wrong: {this.state.error.toString()}</h1>;
    }
    return this.props.children;
  }
}

export default ErrorBoundary