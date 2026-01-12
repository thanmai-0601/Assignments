//EXERCISE 1 – EVENT BUBBLING
const paymentSection = document.getElementById("paymentSection");
const payBtn = document.getElementById("payBtn");

paymentSection.addEventListener("click", () => {
    console.log("DIV clicked - Payment Section");
});

payBtn.addEventListener("click", () => {
    console.log("BUTTON clicked - Pay Premium");
});

/*
OUTPUT when button is clicked:
1. BUTTON clicked - Pay Premium
2. DIV clicked - Payment Section

Event Phase: Bubbling phase (event flows from child → parent)
*/



//EXERCISE 2 – EVENT CAPTURING
const policyContainer = document.getElementById("policyContainer");
const policyBtn = document.getElementById("policyBtn");

policyContainer.addEventListener("click", () => {
    console.log("Parent Capturing - Validating User");
}, true); // capturing

policyBtn.addEventListener("click", () => {
    console.log("Child Capturing - Showing Policy Details");
}, true); // capturing

/*
Expected Output:
1. Parent Capturing - Validating User
2. Child Capturing - Showing Policy Details

Event Phase: Capturing phase (parent → child)
*/



//EXERCISE 3 – stopPropagation
const policyCard = document.getElementById("policyCard");
const deleteBtn = document.getElementById("deleteBtn");

policyCard.addEventListener("click", () => {
    console.log("Navigating to Policy Details...");
});

deleteBtn.addEventListener("click", (event) => {
    event.stopPropagation();   // STOP bubbling
    console.log("Policy Deleted");
});

/*
Result:
- Clicking card → navigates
- Clicking delete → only deletes
- Navigation log does NOT appear
*/



// EXERCISE 4 – Claims Dashboard
const claimRow = document.getElementById("claimRow");
const approveBtn = document.getElementById("approveBtn");

// Parent: Claim Row Click
claimRow.addEventListener("click", () => {
    console.log("Opening Claim Details");
});

// Child: Approve Button Click
approveBtn.addEventListener("click", (event) => {
    event.stopPropagation();   // Prevent parent click
    console.log("Claim Approved");
});

/*
Without stopPropagation()

Output would be:
Claim Approved
Opening Claim Details

because event bubbles to parent

With stopPropagation()

Output:
Claim Approved

parent event is blocked
Only approval happens, no navigation.*/
