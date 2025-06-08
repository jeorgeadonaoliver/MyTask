import { AuthResponseModel } from "@/features/authentication/domain/entities/auth-response.model";
import { AuthenticateUserCommand } from "../../application/command/authenticate-user.command";

export interface IAuthRepository {
    login(data: AuthenticateUserCommand): Promise<AuthResponseModel>;
}