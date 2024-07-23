const express = require("express");
const productRoute = require("./routes/products");

require("dotenv").config();

const app = express();
const PORT = process.env.PORT || 5000;

app.use(express.json());

app.use("/products", productRoute);

app.listen(PORT, () => {
  console.log(`Storage app running on port ${PORT}`);
});
