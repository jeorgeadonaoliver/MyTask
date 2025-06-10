import { AuthResponseModel } from "@/features/authentication/domain/entities/auth-respons-entity";
import { AuthenticateUserCommand } from "../../application/command/authenticate-user.command";

export interface IAuthRepository {
    login(data: AuthenticateUserCommand): Promise<AuthResponseModel>;
}