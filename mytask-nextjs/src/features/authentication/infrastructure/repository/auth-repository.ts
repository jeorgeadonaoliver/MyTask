import axiosBase from '@/api/axiosBase';
import { AuthenticateUserCommand } from '../../application/command/authenticate-user.command'
import { AuthResponseModel } from '../../domain/entities/auth-respons-entity';
import { IAuthRepository } from '@/features/authentication/domain/interface/i-auth-repository';

export class AuthRepository implements IAuthRepository {

    async login(data: AuthenticateUserCommand): Promise<AuthResponseModel> {
        try
        {
            const response = await axiosBase.post<AuthResponseModel>('api/v1/Auth/Login',data,{
                withCredentials: true,
            });
            return response.data;

        }catch(error)
        {
            console.log('Error on connecting to login ', error);
            throw error;
        }
    }
}
