import { defineConfig } from 'vite'
import react from '@vitejs/plugin-react'
import path from 'path'

// https://vite.dev/config/
export default defineConfig({
  base:"/app/",
  plugins: [react()],
  build: {
    outDir: path.resolve(__dirname,'../wwwroot/app'),
    emptyOutDir: true,
  },
  server: {
    proxy:{
      '/api':'http://localhost:5096'
    }
  }
})
