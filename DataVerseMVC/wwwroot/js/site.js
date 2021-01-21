// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




    addCust = $('#addCustomer').on('click', () => {
        debugger;
        actionUrl = '/api/customer/'
        actiontype = 'POST'
        actionDataType = 'json'
        debugger;
        sendData = {
            'firstName': $('#FirstName').val(),
            'lastName': $('#LastName').val(),
            'email': $('#Email').val(),
            'address': $('#Address').val(),
            'telephone': $('#Telephone').val()
        }

        $.ajax({
            url: actionUrl,
            dataType: actionDataType,
            type: actiontype,
            data: JSON.stringify(sendData),
            contentType: 'application/json',
            processData: false,

            success: function (data, textStatus, jQxhr) {
                setTimeout(function () {
                    alert("Customer was added!")
                    window.open("/home/customers", "_self");
                }, 500);
            },
            error: function (jqXhr, textStatus, errorThrown) {
                console.log(errorThrown);
            }

        });
    });


    updateCustomer = $('.updateCustomer').on('click', () => {
        debugger;
        id = $("#Id").val()

        actionUrl = "/api/customer/" + id
        actiontype = "PUT"
        actionDataType = "json"

        sendData = {
            "firstName": $("#FirstName").val(),
            "lastName": $("#LastName").val(),
            "address": $("#Address").val(),
            "email": $("#Email").val(),
            "telephone": $("#Telephone").val()
        }


        $.ajax({
            url: actionUrl,
            dataType: actionDataType,
            type: actiontype,
            data: JSON.stringify(sendData),
            contentType: 'application/json',
            processData: false,

            success: function (data, textStatus, jQxhr) {
                alert("Customer was updated successfully!")
                window.open("/home/customers", "_self")
            },
            error: function (jqXhr, textStatus, errorThrown) {
                alert(errorThrown);
            }

        });

    })

function deleteCustomer() {

    id = $('#Id').val()

    actionUrl = '/api/customer/' + id
    actiontype = 'DELETE'
    actionDataType = 'json'

    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,

        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {

            alert(JSON.stringify(data))
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }

    });
}

