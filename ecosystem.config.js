module.exports = {
  apps: [
    {
      name: "backend",
      script: "node",
      args: "app.js",
      cwd: "./backend",
      watch: ["./backend"],
    },
    {
      cwd: "./frontend",
      name: "Netxjs App",
      script: "./frontend/node_modules/next/dist/bin/next",
      args: "start",
      env: {
        PORT: "3000",
      },
    },
  ],
};
