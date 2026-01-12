const cells = document.querySelectorAll(".cell");
const statusText = document.getElementById("status");
const restartBtn = document.getElementById("restartBtn");

let currentPlayer = "X";
let board = ["", "", "", "", "", "", "", "", ""];
let gameActive = true;

const winningConditions = [
  [0,1,2], [3,4,5], [6,7,8],
  [0,3,6], [1,4,7], [2,5,8],
  [0,4,8], [2,4,6]
];

cells.forEach((cell, index) => {
  cell.addEventListener("click", () => handleCellClick(cell, index));
});

restartBtn.addEventListener("click", restartGame);

function handleCellClick(cell, index) {
  if (board[index] !== "" || !gameActive) return;

  board[index] = currentPlayer;
  cell.textContent = currentPlayer;
  cell.style.color = currentPlayer === "X" ? "#c23a3a" : "#e5e7eb";
  cell.classList.add("taken");

  checkResult();
}

function checkResult() {
  let roundWon = false;

  for (let condition of winningConditions) {
    const [a, b, c] = condition;
    if (board[a] && board[a] === board[b] && board[a] === board[c]) {
      roundWon = true;
      break;
    }
  }

  if (roundWon) {
    statusText.textContent = `🏆 Player ${currentPlayer} Wins!`;
    statusText.className = "result win";
    gameActive = false;
    return;
  }

  if (!board.includes("")) {
    statusText.textContent = "🤝 It's a Draw!";
    statusText.className = "result draw";
    gameActive = false;
    return;
  }

  currentPlayer = currentPlayer === "X" ? "O" : "X";
  statusText.textContent = `Player ${currentPlayer}'s Turn`;
}

function restartGame() {
  currentPlayer = "X";
  board = ["", "", "", "", "", "", "", "", ""];
  gameActive = true;

  statusText.textContent = "Player X's Turn";
  statusText.className = "";

  cells.forEach(cell => {
    cell.textContent = "";
    cell.classList.remove("taken");
    cell.style.color = "#c23a3a";
  });
}
