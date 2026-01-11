const plans = [
  { name: "Health Secure", premium: 3000, coverage: "Up to 10L" },
  { name: "Life Shield", premium: 5000, coverage: "Up to 20L" },
  { name: "Vehicle Protect", premium: 2000, coverage: "Up to 5L" }
];

let customers = [];
let idCounter = 1;

/* Render Plans */
const plansContainer = document.getElementById("plansContainer");
plansContainer.innerHTML = plans.map(p => `
  <div class="bg-slate-800 p-4 rounded shadow plan-card-green">
    <h3 class="text-lg font-bold mb-2">${p.name}</h3>
    <p>Base Premium: ₹${p.premium}</p>
    <p>Coverage: ${p.coverage}</p>
    <button class="btn-primary mt-3">Enroll</button>
  </div>
`).join("");

function calculatePremium(age, policy, coverage) {
  let base = 0;
  if (policy === "Health") base = 3000;
  if (policy === "Life") base = 5000;
  if (policy === "Vehicle") base = 2000;

  if (age > 45) base *= 1.2;
  base += (coverage - 1) * 500;

  return Math.round(base);
}

const coverageSlider = document.getElementById("coverage");
const coverageValue = document.getElementById("coverageValue");
coverageSlider.oninput = () => coverageValue.textContent = coverageSlider.value;

document.getElementById("enquiryForm").addEventListener("submit", e => {
  e.preventDefault();
  clearErrors();

  const name = document.getElementById("name").value.trim();
  const age = +document.getElementById("age").value;
  const email = document.getElementById("email").value.trim();
  const policy = document.getElementById("policy").value;
  const coverage = +coverageSlider.value;

  let valid = true;

  if (!name) { showError("nameError", "Customer name is required"); valid = false; }
  if (!age || age < 18) { showError("ageError", "Age must be 18 or above"); valid = false; }
  if (!email.includes("@")) { showError("emailError", "Enter a valid email address"); valid = false; }
  if (!policy) { showError("policyError", "Please select a policy type"); valid = false; }

  if (!valid) return;

  const premium = calculatePremium(age, policy, coverage);

  customers.push({ id: idCounter++, name, age, policyType: policy, coverage, premium });

  updateDashboard();
  e.target.reset();
  coverageValue.textContent = 1;
});

function updateDashboard() {
  const filter = document.getElementById("filterPolicy").value;
  const search = document.getElementById("searchName").value.toLowerCase();

  const filtered = customers.filter(c =>
    (filter === "All" || c.policyType === filter) &&
    c.name.toLowerCase().includes(search)
  );

  renderTable(filtered);
  updateSummary();
}

function renderTable(list) {
  document.getElementById("customerTable").innerHTML = list.map(c => `
    <tr class="border-t border-slate-700">
      <td class="p-2">${c.name}</td>
      <td>${c.age}</td>
      <td>${c.policyType}</td>
      <td>${c.coverage}</td>
      <td>₹${c.premium}</td>
    </tr>
  `).join("");
}

function updateSummary() {
  document.getElementById("statCustomers").textContent = customers.length;
  document.getElementById("statPolicies").textContent = customers.length;
  document.getElementById("statClaims").textContent = Math.floor(customers.length / 3);
  document.getElementById("totalPremium").textContent =
    customers.reduce((sum, c) => sum + c.premium, 0);
}

document.getElementById("filterPolicy").onchange = updateDashboard;
document.getElementById("searchName").oninput = updateDashboard;

function showError(id, message) {
  document.getElementById(id).textContent = message;
}

function clearErrors() {
  document.querySelectorAll(".error").forEach(e => e.textContent = "");
}
