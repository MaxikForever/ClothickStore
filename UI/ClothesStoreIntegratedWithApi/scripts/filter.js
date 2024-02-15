const category = document.querySelector("#category");
const searchBar = document.getElementById("search-bar");
const filter = document.getElementById("filter");
const submitButton = document.querySelectorAll("#form input")[1];


submitButton.addEventListener("click", (e) => e.preventDefault() )



const visibleProducts = () => {
    const allProducts = document.querySelectorAll(".pro");
    const visibleProducts = [];
    
    allProducts.forEach(product => {
        const style = window.getComputedStyle(product);
        if(style.display !== "none") {
            visibleProducts.push(product);
        }
    })
    return visibleProducts;
}



function filterProducts(keyword) {
    let allProducts = [];
    if(searchBar.value == "") {
       allProducts = document.querySelectorAll(".pro");
    } else {
        allProducts = visibleProducts();
    }
    
    keyword = keyword.toLowerCase();
    allProducts.forEach((product) => {
        const productTitle = product.querySelector(".des h5").innerText.toLowerCase();
        if (productTitle === keyword) {
            product.style.display = "block";
        } else {
            product.style.display = "none";
        }
    });
}


setTimeout(() => {
    // filterProducts ;

    
    let allCategoriesElement = document.querySelectorAll(".des h5");

    const allCategories = ["all"];

    allCategoriesElement.forEach(cat => {
        if(!allCategories.includes(cat.innerHTML.toLowerCase())) {
            allCategories.push(cat.innerHTML.toLowerCase());
        }    
    })

    allCategories.forEach(cat => {
        console.log("category filter")
        category.innerHTML += `<option value="${cat}">${cat}</option>`
    })


}, 2000);


category.addEventListener("change", (e) => {
    if(e.target.value === "all" || e.target.value === "") {
        const allProducts = document.querySelectorAll(".pro");
        allProducts.forEach(product => { 
            product.style.display = "block";
        })
    } else {
        filterProducts(e.target.value);
    }
})


// searchbar

searchBar.addEventListener("input", () => console.log("a") )

searchBar.addEventListener("input", searchFilter);

function searchFilter() {
    

    const allVisibleProducts = document.querySelectorAll(".pro");

    const filter = searchBar.value.toLowerCase();

    allVisibleProducts.forEach( item => {
        let text =  item.querySelector(".productTitle").innerText.toLowerCase();

        if(text.toLowerCase().includes(filter)) {
            item.style.display = "";
        } else {
            item.style.display = "none";
        }
    })

}



filter.addEventListener("change", (e) => {
    const allVisibleProducts = visibleProducts();

    if (e.target.value === "alphabetical") {
        // Create an array of objects with product text and elements
        const productArray = allVisibleProducts.map((item) => {
            const text = item.querySelector(".des .productTitle").innerText.toLowerCase();
            return { text, element: item };
        });

        // Sort the productArray based on the text
        productArray.sort((a, b) => a.text.localeCompare(b.text));

        // Reorder the elements in the DOM based on the sorted array
        productArray.forEach((product, index) => {
            product.element.style.order = index;
        });
    } else if(e.target.value === "lower") {

        const productArray = allVisibleProducts.map((item) => {
            const text = item.querySelector(".des .price").innerText.toLowerCase();
            return { text, element: item };
        });
    
        productArray.sort((a, b) => {
            const numA = parseFloat(a.text.slice(1));
            const numB = parseFloat(b.text.slice(1));
            return numA - numB;
        });

        
        productArray.forEach((product, index) => {
            product.element.style.order = index;
        });
      
    } else if(e.target.value === "higher") {
        const productArray = allVisibleProducts.map((item) => {
            const text = item.querySelector(".des .price").innerText.toLowerCase();
            return { text, element: item };
        });
    
        productArray.sort((a, b) => {
            const numA = parseFloat(a.text.slice(1));
            const numB = parseFloat(b.text.slice(1));
            return numB - numA;
        });
        
        productArray.forEach((product, index) => {
            product.element.style.order = index;
        });
    }
});
