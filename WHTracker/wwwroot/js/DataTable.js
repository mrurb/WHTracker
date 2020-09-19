$(document).ready(function () {

    $.fn.dataTable.render.ISK = function () {
        return function (data, type, row) {
            if (type === 'display') {
                return abbreviateNumber(data) + " ISK";
            }

            // Search, order and type can use the original data
            return data;
        };
    };

    var table = $('#whdata').DataTable({
        scrollY: 650,
        scrollY: '69VH',
        scrollCollapse: true,
        dom: "<'row'<'col-sm-12 col-md-1'l><'col-sm-12 col-md-1 dmpickplace'><'col-sm-12 col-md-1 dpick'><'col-sm-12 col-md-2 capick'><'col-sm-12 col-md-7'f>>" +
            "<'row'<'col-sm-12'tr>>" +
            "<'row'<'col-sm-12 col-md-5'i><'col-sm-12 col-md-7'p>>",
        "deferRender": true,
        "lengthMenu": [10, 20, 30, 60, 120],
        pageLength: 30,
        ajax: "/api/Aggregate/corporation/day/" + date,
        "order": [[6, "desc"]],
        columns: [
            {
                "className": 'details-control',
                "orderable": false,
                "data": null,
                "defaultContent": ''
            },
            {
                render: {
                    display: function(data, type, row) {
                        var catype = $("#CAType").val() == "Corporation" ? "corporations" : "alliances";
                        var zkcatype = $("#CAType").val() == "Corporation" ? "corporation" : "alliance";
                        var ca = $("#CAType").val() == "Corporation" ? row.corporation : row.alliance;
                        var imageURL = ca.id < 98000000 ? 'https://images.evetech.net/alliances/1/logo?size=32' : 'https://images.evetech.net/' + catype + '/' + ca.id + '/logo?size=32';

                        return '<a href="https://zkillboard.com/' + zkcatype + '/' + ca.id + '/" target="_Blank"><img height="24px" src="' + imageURL + '" data-/> ' + ca.name+  '</a>';
                    },
                    _: function (data, type, row) {
                        var ca = $("#CAType").val() == "Corporation" ? row.corporation : row.alliance;
                        return ca.name + " " + ca.ticker;
                    }
                }
            },
            {
                render: function (data, type, row) {
                    if (row.lossesTotal == 0) {
                        return (row.killsTotal / 1).toFixed(2);
                    }
                    return (row.killsTotal / row.lossesTotal).toFixed(2);
                },
                orderSequence: ["desc", "asc"]
            },
            {
                "data": "killsTotal",
                orderSequence: ["desc", "asc"]
            },
            {
                "data": "lossesTotal",
                orderSequence: ["desc", "asc"]
            },
            {
                render: function (data, type, row) {
                    if (row.iskLostTotal == 0) {
                        return (row.iskKilledTotal / 1).toFixed(2);
                    }
                    return (row.iskKilledTotal / row.iskLostTotal).toFixed(2);
                },
                orderSequence: ["desc", "asc"]
            },
            {
                "data": "iskKilledTotal",
                render: $.fn.dataTable.render.ISK(),
                orderSequence: ["desc", "asc"]
            },
            {
                "data": "iskLostTotal",
                render: $.fn.dataTable.render.ISK(),
                orderSequence: ["desc", "asc"]
            },
            {
                "data": "damageDealtTotal",
                orderSequence: ["desc", "asc"]
            },
            {
                "data": "damageTakenTotal",
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
    $(".picker").change(function () {
        table.ajax.url("/api/Aggregate/" + $("#CAType").val() + "/" + $("#DMPick").val() + "/" + $("#date").val()).load();

    })
    $("#date")[0].value = getDay();


    $("#DMPick").change(function () {
        if ($("#DMPick").val() == "month") {
            $("#date")[0].type = "month";
            $("#date")[0].value = getMonth();
        } else {
            $("#date")[0].type = "date";
            $("#date")[0].value = getDay();
        }
        table.ajax.url("/api/Aggregate/" + $("#CAType").val() + "/" + $("#DMPick").val() + "/" + $("#date").val()).load();

    })


});
//End Setup


var SI_SYMBOL = ["", "K", "M", "B", "T", "P", "E"];

function abbreviateNumber(number) {

    // what tier? (determines SI symbol)
    var tier = Math.log10(number) / 3 | 0;

    // if zero, we don't need a suffix
    if (tier == 0) return number;

    // get suffix and determine scale
    var suffix = SI_SYMBOL[tier];
    var scale = Math.pow(10, tier * 3);

    // scale the number
    var scaled = number / scale;

    // format number and add suffix
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
