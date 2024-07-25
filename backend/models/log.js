const sequelize = require("../db");
const { DataTypes } = require("sequelize");
const Log = sequelize.define(
  "Log",
  {
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

Log.sync();

module.exports = Log;
