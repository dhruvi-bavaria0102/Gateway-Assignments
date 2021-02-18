$(function () {
    $("#jqGrid").jqGrid({
        url: "/Vehicle/GetVehicle",
        datatype: 'json',
        mtype: 'Get',
        colNames: ['ID', 'License Plate', 'Make', 'Model', 'Registration Date', 'Owner Name', 'Chassis Number', 'Customer ID'],
        colModel: [
            { key: true, hidden: true, name: 'ID', index: 'ID', editable: true },
            { key: false, name: 'LicensePlate', index: 'LicensePlate', editable: true },
            { key: false, name: 'Make', index: 'Make', editable: true },
            { key: false, name: 'Model', index: 'Model', editable: true },
            { key: false, name: 'RegistrationDate', index: 'RegistrationDate', editable: true },
            { key: false, name: 'OwnerName', index: 'OwnerName', editable: true },
            { key: false, name: 'ChassisNumber', index: 'ChassisNumber', editable: true },
            { key: false, name: 'CustomerID', index: 'CustomerID', editable: true },],
        pager: jQuery('#jqControls'),
        rowNum: 10,
        rowList: [10, 20, 30, 40, 50],
        height: '100%',
        viewrecords: true,
        caption: 'Vehicle Records',
        emptyrecords: 'No Vehicle Records are Available to Display',
        jsonReader: {
            root: "rows",
            page: "page",
            total: "total",
            records: "records",
            repeatitems: false,
            Id: "0"
        },
        autowidth: true,
        multiselect: false,
    }).navGrid('#jqControls', { edit: true, add: true, del: true, search: false, refresh: true },
        {
            zIndex: 100,
            url: '/Vehicle/Edit',
            closeOnEscape: true,
            closeAfterEdit: true,
            recreateForm: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/Vehicle/Create",
            closeOnEscape: true,
            closeAfterAdd: true,
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        },
        {
            zIndex: 100,
            url: "/Vehicle/Delete",
            closeOnEscape: true,
            closeAfterDelete: true,
            recreateForm: true,
            msg: "Are you sure you want to delete Student... ? ",
            afterComplete: function (response) {
                if (response.responseText) {
                    alert(response.responseText);
                }
            }
        });
});

