$(document).ready(function () {

    function loadContent(url) {
        $.ajax({
            url: url,
            type: "GET",
            success: function (response) {
                $("#container-right").html(response);
                window.history.pushState({ path: url }, "", url);
                $(".menu-link").removeClass("active-link");

                $(".menu-link").each(function () {
                    if ($(this).data("url") === url) {
                        $(this).addClass("active-link");
                    }
                });
            },
        });
    }

    if (section) {
        loadContent("/Admin/" + section);
        //$(".menu-link").addClass("active-link");
    }

    $(".menu-link").click(function (e) {
        e.preventDefault();
        $(".menu-link").removeClass("active-link");
        var url = $(this).data("url");
        console.log(url);
        loadContent(url);
    });

    $("#importFileBtn").click(function () {
        var fileInput = document.getElementById("myFile");
        var file = fileInput.files[0];
        var fileType = $("#categoryFilter").val();

        if (!file || fileType === "all") {
            alert("Please select a file and a file type.");
            return;
        }

        var records = prompt("Enter the number of records:");

        if (!records || isNaN(records) || parseInt(records) <= 0) {
            alert("Please enter a valid number of records.");
            return;
        }

        var formData = new FormData();
        formData.append("file", file);
        formData.append("fileType", fileType);
        formData.append("record", records.trim().toString());

        $.ajax({
            url: "/api/importdata/upload",
            type: "POST",
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                alert(response.message);
                location.reload(); // Refresh the page to show the new entry
            },
            error: function (xhr) {
                alert("Error uploading file: " + xhr.responseText);
            }
        });
    });


    $(document).on("click", ".delete-btn", function () {  // Changed selector to class
        var recordId = $(this).data("id");
        console.log("Deleting record with ID:", recordId);

        if (!recordId) {
            alert("Record ID is missing!");
            return;
        }

        if (!confirm("Are you sure you want to delete this record?")) {
            return;
        }

        $.ajax({
            url: `/api/importdata/delete/${recordId}`,
            type: "DELETE",
            success: function (res) {
                alert(res.message);
                location.reload();
            },
            error: function (err) {
                alert("Error deleting record: " + err.responseText);
            }
        });
    });
});
