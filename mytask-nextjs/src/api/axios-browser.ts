import axios from "axios";

const createBrowserAxios = axios.create({
  baseURL: process.env.NEXT_PUBLIC_API_BASE!, //"https://localhost:5000/",
  //baseURL: "/",
  withCredentials: true, 
  timeout: 10000,
  headers: { "Content-Type": "application/json" },
});

export default createBrowserAxios;