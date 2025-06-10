import axiosBase from "@/api/axios-browser";
import createServerAxios from "@/api/axios-server";
import { UserEntity } from "../domain/entities/user-entity";
import { IUserRepository } from "../domain/interface/i-user-repository";

export class UserRepository implements IUserRepository {
    
    async createUsers(data: Omit<UserEntity, 'id'>): Promise<boolean> {
            console.log("User created:", data);
            const result  = await axiosBase.post('api/v1/Auth/RegisterUser', data);
            return result.data;
    }

    async getUsers(): Promise<UserEntity[]> {
        const axios = await createServerAxios();  
        const result  = await axios.get('api/v1/users');
        return result.data;
    }
};