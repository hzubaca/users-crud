const PROXY_CONFIG = [
  {
    context: [
      "/",
    ],
    target: "https://localhost:7154",
    secure: false
  }
]

module.exports = PROXY_CONFIG;
