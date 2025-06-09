'use client';

import React, { useState } from "react";
import SubmitButton from "./login-button";
import useLogin from "@/hooks/authentication/useLogin";


const LoginForm = () => {

    const login = useLogin();
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
        console.log("Form submitted with data:", formData);
        login.mutate(formData);
    }

    return (
        <div className="mx-auto p-6 w-full">
            <div className="mt-5 ">
                <form onSubmit={onSubmit}>
                    <div className="grid gap-y-4 text-gray-300">
                        <div>
                        <label htmlFor="email" className="block text-sm font-bold ml-1 mb-2 dark:text-white">Email address</label>
                        <div className="relative">
                            <input type="email" id="email" name="email" onChange={handleChange}
                                className="py-3 px-4 block w-full border-2 border-gray-200 rounded-md text-sm focus:border-blue-500 focus:ring-blue-500 shadow-sm" required aria-describedby="email-error"/>
                        </div>
                        <p className="hidden text-xs text-red-600 mt-2" id="email-error">Please include a valid email address so we can get back to you</p>
                        </div>
                                    <div>
                        <label htmlFor="password" className="block text-sm font-bold ml-1 mb-2 dark:text-white">Password</label>
                        <div className="relative">
                            <input type="password" id="password" name="password" onChange={handleChange}
                                className="py-3 px-4 block w-full border-2 border-gray-200 rounded-md text-sm focus:border-blue-500 focus:ring-blue-500 shadow-sm" required aria-describedby="email-error"/>
                        </div>
                        <p className="hidden text-xs text-red-600 mt-2" id="email-error">Please include a valid email address so we can get back to you</p>
                        </div>
                        {/* <button type="submit" className="py-3 px-4 inline-flex justify-center items-center gap-2 rounded-md border border-transparent font-semibold bg-blue-500 text-white hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2 transition-all text-sm dark:focus:ring-offset-gray-800">Login</button> */}
                        <SubmitButton />
                        {login.isError && (
                            <p className="text-red-500 text-sm mt-2">{(login.error.message)}</p>
                        )}
                    </div>
                </form>
            </div>
        </div>
        
    );
};

export default LoginForm;