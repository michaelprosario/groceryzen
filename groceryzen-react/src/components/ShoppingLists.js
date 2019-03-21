import React, { Component } from 'react';
import axios from 'axios';
import AppEnvironment from './AppEnvironment';

class ShoppingLists extends Component {

    constructor(props) {
        super(props);

        this.state = {
            records: [],
            isLoading: false,
            error: null
        };
    }

    loadList() {
        this.setState({ isLoading: true });

        let url = AppEnvironment.getServerRoot() + '/GroceryZen/ListShoppingLists';
        axios.get(url)
        .then(result => this.setState({
            records: result.data.records,
            isLoading: false
        }))
        .catch(error => this.setState({
            error,
            isLoading: false
        }));
    }

    archiveList(recordId) {
        let url = AppEnvironment.getServerRoot() + '/GroceryZen/ArchiveShoppingList';
        let data = {
            "Id": recordId
        }
        axios.post(url,data)
        .then(function (response) {
            window.location = window.location.href;
        })
        .catch(function (error) {
            console.log(error);
        });
    }

    onClickSelectItem(record){
        console.log(record);
    }    
    
    componentDidMount() {
        this.loadList();
    }

    onClickItemSelect(recordId) {
        window.location = "/edit-shopping-list/" + recordId;
    }

    onClickArchive(recordId, e) {
        console.log("archive " + recordId);
        this.archiveList(recordId);

        e.stopPropagation();
    }

    onClickNewShoppingList() {
        window.location = "/create-shopping-list";
    }

    render() {
        const { records, isLoading } = this.state;

        if (isLoading) {
            return <p>Loading ...</p>;
        }

        return (
            <div id="divShoppingLists">
                <button type="button"
                    className="btn btn-primary"
                    onClick={() => this.onClickNewShoppingList()}>
                    New Shopping List
                </button>

                <ul className="list-group">
                    <li className="list-group-item">My Shopping Lists</li>
                    {records.map(record =>
                    <li className="list-group-item"
                        onClick={() => this.onClickItemSelect(record.id)}
                        key={record.id}
                        >
                        {record.name}
                        <button type="button"
                                className="btn btn-secondary pull-right"
                                onClick={(e) => this.onClickArchive(record.id, e)}>
                            Archive
                            </button>

                    </li>
                    )}
                </ul>

            </div>
        );
    }
}

export default ShoppingLists;