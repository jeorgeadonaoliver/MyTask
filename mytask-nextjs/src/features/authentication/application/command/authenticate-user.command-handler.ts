
import { AuthResponseModel } from "../../domain/entities/auth-response.model";
import { IAuthRepository } from "../../domain/interface/i-auth-repository";
import { AuthenticateUserCommand } from "../command/authenticate-user.command";


export class AuthenticateUserCommandHandler {

    private _authRepository: IAuthRepository;

    constructor(authRepository: IAuthRepository) {
        this._authRepository = authRepository;
    }

    async execute(command:AuthenticateUserCommand): Promise<AuthResponseModel> {
 
        if (!command || typeof command !== 'object') {
            throw new Error("Invalid command: Command object is required.");
        }

        if (!command.email || !command.password) {
            throw new Error("Email and password are required.");
        }

        const response = await this._authRepository.login(command);

        return response;
    }
}