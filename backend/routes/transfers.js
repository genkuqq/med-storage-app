const express = require("express");
const router = express.Router();
const { Transfers, Transfer_Product } = require("../models/transfers");
const CustomLogger = require("../handler/logger");

router.get("/", async (req, res) => {
  try {
    const transfers = await Transfers.findAll();
    res.status(200).json(transfers);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

router.post("/", async (req, res) => {
  try {
    const transfer = await Transfers.create(req.body);
    res.status(201).json({
      message: `Transfer succesfully created. Transfer ID: ${transfer.id}`,
    });
    CustomLogger(
      "Info",
      `Yeni bir transfer oluşturuldu. Transfer No: ${transfer.id}`
    );
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

router.get("/:id", async (req, res) => {
  try {
    const transfer = await Product.findByPk(req.params.id);
    if (!product) {
      return res.status(404).json({ error: "Transfer not found!" });
    }
    res.status(200).json(transfer);
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

router.put("/:id", async (req, res) => {
  try {
    await Transfers.update(req.body, { where: { id: req.params.id } });
    const updatedProduct = await Product.findByPk(req.params.id);
    res.status(200).json(updatedProduct);
    CustomLogger("Info", `Ürün bilgisi düzenlendi. Ürün No: ${req.params.id}`);
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
    CustomLogger(
      "Info",
      `Ürün veritabanından silindi. Ürün No: ${req.params.id}`
    );
  } catch (err) {
    res.status(500).json({ error: err.message });
  }
});

module.exports = router;
