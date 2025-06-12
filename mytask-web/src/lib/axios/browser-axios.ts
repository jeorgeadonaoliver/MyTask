import axios from 'axios';

export const createBrowserAxios = axios.create({
  baseURL: process.env.NEXT_PUBLIC_API_BASE!,
  withCredentials: true, 
  timeout: 10000,
  headers: { "Content-Type": "application/json" },
});

createBrowserAxios.interceptors.response.use(
  (res) => res,
  (err) =>{
    console.error("API error", err);
    return Promise.reject(err);
  }
);




