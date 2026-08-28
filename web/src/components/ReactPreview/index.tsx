import React from "react";
import { useColorMode } from "@docusaurus/theme-common";
import {
  SandpackCodeEditor,
  SandpackLayout,
  SandpackPreview,
  SandpackProvider,
  defaultDark,
  defaultLight,
} from "@codesandbox/sandpack-react";

// Tailwind est chargé dans l'aperçu, comme dans les projets Next.js du cours.
const TAILWIND_CDN = "https://cdn.jsdelivr.net/npm/@tailwindcss/browser@4";

// Reprise du globals.css des laboratoires (avec les classes personnelles).
const GLOBAL_STYLES = `body {
  background: #ffffff;
  color: #171717;
  font-family: Arial, Helvetica, sans-serif;
  margin: 0;
}

.btn {
  color: white;
  font-weight: bold;
  padding: 0.5rem 1rem;
  border: none;
  border-radius: 0.125rem;
  cursor: pointer;
}

.textInput {
  display: block;
  margin-bottom: 0.5rem;
}

/* Tailwind retire la bordure native des champs : on la redessine. */
.textInput:not([type="checkbox"]) {
  border: 1px solid #c4c4cc;
  border-radius: 0.125rem;
  padding: 0.25rem 0.5rem;
}

.btn-blue   { background-color: royalblue; }
.btn-red    { background-color: crimson; }
.btn-yellow { background-color: goldenrod; }

.cyan  { background-color: rgb(229, 255, 255); }
.red   { background-color: rgb(255, 229, 229); }
.amber { background-color: rgb(255, 248, 229); }
.light { background-color: rgb(244, 245, 246); }
.dark  { background-color: rgb(87, 87, 87); }
`;

interface ReactPreviewProps {
  /** Code du composant (avec un export default) montré dans l'éditeur. */
  code?: string;
  /** Nom du fichier qui contient `code`. */
  fileName?: string;
  /** Fichiers supplémentaires visibles dans l'éditeur. (Ex : une classe) */
  files?: Record<string, string>;
  /** CSS propre à l'exemple, montré dans un onglet globals.css. */
  css?: string;
  /** Hauteur de l'éditeur. (Par défaut : la hauteur du code) */
  codeHeight?: string | number;
  /** Hauteur de l'aperçu. */
  previewHeight?: string | number;
}

export default function ReactPreview({
  code = "",
  fileName = "/page.tsx",
  files,
  css = "",
  codeHeight = "auto",
  previewHeight = "12rem",
}: ReactPreviewProps): React.ReactElement {
  const { colorMode } = useColorMode();

  const entryFile = fileName.startsWith("/") ? fileName : `/${fileName}`;
  const entryImport = `.${entryFile.replace(/\.[jt]sx?$/, "")}`;
  const extraFiles = files ?? {};

  const cssFile = css ? { "/globals.css": css } : {};

  const sandpackFiles = {
    [entryFile]: code,
    ...extraFiles,
    ...cssFile,
    // Le bac à sable n'a pas de routeur Next.js : App rend simplement la page.
    "/App.tsx": {
      code:
        (css ? `import "./globals.css";\n` : "") +
        `import Page from "${entryImport}";\n\nexport default function App() {\n  return <Page />;\n}\n`,
      hidden: true,
    },
    "/styles.css": { code: GLOBAL_STYLES, hidden: true },
  };

  return (
    <SandpackProvider
      template="react-ts"
      theme={colorMode === "dark" ? defaultDark : defaultLight}
      options={{
        activeFile: entryFile,
        visibleFiles: [entryFile, ...Object.keys(extraFiles), ...Object.keys(cssFile)],
        externalResources: [TAILWIND_CDN],
      }}
      files={sandpackFiles}
    >
      {/* Le code est empilé au-dessus de l'aperçu pour être bien lisible. */}
      <SandpackLayout style={{ flexDirection: "column", height: "auto" }}>
        <SandpackCodeEditor
          showTabs
          showLineNumbers
          wrapContent
          // `flex` doit être neutralisé, sinon la hauteur automatique s'écrase.
          style={{ flex: "0 0 auto", height: codeHeight }}
        />
        <SandpackPreview style={{ flex: "0 0 auto", height: previewHeight }} />
      </SandpackLayout>
    </SandpackProvider>
  );
}
