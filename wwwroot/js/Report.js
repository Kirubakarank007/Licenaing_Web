$(document).ready(function () {

    function applyAlternateColors() {
        $(".data-container:visible").each(function (index) {
            var rowColor = index % 2 === 0 ? "white" : "#eceef1";
            $(this).css("background-color", rowColor);
        });
    }

    function updateRecordCount() {
        var visibleCount = $(".data-container:visible").length;
        var totalCount = $(".data-container").length;
        $("#show").text(`Showing 1 to ${visibleCount} of ${totalCount} entries`);
        $("#shows").text(`Showing 1 to ${visibleCount} of ${totalCount} entries`);
    }

    //function addInputFields() {
    //    $(".data-container").each(function () {
    //        var hasParam = $(this).attr("data-has-param") === "true";

    //        // Remove existing input fields before adding new ones
    //        $(this).find("input").remove();

    //        if (hasParam) {
    //            $(this).find(".parameter").after('<input type="text" class="param-input" placeholder="Enter value">');
    //        }
    //    });
    //}

    $("#categoryFilter").change(function () {
        var selectedCategory = $(this).val().trim().toLowerCase();

        $(".data-container").each(function () {
            var rowCategory = $(this).attr("data-category").trim().toLowerCase();
            if (selectedCategory === "all" || rowCategory === selectedCategory) {
                $(this).show();
            } else {
                $(this).hide();
            }
        });
        //addInputFields();
        updateRecordCount();
        applyAlternateColors();
    });
    //addInputFields();
    applyAlternateColors();
});
