const API_URL = "https://jsonplaceholder.typicode.com/users";
let accounts = [];

const loader = document.getElementById("loader");
const errorBox = document.getElementById("error");
const accountsBody = document.getElementById("accountsBody");
const branchFilter = document.getElementById("branchFilter");
const searchInput = document.getElementById("searchInput");
const totalBalanceEl = document.getElementById("totalBalance");

// ------------------ Utilities ------------------

function randomBalance() {
  return Math.floor(Math.random() * 40001) + 10000;
}

function saveToStorage() {
  localStorage.setItem("bankAccounts", JSON.stringify(accounts));
}

function loadFromStorage() {
  return JSON.parse(localStorage.getItem("bankAccounts"));
}

// ------------------ Fetch Accounts ------------------

async function fetchAccounts() {
  loader.classList.remove("hidden");
  try {
    const res = await fetch(API_URL);
    if (!res.ok) throw new Error("API Failed");

    const data = await res.json();

    accounts = data.map(u => ({
      id: u.id,
      name: u.name,
      email: u.email,
      branch: u.address.city,
      balance: randomBalance(),
      transactions: []
    }));

    saveToStorage();
    populateBranches();
    renderAccounts();

  } catch (err) {
    errorBox.textContent = "Failed to load accounts!";
    errorBox.classList.remove("hidden");
  } finally {
    loader.classList.add("hidden");
  }
}

// ------------------ Render ------------------

function renderAccounts(list = accounts) {
  accountsBody.innerHTML = "";

  list.forEach(acc => {
    const tr = document.createElement("tr");

    if (acc.balance < 5000) tr.classList.add("low-balance");

    tr.innerHTML = `
      <td>${acc.id}</td>
      <td>${acc.Name}</td>
      <td>${acc.email}</td>
      <td>${acc.branch}</td>
      <td>₹${acc.balance}</td>
      <td>
        <button onclick="deposit(${acc.id})">Deposit</button>
        <button onclick="withdraw(${acc.id})">Withdraw</button>
        <button onclick="deleteAccount(${acc.id})">Delete</button>
      </td>
      <td>
        <div class="history-box">
          ${acc.transactions.map(t => `${t.type} ₹${t.amount} (${t.time})`).join("<br>")}
        </div>
      </td>
    `;

    accountsBody.appendChild(tr);
  });

  updateTotalBalance();
}

// ------------------ Branch Filter ------------------

function populateBranches() {
  const branches = [...new Set(accounts.map(a => a.branch))];
  branches.forEach(b => {
    const opt = document.createElement("option");
    opt.value = b;
    opt.textContent = b;
    branchFilter.appendChild(opt);
  });
}

branchFilter.addEventListener("change", () => {
  filterAndSearch();
});

// ------------------ Search ------------------

searchInput.addEventListener("input", filterAndSearch);

function filterAndSearch() {
  const term = searchInput.value.toLowerCase();
  const branch = branchFilter.value;

  let filtered = accounts.filter(a =>
    a.name.toLowerCase().includes(term)
  );

  if (branch) {
    filtered = filtered.filter(a => a.branch === branch);
  }

  renderAccounts(filtered);
}

// ------------------ Deposit & Withdraw (Closures) ------------------

function transactionHandler(acc, type) {
  return function () {
    const amount = parseInt(prompt(`Enter amount to ${type}:`));
    if (!amount || amount <= 0) return;

    if (type === "withdraw" && acc.balance < amount) {
      alert("Insufficient balance!");
      return;
    }

    if (type === "withdraw") acc.balance -= amount;
    else acc.balance += amount;

    // Minimum balance rule
    if (acc.balance < 5000) {
      acc.balance -= 200;
      alert("Minimum balance violated! ₹200 penalty applied.");
    }

    acc.transactions.push({
      type: type.toUpperCase(),
      amount,
      time: new Date().toLocaleString()
    });

    saveToStorage();
    renderAccounts();
  }
}

function deposit(id) {
  const acc = accounts.find(a => a.id === id);
  transactionHandler(acc, "deposit")();
}

function withdraw(id) {
  const acc = accounts.find(a => a.id === id);
  transactionHandler(acc, "withdraw")();
}

// ------------------ Create Account ------------------

document.getElementById("createForm").addEventListener("submit", async e => {
  e.preventDefault();

  const newAcc = {
    Name: Name.value,
    email: email.value,
    address: { city: branch.value }
  };

  const res = await fetch(API_URL, {
    method: "POST",
    body: JSON.stringify(newAcc),
    headers: { "Content-Type": "application/json" }
  });

  const data = await res.json();
  
  const account = {
    id: Date.now(),
    Name: data.Name,
    email: data.email,
    branch: data.address.city,
    balance: 10000,
    transactions: []
  };

  accounts.push(account);
  saveToStorage();
  populateBranches();
  renderAccounts();

  e.target.reset();
});

// ------------------ Delete ------------------

async function deleteAccount(id) {
  if (!confirm("Are you sure?")) return;

  await fetch(`${API_URL}/${id}`, { method: "DELETE" });

  accounts = accounts.filter(a => a.id !== id);
  saveToStorage();
  renderAccounts();
}

// ------------------ Sorting ------------------

document.getElementById("sortBtn").addEventListener("click", () => {
  accounts.sort((a, b) => b.balance - a.balance);
  renderAccounts();
});

// ------------------ Total Balance ------------------

function updateTotalBalance() {
  const total = accounts.reduce((sum, a) => sum + a.balance, 0);
  totalBalanceEl.textContent = total;
}

// ------------------ Init ------------------

function init() {
  const stored = loadFromStorage();
  if (stored && stored.length) {
    accounts = stored;
    populateBranches();
    renderAccounts();
  } else {
    fetchAccounts();
  }
}

init();
