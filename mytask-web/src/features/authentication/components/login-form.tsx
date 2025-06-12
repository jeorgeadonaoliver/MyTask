'use client'

import useLoginForm from "../hooks/useLoginForm";

const LoginForm = () => {

    const { register, onSubmit, errors, isSubmitting } = useLoginForm();

    return (
        <div className="mx-auto p-6 w-full">
            <div className="mt-5 ">
                <form onSubmit={onSubmit}>
                    <div className="grid gap-y-4 text-gray-900">
                        <div>
                            <label htmlFor="email" className="block text-sm font-bold ml-1 mb-2 dark:text-white">Email address</label>
                            <div className="relative">
                                <input type="email" id="email" {...register('email')} placeholder="your@example.com" suppressHydrationWarning
                                    className="py-3 px-4 block w-full border-2 border-gray-200  bg-gray-200 rounded-md text-sm focus:border-blue-500 focus:ring-blue-500 shadow-sm" required aria-describedby="email-error"/>
                                    {errors.email && (
                                        <p className="mt-1 text-sm text-red-600">{errors.email.message}</p>
                                    )}
                            </div>
                        </div>
                        <div>
                            <label htmlFor="password" className="block text-sm font-bold ml-1 mb-2 dark:text-white">Password</label>
                            <div className="relative">
                                <input type="password" id="password" {...register('password')}  suppressHydrationWarning
                                    className="py-3 px-4 block w-full border-2 bg-gray-200  border-gray-200 rounded-md text-sm focus:border-blue-500 focus:ring-blue-500 shadow-sm" required aria-describedby="email-error"/>
                                {errors.password && (
                                    <p className="mt-1 text-sm text-red-600">{errors.password.message}</p>
                                )}
                            </div>
                        </div>
                        <button type="submit" disabled={isSubmitting}
                            className="w-full flex justify-center py-2 px-4 border border-transparent rounded-md shadow-sm text-sm font-medium text-white bg-blue-600 hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500 disabled:opacity-50">
                                {isSubmitting ? 'Logging in...' : 'Login'}
                        </button>
                    </div>
                </form>
            </div>
        </div>
    );
};

export default LoginForm;