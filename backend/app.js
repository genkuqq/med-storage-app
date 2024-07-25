const express = require("express");
const productRoute = require("./routes/products");
const sequelize = require("./db");

require("dotenv").config();

const app = express();
const PORT = process.env.PORT || 5000;

app.use(express.json());

app.use("/products", productRoute);

sequelize
  .sync()
  .then(() => console.log("Database & tables created!"))
  .catch((err) => console.error("Error creating database tables:", err));

app.listen(PORT, () => {
  console.log(`Storage app running on port ${PORT}`);
});
