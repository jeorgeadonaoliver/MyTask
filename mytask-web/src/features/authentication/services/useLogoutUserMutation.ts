import { useMutation } from "@tanstack/react-query";
import LogoutRequest from "../api/logout-request";
import { toast } from "react-toastify";

interface useLogoutUserMutationProps {
    onSuccessRedirect : (url: string) => void;
}

const useLogoutUserMutation = ({onSuccessRedirect} : useLogoutUserMutationProps) => {
    return useMutation({
        mutationFn: async() =>{
            const response = await LogoutRequest();
            return response;
        }, 
        onSuccess: async () => {
            onSuccessRedirect('/login')
            toast.success("Logout successful!");
        },
        onError: (error) => {
            console.error('Logout failed! ',error);
        }
    });
};


export default useLogoutUserMutation;