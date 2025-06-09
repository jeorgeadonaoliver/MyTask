'use client';

import SubmitButton from "./login-button";
import useLoginForm from "../hook/useLoginForm";


const LoginForm = () => {

    const { handleChange, onSubmit, login } = useLoginForm();

    return (
        <div className="mx-auto p-6 w-full">
            <div className="mt-5 ">
                <form onSubmit={onSubmit}>
                    <div className="grid gap-y-4 text-gray-900">
                        <div>
                        <label htmlFor="email" className="block text-sm font-bold ml-1 mb-2 dark:text-white">Email address</label>
                        <div className="relative">
                            <input type="email" id="email" name="email" onChange={handleChange} suppressHydrationWarning
                                className="py-3 px-4 block w-full border-2 border-gray-200  bg-gray-200 rounded-md text-sm focus:border-blue-500 focus:ring-blue-500 shadow-sm" required aria-describedby="email-error"/>
                        </div>
                        <p className="hidden text-xs text-red-600 mt-2" id="email-error">Please include a valid email address so we can get back to you</p>
                        </div>
                                    <div>
                        <label htmlFor="password" className="block text-sm font-bold ml-1 mb-2 dark:text-white">Password</label>
                        <div className="relative">
                            <input type="password" id="password" name="password" onChange={handleChange} suppressHydrationWarning
                                className="py-3 px-4 block w-full border-2 bg-gray-200  border-gray-200 rounded-md text-sm focus:border-blue-500 focus:ring-blue-500 shadow-sm" required aria-describedby="email-error"/>
                        </div>
                        <p className="hidden text-xs text-red-600 mt-2" id="email-error">Please include a valid email address so we can get back to you</p>
                        </div>
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