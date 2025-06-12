import axios, { AxiosInstance } from "axios";
import { cookies } from "next/headers";

export const createServerAxios = async (): Promise<AxiosInstance> => {
  const token = (await cookies()).get('authToken')?.value;

  const instance = axios.create({
    baseURL: process.env.API_BASE!,
    headers: token ? { Authorization: `Bearer ${token}` } : {},
    withCredentials: true,
  });

  instance.interceptors.response.use(
    (res) => res,
    (err) => {
      console.error("Server API error", err);
      return Promise.reject(err);
    }
  );

  return instance;
};