/* click handler for when a user clicks on a letter */
function letterClicked() {

    var params = {
        letterSelected: $(this).data('letter')

    };
    
    $.ajax({
        url: 'home/GuessLetter',
        type: "POST",
        data: JSON.stringify(params),
        contentType: 'application/json; charset=utf-8',
        success: function (data, textStatus, jqXHR) {
            window.location.reload();

        },
        error: function (jqXHR, textStatus, errorThrown) {
        }
    });

}

$(document).ready(function () {
    $("ul.alphabitList li").on("click", letterClicked);
});