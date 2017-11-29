$(document).ready(function () {
    $("#table1").DataTable({
        "autoWidth": false

    });
    $(".dataTable").DataTable({
        "autoWidth": false,
        "aLengthMenu": [[5,10, 20, 30,50,100,500,1000,5000,10000, -1], [5,10,20,30,50,100,500,1000,5000,10000, "All"]],
        "pageLength": 5
    });

   


  
});