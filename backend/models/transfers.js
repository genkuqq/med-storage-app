const sequelize = require("../db");
const { DataTypes } = require("sequelize");
const Product = require("./product");
const Transfers = sequelize.define("Transfers", {
  id: {
    primaryKey: true,
    allowNull: false,
    autoIncrement: true,
    type: DataTypes.INTEGER,
  },
  name: {
    type: DataTypes.STRING,
    allowNull: false,
    unique: true,
  },
  transferStatus: {
    type: DataTypes.ENUM("Ongoing", "Completed"),
    allowNull: false,
    defaultValue: "Ongoing",
  },
});

const Transfer_Product = sequelize.define(
  "Transfer_Product",
  {
    id: {
      primaryKey: true,
      allowNull: false,
      autoIncrement: true,
      type: DataTypes.INTEGER,
    },
    transferId: {
      type: DataTypes.INTEGER,
      references: {
        model: Transfers,
        key: "id",
      },
      allowNull: false,
    },
    productId: {
      type: DataTypes.INTEGER,
      references: {
        model: Product,
        key: "id",
      },
      allowNull: false,
    },
    quantitySent: {
      type: DataTypes.INTEGER,
      allowNull: false,
    },
    quantityReturned: {
      type: DataTypes.INTEGER,
      defaultValue: 0,
    },
  },
  { timestamps: false }
);

Transfers.sync({ alter: true });
Transfer_Product.sync({ alter: true });

module.exports = { Transfers, Transfer_Product };
