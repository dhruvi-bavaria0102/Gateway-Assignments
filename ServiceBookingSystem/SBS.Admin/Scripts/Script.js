$(function () {  
    $("#jqGrid").jqGrid({  
        url: "/Admin/GetCustomer",  
        datatype: 'json',  
        mtype: 'Get',  
        colNames: ['ID', 'Customer Name', 'Address', 'Contact', 'Zipcode', 'Home Contact','EmailID','Password','Problem'],  
        colModel: [  
            { key: true, hidden: true, name: 'ID', index: 'ID', editable: true },  
            { key: false, name: 'Name', index: 'Name', editable: true },  
            { key: false, name: 'Address', index: 'Address', editable: true },  
            { key: false, name: 'Zipcode', index: 'Zipcode', editable: true },  
            { key: false, name: 'Contact', index: 'Contact', editable: true },  
            { key: false, name: 'HomeContact', index: 'HomeContact', editable: true },
        { key: false, name: 'EmailID', index: 'EmailID', editable: true },
        { key: false, name: 'Password', index: 'Password', editable: true },
        { key: false, name: 'Problem', index: 'Problem', editable: true }],  
        pager: jQuery('#jqControls'),  
        rowNum: 10,  
        rowList: [10, 20, 30, 40, 50],  
        height: '100%',  
        viewrecords: true,  
        caption: 'Customer Records',  
        emptyrecords: 'No Customer Records are Available to Display',  
        jsonReader: {  
            root: "rows",  
            page: "page",  
            total: "total",  
            records: "records",  
            repeatitems: false,  
            Id: "0"  
        },  
        autowidth: true,  
        multiselect: false 
    }).navGrid('#jqControls', { edit: true, add: true, del: true, search: false, refresh: true },
        {
            zIndex: 100,
            url: '/Admin/Edit',
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
            url: "/Admin/Create",
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
            url: "/Admin/Delete",
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
   
 