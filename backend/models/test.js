const sequelize = require("../db");
const { DataTypes } = require("sequelize");
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

Test.sync();

module.exports = Test;
