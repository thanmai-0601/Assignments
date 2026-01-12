//Task 1– Select by ID 
let text=document.getElementById("pageTitle");
text.innerText="Customer Insurance Overview";


//Task 2– Select by Tag Name 
let tag=document.getElementsByTagName("li");

for (let li of tag) {
    li.style.border = "1px solid black";
}
console.log("Total customers:", tag.length);


//Task 3– Select by Class Name
let policies = document.getElementsByClassName("policy");

for (let p of policies) {
    p.classList.add("highlight");
    p.style.color = "blue";
}


//Task 4– Select using CSS Selectors 
let firstCustomer = document.querySelector("#customerList li");
firstCustomer.style.backgroundColor = "red";

let allCustomers = document.querySelectorAll("#customerList li");

let lastCustomer = document.querySelector("#customerList li:last-child");
lastCustomer.classList.add("active");


//Task 5– HTML Object Collections 
console.log("Number of forms:", document.forms.length);
console.log("Number of images:", document.images.length);

for (let link of document.links) {
    link.innerText = "More Info";
}


//Task 6– Add a new customer dynamically and observe: 
let newCustomer = document.createElement("li");
newCustomer.className = "customer";
newCustomer.textContent = "Meena – Health";
document.getElementById("customerList").appendChild(newCustomer);


//Task 7 – Attribute-Based Selection 
let textInputs = document.querySelectorAll('input[type="text"]');

textInputs.forEach(input => {
    input.style.backgroundColor = "yellow";
    input.placeholder = "Enter Full Name";
});


//Task 8 – Multiple Class Selection 
let priorityCustomers = document.querySelectorAll(".customer.active");

priorityCustomers.forEach(cust => {
    cust.style.color = "darkgreen";
    cust.textContent += " (Priority Customer)";
});


//Task 9 – Descendant vs Child Selector
let descendantList = document.querySelectorAll("#customerList li");
let childList = document.querySelectorAll("#customerList > li");

console.log("Descendant <li> count:", descendantList.length);
console.log("Direct child <li> count:", childList.length);


//Task 10 – Even / Odd Selection (CSS Pseudo Selectors) 
let nthCustomers = document.querySelectorAll("#customerList li");

nthCustomers.forEach((li, index) => {
    if ((index + 1) % 2 === 0) {
        li.style.backgroundColor = "#e5e7eb"; // light gray
    } else {
        li.style.backgroundColor = "#dbeafe"; // light blue
    }
});


//Task 11 – Form Elements Collection
let form = document.forms["enquiryForm"];

for (let el of form.elements) {
    if (el.name) {
        console.log("Input field:", el.name);
    }
}
form.querySelector("button").disabled = true;


//Task 12 – NodeList vs HTMLCollection
let policyHTMLCollection = document.getElementsByClassName("policy");
let policyNodeList = document.querySelectorAll(".policy");

let newPolicy = document.createElement("p");
newPolicy.className = "policy";
newPolicy.textContent = "Travel Insurance";
document.body.appendChild(newPolicy);

console.log("HTMLCollection updated:", policyHTMLCollection.length);
console.log("NodeList static:", policyNodeList.length);

//Task 13 – Text Content Filtering 
let customersList = document.querySelectorAll("#customerList li");

customersList.forEach(li => {
    const text = li.textContent;

    if (text.includes("Life")) {
        li.style.backgroundColor = "aqua";
    }

    if (text.includes("Vehicle")) {
        li.style.display = "none";
    }
});


//Task 14 – Closest & Parent Traversal 
document.querySelectorAll("#customerList li").forEach(li => {
    li.addEventListener("click", () => {
        let ul = li.closest("ul");
        ul.style.border = "3px solid red";
    });
});


//Task 15 – Complex Selector Challenge
let policyExceptFirst = document.querySelectorAll("p.policy:not(:first-child)");

policyExceptFirst.forEach(p => {
    p.style.fontStyle = "italic";
    p.textContent = "✔ " + p.textContent;
});
