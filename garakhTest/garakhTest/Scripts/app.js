$(document).ready(function () {

var grid = $("#grid-data").bootgrid({
    ajax: true,
    ajaxSettings: {
        method: "GET",
        cache: false
    },
    rowCount: -1,
    url: window.location.origin + '/api/values',
    formatters: {
        "commands": function (column, row) {
            return "<button type=\"button\" class=\"btn btn-xs btn-default command-edit\" data-row-id=\"" + row.Id + "\"><img src=\"https://img.icons8.com/material/24/000000/edit.png\"></button> " +
                "<button type=\"button\" class=\"btn btn-xs btn-default command-delete\" data-row-id=\"" + row.Id + "\"><img src=\"https://img.icons8.com/material/24/000000/filled-trash.png\"></button>";
        }
    }
}).on("loaded.rs.jquery.bootgrid", function () {
    /* Executes after data is loaded and rendered */
    grid.find(".command-edit").on("click", function (e) {
        alert("You pressed edit on row: " + $(this).data("row-id"));
    }).end().find(".command-delete").on("click", function (e) {
        var a = window.location.origin + '/api/values/' + $(this).data("row-id");
        $.ajax({
            url: window.location.origin + '/api/values/' + $(this).data("row-id"),
            type: 'DELETE',
            success: function (result) {
                $("#grid-data").bootgrid("reload");
            }
        });
    });
});

});


