// lib/axios-server.ts          (used only in the Node runtime)
import axios, { AxiosInstance } from 'axios';
import { cookies } from 'next/headers';

const createServerAxios = async (): Promise<AxiosInstance> => {
  const token = (await cookies()).get('authToken')?.value;   
  return axios.create({
    baseURL: process.env.API_BASE!,                  // never leak envs to the browser
    headers: token ? { Authorization: `Bearer ${token}` } : {},
    withCredentials: true,
  });
};

export default createServerAxios;
