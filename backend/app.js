const express = require("express");
const sequelize = require("./db");

const productRoute = require("./routes/products");
const registerRoute = require("./routes/register");
const loginRoute = require("./routes/login");

require("dotenv").config();

const app = express();
const PORT = process.env.PORT || 5000;

app.use(express.json());

app.use("/api/v1/products", productRoute);
app.use("/api/v1/register", registerRoute);
app.use("/api/v1/login", loginRoute);

sequelize
  .sync()
  .then(() => console.log("Database & tables created!"))
  .catch((err) => console.error("Error creating database tables:", err));

app.listen(PORT, () => {
  console.log(`Storage app running on port ${PORT}`);
});
