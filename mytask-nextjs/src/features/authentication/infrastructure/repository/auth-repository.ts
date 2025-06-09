import api from '@/api/api';
import { AuthenticateUserCommand } from '../../application/command/authenticate-user.command'
import { AuthResponseModel } from '../../domain/entities/auth-response.model';
import { IAuthRepository } from '@/features/authentication/domain/interface/i-auth-repository';

export class AuthRepository implements IAuthRepository {

    async login(data: AuthenticateUserCommand): Promise<AuthResponseModel> {
        try
        {
            const response = await api.post<AuthResponseModel>('api/v1/Auth/Login',data,{
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
