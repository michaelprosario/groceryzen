function handleSearch() {
    // get key words from text box ...
    let keyWords = document.getElementById("txtSearch").value;
    if(!keyWords || keyWords.length === 0)
    {
        alert("Please provide a valid search term.")
        return;
    }

    let jsonQuery = {
        first: 1,
        rows: 300,
        page: 1,
        sortField: "",
        sortOrder: 0,
        keyword: keyWords,
        tag: ""
    }   
    console.log("query..................");
    console.log(jsonQuery);

    $.ajax({
    url:"/api/Posts/v1/Search",
    type:"POST",
    data:JSON.stringify(jsonQuery),
    contentType:"application/json",
    
    success: function(response){
        console.log(response)
        $("#divPostsArea").html(response);
    }
    })    

}
