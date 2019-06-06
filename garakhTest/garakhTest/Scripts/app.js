$("#grid-data").bootgrid({
    ajax: true,
    ajaxSettings: {
        method: "GET",
        cache: false
    },
    url: window.location.origin + '/api/values',
    formatters: {
        "link": function (column, row) {
            return "<a href=\"#\">" + column.id + ": " + row.id + "</a>";
        }
    }
});