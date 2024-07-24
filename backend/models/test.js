const sequelize = require("../db");
const { DataTypes, Model } = require("sequelize");
const Test = sequelize.define("Test", {
  id: {
    primaryKey: true,
    allowNull: false,
    autoIncrement: true,
    type: DataTypes.INTEGER,
  },
  test: {
    type: DataTypes.STRING,
    allowNull: false,
  },
});

Test.sync({ alter: true });
console.log("==> The table for the Test model was just (re)created!");

module.exports = Test;
