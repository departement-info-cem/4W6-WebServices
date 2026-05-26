// @ts-check

/** @type {import('@docusaurus/plugin-content-docs').SidebarsConfig} */
const sidebars = {
  docs: [
    {
      type: "doc",
      label: "1.1 - Intro à React / Next.js 🏁",
      id: "notes/rencontre1.1", 
      customProps: { 
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-09"}
          ],
          "Philippe": [
            {"1020": "2026-08-09"}
          ]
        },
        tooltip: "visible",
      }
    },
    {
      type: "doc",
      label: "1.2 - Composant dynamique 🏃",
      id: "notes/rencontre1.2",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-09"}
          ],
          "Philippe": [
            {"1020": "2026-08-09"}
          ]
        },
        tooltip: "cache",
      }
    },
    {
      type: "doc",
      label: "2.1 - Requêtes HTTP ↔️",
      id: "notes/rencontre2.1",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-11"}
          ],
          "Philippe": [
            {"1020": "2026-08-09"}
          ]
        }
      }
    },
    {
      type: "doc",
      label: "2.2 - TP1 (5%) 🔨",
      id: "notes/rencontre2.2",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-11"}
          ],
          "Philippe": [
            {"1020": "2026-08-11"}
          ]
        },
        avancementLabel: "TP1",
        avancement: 1
      },
      "className": "remise-tp1"
    },
    {
      type: "doc",
      label: "3.1 - Plusieurs composants 🧩",
      id: "notes/rencontre3.1",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-12"}
          ],
          "Philippe": [
            {"1020": "2026-08-11"}
          ]
        }
      }
    },
    {
      type: "doc",
      label: "3.2 - Contexts et hooks 🎣",
      id: "notes/rencontre3.2",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-12"}
          ],
          "Philippe": [
            {"1020": "2026-08-12"}
          ]
        }
      }
    },
    {
      type: "doc",
      label: "4.1 - Stockage, i18n, token 🪙",
      id: "notes/rencontre4.1",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-16"}
          ],
          "Philippe": [
            {"1020": "2026-08-12"}
          ]
        }
      }
    },
    {
      type: "doc",
      label: "4.2 - Maps, vidéos, UI 🗺️",
      id: "notes/rencontre4.2",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-16"}
          ],
          "Philippe": [
            {"1020": "2026-08-16"}
          ]
        }
      }
    },
    {
      type: "doc",
      label: "5.1 - TP2 (20%) 🔨",
      id: "notes/rencontre5.1",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-18"}
          ],
          "Philippe": [
            {"1020": "2026-08-18"}
          ]
        },
        avancementLabel: "TP2",
        avancement: 0.25
      }
    },
    {
      type: "doc",
      label: "5.2 - TP2 (20%) 🔨",
      id: "notes/rencontre5.2",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-18"}
          ],
          "Philippe": [
            {"1020": "2026-08-18"}
          ]
        },
        avancementLabel: "TP2",
        avancement: 0.5
      }
    },
    {
      type: "doc",
      label: "6.1 - TP2 (20%) 🔨",
      id: "notes/rencontre6.1",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-19"}
          ],
          "Philippe": [
            {"1020": "2026-08-19"}
          ]
        },
        avancementLabel: "TP2",
        avancement: 0.75
      }
    },
    {
      type: "doc",
      label: "6.2 - TP2 (20%) 🔨",
      id: "notes/rencontre6.2",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-19"}
          ],
          "Philippe": [
            {"1020": "2026-08-19"}
          ]
        },
        avancementLabel: "TP2",
        avancement: 1
      },
    },
    {
      type: "doc",
      label: "7.1 - Intra formatif 📝",
      id: "notes/rencontre7.1",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-23"}
          ],
          "Philippe": [
            {"1020": "2026-08-16"}
          ]
        },
      }
    },
    {
      type: "doc",
      label: "7.2 - Intra sommatif (15%) 📝",
      id: "notes/rencontre7.2",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-23"}
          ],
          "Philippe": [
            {"1020": "2026-08-19"}
          ]
        }
      },
      "className": "examen"
    },
    {
      type: "doc",
      label: "8.1 - Intro Web API 🌐",
      id: "notes/rencontre8.1",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-25"}
          ],
          "Philippe": [
            {"1020": "2026-08-23"}
          ]
        }      }
    },
    {
      type: "doc",
      label: "8.2 - Relations et DTOs 👨‍👩‍👧",
      id: "notes/rencontre8.2",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-25"}
          ],
          "Philippe": [
            {"1020": "2026-08-23"}
          ]
        }
      }
    },
    {
      type: "doc",
      label: "9.1 - Utilisateurs et services 👤",
      id: "notes/rencontre9.1",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-26"}
          ],
          "Philippe": [
            {"1020": "2026-08-25"}
          ]
        }
      }
    },
    {
      type: "doc",
      label: "9.2 - Retours, sécurité, seed 🌱",
      id: "notes/rencontre9.2",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-08-26"}
          ],
          "Philippe": [
            {"1020": "2026-08-25"}
          ]
        },
        avancementLabel: "TP3",
        avancement: 0.05
      },

    },
    {
      type: "doc",
      label: "10.1 - TP3 (10%) 🔨",
      id: "notes/rencontre10.1",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-07-01"}
          ],
          "Philippe": [
            {"1020": "2026-08-26"}
          ]
        },
        avancementLabel: "TP3",
        avancement: 0.5
      }
    },
    {
      type: "doc",
      label: "10.2 - TP3 (10%) 🔨",
      id: "notes/rencontre10.2",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-07-01"}
          ],
          "Philippe": [
            {"1020": "2026-08-26"}
          ]
        },
        avancementLabel: "TP3",
        avancement: 1
      }
    },
    {
      type: "doc",
      label: "11.1 - Serveur d'images 🖼️",
      id: "notes/rencontre11.1",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-07-02"}
          ],
          "Philippe": [
            {"1020": "2026-08-26"}
          ]
        }
      },
      "className": "remise-tp3"
    },
    {
      type: "doc",
      label: "11.2 - Rôles 🧝",
      id: "notes/rencontre11.2",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-07-02"}
          ],
          "Philippe": [
            {"1020": "2026-07-01"}
          ]
        }
      }
    },
    {
      type: "doc",
      label: "12.1 - Git et TP4 🫒",
      id: "notes/rencontre12.1",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-07-03"}
          ],
          "Philippe": [
            {"1020": "2026-07-01"}
          ]
        },
        avancementLabel: "TP4",
        avancement: 0.05
      }
    },
    {
      type: "doc",
      label: "12.2 - TP4 (25%) 🔨",
      id: "notes/rencontre12.2",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-07-03"}
          ],
          "Philippe": [
            {"1020": "2026-07-01"}
          ]
        },
        avancementLabel: "TP4",
        avancement: 0.2
      }
    },
    {
      type: "doc",
      label: "13.1 - TP4 (25%) 🔨",
      id: "notes/rencontre13.1",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-07-07"}
          ],
          "Philippe": [
            {"1020": "2026-07-02"}
          ]
        },
        avancementLabel: "TP4",
        avancement: 0.4
      }
    },
    {
      type: "doc",
      label: "13.2 - TP4 (25%) 🔨",
      id: "notes/rencontre13.2",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-07-07"}
          ],
          "Philippe": [
            {"1020": "2026-07-07"}
          ]
        },
        avancementLabel: "TP4",
        avancement: 0.6
      }
    },
    {
      type: "doc",
      label: "14.1 - TP4 (25%) 🔨",
      id: "notes/rencontre14.1",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-07-10"}
          ],
          "Philippe": [
            {"1020": "2026-07-04"}
          ]
        },
        avancementLabel: "TP4",
        avancement: 0.8
      }
    },
    {
      type: "doc",
      label: "14.2 - TP4 (25%) 🔨",
      id: "notes/rencontre14.2",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-07-09"}
          ],
          "Philippe": [
            {"1020": "2026-07-07"}
          ]
        },
        avancementLabel: "TP4",
        avancement: 1
      },
      "className": "remise-tp4"
    },
    {
      type: "doc",
      label: "15.1 - Final formatif 📝",
      id: "notes/rencontre15.1",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-07-09"}
          ],
          "Philippe": [
            {"1020": "2026-07-02"}
          ]
        }
      },
    },
    {
      type: "doc",
      label: "15.2 - Final sommatif (25%) 📝",
      id: "notes/rencontre15.2",
      customProps: {
        calendrier: {
          "Pierre-0livier": [
            {"1010": "2026-07-10"}
          ],
          "Philippe": [
            {"1020": "2026-07-04"}
          ]
        }
      },
      "className": "examen"
    }
  ],
  "tp": [
    {
      type: "autogenerated",
      "dirName": "02-tp"
    }
  ],
  labos: [{type:'autogenerated', dirName:'03-labos'}],
  angular: [{type: 'autogenerated', dirName: '04-angular'}]
};

module.exports = sidebars;
