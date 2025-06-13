import { useMutation, useQueryClient } from "@tanstack/react-query";
import { LoginRequestType, LoginResponseType } from "../types/login";
import loginRequest from "../api/login-request";
import { toast } from "react-toastify";

interface useLoginUserMutationProps{
    onSuccessRedirect: (url: string) => void;
}

const useLoginUserMutation = ({onSuccessRedirect} : useLoginUserMutationProps) => {
    const queryClient = useQueryClient();

    return useMutation({
        mutationFn: async(data: LoginRequestType) =>{
            const response = await loginRequest(data);
            console.log("Request: ", response);

            return response;
        },
        onSuccess: async (response: LoginResponseType) =>{
            queryClient.setQueryData(["fullname"], response.fullname);
            queryClient.setQueryData(["role"], response.role);
            toast.success("Login successful");

            onSuccessRedirect('/home');
        },
        onError: (error) => {
            toast.error("Login failed");
            console.error('Login failed:', error);
        },
    });
}

export default useLoginUserMutation;