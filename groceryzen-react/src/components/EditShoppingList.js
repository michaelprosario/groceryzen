import React, { Component } from 'react';
import axios from 'axios';
import AppEnvironment from './AppEnvironment';
import ItemSearch from './ItemSearch'

class EditShoppingList extends Component {

  constructor(props) {
    super(props);
    this.state = { isLoading: true, records: [], shoppingListId: 0 };
    this.handleItemSelected = this.handleItemSelected.bind(this);
  }

  loadList(shoppingListItemId) {
    this.setState({ isLoading: true });

    let url = AppEnvironment.getServerRoot() + '/GroceryZen/ListShoppingListItems';
    let postData = {
      "ShoppingListId": shoppingListItemId
    };

    axios({
      method: 'post',
      url: url,
      data: postData
    })
    .then(result => this.setState({
      records: result.data.records,
      isLoading: false, 
      shoppingListId: shoppingListItemId
    }))
    .catch(function (error) {
      console.log(error);
    });
  }

  handleItemSelected(shoppingListId) {
    this.loadList(shoppingListId);
  }

  componentDidMount() {
    const { params } = this.props.match
    let shoppingListId = params.id;
    this.loadList(shoppingListId);
  }

  render() {
    const { isLoading, records } = this.state;
    const { params } = this.props.match
    this.shoppingListId = params.id;

    if (isLoading) {
      return <p>Loading ...</p>;
    }

    return (
      <div id="divEditShoppingList" >
        <h1>Edit Shopping List</h1>

        <ItemSearch shoppingListId={this.state.shoppingListId} 
                    itemSelected = {this.handleItemSelected} 
                    />

        <h3>Shopping List</h3>
        <button className="btn btn-primary">Add item</button>
        <table className="table table-striped table-hover">
          <thead>
            <tr>
              <th scope="col">Product</th>
              <th scope="col">Category</th>
              <th scope="col">Qty</th>
              <th scope="col">Unit Price</th>
              <th scope="col">Price</th>
            </tr>
          </thead>
          <tbody>
          {records.map(record =>
            <tr key={record.id}>
              <td>{record.productName}</td>
              <td>{record.productCategory}</td>
              <td>{record.qty}</td>
              <td>${record.unitPrice}</td>
              <td>${record.price}</td>
            </tr>
          )}

          </tbody>
        </table>

        <input id="hidShoppingListId" value={params.id} readOnly type="hidden"></input>

      </div>
    );
  }
}

export default EditShoppingList