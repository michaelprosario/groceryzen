import React, { Component } from 'react';
import axios from 'axios';
import AppEnvironment from './AppEnvironment';

class CreateShoppingList extends Component {

    constructor(props) {
      super(props);
  
      this.state = { isLoading: true };
      this.shoppingListName = React.createRef();
    }
  
    componentDidMount() {
      this.setState({ isLoading: false });
    }

    onClickCancel()
    {
        window.location = "../";
    }

    onClickSave(){

        let name = this.shoppingListName.current.value;
        let url = AppEnvironment.getServerRoot() + '/GroceryZen/CreateShoppingList';
        let formData = {
             "Name" : name 
        };

        axios({
            method: 'post',
            url: url,
            data: formData
        })
        .then(function (response) {
          window.location = "../";
        })
        .catch(function (error) {
          console.log(error);
        });
    }
  
    render() {
      const { isLoading } = this.state;
  
      if (isLoading) {
        return <p>Loading ...</p>;
      }
  
      return (
        <div id="divShoppingListForm">            
            <div className="form-group">
                <label htmlFor="shoppingListName">Shopping List Name</label>
                <input  type="text" 
                        className="form-control" 
                        id="shoppingListName" 
                        placeholder="Enter shopping list name"
                        ref={this.shoppingListName}
                        />
            </div>
            <button className="btn btn-primary" onClick={() => this.onClickSave()}>Save</button>
            <button className="btn btn-primary" onClick={() => this.onClickCancel()}>Cancel</button>
        </div>
      );
    }
}

export default CreateShoppingList