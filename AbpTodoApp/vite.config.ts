import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import laravel from 'laravel-vite-plugin'
import path from 'path'
import { mkdirSync } from 'fs'


const outDir = '../SimpleTodoApp/wwwroot/build'
mkdirSync(outDir, { recursive: true })

// https://vite.dev/config/
export default defineConfig({
  plugins: [
    laravel({
      input: ['src/App.tsx'],
      publicDirectory: outDir,
      refresh: true,
    }),
    react()
  ],
  resolve: {
    alias: {
      '@': path.resolve(__dirname, 'src'),
    },
  },
  build: {
    outDir,
    emptyOutDir: true,
  },
})
