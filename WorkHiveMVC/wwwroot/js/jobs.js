function saveProposal() {

    var proposal = JSON.stringify({
        "JobId": $("#JobId").val(),
        //"FreelancerId": "1",
        "BidAmount": $("#bidAmount").val(),
        "NumberOfDays": $("#days").val(), 
        "ProposalDescription": $("#description").val(),

    });
    $.ajax({
        type: "POST",
        url: "/Jobs/SaveProposal",
        data: proposal,
        dataType: "json" , 
        contentType: 'application/json',
        success: function (data) {
            if (data == true) {
                alert("Proposal submitted successfully")
                $('#myModal').hide();
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
