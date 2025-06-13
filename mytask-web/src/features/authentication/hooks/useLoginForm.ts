'use client'

import { useRouter } from "next/navigation";
import useLoginUserMutation from "../services/useLoginUserMutation";
import { LoginRequestType } from "../types/login";
import { LoginSchema } from "../validators/loginSchema";
import { zodResolver } from '@hookform/resolvers/zod';
import { useForm } from "react-hook-form";

const useLoginForm = () => {
    const router = useRouter();

    const{register, handleSubmit, formState: {errors, isSubmitting}} = useForm<LoginRequestType>({
        resolver: zodResolver(LoginSchema), defaultValues:{
            email: '',
            password: '',
        },
    });

    const loginMutation = useLoginUserMutation({onSuccessRedirect: (url) => router.push(url)});

    const onSubmit = handleSubmit(async (data: LoginRequestType) => {
        loginMutation.mutate(data);
    });

    return {
        register, 
        onSubmit,
        errors,
        isSubmitting,
        loginMutation   
     };
};


export default useLoginForm;