/*------------Products-------------*/
        $(document).ready(function () {
            // Show/hide the dropdown when "Product Operations" button is clicked
            $("#product-operations-btn").click(function () {
                $(".product-operations-dropdown").slideToggle("fast");
            });

            // Hide the dropdown when clicking outside of it
            $(document).on("click", function (event) {
                var dropdown = $(".product-operations-dropdown");
                var button = $("#product-operations-btn");

                // Check if the click event was outside the dropdown and the button
                if (!dropdown.is(event.target) && dropdown.has(event.target).length === 0 &&
                    !button.is(event.target) && button.has(event.target).length === 0) {
                    dropdown.hide("fast");
                }
            });
        });
/*------------Providers-------------*/

        $(document).ready(function () {
            // Show/hide the dropdown when "Product Operations" button is clicked
            $("#provider-operations-btn").click(function () {
                $(".provider-operations-dropdown").slideToggle("fast");
            });

            // Hide the dropdown when clicking outside of it
            $(document).on("click", function (event) {
                var dropdown = $(".provider-operations-dropdown");
                var button = $("#provider-operations-btn");

                // Check if the click event was outside the dropdown and the button
                if (!dropdown.is(event.target) && dropdown.has(event.target).length === 0 &&
                    !button.is(event.target) && button.has(event.target).length === 0) {
                    dropdown.hide("fast");
                }
            });
        });
/*------------Users-------------*/

        $(document).ready(function () {
            // Show/hide the dropdown when "Product Operations" button is clicked
            $("#user-operations-btn").click(function () {
                $(".user-operations-dropdown").slideToggle("fast");
            });

            // Hide the dropdown when clicking outside of it
            $(document).on("click", function (event) {
                var dropdown = $(".user-operations-dropdown");
                var button = $("#user-operations-btn");

                // Check if the click event was outside the dropdown and the button
                if (!dropdown.is(event.target) && dropdown.has(event.target).length === 0 &&
                    !button.is(event.target) && button.has(event.target).length === 0) {
                    dropdown.hide("fast");
                }
            });
        });
/*------------Purchase Orders-------------*/

$(document).ready(function () {
    // Show/hide the dropdown when "Product Operations" button is clicked
    $("#purchaseOrders-operations-btn").click(function () {
        $(".purchaseOrders-operations-dropdown").slideToggle("fast");
    });

    // Hide the dropdown when clicking outside of it
    $(document).on("click", function (event) {
        var dropdown = $(".purchaseOrders-operations-dropdown");
        var button = $("#purchaseOrders-operations-btn");

        // Check if the click event was outside the dropdown and the button
        if (!dropdown.is(event.target) && dropdown.has(event.target).length === 0 &&
            !button.is(event.target) && button.has(event.target).length === 0) {
            dropdown.hide("fast");
        }
    });
});

/*------------Receipts-------------*/

$(document).ready(function () {
    // Show/hide the dropdown when "Product Operations" button is clicked
    $("#receipts-operations-btn").click(function () {
        $(".receipts-operations-dropdown").slideToggle("fast");
    });

    // Hide the dropdown when clicking outside of it
    $(document).on("click", function (event) {
        var dropdown = $(".receipts-operations-dropdown");
        var button = $("#receipts-operations-btn");

        // Check if the click event was outside the dropdown and the button
        if (!dropdown.is(event.target) && dropdown.has(event.target).length === 0 &&
            !button.is(event.target) && button.has(event.target).length === 0) {
            dropdown.hide("fast");
        }
    });
});
/*------------Invoices-------------*/

$(document).ready(function () {
    // Show/hide the dropdown when "Product Operations" button is clicked
    $("#invoices-operations-btn").click(function () {
        $(".invoices-operations-dropdown").slideToggle("fast");
    });

    // Hide the dropdown when clicking outside of it
    $(document).on("click", function (event) {
        var dropdown = $(".invoices-operations-dropdown");
        var button = $("#invoices-operations-btn");

        // Check if the click event was outside the dropdown and the button
        if (!dropdown.is(event.target) && dropdown.has(event.target).length === 0 &&
            !button.is(event.target) && button.has(event.target).length === 0) {
            dropdown.hide("fast");
        }
    });
});