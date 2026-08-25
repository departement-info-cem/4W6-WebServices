export default {
    "description": "Chargement de YouTube : Next.js sert le HTML, le CSS et le JavaScript en trois requêtes distinctes, puis le script appelle l'API ASP.NET Core pour les données.",
    "direction": "left-to-right",
    "nodes": [
        { "id": "browser", "type": "laptop", "text": "Navigateur", "icon": "chrome", "lane": 1 },
        { "id": "next", "type": "server", "text": "Next.js", "icon": "nextjs", "lane": 2 },
        { "id": "api", "type": "server", "text": "ASP.NET Core", "icon": "dotnet", "lane": 2 }
    ],
    "zones": [
        { "contains": ["next", "api"], "label": "Serveurs de YouTube", "color": "tomato" }
    ],
    "connections": [
        { "from": "browser", "to": "next", "style": "dotted", "text": "HTTPS" },
        { "from": "browser", "to": "api", "style": "dotted", "text": "HTTPS" }
    ],
    "packets": [
        { "id": "get_home", "kind": "http_packet", "packet_content": { "header": "GET /\nHost: www.youtube.ca" } },
        {
            "id": "html_home", "kind": "http_packet",
            "packet_content": {
                "header": "200 OK\nContent-Type: text/html",
                "body": { "type": "text", "language": "html", "value": "<link rel=\"stylesheet\" href=\"/app.css\">\n<div id=\"__next\"></div>\n<script src=\"/app.js\"></script>" }
            }
        },
        { "id": "get_css", "kind": "http_packet", "packet_content": { "header": "GET /app.css" } },
        {
            "id": "css_home", "kind": "http_packet",
            "packet_content": {
                "header": "200 OK\nContent-Type: text/css",
                "body": { "type": "text", "language": "css", "value": ".grille { display: grid; gap: 16px; }\n.miniature { aspect-ratio: 16 / 9; }" }
            }
        },
        { "id": "get_js", "kind": "http_packet", "packet_content": { "header": "GET /app.js" } },
        {
            "id": "js_home", "kind": "http_packet",
            "packet_content": {
                "header": "200 OK\nContent-Type: application/javascript",
                "body": { "type": "text", "language": "javascript", "value": "fetch(\"/api/accueil\")\n  .then(r => r.json())\n  .then(afficherAccueil);" }
            }
        },
        { "id": "get_accueil", "kind": "http_packet", "packet_content": { "header": "GET /api/accueil\nAccept: application/json" } },
        {
            "id": "json_accueil", "kind": "http_packet",
            "packet_content": {
                "header": "200 OK\nContent-Type: application/json",
                "body": { "type": "text", "language": "json", "value": "[\n  { \"id\": \"dQw4w9WgXcQ\", \"titre\": \"Never Gonna Give You Up\",\n    \"miniature\": \"/img/dQw4.jpg\", \"vues\": 1471000000 },\n  { \"id\": \"9bZkp7q19f0\", \"titre\": \"Gangnam Style\",\n    \"miniature\": \"/img/9bZk.jpg\", \"vues\": 5300000000 }\n]" }
            }
        },
        { "id": "get_watch", "kind": "http_packet", "packet_content": { "header": "GET /watch?v=dQw4w9WgXcQ\nHost: www.youtube.com" } },
        {
            "id": "html_watch", "kind": "http_packet",
            "packet_content": {
                "header": "200 OK\nContent-Type: text/html",
                "body": { "type": "text", "language": "html", "value": "<link rel=\"stylesheet\" href=\"/watch.css\">\n<div id=\"lecteur\"></div>\n<script src=\"/watch.js\"></script>" }
            }
        },
        { "id": "get_css_watch", "kind": "http_packet", "packet_content": { "header": "GET /watch.css" } },
        {
            "id": "css_watch", "kind": "http_packet",
            "packet_content": {
                "header": "200 OK\nContent-Type: text/css",
                "body": { "type": "text", "language": "css", "value": "#lecteur { width: 100%; aspect-ratio: 16 / 9; }\n.commentaires { margin-top: 24px; }" }
            }
        },
        { "id": "get_js_watch", "kind": "http_packet", "packet_content": { "header": "GET /watch.js" } },
        {
            "id": "js_watch", "kind": "http_packet",
            "packet_content": {
                "header": "200 OK\nContent-Type: application/javascript",
                "body": { "type": "text", "language": "javascript", "value": "fetch(\"/api/videos/dQw4w9WgXcQ\")\n  .then(r => r.json())\n  .then(afficherVideo);" }
            }
        },
        { "id": "get_video", "kind": "http_packet", "packet_content": { "header": "GET /api/videos/dQw4w9WgXcQ\nAccept: application/json" } },
        {
            "id": "json_video", "kind": "http_packet",
            "packet_content": {
                "header": "200 OK\nContent-Type: application/json",
                "body": { "type": "text", "language": "json", "value": "{\n  \"titre\": \"Never Gonna Give You Up\",\n  \"video\": \"/media/dQw4w9WgXcQ.mp4\",\n  \"commentaires\": [\n    { \"auteur\": \"Ana\", \"texte\": \"Encore piégé !\" },\n    { \"auteur\": \"Léo\", \"texte\": \"Un classique.\" }\n  ]\n}" }
            }
        }
    ],
    "timeline": [
        { "type": "comment", "text": "1. J'envoie ma première requête HTTP à YouTube.", "keep_until": "rendu_html" },
        {
            "type": "parallel",
            "actions": [
                { "type": "move", "object": "get_home", "from": "browser", "to": "next" },
                { "type": "loading", "object": "browser", "keep_until": "rendu_html" }
            ]
        },
        { "type": "move", "object": "html_home", "from": "next", "to": "browser" },
        {
            "type": "set_content", "id": "rendu_html", "object": "browser", "keep_until": "rendu_css",
            "content": { "type": "text", "url": "https://www.youtube.ca", "value": "📄 HTML reçu — aucun style, aucune donnée" }
        },
        { "type": "comment", "text": "2. Le HTML référence une feuille de style : 2e requête, vers Next.js.", "keep_until": "rendu_css" },
        { "type": "move", "object": "get_css", "from": "browser", "to": "next" },
        { "type": "move", "object": "css_home", "from": "next", "to": "browser" },
        {
            "type": "set_content", "id": "rendu_css", "object": "browser", "keep_until": "rendu_js",
            "content": { "type": "text", "url": "https://www.youtube.ca", "value": "🎨 CSS appliqué — la grille est en place, mais vide" }
        },
        { "type": "comment", "text": "3. Le HTML référence un script : 3e requête, toujours vers Next.js.", "keep_until": "rendu_js" },
        { "type": "move", "object": "get_js", "from": "browser", "to": "next" },
        { "type": "move", "object": "js_home", "from": "next", "to": "browser" },
        {
            "type": "set_content", "id": "rendu_js", "object": "browser", "keep_until": "rendu_accueil",
            "content": { "type": "text", "url": "https://www.youtube.ca", "value": "⚛️ app.js exécuté — ⏳ chargement des vidéos… ▭▭▭ ▭▭▭" }
        },
        { "type": "comment", "text": "4. Le script appelle l'API : 4e requête, vers un AUTRE serveur (ASP.NET Core).", "keep_until": "rendu_accueil" },
        { "type": "move", "object": "get_accueil", "from": "browser", "to": "api" },
        { "type": "loading", "id": "calcul_accueil", "object": "api", "duration": 700 },
        { "type": "move", "object": "json_accueil", "from": "api", "to": "browser", "wait_for": "calcul_accueil" },
        {
            "type": "set_content", "id": "rendu_accueil", "object": "browser", "keep_until": "rendu_watch_html",
            "content": { "type": "text", "url": "https://www.youtube.ca", "value": "▶ Accueil affichée : Never Gonna Give You Up · Gangnam Style" }
        },
        { "type": "comment", "text": "5. Je clique sur une vidéo : nouvelle requête HTTP à Next.js.", "keep_until": "rendu_watch_html" },
        { "type": "move", "object": "get_watch", "from": "browser", "to": "next" },
        { "type": "move", "object": "html_watch", "from": "next", "to": "browser" },
        {
            "type": "set_content", "id": "rendu_watch_html", "object": "browser", "keep_until": "rendu_watch_css",
            "content": { "type": "text", "url": "https://www.youtube.com/watch?v=dQw4w9WgXcQ", "value": "📄 HTML de la page vidéo — lecteur non stylé" }
        },
        { "type": "move", "object": "get_css_watch", "from": "browser", "to": "next" },
        { "type": "move", "object": "css_watch", "from": "next", "to": "browser" },
        {
            "type": "set_content", "id": "rendu_watch_css", "object": "browser", "keep_until": "rendu_watch_js",
            "content": { "type": "text", "url": "https://www.youtube.com/watch?v=dQw4w9WgXcQ", "value": "🎨 CSS de la page vidéo appliqué — le lecteur est dimensionné" }
        },
        { "type": "move", "object": "get_js_watch", "from": "browser", "to": "next" },
        { "type": "move", "object": "js_watch", "from": "next", "to": "browser" },
        {
            "type": "set_content", "id": "rendu_watch_js", "object": "browser", "keep_until": "rendu_video",
            "content": { "type": "text", "url": "https://www.youtube.com/watch?v=dQw4w9WgXcQ", "value": "⚛️ watch.js exécuté — ⏳ chargement de la vidéo… ▭▭▭▭" }
        },
        { "type": "comment", "text": "6. Le script redemande les données à l'API ASP.NET Core.", "keep_until": "rendu_video" },
        { "type": "move", "object": "get_video", "from": "browser", "to": "api" },
        { "type": "loading", "id": "calcul_video", "object": "api", "duration": 800 },
        { "type": "move", "object": "json_video", "from": "api", "to": "browser", "wait_for": "calcul_video" },
        {
            "type": "parallel",
            "actions": [
                {
                    "type": "set_content", "id": "rendu_video", "object": "browser", "keep_until_end": true,
                    "content": { "type": "text", "url": "https://www.youtube.com/watch?v=dQw4w9WgXcQ", "value": "🎥 Vidéo lue · 📃 Never Gonna Give You Up · 📜 2 commentaires" }
                },
                { "type": "comment", "text": "Next.js sert la page ; ASP.NET Core sert les données. Deux serveurs, deux requêtes.", "keep_until_end": true }
            ]
        },
        { "type": "wait", "delay_ms": 1200 }
    ]
};