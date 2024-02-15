'use strict'

const HostUrl = "https://clothickapi20240124181857.azurewebsites.net";
const productsSection = document.getElementById("prodetails");
const productVariants = [];
let productIdGlobal;


document.addEventListener('DOMContentLoaded', async () => {

    const { products } = await import('./api.js');
    const urlParams = new URLSearchParams(window.location.search);
    const productId = urlParams.get('productId');
    const productVariantId = urlParams.get('variantId');

    if (productId) {
        await getProductVariants(productId, products, productVariantId);
    } else {
        console.error('No product ID found in URL');
    }
});


async function getProductVariants(productId, products, productVariantId) {
    try {
        const response = await fetch(`${HostUrl}/products/${productId}/variants/distinct`);
        if (!response.ok) {
            throw new Error('Network response was not ok.');
        }
        const data = await response.json();
    
        // Clear previous data and add new variants
        productVariants.length = 0;
        data.forEach(variant => productVariants.push(variant));


        const selectedVariant = productVariantId 
        ? productVariants.find(v => v.id == productVariantId) 
        : productVariants[0];

        console.log(selectedVariant)

        let mainImageUrl = `${HostUrl}${selectedVariant.images[0]}`;
        
        // Start with the main image
        let imagesHtml = `
            <div class="single-pro-image">
                <img src="${mainImageUrl}" width="100%" id="MainImg" alt="">  
                <div class="small-img-group">`;
        
        // Add each additional image
        selectedVariant.images.forEach((image, index) => {
                let imageUrl = `${HostUrl}${image}`;
                imagesHtml += `
                    <div class="small-img-col">
                        <img src="${imageUrl}" width="100%" class="small-img" alt="">
                    </div>`;
            
        });
        
        // Close the div for small-img-group
        imagesHtml += `</div></div>`;
 
        productsSection.innerHTML += imagesHtml;

        const sizes = await fetchProductSizes(productId);

        // Generate options for sizes
        let sizeOptions = sizes.map(size => `<option>${size}</option>`).join('');

        const product = products.find(p => p.id == productId);

        const currentProductVariant = productVariants.find(pv => pv.id == productVariantId) 

        productsSection.innerHTML += `
        <div  class="single-pro-details" >
            <h6>${product.categoryName}</h6>
            <h4>${product.brandName}</h4>
            <h4 class="productTitle">${product.title}</h4>
            <h2>${product.price}$</h2>
            <select>${sizeOptions}</select>
            <input type="number" value="1">
            <button class="normal">Add To Cart</button>
            <h4>Product Details</h4>
            <span>${product.description}</span>  
            <h5 class="product-color">Color ${selectedVariant.color}</h5>
            <h5>Stock: ${currentProductVariant.stock}</h5>
         </div>
        `
        attachClickHandlersToImages();

        const productVariantsClass = document.getElementById("productVariantsContainer");

        productVariants.forEach(prv => {
       
            console.log(prv.images[0])
            let imageUrl = `${HostUrl}/${prv.images[0]}`;
            let stars = 0; 
            let averageRating = 0;
            if (product.productRatings && product.productRatings.length > 0) {
               averageRating = product.productRatings.reduce((acc, rating) => acc + rating.starRating, 0) / product.productRatings.length;
           }
            if (product.productRatings && product.productRatings.length > 0) {
                stars = Array(Math.round(averageRating)).fill('<i class="fas fa-star"></i>').join('');
            }
        
        productVariantsClass.innerHTML += `
        <div class="pro" onclick="window.location.href='sproduct.html?productId=${productId}&variantId=${prv.id}';">
                <img src="${imageUrl}" alt="${product.brandName}">
            <div class="des">
                    <span>${product.brandName}</span>
                    <h5>${product.categoryName}</h5>
                    <h4 class="productTitle">${product.title}</h4>
                <div class="start"> 
                    ${stars}
                </div>
                <br>
                <h4>$${product.price}</h4>
            </div>
            <a href="#"><i class="fa-solid fa-cart-shopping cart"></i></a>
         </div>
        `
    })
    
        

    } catch (error) {
        console.error('Error fetching product variants:', error);
    }
}

function attachClickHandlersToImages() {
    // Check if the small images are available in the DOM
    const smallImgElements = document.querySelectorAll(".small-img");
    if (smallImgElements.length === 0) {
        console.error("No small images found");
        return;
    }

    smallImgElements.forEach(img => {
        img.onclick = () => {
            const MainImg = document.getElementById("MainImg"); 
            MainImg.src = img.src;
        };
    });
}


async function fetchProductSizes(productId) {
    const response = await fetch(`${HostUrl}/product/${productId}/productvariant/Size`);
    if (!response.ok) {
        throw new Error('Network response was not ok.');
    }
    const sizes = await response.json();
    return sizes; 
}




