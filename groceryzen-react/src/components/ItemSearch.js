import React, { Component } from 'react';
import axios from 'axios';
import AppEnvironment from './AppEnvironment';

class ItemSearch extends Component {
    constructor(props){
      super(props);
      this.txtSearch = React.createRef();
  
      this.state = {
        records: [],
        shoppingListId: this.props.shoppingListId
      }
    }
  
    onClickSearch() {
      let searchTerm = this.txtSearch.current.value;
      let url = AppEnvironment.getServerRoot() + '/GroceryZen/ListProductsForSearch';
                                                              
      let formData = {
        "Query": searchTerm
      }
  
      axios({
        method: 'post',
        url: url,
        data: formData
      })
      .then(result => this.setState({
        records: result.data.records,
        isLoading: false,
        shoppingListId: this.props.shoppingListId
      }))
      .catch(function (error) {
        console.log(error);
      });
    }
  
    onClickSelectItem(record) {
      
      let url = AppEnvironment.getServerRoot() + '/GroceryZen/CreateShoppingListItem';
      let postData = {
        "ShoppingListId": this.props.shoppingListId,
        "ProductName": record.name,
        "ProductCategory": record.categoryPath,
        "UnitPrice": record.salePrice,
        "Qty": 1,
        "Price": record.salePrice
      };
  
      let component = this;
      let shoppingListId = this.props.shoppingListId;
  
      axios({
        method: 'post',
        url: url,
        data: postData
      })
      .then(function(result) {
        component.props.itemSelected(shoppingListId);
      })
      .catch(function (error) {
        console.log(error);
      });
  
    }
  
    render(){
      const { records, isLoading } = this.state;
  
      this.tableStyle = records.length > 0 ? {display: "block"} : {display: "none"};
  
      if(isLoading){
        return <div>Loading ...</div> 
      }
  
      return (
  
        <div id="divItemSearch">
          <h3>Item Search</h3>
          <div>Enter product search term</div>
          <div>
            <input type="text" id="txtSearch" ref={this.txtSearch}  />
            <button 
              className="btn btn-primary"
              onClick={() => this.onClickSearch() }
            >Search</button>
          </div>
          <table className="table table-striped table-hover" style={this.tableStyle}>
            <thead>
            <tr>
            <th scope="col">&nbsp;</th>
              <th scope="col"></th>
              <th scope="col">Product</th>
              <th scope="col">Category</th>
              <th scope="col">Unit Price</th>
              <th>&nbsp;</th>
            </tr>
            </thead>
            <tbody>
            {records.map(record =>
              <tr key={record.name}>
                <td>
                  <img src={record.thumbnailImage} alt="Item image"></img>
                </td>
                <td>{record.name}</td>
                <td>{record.categoryPath}</td>
                <td>${record.salePrice}</td>
                <td>
                  <button 
                    className="btn btn-primary"
                    onClick={(e) => this.onClickSelectItem(record, e)} > Select </button>
                </td>
              </tr>
            )}
  
            </tbody>
          </table>
        </div>
      );
    }
  }
  
  export default ItemSearch;