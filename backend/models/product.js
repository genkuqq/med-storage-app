const sequelize = require("../db");
const { DataTypes } = require("sequelize");
const Product = sequelize.define(
  "Product",
  {
    id: {
      primaryKey: true,
      allowNull: false,
      autoIncrement: true,
      type: DataTypes.INTEGER,
    },
    productName: {
      type: DataTypes.STRING,
      allowNull: true,
    },
    productNo: {
      type: DataTypes.INTEGER,
      allowNull: true,
    },
    serialNo: {
      type: DataTypes.INTEGER,
      allowNull: true,
    },
    lotNo: {
      type: DataTypes.STRING,
      allowNull: true,
    },
    productionDate: {
      type: DataTypes.DATE,
      allowNull: true,
    },
    expirationDate: {
      type: DataTypes.DATE,
      allowNull: true,
    },
  },
  { timestamps: false }
);

Product.sync({ alter: true });
console.log("==> The table for the Product model was just (re)created!");

module.exports = Product;
