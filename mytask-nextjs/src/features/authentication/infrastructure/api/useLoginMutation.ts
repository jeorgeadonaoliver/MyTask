import { AuthenticateUserCommand } from "@/features/authentication/application/command/authenticate-user.command";
import { AuthenticateUserCommandHandler } from "@/features/authentication/application/command/authenticate-user.command-handler";
import { AuthResponseModel } from "@/features/authentication/domain/entities/auth-response.model";
import { IAuthRepository } from "@/features/authentication/domain/interface/i-auth-repository";
import { AuthRepository } from "@/features/authentication/infrastructure/repository/auth-repository";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useRef } from "react";
import { toast } from "react-toastify";

interface useLoginMutationProps{
    onSuccessRedirect: (url: string) => void;
}

const useLoginMutation = ({onSuccessRedirect}:useLoginMutationProps) => {
    const queryClient = useQueryClient();
    const authRepositoryRef = useRef<IAuthRepository| null>(null);
    const authCommandHandlerRef = useRef<AuthenticateUserCommandHandler | null>(null);

    if(!authRepositoryRef.current || !authCommandHandlerRef.current) {
        authRepositoryRef.current = new AuthRepository();
        authCommandHandlerRef.current = new AuthenticateUserCommandHandler(authRepositoryRef.current);
    }

    const authCommandHandler = authCommandHandlerRef.current;
    
    return useMutation({
        mutationFn: async (data : AuthenticateUserCommand) =>{

            const response = authCommandHandler?.execute(data);
            return response;
        },
        onSuccess: async(response: AuthResponseModel) => {

            queryClient.setQueryData(["fullname"], response.fullName);
            queryClient.setQueryData(["role"], response.role);
            toast.success("Login successful");
            onSuccessRedirect('/home');
        },
        onError: (error) => {
            toast.error("Login failed");
            console.error('Login failed:', error);
        },
    });
};

export default useLoginMutation;