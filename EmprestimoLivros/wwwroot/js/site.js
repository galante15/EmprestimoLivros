
$(document).ready(function () {

    $('#Emprestimos').DataTable({

        language:
        {
            "decimal": "",
            "emptyTable": "No data available in table",
            "info": "Mostando _START_ registro de  _END_ em um total _TOTAL_ entradas",
            "infoEmpty": "Showing 0 to 0 of 0 entries",
            "infoFiltered": "(filtered from _MAX_ total entries)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ entradas",
            "loadingRecords": "Loading...",
            "processing": "",
            "search": "Procurar:",
            "zeroRecords": "No matching records found",
            "paginate": {
                "first": "Primeiro",
                "last": "Último",
                "next": "Próximo",
                "previous": "Anterior"
            },
            "aria": {
                "orderable": "Order by this column",
                "orderableReverse": "Reverse order this column"
            }
        }

        

    });

    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {
            $(this).alert('close');
        })
    }, 3000)

    // setTimeout é para determinar a quantidade de tempo que ficará aberto, no caso acima é 5000
    // Após isso o $(".alert") acessa a div de alerta que está na index do empréstimo.
    //depois da um fadeOut que é tipo um estilo para sair/fechar. Depois tem o slow q significa a velocidade do estilo.
    //depois tem o que quer que esse faça, no caso acima é close que é igual a sair.
});

      