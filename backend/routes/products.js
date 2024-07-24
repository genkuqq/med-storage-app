const express = require("express");
const router = express.Router();
const Product = require("../models/product");

router.get("/", async (req, res) => {
  try {
    const products = await Product.findAll();
    res.status(200).json(products);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

router.post("/", async (req, res) => {
  try {
    const product = await Product.create({
      productName: "te1",
      productNo: 1,
      serialNo: 1,
      lotNo: "a1",
      productionDate: 1,
      expirationDate: 1,
    });
    //const product = await Product.create(req.body);
    res.status(201).json({
      message: `Product succesfully created. Product ID: ${product.id}`,
    });
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

router.get("/:id", async (req, res) => {
  try {
    const product = await Product.findByPk(req.params.id);
    if (!product) {
      return res.status(404).json({ error: "Product not found!" });
    }
    res.status(200).json(product);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

router.put("/:id", async (req, res) => {
  try {
    await Product.update(req.body, { where: { id: req.params.id } });
    console.log(req.body);
    const updatedProduct = await Product.findByPk(req.params.id);
    res.status(200).json(updatedProduct);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

router.delete("/:id", async (req, res) => {
  try {
    const product = await Product.findByPk(req.params.id);
    if (!product) {
      return res.status(404).json({ error: "Product not found!" });
    }
    await Product.destroy({ where: { id: req.params.id } });
    res.status(200).json({ message: "Product succesfully deleted." });
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

module.exports = router;
