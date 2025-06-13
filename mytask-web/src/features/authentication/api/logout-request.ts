import { createBrowserAxios } from "@/lib/axios/browser-axios";

const LogoutRequest = async() => {
    const response = await createBrowserAxios.get('api/v1/Auth/Logout');
    return response;
};

export default LogoutRequest;