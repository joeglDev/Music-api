import { Hono } from "hono";
import openApiDoc from "../openapi/openapi.json" with { type: "json" };
import { swaggerUI } from "@hono/swagger-ui";
import { basicAuth } from "hono/basic-auth";
import { handleAuth } from "./auth";
import { handleGetAlbums } from "./handlers";

export const app = new Hono()
  .basePath("/api")
  // Middleware applied auth to all routes containing /auth/
  .use(
    basicAuth({
      verifyUser: (username, password, c) => handleAuth(username, password),
    }),
  )

  // ping server
  .get("/ping", (c) => c.text("pong"))
  .get("/auth/ping", (c) => c.text("ping"))

  // documentation
  .get("/docs/schema", (c) => c.json(openApiDoc))
  .get("/docs/ui", swaggerUI({ url: "/api/docs/schema" }))

  // music endpoints
  .get("/albums", async (c) => await handleGetAlbums(c));

export type AppType = typeof app;
