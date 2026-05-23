import { defineConfig } from "@rcmade/hono-docs";

export default defineConfig({
  tsConfigPath: "./tsconfig.json",
  openApi: {
    openapi: "3.0.0",
    info: { title: "Hono discogs clone", version: "1.0.0" },
    servers: [{ url: "http://localhost:3000" }],
  },
  outputs: {
    openApiJson: "./openapi/openapi.json",
  },
  apis: [
    {
      name: "Documentation",
      apiPrefix: "", // This will be prepended to all `api` values below
      appTypePath: "src/app.ts", // Path to your AppType export
    },
  ],
});
