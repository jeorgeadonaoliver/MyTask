'use client'

import LoginForm from "@/features/authentication/components/login-form";
import Card from "@/shared/components/card";

const Login = () => {

    return(
        <div className="flex flex-col items-center justify-center min-h-screen bg-neutral-900">
          <main id="content" role="main" className="w-full max-w-xl mx-auto p-6">
            <div className="p-4 sm:p-7">
              <Card title="" icon={undefined}>
                <div className="text-center">
                <h1 className="block text-2xl font-bold text-gray-800 dark:text-white">Welcome Back!</h1>
                  <p className="mt-2 text-sm text-gray-600 dark:text-gray-400">
                    Forgot your password?
                    <a className="text-blue-600 decoration-2 hover:underline font-medium" href="#">
                      Click here
                    </a>
                  </p>
                </div>
                <LoginForm></LoginForm>
              </Card>
            </div>
          </main>
        </div>
    );
};

export default Login;