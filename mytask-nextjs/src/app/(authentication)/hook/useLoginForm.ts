'use client';

import useLoginMutation from "@/features/authentication/infrastructure/api/useLoginMutation";
import { useRouter } from "next/navigation";
import { useState } from "react";

const useLoginForm = () => {
    const router = useRouter();
    const login = useLoginMutation({onSuccessRedirect: (url) => router.push(url)});
    const[formData, setFormData] = useState({
        email: '',
        password: ''
    });

    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        setFormData({
            ...formData,[e.target.name]: e.target.value
        });
    };

    const onSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        login.mutate(formData);
    };

    return {
       formData, 
       handleChange, 
       onSubmit,
       login   
    };
};

export default useLoginForm;