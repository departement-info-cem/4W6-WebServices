import React from "react";
import { useColorMode } from "@docusaurus/theme-common";
import {
  SandpackCodeEditor,
  SandpackConsole,
  SandpackPreview,
  SandpackProvider,
  defaultDark,
  defaultLight,
} from "@codesandbox/sandpack-react";

interface JavaScriptConsoleProps {
  code?: string;
  files?: Record<string, string>;
  language?: "javascript" | "typescript";
}

export default function JavaScriptConsole({
  code,
  files,
  language = "javascript",
}: JavaScriptConsoleProps): React.ReactElement {
  const { colorMode } = useColorMode();
  const isTypeScript =
    language === "typescript" || Object.keys(files ?? {}).some((file) => file.endsWith(".ts"));
  const entryFile = isTypeScript ? "/index.ts" : "/index.js";
  const sandpackFiles = files ?? { [entryFile]: code ?? "" };
  const activeFile = files?.["/index.js"] ? "/index.js" : entryFile;

  return (
    <SandpackProvider
      template={isTypeScript ? "vanilla-ts" : "vanilla"}
      theme={colorMode === "dark" ? defaultDark : defaultLight}
      options={{
        activeFile,
        autorun: false,
        autoReload: false,
        visibleFiles: Object.keys(sandpackFiles),
      }}
      files={sandpackFiles}
    >
      <SandpackPreview style={{ display: "none" }} />
      <SandpackCodeEditor
        showTabs={Object.keys(sandpackFiles).length > 1}
        showLineNumbers
        style={{ minHeight: "17rem" }}
      />
      <SandpackConsole resetOnPreviewRestart style={{ minHeight: "10rem" }} />
    </SandpackProvider>
  );
}