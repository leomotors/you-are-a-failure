// @ts-check

import adapter from "@sveltejs/adapter-static";
import preprocess from "svelte-preprocess";
import path from "path";

/** @type {import("@sveltejs/kit").Config} */
export default {
  // Consult https://github.com/sveltejs/svelte-preprocess
  // for more information about preprocessors
  preprocess: [
    preprocess({
      postcss: true,
    }),
  ],

  kit: {
    adapter: adapter({
      pages: "build",
      assets: "build",
      fallback: null,
    }),
    vite: {
      resolve: {
        alias: {
          $components: path.resolve("./src/components"),
        },
      },
    },
    prerender: {
      default: true,
    },
  },
};
