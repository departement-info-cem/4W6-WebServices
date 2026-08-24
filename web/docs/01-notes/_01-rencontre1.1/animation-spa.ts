export default {
    "direction": "left-to-right",
    "nodes": [
        {
            "id": "browser",
            "type": "laptop",
            "text": "Navigateur",
            "icon": "chrome",
            "lane": 1
        },
        {
            "id": "web",
            "type": "server",
            "text": "Serveur web",
            "icon": "nextjs",
            "lane": 2
        },
        {
            "id": "api",
            "type": "server",
            "text": "Web API",
            "icon": "dotnet",
            "lane": 2
        },
        {
            "id": "db",
            "type": "database",
            "text": "BD",
            "icon": "mssql",
            "align_with": "api",
            "lane": 3
        }
    ],
    "packets": [
        {
            "id": "getindex",
            "kind": "http_packet",
            "packet_content": {
                "header": "GET /"
            }
        },
        {
            "id": "html",
            "kind": "http_packet",
            "packet_content": {
                "header": "200 OK\nContent-Type: text/html",
                "body": {
                    "type": "text",
                    "value": "<div id=\"root\"></div>\n<script src=\"/app.js\"></script>",
                    "language": "html"
                }
            }
        },
        {
            "id": "getjs",
            "kind": "http_packet",
            "packet_content": {
                "header": "GET /app.js"
            }
        },
        {
            "id": "js",
            "kind": "http_packet",
            "packet_content": {
                "header": "200 OK\nContent-Type: application/javascript",
                "body": {
                    "type": "text",
                    "value": "fetch(\"/api/products\")\n  .then(r => r.json())\n  .then(render);",
                    "language": "javascript"
                }
            }
        },
        {
            "id": "apireq",
            "kind": "http_packet",
            "packet_content": {
                "header": "GET /api/products\nAccept: application/json"
            }
        },
        {
            "id": "sql",
            "kind": "sql_request",
            "request_content": "SELECT id, name FROM products"
        },
        {
            "id": "rows",
            "kind": "sql_response",
            "response_content": {
                "header": "3 lignes",
                "body": {
                    "type": "table",
                    "columns": [
                        "id",
                        "nom"
                    ],
                    "rows_data": [
                        [
                            1,
                            "Clavier"
                        ],
                        [
                            2,
                            "Souris"
                        ],
                        [
                            3,
                            "Écran"
                        ]
                    ]
                }
            }
        },
        {
            "id": "apires",
            "kind": "http_packet",
            "packet_content": {
                "header": "200 OK\nContent-Type: application/json",
                "body": {
                    "type": "text",
                    "value": "[\n  { \"id\": 1, \"name\": \"Clavier\" },\n  { \"id\": 2, \"name\": \"Souris\" },\n  { \"id\": 3, \"name\": \"Écran\" }\n]",
                    "language": "json"
                }
            }
        }
    ],
    "connections": [
        {
            "from": "browser",
            "to": "web",
            "style": "dotted"
        },
        {
            "from": "browser",
            "to": "api",
            "style": "dotted"
        },
        {
            "from": "api",
            "to": "db",
            "style": "dotted"
        }
    ],
    "timeline": [
        {
            "type": "comment",
            "object": "browser",
            "text": "1. Le navigateur demande la page au serveur web"
        },
        {
            "type": "parallel",
            "actions": [
                {
                    "type": "move",
                    "object": "getindex",
                    "from": "browser",
                    "to": "web"
                },
                {
                    "type": "loading",
                    "object": "browser",
                    "keep_until": "shell"
                }
            ]
        },
        {
            "type": "move",
            "object": "html",
            "from": "web",
            "to": "browser"
        },
        {
            "type": "set_content",
            "id": "shell",
            "object": "browser",
            "content": {
                "type": "text",
                "url": "mon.app/produits",
                "value": "📄 index.html rendu — <div id=\"root\"> encore vide"
            },
            "keep_until": "waiting"
        },
        {
            "type": "move",
            "object": "getjs",
            "from": "browser",
            "to": "web"
        },
        {
            "type": "move",
            "object": "js",
            "from": "web",
            "to": "browser"
        },
        {
            "type": "comment",
            "object": "browser",
            "text": "2. La coquille est affichée mais vide : le script appelle l'API"
        },
        {
            "type": "set_content",
            "id": "waiting",
            "object": "browser",
            "content": {
                "type": "text",
                "url": "mon.app/produits",
                "value": "⚛️ SPA démarrée · ⏳ chargement… ▭▭▭▭▭ ▭▭▭"
            },
            "keep_until": "render"
        },
        {
            "type": "move",
            "object": "apireq",
            "from": "browser",
            "to": "api"
        },
        {
            "type": "loading",
            "object": "api",
            "duration": 400
        },
        {
            "type": "move",
            "object": "sql",
            "from": "api",
            "to": "db"
        },
        {
            "type": "loading",
            "id": "dbwork",
            "object": "db",
            "duration": 600
        },
        {
            "type": "move",
            "object": "rows",
            "from": "db",
            "to": "api",
            "wait_for": "dbwork"
        },
        {
            "type": "move",
            "object": "apires",
            "from": "api",
            "to": "browser"
        },
        {
            "type": "parallel",
            "actions": [
                {
                    "type": "set_content",
                    "id": "render",
                    "object": "browser",
                    "keep_until_end": true,
                    "content": {
                        "type": "text",
                        "url": "mon.app/produits",
                        "value": "✅ 3 produits : Clavier · Souris · Écran"
                    }
                },
                {
                    "type": "comment",
                    "object": "browser",
                    "text": "3. Le JSON devient du DOM : les produits sont affichés",
                    "keep_until_end": true
                }
            ]
        },
        {
            "type": "wait",
            "delay_ms": 1000
        }
    ]
};