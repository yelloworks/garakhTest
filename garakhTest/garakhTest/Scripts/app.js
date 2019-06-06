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
        $("#dialog-form")
            .data("itemId", $(this).data("row-id"))  // Set your data values
            .dialog("open");

    }).end().find(".command-delete").on("click", function (e) {
        $.ajax({
            url: window.location.origin + '/api/values/' + $(this).data("row-id"),
            type: 'DELETE',
            success: function (result) {
                $("#grid-data").bootgrid("reload");
            }
        });
    });
        });

    var modalData = undefined;
    $("#dialog-form").dialog({
        resizable: false,
        height: 300,
        width: 400,
        modal: true,
        autoOpen: false,
        beforeClose: function () {
            $(this).data("isNew", false)
            $("#modalName").val("");
            $("#modalGroup").val("");
        },
        open: function () {
            modalData = undefined;
            if ($(this).data("isNew") != true) {
                $.get(window.location.origin + '/api/values/' + $(this).data("itemId"), function (data, status) {
                if (status == "success") {
                    modalData = data;
                    $("#modalName").val(data.Name);
                    $("#modalGroup").val(data.Group);
                    console.log(modalData);
                };
            })
            }
            
        },
        buttons: {
            "OK": function () {
                if (modalData != undefined) {
                    modalData.Name = $("#modalName").val();
                    modalData.Group = $("#modalGroup").val();
                    $.ajax({
                        url: window.location.origin + '/api/values/' + $(this).data("itemId"),
                        type: 'PUT',
                        success: function () {
                            $("#grid-data").bootgrid("reload");
                        },
                        data: modalData,
                    });
                } 
                if ($(this).data("isNew") == true) {
                    modalData = { Id: 0, Name: $("#modalName").val(), Group: $("#modalGroup").val() };
                    $.ajax({
                        url: window.location.origin + '/api/values',
                        type: 'POST',
                        success: function () {
                            $("#grid-data").bootgrid("reload");
                        },
                        data: modalData,
                    });

                }

                $(this).dialog("close");             
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });

    $("#addBtn").click(function () {
        modalData = undefined;
        $("#dialog-form")
            .data("isNew", true)  
            .dialog("open");
    })

});


