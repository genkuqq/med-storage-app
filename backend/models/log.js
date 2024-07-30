const sequelize = require("../db");
const { DataTypes } = require("sequelize");
const Log = sequelize.define(
  "Log",
  {
    title: {
      type: DataTypes.STRING,
      allowNull: true,
    },
    message: {
      type: DataTypes.STRING,
      allowNull: true,
    },
    date: {
      type: DataTypes.DATE,
      allowNull: true,
    },
  },
  { timestamps: false }
);

Log.sync({ alter: true });

module.exports = Log;
