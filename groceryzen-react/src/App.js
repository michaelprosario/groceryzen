import React, { Component } from 'react';
import './App.css';
import { BrowserRouter as Router, Route } from 'react-router-dom';
import CreateShoppingList from './components/CreateShoppingList';
import ShoppingLists from './components/ShoppingLists';
import EditShoppingList from './components/EditShoppingList';

class App extends Component {
  render() {
    return (
      <Router>
        <div>
        <Route path="/" component={ ShoppingLists } exact />
        <Route path="/create-shopping-list" component={ CreateShoppingList } />
        <Route path="/edit-shopping-list/:id" component={ EditShoppingList } />
        </div>
    </Router>      
    );
  }
}

export default App;
