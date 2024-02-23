// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/*!
  * Bootstrap v4.3.1 (https://getbootstrap.com/)
  * Copyright 2011-2019 The Bootstrap Authors (https://github.com/twbs/bootstrap/graphs/contributors)
  * Licensed under MIT (https://github.com/twbs/bootstrap/blob/master/LICENSE)
  */


    // Update cart items count dynamically
    function updateCartItemCount() {
        fetch('/Cart/GetCartItemsCount')
            .then(response => response.text())
            .then(count => {
                if (count > 0) {
                    document.getElementById('cartItemCount').innerText = count;
                    document.getElementById('cartItemCount').style.backgroundColor = 'red'; // Replace with your desired background color
                    document.getElementById('cartItemCount').style.color = 'white'; // Replace with your desired text color
                } else {
                    document.getElementById('cartItemCount').innerText = '';
                }
            })
            .catch(error => console.error('Error updating cart items count:', error));
    }

    // Update cart items count when the page loads
    document.addEventListener('DOMContentLoaded', updateCartItemCount);



 