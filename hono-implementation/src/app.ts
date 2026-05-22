import { Hono } from 'hono';
import openApiDoc from "../openapi/openapi.json" with {type: 'json'};
import {swaggerUI} from "@hono/swagger-ui";

export const app = new Hono()
    .basePath('/api')
    .get('/ping', (c) => c.text('pong'))

// documentation
    .get('/docs/schema', (c) => c.json(openApiDoc))
    .get('/docs/ui', swaggerUI({ url: '/api/docs/schema' }))

export type AppType = typeof app;

