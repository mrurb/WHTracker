﻿$(document).ready(function () {

    var ExculdeStructure = false;
    var SortOrderArray = [[6, "desc"]];
    if (SortOrder != "") {
       var ta = []
        SortOrder.split(";").forEach(OL => ta.push(OL.split(",")));
        SortOrderArray = ta;
    }
    $.fn.dataTable.render.ISK = function (exclude) {
        return function (data, type, row, meta) {
            if (ExculdeStructure && exclude != undefined) {
                data = data - row[exclude];
            }
            if (type === 'display') {
                return abbreviateNumber(data) + " ISK";
            }

            // Search, order and type can use the original data
            return data;
        };
    };

    $.fn.dataTable.render.numberB = function (exclude) {
        return function (data, type, row) {
            if (ExculdeStructure && exclude != undefined) {
                data = data - row[exclude];
            }
            if (type === 'display') {
                return abbreviateNumber(data);
            }

            // Search, order and type can use the original data
            return data;
        };
    };

    var table = $('#whdata')
        .on('xhr.dt', function (e, settings, json, xhr) {
            $('#LastUpdated').html("Last updated: " + json.lastUpdated);
        })
        .DataTable({
            scrollY: 650,
            scrollY: '69VH',
            scrollCollapse: true, 
            dom: "<'row'<'col-sm-12 col-md-1'l><'col-sm-12 col-md-1 dmpickplace'><'col-sm-12 col-md-1 dpick'><'col-sm-12 col-md-2 capick'><'col-sm-12 col-md-1 strexc'><'col-sm-12 col-md-6'f>>" +
                "<'row'<'col-sm-12'tr>>" +
                "<'row'<'col-sm-12 col-md-5' i<'#LastUpdated' >><'col-sm-12 col-md-7'p>>",
            "deferRender": true,
            "lengthMenu": [10, 20, 30, 60, 120],
            pageLength: 30,
            ajax: "/api/Aggregate/" + ACString + "/" + DMString + "/" + date,
            "order": SortOrderArray,
            columns: [
                {
                    "className": 'details-control',
                    "searchable": false,
                    "orderable": false,
                    "data": null,
                    "defaultContent": ''
                },
                {
                    "className": '',
                    "searchable": false,
                    "orderable": false,
                    "data": "id",
                    "defaultContent": ''
                },
                {
                    render: {
                        display: function (data, type, row) {
                            var catype = $("#CAType").val() == "Corporation" ? "corporations" : "alliances";
                            var zkcatype = $("#CAType").val() == "Corporation" ? "corporation" : "alliance";
                            var ca = $("#CAType").val() == "Corporation" ? row.corporation : row.alliance;
                            var imageURL = ca.id < 98000000 ? 'https://images.evetech.net/alliances/1/logo?size=32' : 'https://images.evetech.net/' + catype + '/' + ca.id + '/logo?size=32';

                            return '<a href="https://zkillboard.com/' + zkcatype + '/' + ca.id + '/" target="_Blank"><img height="24px" src="' + imageURL + '" data-/> ' + ca.name + '</a>';
                        },
                        _: function (data, type, row) {
                            var ca = $("#CAType").val() == "Corporation" ? row.corporation : row.alliance;
                            return ca.name + " " + ca.ticker;
                        }
                    }
                },
                {
                    "data": "killsTotal",
                    render: function (data, type, row, meta) {
                        if (ExculdeStructure) {
                            data = data - row.killsStructure;
                        }
                        return type === 'display' ? data : data;
                    },
                    orderSequence: ["desc", "asc"]
                },
                {
                    "data": "lossesTotal",
                    render: function (data, type, row, meta) {
                        if (ExculdeStructure) {
                            data = data - row.lossesStructure;
                        }
                        return type === 'display' ? data : data;
                    },
                    orderSequence: ["desc", "asc"]
                },
                {
                    render: function (data, type, row) {
                        var losses = row.lossesTotal;
                        var kills = row.killsTotal;
                        if (ExculdeStructure) {
                            losses - row.lossesStructure;
                            kills - row.killsStructure;
                        }
                        return losses == 0 ? (kills / 1).toFixed(2) : (kills / losses).toFixed(2);
                    },
                    orderSequence: ["desc", "asc"]
                },
                {
                    "data": "iskKilledTotal",
                    render: $.fn.dataTable.render.ISK("iskKilledStructure"),
                    orderSequence: ["desc", "asc"]
                },
                {
                    "data": "iskLostTotal",
                    render: $.fn.dataTable.render.ISK("iskLostStructure"),
                    orderSequence: ["desc", "asc"]
                },
                {
                    "data": "damageDealtTotal",
                    render: $.fn.dataTable.render.numberB("damageDealtStructure"),
                    orderSequence: ["desc", "asc"]
                },
                {
                    "data": "damageTakenTotal",
                    render: $.fn.dataTable.render.numberB("damageTakenStructure"),
                    orderSequence: ["desc", "asc"]
                },
                {
                    "data": "lossesDic",
                    orderSequence: ["desc", "asc"]
                },
                {
                    "data": "rorqualKills",
                    orderSequence: ["desc", "asc"]
                },
                {
                    "data": "dreadKills",
                    orderSequence: ["desc", "asc"]
                },
                {
                    "data": "carrierKills",
                    orderSequence: ["desc", "asc"]
                },
                {
                    "data": "faxesKills",
                    orderSequence: ["desc", "asc"]
                },
                {
                    "data": "mediumStructureKills",
                    orderSequence: ["desc", "asc"]
                },
                {
                    "data": "largeStructureKills",
                    orderSequence: ["desc", "asc"]
                },
                {
                    "data": "xlStructureKills",
                    orderSequence: ["desc", "asc"]
                },
            ]
        });

    /*table.on('order.dt search.dt page.dt', function () {
        table.column(0, { search: 'applied', page: 'current'}).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();*/
    table.on('order.dt search.dt', function () {
        table.rows({ search: 'applied', order: 'applied' }).every(function (rowIdx, tableLoop, rowLoop) {
            var data = this.data();
            data.id = rowLoop + 1;
            this.data(data);
        });
    }).draw();

    table.on('order.dt', function () {
        ChangeUrl();
    });

    $('#whdata tbody').on('click', 'td.details-control', function () {
        var tr = $(this).closest('tr');
        var row = table.row(tr);

        if (row.child.isShown()) {
            // This row is already open - close it
            row.child.hide();
            tr.removeClass('shown');
        }
        else {
            // Open this row
            row.child(template("ChildTemplate", row.data())).show();
            tr.addClass('shown');
        }
    });
    $(".dmpickplace").html($("#cattemp")[0].innerHTML);
    $(".dpick").html($("#dmptemp")[0].innerHTML);
    $(".capick").html($("#dptemp")[0].innerHTML);
    $(".strexc").html($("#ExcludeStructure")[0].innerHTML);

    $("#ExcludeStrctureInput").change(function () {
        ExculdeStructure = !ExculdeStructure;
        table.draw();
        console.log(ExculdeStructure);

    })

    $(".picker").change(function () {
        ChangeTable();

    })
    $("#date")[0].value = date;


    $("#DMPick").change(function () {
        if ($("#DMPick").val() == "month") {
            $("#date")[0].type = "month";
            $("#date")[0].value = getMonth();
        } else {
            $("#date")[0].type = "date";
            $("#date")[0].value = getDay();
        }
        ChangeTable();
    })

    function ChangeUrl() {
        var order = table.order();
        var orderString = "";
        for (var i = 0; i < order.length; i++) {
            const newLocal = order[i][0];
            const newLocal_1 = order[i][1];
            const newLocal_2 = i == order.length-1 ? "" : ";";
            orderString += "" + newLocal + "," + newLocal_1 + newLocal_2;
        }
        var urlOptions = [$("#CAType").val(), $("#DMPick").val(), $("#date").val(), orderString]

        window.history.replaceState("", "", "/Home/Index/" + urlOptions.join("/")+"/")
    }

    function ChangeTable() {
        var urlOptions = [$("#CAType").val(), $("#DMPick").val(), $("#date").val()]
        ChangeUrl()
        table.ajax.url("/api/Aggregate/" + urlOptions.join("/")+"/").load();

    }


});
//End Setup


var SI_SYMBOL = ["", "K", "M", "B", "T", "P", "E"];

function abbreviateNumber(number) {
    var tier = Math.log10(number) / 3 | 0;
    if (tier == 0) return number;
    var suffix = SI_SYMBOL[tier];
    var scale = Math.pow(10, tier * 3);
    var scaled = number / scale;
    return scaled.toFixed(1) + suffix;
}


function abbreviateISK(number) {
    return abbreviateNumber(number) + " ISK";
}

function template(templateid, data) {
    return document.getElementById(templateid).innerHTML
        .replace(
            /{(\w.*)}/g,
            function (m, key) {
                var varible = key.split(",");
                var keys = varible[0].split(".");
                if (keys.length > 1) {
                    if (keys[0] == "corporation" || keys[0] == "alliance") {
                        keys[0] = $("#CAType").val() == "Corporation" ? "corporation" : "alliance";
                    }
                    var returnData = data.hasOwnProperty(keys[0]) ? data[keys[0]][keys[1]] : "";
                    if (varible.length > 1) {
                        return TemplateFormat(returnData, varible[1]);
                    }
                    return returnData
                }

                var returnData = data.hasOwnProperty(varible[0]) ? data[varible[0]] : "";
                if (varible.length > 1) {
                    return TemplateFormat(returnData, varible[1]);
                }
                return returnData
            }
        );
}


function TemplateFormat(number, senum) {
    switch (senum) {
        case "isk":
            return abbreviateISK(number);
        case "number":
            return abbreviateNumber(number);
        default:
            return abbreviateNumber(number);
    }
}

function getDay() {
    var date = new Date();
    var mm = date.getUTCMonth() + 1;
    return date.getUTCFullYear() + "-" + IntWithZero(mm) + "-" + IntWithZero(date.getUTCDate())
}

function getMonth() {
    var date = new Date();
    var mm = date.getUTCMonth() + 1;
    return date.getUTCFullYear() + "-" + IntWithZero(mm)
}

function IntWithZero(mm) {
    if (mm < 10) {
        mm = '0' + mm;
    }
    return mm;
}
