const products = [];
async function getApiData() {
    // Fetch the data from the API and return the promise
  
   await fetch('https://clothickapi20240124181857.azurewebsites.net/Products')
        .then( res =>{
            if (res.ok) {
             return res.json()
            } else {
                console.log("Error loading api")
            }
        }) 
        .then (data => {
            data.forEach( product => {
                 products.push(product)   
            })
        })
        .catch(error => console.log("error ", error))
     
}



await getApiData();
console.log("api awaited")
export {getApiData, products}