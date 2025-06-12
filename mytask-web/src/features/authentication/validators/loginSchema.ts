import { z } from "zod";

export const LoginSchema = z.object({
    email: z.string().email('Invalid Email address').min(1, 'Email is required!'),
    password: z.string().min(1,'Password is required!'),
});

export type LoginRequestType = z.infer<typeof LoginSchema>;