import type { Context } from "../../node_modules/hono/dist/types/context.d.ts";
import { Client } from "pg";
import type { AlbumRow } from "../types";
import type { QueryResult } from "@types/pg";

export const handleGetAlbums = async (c: Context) => {
  const client = await new Client({
    user: process.env.USER,
    password: process.env.PASSWORD,
    database: process.env.DATABASE,
    host: process.env.HOST,
  }).connect();

  const res: QueryResult<AlbumRow> = await client.query("SELECT * FROM albums");
  await client.end();

  return c.json(res.rows);
};
