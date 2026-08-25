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

export default function JavaScriptConsole({ code }: { code: string }): React.ReactElement {
  const { colorMode } = useColorMode();

  return (
    <SandpackProvider
      template="vanilla"
      theme={colorMode === "dark" ? defaultDark : defaultLight}
      options={{
        activeFile: "/index.js",
        autorun: false,
        autoReload: false,
        visibleFiles: ["/index.js"],
      }}
      files={{ "/index.js": code }}
    >
      <SandpackPreview style={{ display: "none" }} />
      <SandpackCodeEditor
        showTabs={false}
        showLineNumbers
        style={{ minHeight: "17rem" }}
      />
      <SandpackConsole resetOnPreviewRestart style={{ minHeight: "10rem" }} />
    </SandpackProvider>
  );
}