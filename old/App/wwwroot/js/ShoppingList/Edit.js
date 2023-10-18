function onChange(e) {
    var rows = e.sender.select();
    rows.each(function(e) {
        var grid = $("#divProductSearchGrid").data("kendoGrid");
        var dataItem = grid.dataItem(this);
        var request = getAddShoppingListItemRequest(dataItem);
        saveShoppingListItem(request);
    })
};

function getAddShoppingListItemRequest(dataItem) {
    var id = $("#Id").val()
    var request = {
        "ShoppingId": id, 
        "ProductName": dataItem.name,
        "ProductCategory": dataItem.categoryPath,
        "UnitPrice" : dataItem.salePrice
    }

    return request;
}

function saveShoppingListItem(request){    
    $.ajax({
        url : "/shoppinglistitems/createshoppinglistitem",
        type : 'POST',
        data : request,
        dataType:'json',
        success : function(data) {              
            $("#divAddShoppingListItem").css("display", "none");
            $("#divProductSearchGrid").css("display", "none");
            loadShoppingListItems();
        },
        error : function(request,error)
        {
            alert("Request: "+JSON.stringify(request));
        }
    });        
}

function getSimpleColumn(fieldName){
    return {
        field: fieldName,
        title: fieldName
    }
}

function loadProductGrid(productRows){

    $("#divProductSearchGrid").css("display", "block");
    $("#divProductSearchGrid").kendoGrid({
        dataSource: productRows,
        groupable: false,
        sortable: true, 
        selectable: "row",    
        change: onChange,
        columns: [ 
            getSimpleColumn("name"),
            getSimpleColumn("salePrice"),
            getSimpleColumn("categoryPath") 
        ]
    });
}

function handleSearchClick(){
    var strQuery = $("#query").val();
    if(strQuery == ""){
        alert("Enter key words for product search");
        return;
    }

    $.ajax({
        url : "/shoppinglistitems/listproductsforsearch",
        type : 'GET',
        data : {
            'queryString' : strQuery
        },
        dataType:'json',
        success : function(data) {              
            loadProductGrid(data.records);
        },
        error : function(request,error)
        {
            alert("Request: "+JSON.stringify(request));
        }
    });            
}

function getShoppingListItemData() {
    var id = $("#Id").val();
    $.ajax({
        url : "/shoppinglist/listshoppinglistitems/",
        type : 'GET',
        data : {
            'Id' : id
        },
        dataType:'json',
        success : function(data) {              
            loadShoppingListItemsGrid(data.records);
        },
        error : function(request,error)
        {
            alert("Request: "+JSON.stringify(request));
        }
    });        
}

function loadShoppingListItemsGrid(data) {
    $("#divShoppingListItemsGrid").kendoGrid({
        dataSource: data,
        groupable: true,
        sortable: true, 
        selectable: "row",    
        change: onChange,
        columns: 
        [ 
            getSimpleColumn("productName"),    
            getSimpleColumn("productCategory"),
            getSimpleColumn("unitPrice"),
            getSimpleColumn("qty"),
            getSimpleColumn("price")
        ]
    });
}

function loadShoppingListItems() {
    getShoppingListItemData();
}

function addShoppingListItem(){
    $("#divAddShoppingListItem").css("display", "block");
    $("#query").val("");
    $("#query").focus();
}

$(document).ready(function(){
    loadShoppingListItems();
})