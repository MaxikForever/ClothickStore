const slider = document.querySelector("#slider");
const arrowRight = document.querySelector("#arrow-right")
const arrowLeft = document.querySelector("#arrow-left")
const dotsContainer = document.querySelector(".slider__dots");
let sliderWrapper = document.querySelector(".slider__wrapper");

let width;
    if(sliderWrapper) {
        console.log("sliderWrapper")
         width = document.querySelectorAll(".slider__wrapper")[0].offsetWidth;


         let currentDot = 0; 



         const slides = [
             {
                 id: 1,
                 title: "crazy deals",
                 slogan: "buy 1 get 1 free",
                 description: "The best classic dress is on sale at cara",
                 image: "https://images.unsplash.com/photo-1610904058165-22a3b21d60d8?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1925&q=80",
                 buttonText: "Learn More",
             },
             {
                 id: 2,
                 title: "spring/summer",
                 slogan: "upcoming season",
                 description: "The best clothes are on sale at cara",
                 image: "https://images.unsplash.com/photo-1490114538077-0a7f8cb49891?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80",
                 buttonText: "Collection",
             },
             {
                 id: 3,
                 title: "",
                 slogan: "NEW FOOTWEAR COLLECTION",
                 description: "",
                 image: "/img/banner/b4.jpg",
                 buttonText: "Check Sales",
                 sale: "Spring/Summer 2023",
             },
             {
                 id: 4,
                 title: "",
                 slogan: "T-SHIRTS",
                 description: "",
                 image: "https://images.unsplash.com/photo-1523381210434-271e8be1f52b?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80",
                 buttonText: "Check Sales",
                 sale: "New Trendy Prints",
             },
         
         ]
         
         if(slides.length % 2){
             alert("Number of slides must be even")
         }
         
         slider.style.width = `${slides.length * width}px`;
         
         slides.forEach(slide => { // Loops through each slide
             slider.innerHTML += // Adds the following HTML to the slider
             `
                 <div class="slide" style="background-image: url(${slide.image});">
                     <div class="banner-box"> 
                         <h4>${slide.title}</h4> 
                         <h2>${slide.slogan}</h2> 
                         <span>${slide.description}</span> 
                         <h3 class="sales">${slide.sale?`Sale ${slide.sale}` : "" }</h3><br/>
                         <button class="white">${slide.buttonText}</button> 
                     </div>
                 </div>
             `
           
         })
         
         
         let positionX = 0; 
         
         arrowLeft.style.display = "none"
         
         
         arrowRight.addEventListener("click", () => {
             stopAutoSlide();
             positionX+=width;
             switchDots(true);
             checkArrows();
             slider.style.transform = `translateX(-${positionX}px)`;
             startAutoSlide();
         
         })
         
         arrowLeft.addEventListener("click", () => {
             stopAutoSlide();
             positionX -=width;
             switchDots(false);
             checkArrows(); 
             slider.style.transform = `translateX(-${positionX}px)`;
             startAutoSlide();
         
         })
         
         
         //check the position of the slider
         function checkArrows() {
             arrowLeft.style.display = positionX === 0 ? "none" : "block";
             arrowRight.style.display =  (positionX === (slides.length - 1) * width) ? "none": "block";
         }
         
         
         
         // adding dots
         for (let i =0; i<slides.length; i ++) {
             const dot = document.createElement("div");
             dot.className = "dot";
             dotsContainer.append(dot);
         }
         
         dotsContainer.children[0].classList.add("active-dot")
         
         function switchDots (order) {
            
             try {
                 dotsContainer.children[currentDot].classList.remove("active-dot");
             } catch (ex) {
                 dotsContainer.lastChild.classList.remove("active-dot")    
             }
             
          currentDot+= order ? 1 : -1;
          console.log(currentDot, order)
           dotsContainer.children[currentDot].classList.add("active-dot");
         }
         
         
         
         let interval;
         let dotStep =1;
         
         
         function startAutoSlide() {
         
            
             interval = setInterval(() => {
                 if(positionX === (width * (slides.length -1 ) ) ) {
                     positionX = -width;
                     currentDot = -1; 
                 };
                 arrowRight.click()
             }, 4000)
         }
         
         function stopAutoSlide() {
             clearInterval(interval)
         }
         
         startAutoSlide();
         
         
         // Function to update slider and related calculations
         function updateSlider() {
             console.log("update")
             // Recalculate width based on the new window size
             width = document.querySelectorAll(".slider__wrapper")[0].offsetWidth;
             dotsContainer.children[currentDot].classList.remove("active-dot")
             currentDot = 0;
             dotsContainer.children[currentDot].classList.add("active-dot")
             // Update the slider width
             slider.style.width = `${slides.length * width}px`;
         
             // Recalculate and update the position of the slider
             positionX = currentDot * width * -1;
             slider.style.transform = `translateX(${positionX}px)`;
         
             checkArrows();
         }
         
         // Add an event listener for the window resize event
         window.addEventListener("resize", updateSlider);
         
         
         // Initial setup
         updateSlider();
         


    } else {
         width = 0
    }



