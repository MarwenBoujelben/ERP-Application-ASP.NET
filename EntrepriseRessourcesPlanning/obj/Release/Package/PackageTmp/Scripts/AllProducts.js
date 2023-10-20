/*Script for the Search bar*/
function searchProducts() {
    var input, filter, productName, i, txtValue;
    input = document.getElementById('searchInput');
    filter = input.value.toUpperCase();

    if (filter === "") {
        // If the search input is empty, reset filteredProducts to the original array
        filteredProducts = Array.from(allProducts);
    } else {
        for (i = 0; i < filteredProducts.length; i++) {
            productName = filteredProducts[i].querySelector('h3');
            txtValue = productName.textContent || productName.innerText;

            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                // Apply yellow highlight to matched characters
                var regex = new RegExp(filter, 'ig');
                var highlightedText = txtValue.replace(regex, function (matched) {
                    return '<span class="highlight">' + matched + '</span>';
                });
                productName.innerHTML = highlightedText;

                filteredProducts[i].style.display = 'block';
            } else {
                productName.innerHTML = txtValue; // Restore original text
                filteredProducts[i].style.display = 'none';
            }
        }

        // Update filteredProducts to only include the displayed products
        filteredProducts = Array.from(document.querySelectorAll('.product-container[style="display: block;"]'));
    }

    currentPage = 1;
    showPage(currentPage, filteredProducts);
}




/*Script for Sorting products by price*/

function sortProducts() {
    var sortOption = document.getElementById('sortOption').value;
    var productsContainer = document.querySelector('.products-container');
    var products = Array.from(productsContainer.getElementsByClassName('product-container'));

    switch (sortOption) {
        case 'priceLowToHigh':
            products.sort(function (a, b) {
                var priceA = parseFloat(a.querySelector('.new-price').innerText.replace(/[^0-9.-]+/g, ''));
                var priceB = parseFloat(b.querySelector('.new-price').innerText.replace(/[^0-9.-]+/g, ''));
                return priceA - priceB;
            });
            break;
        case 'priceHighToLow':
            products.sort(function (a, b) {
                var priceA = parseFloat(a.querySelector('.new-price').innerText.replace(/[^0-9.-]+/g, ''));
                var priceB = parseFloat(b.querySelector('.new-price').innerText.replace(/[^0-9.-]+/g, ''));
                return priceB - priceA;
            });
            break;
        default:
            break;
    }

    products.forEach(function (product) {
        productsContainer.appendChild(product);
    });
}

/*Script to go up Page*/

function goToTop() {
    window.scrollTo({ top: 0, behavior: 'smooth' });
}
