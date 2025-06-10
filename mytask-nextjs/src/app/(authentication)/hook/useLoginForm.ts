'use client';

import useForm from "@/app/shared/hook/useForm";
import useLoginMutation from "@/features/authentication/infrastructure/api/useLoginMutation";
import { useRouter } from "next/navigation";

const useLoginForm = () => {
    const router = useRouter();
    const login = useLoginMutation({onSuccessRedirect: (url) => router.push(url)});

    const{formData, handleChange} = useForm({
        email: '',
        password: ''
    });

    const onSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        login.mutate(formData);
    };

    return {
       handleChange, 
       onSubmit,
       login   
    };
};

export default useLoginForm;