'use strict';
import { products } from "./api.js";
import * as slider from "./slider.js";
import * as nav from "./navbar.js";
import * as theme from "./switchTheme.js";
import * as filter from "./filter.js";

const productsList = products; 
const HostUrl = "https://clothickapi20240124181857.azurewebsites.net";
const productsDiv = document.querySelector('.pro-container[attribute="api"]');

// Using an IIFE (Immediately Invoked Function Expression) to use async/await
(async () => {
    for (const prd of productsList) {
        try {
            const response = await fetch(`${HostUrl}/products/${prd.id}/variants/distinct`);
            if (!response.ok) 
                throw new Error('Network response was not ok.');

            const data = await response.json();
            const productVariants = [];
            data.forEach(variant => productVariants.push(variant));

            productVariants.forEach(prv => {

                let imageUrl = `${HostUrl}/${prv.images[0]}`;
                let stars = 0;
                let averageRating = 0;
                if (prd.productRatings && prd.productRatings.length > 0) {
                    averageRating = prd.productRatings.reduce((acc, rating) => acc + rating.starRating, 0) / prd.productRatings.length;
                    stars = Array(Math.round(averageRating)).fill('<i class="fas fa-star"></i>').join('');
                }
    
                productsDiv.innerHTML += `
                <div class="pro" onclick="window.location.href='sproduct.html?productId=${prd.id}&variantId=${prv.id}';">
                        <img src="${imageUrl}" alt="${prd.brandName}">
                        <div class="des">
                            <span>${prd.brandName}</span>
                            <h5>${prd.categoryName}</h5>
                            <h4 class="productTitle">${prd.title}</h4>
                            <div class="start">${stars}</div>
                            <h4 class="price">$${prd.price}</h4>
                        </div>
                        <a href="#"><i class="fa-solid fa-cart-shopping cart"></i></a>
                    </div>
                `;

            })

           
        } catch (error) {
            console.error('Error:', error);
        }
    }
})();
