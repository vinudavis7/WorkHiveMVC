function saveBid() {

    var proposal = JSON.stringify({
        "JobId": $("#JobId").val(),
        "BidAmount": $("#bidAmount").val(),
        "ExpectedDate": $("#days").val(), 
        "Description": $("#description").val(),
        "Status":"Pending"
    });
    $.ajax({
        type: "POST",
        url: "/Jobs/SaveBid",
        data: proposal,
        dataType: "json" , 
        contentType: 'application/json',
        success: function (data) {
            if (data == true) {
                alert("Bid submitted successfully")
                $('#myModalproposal').hide();
                $('.modal-backdrop').remove()
            }
            else
                alert("Operation failed")
        },
        error: function () {
            alert("Error occured!!")
        }
    });
}

function search() {
    var searchTitle = $("#searchTitle").val();
    var searchLocation = $("#searchLocation").val();
    $("#loader").show()
    var search = JSON.stringify({
        "SearchLocation": searchLocation ,
        "SearchTitle": searchTitle,
        "SearchJobType": "",
        "ClientID":0,

    });
    console.log(search)

    $.ajax({
        type: "POST",
        url: "/Jobs/Search",
        //dataType: "json",
        data: search,
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        success: function (data) {
            $("#search-result").empty();
            $("#search-result").append(data)
            $("#loader").hide()        },
        error: function (data) {
            console.log(data)
            alert("Error occured!!")
            $("#loader").hide()   
        }
    });


}
