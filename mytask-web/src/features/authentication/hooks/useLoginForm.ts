'use client'

import { useRouter } from "next/navigation";
import useLoginMutation from "../services/useLoginMutation";
// import useForm from "@/shared/hooks/useForm";
import { LoginRequestType } from "../types/login";
import { LoginSchema } from "../validators/loginSchema";
import { zodResolver } from '@hookform/resolvers/zod';
import { useForm } from "react-hook-form";


// const useLoginForm = () => {
//     const router = useRouter();
//     const login = useLoginMutation({onSuccessRedirect: (url) => router.push(url)});

//     const{formData, handleChange} = useForm({
//         email: '',
//         password: ''
//     });

//     const onSubmit = (e: React.FormEvent) => {
//         e.preventDefault();
//         login.mutate(formData);
//     };

//     return {
//        handleChange, 
//        onSubmit,
//        login   
//     };
// };

// export default useLoginForm;

const useLoginForm = () => {
    const router = useRouter();

    const{register, handleSubmit, formState: {errors, isSubmitting}} = useForm<LoginRequestType>({
        resolver: zodResolver(LoginSchema), defaultValues:{
            email: '',
            password: '',
        },
    });

    const loginMutation = useLoginMutation({onSuccessRedirect: (url) => router.push(url)});

    const onSubmit = handleSubmit(async (data: LoginRequestType) => {
        console.log("Validated form data:", data);
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