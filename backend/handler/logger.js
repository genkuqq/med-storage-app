const Log = require("../models/log");

async function CustomLogger(title, message) {
  const now = new Date();
  const formattedDate = now.toLocaleString("tr-TR", {
    day: "2-digit",
    month: "2-digit",
    year: "numeric",
    hour: "2-digit",
    minute: "2-digit",
    second: "2-digit",
  });
  console.log(`${formattedDate} | ${title} | ${message}`);
  await Log.create({ title: title, message: message, date: now });
}

module.exports = CustomLogger;
