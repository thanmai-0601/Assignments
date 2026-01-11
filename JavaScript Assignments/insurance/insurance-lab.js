const output = document.getElementById("output");

function print(message) {
    output.innerHTML += message + "<br>";
}

// Lab 1
function lab1() {
    output.innerHTML = "";
    let companyName = "Hartford India Insurance";
    let activePolicies = 12500;
    let offersHealthInsurance = true;

    print(companyName);
    print(activePolicies);
    print(offersHealthInsurance);
}

// Lab 2
function lab2() {
    output.innerHTML = "";
    let basePremium = 6000;
    let gst = 0.18;
    let total = basePremium+ basePremium * gst;

    print("Total Premium with GST: ₹" + total);
}

// Lab 3
function lab3() {
    output.innerHTML = "";
    let age = 22;
    print("Eligible: " + (age >= 18));
}

// Lab 4
function lab4() {
    output.innerHTML = "";
    let policyId = "POL123";
    let name = "Krishna";
    let status = "Active";

    print(`Policy ${policyId} for ${name} is ${status}`);
}

// Lab 5
function lab5() {
    output.innerHTML = "";
    let premium = 12000;
    let discount = 0.15;
    let finalAmount = premium - premium * discount;

    print("Final Premium: ₹" + finalAmount);
}

// Lab 6
function lab6() {
    output.innerHTML = "";
    const MAX_COVERAGE = 500000;
    print("Maximum Coverage: ₹" + MAX_COVERAGE);
}

// Lab 7
function lab7() {
    output.innerHTML = "";
    const yearlyPremium = monthly => monthly * 12;
    print("Yearly Premium: ₹" + yearlyPremium(6000));
}

// Lab 8
function lab8() {
    output.innerHTML = "";
    let isActive = true;
    let paid = true;

    print("Policy Valid: " + (isActive && paid));
}

// Lab 9
function lab9() {
    output.innerHTML = "";
    let claim = 200000;
    let coverage = 300000;

    if (claim <= coverage) {
        print(`Claim ₹${claim} APPROVED`);
    } else {
        print(`Claim ₹${claim} REJECTED`);
    }
}

// Lab 10
function lab10() {
    output.innerHTML = "";
    const bonus = (premium, hasClaim) =>
        hasClaim ? premium : premium + premium * 0.05;

    print("Premium after Bonus: ₹" + bonus(12000, false));
}
