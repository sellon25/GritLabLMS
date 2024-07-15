// Function to apply the search and filter
function applyFilter(id) {
    // Get the search input and filter value
    var searchValue = document.getElementById("txtSearch").value.toLowerCase();
    var filterValue = document.getElementById("ddlFilter").value;

    // Get the table rows
    var table = document.getElementById(id);
    var rows = table.getElementsByTagName("tr");

    // Loop through the rows and apply the filter
    for (var i = 0; i < rows.length; i++) {
        var cells = rows[i].getElementsByTagName("td");
        var showRow = true;

        var inputText = cells[0].getElementsByTagName("input")[0].value.toLowerCase();
        // Apply search filter
        if (searchValue && !inputText.includes(searchValue) &&
            !cells[1].innerText.toLowerCase().includes(searchValue) &&
            !cells[2].innerText.toLowerCase().includes(searchValue) &&
            !cells[3].innerText.toLowerCase().includes(searchValue)) {
            showRow = false;
        }

        // Apply status filter
        if (filterValue && filterValue !== "All" && cells[4].innerText !== filterValue) {
            showRow = false;
        }

        // Show or hide the row
        rows[i].style.display = showRow ? "" : "none";
    }
}

// Function to reset the search and filter
function resetFilter(id) {
    document.getElementById("txtSearch").value = "";
    document.getElementById("ddlFilter").value = "All";
    applyFilter(id);
}

// Add event listeners for the search and filter elements

//document.getElementById("ddlFilter").addEventListener("change", applyFilter););