import axios from "axios";

const axiosBase = axios.create({
  baseURL: "https://localhost:5000/",
  //baseURL: "/",
  withCredentials: true, 
  timeout: 10000,
  headers: { "Content-Type": "application/json" },
});

export default axiosBase;