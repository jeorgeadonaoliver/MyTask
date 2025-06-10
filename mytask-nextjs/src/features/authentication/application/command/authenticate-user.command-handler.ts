// import { NextResponse } from "next/server";
import { AuthResponseModel } from "../../domain/entities/auth-respons-entity";
import { IAuthRepository } from "../../domain/interface/i-auth-repository";
import { AuthenticateUserCommand } from "../command/authenticate-user.command";


export class AuthenticateUserCommandHandler {

    private _authRepository: IAuthRepository;

    constructor(authRepository: IAuthRepository) {
        this._authRepository = authRepository;
    }

    async execute(command:AuthenticateUserCommand): Promise<AuthResponseModel> {
            if (!command || !command.email || !command.password) {
                throw new Error("Email and password are required.");
            }
        try
        {   
            const data = await this._authRepository.login(command);

            // const response = NextResponse.json({
            //     fullName: data.fullName,
            //     role: data.role,
            //     message: "Login successful",
            // });

            // response.cookies.set('authToken', data.token, {
            //     httpOnly: true,
            //     path: '/',
            //     maxAge: 60 * 60 * 24, // 1 day
            //     sameSite: 'lax',
            // });

            // console.log('Token set in cookie:', data.token);

            return data;
        }
        catch (error) {
            console.error("Error during authentication:", error);
            throw new Error("Authentication failed. Please try again.");
        }
    }
}