$(document).ready(function () {

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
        ajax: "/api/Aggregate/corporation/day/"+date,
        "order": [[6, "desc"]],
        columns: [
        {
            "className": 'details-control',
            "orderable": false,
            "data": null,
            "defaultContent": ''
        },
        {
            render: function (data, type, row) {
                var catype = $("#CAType").val() == "Corporation" ? "corporations" : "alliances";
                var zkcatype = $("#CAType").val() == "Corporation" ? "corporation" : "alliance";
                var ca = $("#CAType").val() == "Corporation" ? row.corporation : row.alliance;
                return '<a href="https://zkillboard.com/' + zkcatype + '/' + ca.id + '/" target="_Blank"><img height="24px" src="https://images.evetech.net/' + catype + '/' + ca.id + '/logo?size=32"/> ' + ca.name + '</a>';
            },
        },
        {
            render: function (data, type, row)
            {
                if (row.lossesTotal == 0) {
                        return (row.killsTotal / 1).toFixed(2);
                }
                    return (row.killsTotal / row.lossesTotal).toFixed(2);
            }
        },
        { "data": "killsTotal" },
        { "data": "lossesTotal" },
        {
            render: function (data, type, row) {
                if (row.iskLostTotal == 0) {
                        return (row.iskKilledTotal / 1).toFixed(2);
                }
                return (row.iskKilledTotal / row.iskLostTotal).toFixed(2);
            }
        },
        {
            "data": "iskKilledTotal",
            render: $.fn.dataTable.render.number(',', '.', 0, '', ' ISK')
        },
        {
            "data": "iskLostTotal",
            render: $.fn.dataTable.render.number(',', '.', 0, '', ' ISK')
        },
        { "data": "damageDealtTotal" },
        { "data": "damageTakenTotal" },
        { "data": "rorqualKills" },
        { "data": "dreadKills" },
        { "data": "carrierKills" },
        { "data": "faxesKills" },
        { "data": "mediumStructureKills" },
        { "data": "largeStructureKills" },
        { "data": "xlStructureKills" },
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




function template(templateid, data) {
    return document.getElementById(templateid).innerHTML
        .replace(
            /{(\w.*)}/g,
            function (m, key) {
                var keys = key.split(".");
                if (keys.length > 1) {
                    if (keys[0] == "corporation" || keys[0] == "alliance") {
                        keys[0] = $("#CAType").val() == "Corporation" ? "corporation" : "alliance";
                    }
                    return data.hasOwnProperty(keys[0]) ? data[keys[0]][keys[1]] : ""
                }

                return data.hasOwnProperty(key) ? data[key] : "";
            }
        );
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
