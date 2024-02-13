$(function () {
    $("#datatable").DataTable({
        dom: 'Bfrtip',
        "responsive": true, "lengthChange": false, "autoWidth": false
        /*,"buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]*/
    }).buttons().container().appendTo('#datatable_wrapper .col-md-8:eq(0)');



    if ($.fn.dataTable.isDataTable('.datatable')) {
        table = $('.datatable').DataTable({
            //dom: 'Bfrtip',
            /*"buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"],*/
            "paging": true,
            "lengthChange": false,
            "searching": false,
            "ordering": true,
            "autoWidth": false,
            "responsive": true,
            "pageLength": 30,
            order: [[0, "ASC"]]
        });
    }
    else {
        table = $('.datatable').DataTable({
            //dom: 'Bfrtip',
            /*"buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"],*/
            "paging": true,
            "lengthChange": false,
            "searching": false,
            "ordering": true,
            "autoWidth": false,
            "responsive": true,
            "pageLength": 30,
            order: [[0, "ASC"]]
        });
    }


    //$('.datatable').DataTable({
    //    //dom: 'Bfrtip',
    //    /*"buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"],*/
    //    "paging": true,
    //    "lengthChange": false,
    //    "searching": false,
    //    "ordering": true,
    //    "autoWidth": false,
    //    "responsive": true,
    //    "pageLength": 30,
    //    order: [[0, "ASC"]]
    //});
    //$('.datatable2').DataTable({
    //    //dom: 'Bfrtip',
    //    /*"buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"],*/
    //    "paging": true,
    //    "lengthChange": false,
    //    "searching": false,
    //    "ordering": true,
    //    "autoWidth": false,
    //    "responsive": true,
    //    "pageLength": 30,
    //    order: [[0, "ASC"]]
    //});
});
