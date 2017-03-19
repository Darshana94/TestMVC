//autocomplete customer
$(document).ready(function () {
    $("#Cus_Name").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "/Test/GetCustomers",
                type: "POST",
                dataType: "json",
                data: { Prefix: request.term },
                success: function (data) {
                    response($.map(data, function (item) {
                        return { label: item.Cus_Name, value: item.Cus_Name };
                    }))

                }
            })
        },
        messages: {
            noResults: "",
            results: function (count) {
                return count + (count > 1 ? ' results' : ' result ') + ' found';
            }
        }
    });
})

//Add button click function
$('#add').click(function () {

    $.getJSON('/Test/BillList/' + $('#Customer').val(), function (data) {

        var items = '<table><tr><th>Name</th><th>Address</th></tr>';
        $.each(data, function (i, country) {
            items += "<tr><td>" + country.ContactName + "</td><td>" + country.Address + "</td></tr>";
        });
        items += "</table>";

        $('#rData').html(items);
    }, 'json');
});