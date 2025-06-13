import { createBrowserAxios } from "@/lib/axios/browser-axios";
import { LoginRequestType, LoginResponseType } from "../types/login"

const loginRequest = async(data:LoginRequestType) : Promise<LoginResponseType> => {
    const response = await createBrowserAxios.post<LoginResponseType>('api/v1/Auth/Login',data,{
        withCredentials: true,
    });
    return response.data;
}

export default loginRequest;