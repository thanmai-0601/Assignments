// ================= CONFIG ==================
const API_URL = "https://6969018d69178471522c4179.mockapi.io/policies";

let policies = [];

// ================= TASK 1: FETCH POLICIES ==================
async function fetchPolicies() {
    try {
        const res = await fetch(API_URL);

        if (!res.ok) throw new Error("API Failure");

        policies = await res.json();
        displayPolicies(policies);
    } catch (error) {
        showMessage("Failed to fetch policies: " + error.message);
    }
}

fetchPolicies();

// ================= TASK 2: DISPLAY POLICIES ==================
function displayPolicies(data) {
    const container = document.getElementById("policiesContainer");
    container.innerHTML = "";

    data.forEach(policy => {
        const div = document.createElement("div");
        div.className = "policy-card";

        div.innerHTML = `
            <h3>${policy.name}</h3>
            <p>ID: ${policy.id}</p>
            <p>Type: ${policy.type}</p>
            <p>Premium: ₹${policy.premium}</p>
            <p>Duration: ${policy.duration} years</p>
            <p>Status: <span class="${policy.status === "Active" ? "active" : "inactive"}">${policy.status}</span></p>
        `;

        container.appendChild(div);
    });
}

// ================= TASK 3: FILTER ==================
function filterPolicies(type) {
    if (type === "All") {
        displayPolicies(policies);
    } else {
        const filtered = policies.filter(p => p.type === type);
        displayPolicies(filtered);
    }
}

// ================= TASK 4: TOTAL PREMIUM (reduce) ==================
function calculateTotalPremium() {
    try {
        const total = policies
            .filter(p => p.status === "Active")
            .reduce((sum, p) => sum + Number(p.premium), 0);

        alert("Total Active Premium = ₹" + total);
    } catch (error) {
        showMessage("Premium calculation error");
    }
}

// ================= TASK 5: DISCOUNT (map) ==================
function applyDiscount() {
    policies = policies.map(p => {
        if (p.premium > 10000) {
            return { ...p, premium: Math.round(p.premium * 0.9) };
        }
        return p;
    });

    displayPolicies(policies);
    alert("10% Discount Applied to policies above ₹10,000");
}

// ================= TASK 6: CALLBACK APPROVAL ==================
function approvePolicyCallback(policyId, callback) {
    setTimeout(() => {
        const policy = policies.find(p => p.id == policyId);

        if (!policy) {
            callback("Invalid Policy ID", null);
        } else {
            callback(null, "Policy Approved: " + policy.name);
        }
    }, 2000);
}

// ================= TASK 7: PROMISE BASED PURCHASE ==================
function approvePolicyPromise(policyId) {
    return new Promise((resolve, reject) => {
        approvePolicyCallback(policyId, (err, result) => {
            if (err) reject(err);
            else resolve(result);
        });
    });
}

async function purchasePolicy() {
    const id = document.getElementById("policyIdInput").value;

    try {
        const result = await approvePolicyPromise(id);
        alert(result);
    } catch (error) {
        alert("Purchase Failed: " + error);
    }
}

// ================= TASK 8: ERROR HANDLING ==================
function showMessage(msg) {
    document.getElementById("message").innerText = msg;
}
